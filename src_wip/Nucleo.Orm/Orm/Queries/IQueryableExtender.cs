using System;
using System.Linq;
using System.Collections.Generic;


namespace Nucleo.Orm.Queries
{
    public interface IQueryableExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set and returns an anonymous result.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IQueryable Query(Func<IQuerySource<TEntity>, IQueryable> source);

        /// <summary>
        /// Queries the object set and returns an anonymous result.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IQueryable Query<TUnitOfWork>(Func<IQuerySource<TEntity>, TUnitOfWork, IQueryable> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
