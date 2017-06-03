using System;
using System.Linq;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;


namespace Nucleo.Orm.Entities.Queries
{
    public interface IQueryableGenericExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
        IQueryable<TEntity> Query(Func<ObjectSet<TEntity>, IQueryable<TEntity>> source);

        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
        IQueryable<TEntity> Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable<TEntity>> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
