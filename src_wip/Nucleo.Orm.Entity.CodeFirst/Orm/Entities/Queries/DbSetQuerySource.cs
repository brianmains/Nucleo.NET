using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using Nucleo.Orm.Queries;


namespace Nucleo.Orm.Entities.Queries
{
	/// <summary>
	/// Represents the query source for a db set.
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public class DbSetQuerySource<TEntity> : IQuerySource<TEntity>
		where TEntity : class
	{
		private DbContext _context = null;
		private DbSet<TEntity> _set = null;


		/// <summary>
		/// Gets the container unit of work, if there is one.  Otherwise, the active set is returned.
		/// </summary>
		public IUnitOfWork Container
		{
			get
			{
				if (_context is IUnitOfWork)
					return _context as IUnitOfWork;
				else if (_set is IUnitOfWork)
					return _set as IUnitOfWork;

				return default(IUnitOfWork);
			}
		}

		Type IQueryable.ElementType
		{
			get { return ((IQueryable<TEntity>)_set).ElementType; }
		}

		System.Linq.Expressions.Expression IQueryable.Expression
		{
			get { return ((IQueryable<TEntity>)_set).Expression; }
		}

		IQueryProvider IQueryable.Provider
		{
			get { return ((IQueryable<TEntity>)_set).Provider; }
		}



		public DbSetQuerySource(DbContext context, DbSet<TEntity> os)
		{
			Guard.NotNull(context);
			Guard.NotNull(os);

			_context = context;
			_set = os;
		}



		public IEnumerator<TEntity> GetEnumerator()
		{
			return ((IEnumerable<TEntity>)_set).GetEnumerator();
		}

		IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
		{
			return ((IEnumerable<TEntity>)_set).GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return ((System.Collections.IEnumerable)_set).GetEnumerator();
		}
	}
}
