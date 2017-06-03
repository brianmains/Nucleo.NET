using System;
using System.Linq;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;


namespace Nucleo.Orm.Entities.Queries
{
    /// <summary>
    /// Represents an extender that returns a queryable type.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IQueryableExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
        IQueryable Query(Func<ObjectSet<TEntity>, IQueryable> source);

        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
        IQueryable Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
