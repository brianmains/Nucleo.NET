using System;
using System.Collections;
using System.Linq;

namespace Nucleo.Orm.Queries
{
    public interface IListExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList QueryList(Func<IQuerySource<TEntity>, IList> source);

        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList QueryList<TUnitOfWork>(Func<IQuerySource<TEntity>, TUnitOfWork, IList> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
