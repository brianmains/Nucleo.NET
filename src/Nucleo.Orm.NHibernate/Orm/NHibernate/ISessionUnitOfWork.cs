using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate;
using NHibernate.Linq;


namespace Nucleo.Orm.NHibernate
{
	/// <summary>
	/// Represents a unit of work related to sessions.
	/// </summary>
	/// <typeparam name="TEntity">The core entity type the unit of work serves.</typeparam>
	public interface ISessionUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>
		where TEntity : class
	{
		#region " Methods "

		ICriteria CreateCriteria();

		ICriteria CreateCriteria(string alias);

		IList<TEntity> Query(ICriteria criteria);

		IList<TEntity> Query(Func<IQueryOver<TEntity, TEntity>, IList<TEntity>> query);

		#endregion
	}
}
