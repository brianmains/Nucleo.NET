using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Common;


namespace Nucleo.Orm.DataClasses
{
	public interface IDataContext : IDisposable
	{
		#region " Properties "

		ChangeConflictCollection ChangeConflicts { get; }
		int CommandTimeout { get; set; }
		DbConnection Connection { get; }
		bool DeferredLoadingEnabled { get; set; }
		DataLoadOptions LoadOptions { get; set; }
		TextWriter Log { get; set; }
		MetaModel Mapping { get; }
		bool ObjectTrackingEnabled { get; set; }
		DbTransaction Transaction { get; set; }

		#endregion



		#region " Methods "

		void CreateDatabase();
		bool DatabaseExists();
		void DeleteDatabase();
		int ExecuteCommand(string command, params object[] parameters);
		IEnumerable<TResult> ExecuteQuery<TResult>(string query, params object[] parameters);
		IEnumerable ExecuteQuery(Type elementType, string query, params object[] parameters);
		ChangeSet GetChangeSet();
		DbCommand GetCommand(IQueryable query);
		Table<TEntity> GetTable<TEntity>() where TEntity : class;
		ITable GetTable(Type type);
		void Refresh(RefreshMode mode, params object[] entities);
		void Refresh(RefreshMode mode, IEnumerable entities);
		void Refresh(RefreshMode mode, object entity);
		void SubmitChanges();
		void SubmitChanges(ConflictMode failureMode);
		IEnumerable<TResult> Translate<TResult>(DbDataReader reader);
		IMultipleResults Translate(DbDataReader reader);
		IEnumerable Translate(Type elementType, DbDataReader reader);

		#endregion
	}
}
