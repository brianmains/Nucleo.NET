using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Represents the interface for an <see cref="ObjectContext"/> definition.
	/// </summary>
	public interface IObjectContext
	{
		#region " Events "

		event ObjectMaterializedEventHandler ObjectMaterialized;
		event EventHandler SavingChanges;

		#endregion



		#region " Properties "

		int? CommandTimeout { get; set; }

		DbConnection Connection { get; }

		ObjectContextOptions ContextOptions { get; }

		string DefaultContainerName { get; set; }

		[CLSCompliant(false)]
		MetadataWorkspace MetadataWorkspace { get; }

		ObjectStateManager ObjectStateManager { get; }

		#endregion



		#region " Methods "

		void AcceptAllChanges();
		void AddObject(string entitySetName, object entity);
		TEntity ApplyCurrentValues<TEntity>(string entitySetName, TEntity currentEntity) where TEntity : class;
		TEntity ApplyOriginalValues<TEntity>(string entitySetName, TEntity originalEntity) where TEntity : class;
		void ApplyPropertyChanges(string entitySetName, object changed);
		void Attach(IEntityWithKey entity);
		void AttachTo(string entitySetName, object entity);
		void CreateDatabase();
		string CreateDatabaseScript();
		EntityKey CreateEntityKey(string entitySetName, object entity);
		T CreateObject<T>() where T : class;
		ObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class;
		ObjectSet<TEntity> CreateObjectSet<TEntity>(string entitySetName) where TEntity : class;
		void CreateProxyTypes(IEnumerable<Type> types);
		ObjectQuery<T> CreateQuery<T>(string queryString, params ObjectParameter[] parameters);
		bool DatabaseExists();
		void DeleteDatabase();
		void DeleteObject(object entity);
		void Detach(object entity);
		void DetectChanges();
		int ExecuteFunction(string functionName, params ObjectParameter[] parameters);
		ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters);
		ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, MergeOption mergeOption, params ObjectParameter[] parameters);
		int ExecuteStoreCommand(string commandText, params object[] parameters);
		ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters);
		ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters);
		object GetObjectByKey(EntityKey key);
		void LoadProperty(object entity, string navigationProperty);
		void LoadProperty<TEntity>(TEntity entity, Expression<Func<TEntity, object>> selector);
		void LoadProperty(object entity, string navigationProperty, MergeOption mergeOption);
		void LoadProperty<TEntity>(TEntity entity, Expression<Func<TEntity, object>> selector, MergeOption mergeOption);
		void Refresh(RefreshMode refreshMode, IEnumerable collection);
		void Refresh(RefreshMode refreshMode, object entity);
		int SaveChanges();
		int SaveChanges(bool acceptChangesDuringSave);
		int SaveChanges(SaveOptions options);
		ObjectResult<TElement> Translate<TElement>(DbDataReader reader);
		ObjectResult<TEntity> Translate<TEntity>(DbDataReader reader, string entitySetName, MergeOption mergeOption);
		bool TryGetObjectByKey(EntityKey key, out object value);

		#endregion
	}
}
