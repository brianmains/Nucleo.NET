using System;
using System.Collections;
using System.Linq;
using System.Data;
using System.Data.Linq;


namespace Nucleo.Orm.DataClasses.Queries
{
    public interface IListExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList Query(Func<Table<TEntity>, IList> source);

        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList Query<TUnitOfWork>(Func<Table<TEntity>, TUnitOfWork, IList> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
