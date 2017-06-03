using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;


namespace Nucleo.Orm.DataClasses.Queries
{
    public interface IQueryableExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set and returns an anonymous result.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
        IQueryable Query(Func<Table<TEntity>, IQueryable> source);

        /// <summary>
        /// Queries the object set and returns an anonymous result.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
        IQueryable Query<TUnitOfWork>(Func<Table<TEntity>, TUnitOfWork, IQueryable> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
