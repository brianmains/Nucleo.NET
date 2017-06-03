using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using System.Data.Objects.DataClasses;


namespace Nucleo.Orm.Entities.Queries
{
	public class QueryProvider<TEntity> : IQueryableExtender<TEntity>, IQueryableGenericExtender<TEntity>, IListExtender<TEntity>, IListGenericExtender<TEntity>
		where TEntity: class
	{
		private ObjectSet<TEntity> _os = null;



		public QueryProvider(ObjectSet<TEntity> os)
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

		public IQueryable Query(Func<ObjectSet<TEntity>, IQueryable> source)
		{
			return source(_os);
		}

		public IQueryable Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable> source) where TUnitOfWork : IUnitOfWork
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}

		public IQueryable<TEntity> Query(Func<ObjectSet<TEntity>, IQueryable<TEntity>> source)
		{
			return source(_os);
		}

		public IQueryable<TEntity> Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable<TEntity>> source) where TUnitOfWork : IUnitOfWork
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}

		System.Collections.IList IListExtender<TEntity>.Query(Func<ObjectSet<TEntity>, IList> source)
		{
			return source(_os);
		}

		System.Collections.IList IListExtender<TEntity>.Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IList> source)
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}

		IList<TEntity> IListGenericExtender<TEntity>.Query(Func<ObjectSet<TEntity>, IList<TEntity>> source)
		{
			return source(_os);
		}

		IList<TEntity> IListGenericExtender<TEntity>.Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IList<TEntity>> source)
		{
			return source(_os, GetUnitOfWork<TUnitOfWork>());
		}
	}
}
