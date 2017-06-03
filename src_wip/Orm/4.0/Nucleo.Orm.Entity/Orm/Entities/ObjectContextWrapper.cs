using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.Objects;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Represents a wrapper for the object context to implement the <see cref="IObjectContext"/> interface.
	/// </summary>
	public class ObjectContextWrapper : IObjectContext
	{
		private ObjectContext _context = null;



		#region " Events "

		public event ObjectMaterializedEventHandler ObjectMaterialized;

		public event EventHandler SavingChanges;

		#endregion



		#region " Properties "

		public int? CommandTimeout
		{
			get { return OriginalContext.CommandTimeout; }
			set { OriginalContext.CommandTimeout = value; }
		}

		public DbConnection Connection
		{
			get { return OriginalContext.Connection; }
		}

		public ObjectContextOptions ContextOptions
		{
			get { return OriginalContext.ContextOptions; }
		}

		public string DefaultContainerName
		{
			get { return OriginalContext.DefaultContainerName; }
			set { OriginalContext.DefaultContainerName = value; }
		}

		public System.Data.Metadata.Edm.MetadataWorkspace MetadataWorkspace
		{
			get { return OriginalContext.MetadataWorkspace; }
		}

		public ObjectStateManager ObjectStateManager
		{
			get { return OriginalContext.ObjectStateManager; }
		}

		public ObjectContext OriginalContext
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the wrapper from the given context.
		/// </summary>
		/// <param name="context">The context.</param>
		public ObjectContextWrapper(ObjectContext context)
		{
			Guard.NotNull(context);

			_context = context;
		}

		#endregion



		#region " Methods "

		public void AcceptAllChanges()
		{
			OriginalContext.AcceptAllChanges();
		}

		public void AddObject(string entitySetName, object entity)
		{
			OriginalContext.AddObject(entitySetName, entity);
		}

		public TEntity ApplyCurrentValues<TEntity>(string entitySetName, TEntity currentEntity) where TEntity : class
		{
			return OriginalContext.ApplyCurrentValues<TEntity>(entitySetName, currentEntity);
		}

		public TEntity ApplyOriginalValues<TEntity>(string entitySetName, TEntity originalEntity) where TEntity : class
		{
			return OriginalContext.ApplyOriginalValues<TEntity>(entitySetName, originalEntity);
		}

		public void Attach(System.Data.Objects.DataClasses.IEntityWithKey entity)
		{
			OriginalContext.Attach(entity);
		}

		public void AttachTo(string entitySetName, object entity)
		{
			OriginalContext.AttachTo(entitySetName, entity);
		}

		public void CreateDatabase()
		{
			OriginalContext.CreateDatabase();
		}

		public string CreateDatabaseScript()
		{
			return OriginalContext.CreateDatabaseScript();
		}

		public System.Data.EntityKey CreateEntityKey(string entitySetName, object entity)
		{
			return OriginalContext.CreateEntityKey(entitySetName, entity);
		}

		public T CreateObject<T>() where T : class
		{
			return OriginalContext.CreateObject<T>();
		}

		public ObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class
		{
			return OriginalContext.CreateObjectSet<TEntity>();
		}

		public ObjectSet<TEntity> CreateObjectSet<TEntity>(string entitySetName) where TEntity : class
		{
			return OriginalContext.CreateObjectSet<TEntity>(entitySetName);
		}

		public void CreateProxyTypes(IEnumerable<Type> types)
		{
			OriginalContext.CreateProxyTypes(types);
		}

		public ObjectQuery<T> CreateQuery<T>(string queryString, params ObjectParameter[] parameters)
		{
			return OriginalContext.CreateQuery<T>(queryString, parameters);
		}

		public bool DatabaseExists()
		{
			return OriginalContext.DatabaseExists();
		}

		public void DeleteDatabase()
		{
			OriginalContext.DeleteDatabase();
		}

		public void DeleteObject(object entity)
		{
			OriginalContext.DeleteObject(entity);
		}

		public void Detach(object entity)
		{
			OriginalContext.Detach(entity);
		}

		public void DetectChanges()
		{
			OriginalContext.DetectChanges();
		}

		public void Dispose()
		{
			OriginalContext.Dispose();
		}

		public int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
		{
			return OriginalContext.ExecuteFunction(functionName, parameters);
		}

		public ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters)
		{
			return OriginalContext.ExecuteFunction<TElement>(functionName, parameters);
		}

		public ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, MergeOption mergeOption, params ObjectParameter[] parameters)
		{
			return OriginalContext.ExecuteFunction<TElement>(functionName, mergeOption, parameters);
		}

		public int ExecuteStoreCommand(string commandText, params object[] parameters)
		{
			return OriginalContext.ExecuteStoreCommand(commandText, parameters);
		}

		public ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
		{
			return OriginalContext.ExecuteStoreQuery<TElement>(commandText, parameters);
		}

		public ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters)
		{
			return OriginalContext.ExecuteStoreQuery<TEntity>(commandText, entitySetName, mergeOption, parameters);
		}

		public object GetObjectByKey(System.Data.EntityKey key)
		{
			return OriginalContext.GetObjectByKey(key);
		}

		public void LoadProperty(object entity, string navigationProperty)
		{
			OriginalContext.LoadProperty(entity, navigationProperty);
		}

		public void LoadProperty<TEntity>(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, object>> selector)
		{
			OriginalContext.LoadProperty<TEntity>(entity, selector);
		}

		public void LoadProperty(object entity, string navigationProperty, MergeOption mergeOption)
		{
			OriginalContext.LoadProperty(entity, navigationProperty, mergeOption);
		}

		public void LoadProperty<TEntity>(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, object>> selector, MergeOption mergeOption)
		{
			OriginalContext.LoadProperty<TEntity>(entity, selector, mergeOption);
		}

		public void Refresh(RefreshMode refreshMode, System.Collections.IEnumerable collection)
		{
			OriginalContext.Refresh(refreshMode, collection);
		}

		public void Refresh(RefreshMode refreshMode, object entity)
		{
			OriginalContext.Refresh(refreshMode, entity);
		}

		public int SaveChanges()
		{
			return OriginalContext.SaveChanges();
		}

		public int SaveChanges(bool acceptChangesDuringSave)
		{
			return OriginalContext.SaveChanges(acceptChangesDuringSave);
		}

		public int SaveChanges(SaveOptions options)
		{
			return OriginalContext.SaveChanges(options);
		}

		public ObjectResult<TElement> Translate<TElement>(System.Data.Common.DbDataReader reader)
		{
			return OriginalContext.Translate<TElement>(reader);
		}

		public ObjectResult<TEntity> Translate<TEntity>(System.Data.Common.DbDataReader reader, string entitySetName, MergeOption mergeOption)
		{
			return OriginalContext.Translate<TEntity>(reader, entitySetName, mergeOption);
		}

		public bool TryGetObjectByKey(System.Data.EntityKey key, out object value)
		{
			return OriginalContext.TryGetObjectByKey(key, out value);
		}

		#endregion
	}
}
