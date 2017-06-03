using System;
using System.Data.Linq;


namespace Nucleo.Orm.DataClasses
{
	public class TableUnitOfWork<TEntity> : ITableUnitOfWork<TEntity>
		where TEntity : class
	{
		private Table<TEntity> _table = null;



		#region " Constructors "

		public TableUnitOfWork(Table<TEntity> table)
		{
			_table = table;
		}

		#endregion



		#region " Methods "

		public TEntity CreateNew()
		{
			return Activator.CreateInstance<TEntity>();
		}

		public TEntity Get(object identifier)
		{
			return null;
		}

		public void QueueDelete(TEntity entity)
		{
			_table.DeleteOnSubmit(entity);
		}

		public void QueueInsert(TEntity entity)
		{
			_table.InsertOnSubmit(entity);
		}

		public void QueueUpdate(TEntity entity)
		{
			
		}

		public void SaveChanges()
		{
			_table.Context.SubmitChanges();
		}

		#endregion
	}
}
