using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Orm.Queries
{
    public interface IQueryableGenericExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IQueryable<TEntity> Query(Func<IQuerySource<TEntity>, IQueryable<TEntity>> source);

        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IQueryable<TEntity> Query<TUnitOfWork>(Func<IQuerySource<TEntity>, TUnitOfWork, IQueryable<TEntity>> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
