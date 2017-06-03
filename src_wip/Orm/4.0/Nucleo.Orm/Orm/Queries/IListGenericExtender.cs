using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Orm.Queries
{
    public interface IListGenericExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList<TEntity> QueryList(Func<IQuerySource<TEntity>, IList<TEntity>> source);

        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList<TEntity> QueryList<TUnitOfWork>(Func<IQuerySource<TEntity>, TUnitOfWork, IList<TEntity>> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
