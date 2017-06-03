using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;


namespace Nucleo.Orm.NHibernate
{
	/// <summary>
	/// Represents the unit of work that works with NHibernate sessions; wraps a session as a unit of work. 
	/// </summary>
	/// <typeparam name="TEntity">The entity type that the session represents.</typeparam>
	public class SessionUnitOfWork<TEntity> : ISessionUnitOfWork<TEntity>
		where TEntity: class
	{
		private ISession _session = null;



		#region " Constructors "

		public SessionUnitOfWork(ISession session)
		{
			_session = session;
			
		}

		#endregion



		#region " Methods "

		public virtual ICriteria CreateCriteria()
		{
			return _session.CreateCriteria<TEntity>();
		}

		public virtual ICriteria CreateCriteria(string alias)
		{
			return _session.CreateCriteria<TEntity>(alias);
		}

		public virtual TEntity CreateNew()
		{
			return Activator.CreateInstance<TEntity>();
		}

		public virtual TEntity Get(object identifier)
		{
			return (TEntity)_session.Get(typeof(TEntity), identifier);
		}

		public virtual IList<TEntity> Query(ICriteria criteria)
		{
			return criteria.List<TEntity>();
		}

		public virtual IList<TEntity> Query(Func<IQueryOver<TEntity, TEntity>, IList<TEntity>> query)
		{
			return query(_session.QueryOver<TEntity>());
		}

		public virtual void QueueDelete(TEntity entity)
		{
			_session.Delete(entity);
		}

		public virtual void QueueInsert(TEntity entity)
		{
			_session.Save(entity);
		}

		public virtual void QueueUpdate(TEntity entity)
		{
			_session.Update(entity);
		}

		public virtual void SaveChanges()
		{
			_session.Flush();
		}

		#endregion
	}
}