using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;

using Nucleo.Orm.Queries;


namespace Nucleo.Orm.Entities.Queries
{
	public class ObjectSetQuerySource<TEntity> : IQuerySource<TEntity>
		where TEntity: class
	{
		private ObjectSet<TEntity> _os = null;



		public IUnitOfWork Container
		{
			get
			{
				if (_os.Context is IUnitOfWork)
					return _os.Context as IUnitOfWork;
				else if (_os is IUnitOfWork)
					return _os as IUnitOfWork;

				return default(IUnitOfWork);
			}
		}

		Type IQueryable.ElementType
		{
			get { return ((IQueryable<TEntity>)_os).ElementType; }
		}

		System.Linq.Expressions.Expression IQueryable.Expression
		{
			get { return ((IQueryable<TEntity>)_os).Expression; }
		}

		IQueryProvider IQueryable.Provider
		{
			get { return ((IQueryable<TEntity>)_os).Provider; }
		}



		public ObjectSetQuerySource(ObjectSet<TEntity> os)
		{
			Guard.NotNull(os);

			_os = os;
		}



		public IEnumerator<TEntity> GetEnumerator()
		{
			return ((IEnumerable<TEntity>)_os).GetEnumerator();
		}

		IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
		{
			return ((IEnumerable<TEntity>)_os).GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return ((System.Collections.IEnumerable)_os).GetEnumerator();
		}
	}
}
