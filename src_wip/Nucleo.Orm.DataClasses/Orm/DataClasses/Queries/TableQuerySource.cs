using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;

using Nucleo.Orm.Queries;


namespace Nucleo.Orm.DataClasses.Queries
{
	public class TableQuerySource<TEntity> : IQuerySource<TEntity>
		where TEntity: class
	{
		private Table<TEntity> _table = null;



		public IUnitOfWork Container
		{
			get 
			{
				if (_table.Context is IUnitOfWork)
					return _table.Context as IUnitOfWork;

				return null;
			}
		}

		Type IQueryable.ElementType
		{
			get { return ((IQueryable<TEntity>)_table).ElementType; }
		}

		System.Linq.Expressions.Expression IQueryable.Expression
		{
			get { return ((IQueryable<TEntity>)_table).Expression; }
		}

		IQueryProvider IQueryable.Provider
		{
			get { return _table; }
		}



		public TableQuerySource(Table<TEntity> table)
		{
			Guard.NotNull(table);

			_table = table;
		}



		public IEnumerator<TEntity> GetEnumerator()
		{
			return _table.GetEnumerator();
		}

		IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
		{
			return _table.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _table.GetEnumerator();
		}
	}
}
