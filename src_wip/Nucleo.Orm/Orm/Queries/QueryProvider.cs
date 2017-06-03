using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Orm.Queries
{
	public class QueryProvider<TEntity> : IQueryableExtender<TEntity>, IQueryableGenericExtender<TEntity>, IListExtender<TEntity>, IListGenericExtender<TEntity>
		where TEntity: class
	{
		private IQuerySource<TEntity> _os = null;



		public QueryProvider(IQuerySource<TEntity> os)
		{
			Guard.NotNull(os);

			_os = os;
		}



		private TUnitOfWork GetUnitOfWork<TUnitOfWork>()
			where TUnitOfWork: IUnitOfWork
		{
			object obj = _os.Container;
			if (obj is TUnitOfWork)
				return (TUnitOfWork)obj;
			else
				return default(TUnitOfWork);
		}

		public IQueryable Query(Func<IQuerySource<TEntity>, IQueryable> source)
		{
			return source(_os);
		}

		public IQueryable Query<TUnitOfWork>(Func<IQuerySource<TEntity>, TUnitOfWork, IQueryable> source) 
			where TUnitOfWork : IUnitOfWork
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}

		public IQueryable<TEntity> Query(Func<IQuerySource<TEntity>, IQueryable<TEntity>> source)
		{
			return source(_os);
		}

		public IQueryable<TEntity> Query<TUnitOfWork>(Func<IQuerySource<TEntity>, TUnitOfWork, IQueryable<TEntity>> source) 
			where TUnitOfWork : IUnitOfWork
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}

		public System.Collections.IList QueryList(Func<IQuerySource<TEntity>, IList> source)
		{
			return source(_os);
		}

		public System.Collections.IList QueryList<TUnitOfWork>(Func<IQuerySource<TEntity>, TUnitOfWork, IList> source)
			where TUnitOfWork: IUnitOfWork
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}

		public IList<TEntity> QueryList(Func<IQuerySource<TEntity>, IList<TEntity>> source)
		{
			return source(_os);
		}

		public IList<TEntity> QueryList<TUnitOfWork>(Func<IQuerySource<TEntity>, TUnitOfWork, IList<TEntity>> source)
			where TUnitOfWork : IUnitOfWork
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}
	}
}
