using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;


namespace Nucleo.Orm.DataClasses.Queries
{
    public interface IListGenericExtender<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList<TEntity> Query(Func<Table<TEntity>, IList<TEntity>> source);

        /// <summary>
        /// Queries the object set.
        /// </summary>
        /// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
        /// <param name="source">The source lambda.</param>
        /// <returns>The query.</returns>
		IList<TEntity> Query<TUnitOfWork>(Func<Table<TEntity>, TUnitOfWork, IList<TEntity>> source)
            where TUnitOfWork : IUnitOfWork;
    }
}
