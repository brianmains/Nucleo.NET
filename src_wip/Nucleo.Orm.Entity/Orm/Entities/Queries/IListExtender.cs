using System;
using System.Collections;
using System.Linq;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;


namespace Nucleo.Orm.Entities.Queries
{
    public interface IListExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList Query(Func<ObjectSet<TEntity>, IList> source);

        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IList> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
