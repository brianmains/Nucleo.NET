using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.EventArguments;
using Nucleo.Orm.Configuration;


namespace Nucleo.Orm
{
	/// <summary>
	/// Represents the parent object to manage the context.
	/// </summary>
	/// <typeparam name="T">The type of object context.</typeparam>
	public class ObjectContextManager<T>
		where T: ObjectContext
	{
		private T _context = null;



		#region " Event Handlers "

		/// <summary>
		/// Fires an event when the changes are submitted.
		/// </summary>
		public event ObjectContextManagerSubmitEventHandler ChangesSubmitted;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the context.
		/// </summary>
		public T Context
		{
			get { return _context; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Performs a bulk update operation.
		/// </summary>
		/// <typeparam name="T">The entity to bulk update.</typeparam>
		/// <param name="actionToPerform">The action to perform on the collection of objects.</param>
		/// <param name="condition"></param>
		public IEnumerable<T> BulkUpdate<T>(Action<T> actionToPerform, Func<T, bool> condition)
			where T: EntityObject
		{
			IEnumerable<T> set = this.Context.CreateObjectSet<T>().Where(condition).ToList();

			foreach (T obj in set)
				actionToPerform(obj);

			return set;
		}

		/// <summary>
		/// Creates a new object context using the generic type, extracting the connection string from the configuration file.
		/// </summary>
		/// <returns>The object context manager.</returns>
		public static ObjectContextManager<T> Create()
		{
			ObjectContextSettingsSection settings = ObjectContextSettingsSection.Instance;
			ObjectContextManager<T> manager = new ObjectContextManager<T>();

			manager.CreateContext(settings.ConnectionStringName, false);
			return manager;
		}

		/// <summary>
		/// Creates the context manager using the specified context.
		/// </summary>
		/// <param name="context">The context to create.</param>
		/// <returns>The object context manager.</returns>
		public static ObjectContextManager<T> Create(T context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			ObjectContextManager<T> manager = new ObjectContextManager<T>();
			manager._context = context;

			return manager;
		}

		/// <summary>
		/// Creates the manager with the specified connection string.
		/// </summary>
		/// <param name="connectionStringName">THe name of the connection string in the &lt;connectionString> section.</param>
		/// <returns>The object context manager.</returns>
		public static ObjectContextManager<T> Create(string connectionStringName)
		{
			ObjectContextManager<T> mgr = new ObjectContextManager<T>();
			mgr.CreateContext(connectionStringName, false);

			return mgr;
		}

		/// <summary>
		/// Creates the manager with the specified connection string.
		/// </summary>
		/// <param name="connectionStringName">The connection string builder to get the connection string from.</param>
		/// <returns>The object context manager.</returns>
		public static ObjectContextManager<T> Create(EntityConnectionStringBuilder connectionString)
		{
			ObjectContextManager<T> mgr = new ObjectContextManager<T>();
			mgr.CreateContext(connectionString.ToString(), true);

			return mgr;
		}

		private void CreateContext(string connectionStringName, bool isConnectionString)
		{
			string connString = null;
			if (isConnectionString)
				connString = connectionStringName;
			else
			{
				ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionStringName];
				if (settings != null)
					connString = settings.ConnectionString;
			}

			if (!string.IsNullOrEmpty(connString))
				_context = (T)Activator.CreateInstance(typeof(T), new object[] { connString });
			else
				_context = (T)Activator.CreateInstance(typeof(T));
		}

		/// <summary>
		/// Creates a new object instance.
		/// </summary>
		/// <typeparam name="TEntity">The entity object to create.</typeparam>
		/// <returns>The entity instance.</returns>
		public TEntity CreateNew<TEntity>()
			where TEntity: EntityObject
		{
			return _context.CreateObject<TEntity>();
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

		/// <summary>
		/// Creates a new query 
		/// </summary>
		/// <typeparam name="T">The entity type to create the query for.</typeparam>
		/// <returns>The object set for the given type.</returns>
		public ObjectSet<T> GetObjectSet<T>()
			where T : EntityObject
		{
			return this._context.CreateObjectSet<T>();
		}

		protected virtual void OnChangesSubmitted(ObjectContextManagerSubmitEventArgs e)
		{
			if (ChangesSubmitted != null)
				ChangesSubmitted(this, e);
		}

		/// <summary>
		/// Wraps a query.
		/// </summary>
		/// <typeparam name="TEntity">The entity being queried.</typeparam>
		/// <param name="query">The original query.</param>
		/// <returns>The result.</returns>
		public ObjectQuery<TEntity> Query<TEntity>(ObjectQuery<TEntity> query)
			where TEntity: EntityObject
		{
			return query;
		}

		/// <summary>
		/// Saves the changes to the database.  Logs any exception to the event log.
		/// </summary>
		/// <returns>Whether the execution occurred successfully.</returns>
		public bool SaveChangesToDatabase()
		{
			try
			{
				this.Context.SaveChanges();
				this.OnChangesSubmitted(new ObjectContextManagerSubmitEventArgs(true));
				return true;
			}
			catch (Exception ex)
			{
				ILoggerService logger = this.GetLoggerService();
				if (logger != null)
				{
					//if (ex is ChangeConflictException)
					//    this.LogErrors(logger, ex);
					//else
					//{
						logger.LogError(ex, "Object Context Manager",
							logger.GetMessageTypes().GetHighest(),
							logger.GetVerbosityTypes().GetLowest());
					//}
				}

				this.OnChangesSubmitted(new ObjectContextManagerSubmitEventArgs(ex));
				return false;
			}
		}

		#endregion
	}
}
