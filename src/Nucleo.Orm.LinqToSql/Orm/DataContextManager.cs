using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;

using Nucleo.Configuration;
using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.EventArguments;
using Nucleo.Logs;
using Nucleo.Orm.Triggers;
using Nucleo.Orm.Configuration;


namespace Nucleo.Orm
{
	/// <summary>
	/// Represents the data context manager that wraps a LINQ to SQL DataContext object.
	/// </summary>
	public class DataContextManager<T>
		where T: DataContext
	{
		private T _context = null;



		#region " Events "

		/// <summary>
		/// Fires an event when the changes are submitted.
		/// </summary>
		public event DataContextManagerSubmitEventHandler ChangesSubmitted;

		/// <summary>
		/// Fires when the triggers run.
		/// </summary>
		public event EventHandler TriggersFired;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the context for the manager.
		/// </summary>
		public T Context
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		private DataContextManager() { }

		#endregion



		#region " Methods "

		public static DataContextManager<T> Create()
		{
			DataContextSettingsSection settings = DataContextSettingsSection.Instance;
			DataContextManager<T> manager = new DataContextManager<T>();

			manager.CreateContext(settings.ConnectionStringName);
			return manager;
		}

		/// <summary>
		/// Creates the context manager using the specified context.
		/// </summary>
		/// <param name="context">The context to create.</param>
		/// <returns>The manager.</returns>
		public static DataContextManager<T> Create(T context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			DataContextManager<T> manager = new DataContextManager<T>();
			manager._context = context;

			return manager;
		}

		public static DataContextManager<T> Create(string connectionStringName)
		{
			if (string.IsNullOrEmpty(connectionStringName))
				throw new ArgumentNullException("connectionStringName");

			DataContextManager<T> mgr = new DataContextManager<T>();
			mgr.CreateContext(connectionStringName);

			return mgr;
		}

		private void CreateContext(string connectionStringName)
		{
			if (!string.IsNullOrEmpty(connectionStringName))
				_context = (T)Activator.CreateInstance(typeof(T),
					new object[] { ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString });
			else
				_context = (T)Activator.CreateInstance(typeof(T));
		}

		/// <summary>
		/// Gets the logger service internally.  Useful to have this method for unit testing with TypeMock.
		/// </summary>
		/// <returns>The logger service.</returns>
		private ILoggerService GetLoggerService()
		{
			ApplicationContext context = ApplicationContext.GetCurrent();
			if (context == null)
				return null;
				
			return context.GetService<ILoggerService>();
		}

		public TriggerCollection GetTriggers<TEntity>(TriggerAction action)
			where TEntity : class
		{
			DataContextSettingsSection section = DataContextSettingsSection.Instance;
			if (section == null)
				return null;

			return DataClassTriggers.GetTriggers<TEntity>(section, action);
		}

		/// <summary>
		/// Logs any errors that occur within the data context.
		/// </summary>
		/// <param name="log">The errors to log.</param>
		private void LogErrors(ILoggerService logger, Exception ex)
		{
			if (this.Context.ChangeConflicts == null)
				return;
			
			foreach (ObjectChangeConflict conflict in this.Context.ChangeConflicts)
			{
				string error = "An error occurred with an object of type: " + conflict.Object.GetType().Name + "\n";

				foreach (MemberChangeConflict memberConflict in conflict.MemberConflicts)
				{
					error += string.Format("Member: {0}, Original Value: {1}, Current Value: {2}, Database Value: {3}",
						memberConflict.Member.Name, memberConflict.OriginalValue, memberConflict.CurrentValue, memberConflict.DatabaseValue);
				}

				logger.LogMessage(error, "Data Context Manager", 
					logger.GetMessageTypes().GetHighest(), 
					logger.GetVerbosityTypes().GetLowest());
			}
		}

		protected virtual void OnChangesSubmitted(DataContextManagerSubmitEventArgs e)
		{
			if (ChangesSubmitted != null)
				ChangesSubmitted(this, e);
		}

		protected virtual void OnTriggersFired(EventArgs e)
		{
			if (TriggersFired != null)
				TriggersFired(this, e);
		}

		/// <summary>
		/// Execute the query by calling ToList and checking for errors.
		/// </summary>
		/// <typeparam name="T">The object type for the query.</typeparam>
		/// <param name="query">The query to execute.</param>
		/// <returns>The final results.</returns>
		public IQueryable<T> Query<T>(IQueryable<T> query)
			where T : class
		{
			try
			{
				return query;
			}
			catch (Exception ex)
			{
				ILoggerService logger = this.GetLoggerService();
				if (logger != null)
					logger.LogError(ex, "Data Context Manager", logger.GetMessageTypes().GetHighest(),
						logger.GetVerbosityTypes().GetLowest());
				throw;
			}
		}

		/// <summary>
		/// Queues an insert into the underlying data context.  Fires any associated triggers before the insertion into the queue.
		/// </summary>
		/// <typeparam name="TEntity">The entity type.</typeparam>
		/// <param name="entity">The type of entity.</param>
		public void QueueDelete<TEntity>(TEntity entity)
			where TEntity : class
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			//Fire any associated triggers
			TriggerCollection triggers = this.GetTriggers<TEntity>(TriggerAction.Delete);
			foreach (ITrigger trigger in triggers)
				trigger.Fire(entity, TriggerAction.Delete);

			this.Context.GetTable<TEntity>().DeleteOnSubmit(entity);
		}

		/// <summary>
		/// Queues an insert into the underlying data context.  Fires any associated triggers before the insertion into the queue.
		/// </summary>
		/// <typeparam name="TEntity">The entity type.</typeparam>
		/// <param name="entity">The type of entity.</param>
		public void QueueInsert<TEntity>(TEntity entity)
			where TEntity : class
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			//Fire any associated triggers
			TriggerCollection triggers = this.GetTriggers<TEntity>(TriggerAction.Insert);
			foreach (ITrigger trigger in triggers)
				trigger.Fire(entity, TriggerAction.Insert);

			this.Context.GetTable<TEntity>().InsertOnSubmit(entity);
		}

		public void QueueUpdate<TEntity>(TEntity entity)
			where TEntity : class
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			//Fire any associated triggers
			TriggerCollection triggers = this.GetTriggers<TEntity>(TriggerAction.Update);
			foreach (ITrigger trigger in triggers)
				trigger.Fire(entity, TriggerAction.Update);
		}

		/// <summary>
		/// Saves the changes to the database.  Logs any exception to the event log.
		/// </summary>
		/// <returns>Whether the execution occurred successfully.</returns>
		public bool SaveChangesToDatabase()
		{
			try
			{
				this.Context.SubmitChanges();
				this.OnChangesSubmitted(new DataContextManagerSubmitEventArgs(true));
				return true;
			}
			catch (Exception ex)
			{
				ILoggerService logger = this.GetLoggerService();
				if (logger != null)
				{
					if (ex is ChangeConflictException)
						this.LogErrors(logger, ex);
					else
					{
						logger.LogError(ex, "Data Context Manager",
							logger.GetMessageTypes().GetHighest(),
							logger.GetVerbosityTypes().GetLowest());
					}
				}

				this.OnChangesSubmitted(new DataContextManagerSubmitEventArgs(ex));
				return false;
			}
		}

		#endregion
	}
}
