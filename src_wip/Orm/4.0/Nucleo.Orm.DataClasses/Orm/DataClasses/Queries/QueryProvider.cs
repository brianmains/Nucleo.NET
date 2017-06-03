using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;


namespace Nucleo.Orm.DataClasses.Queries
{
	public class QueryProvider<TEntity> : IQueryableExtender<TEntity>, IQueryableGenericExtender<TEntity>, IListExtender<TEntity>, IListGenericExtender<TEntity>
		where TEntity: class
	{
		private Table<TEntity> _os = null;



		public QueryProvider(Table<TEntity> os)
		{
			Guard.NotNull(os);

			_os = os;
		}



		private TUnitOfWork GetUnitOfWork<TUnitOfWork>()
		{
			object uow = null;

			if (_os.Context is TUnitOfWork)
				uow = _os.Context;
			else if (_os is TUnitOfWork)
				uow = _os;
			else uow = default(TUnitOfWork);

			return (TUnitOfWork)uow;
		}

		public IQueryable Query(Func<Table<TEntity>, IQueryable> source)
		{
			return source(_os);
		}

		public IQueryable Query<TUnitOfWork>(Func<Table<TEntity>, TUnitOfWork, IQueryable> source) where TUnitOfWork : IUnitOfWork
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}

		public IQueryable<TEntity> Query(Func<Table<TEntity>, IQueryable<TEntity>> source)
		{
			return source(_os);
		}

		public IQueryable<TEntity> Query<TUnitOfWork>(Func<Table<TEntity>, TUnitOfWork, IQueryable<TEntity>> source) where TUnitOfWork : IUnitOfWork
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}

		System.Collections.IList IListExtender<TEntity>.Query(Func<Table<TEntity>, IList> source)
		{
			return source(_os);
		}

		System.Collections.IList IListExtender<TEntity>.Query<TUnitOfWork>(Func<Table<TEntity>, TUnitOfWork, IList> source)
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}

		IList<TEntity> IListGenericExtender<TEntity>.Query(Func<Table<TEntity>, IList<TEntity>> source)
		{
			return source(_os);
		}

		IList<TEntity> IListGenericExtender<TEntity>.Query<TUnitOfWork>(Func<Table<TEntity>, TUnitOfWork, IList<TEntity>> source)
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}
	}
}
