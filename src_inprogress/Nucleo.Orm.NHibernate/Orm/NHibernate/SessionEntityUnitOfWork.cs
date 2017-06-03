using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;


namespace Nucleo.Orm.NHibernate
{
	public class SessionEntityUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>
		where TEntity: class
	{
		private ISession _session = null;



		#region " Constructors "

		public SessionEntityUnitOfWork(ISession session)
		{
			_session = session;
			
		}

		#endregion



		#region " Methods "

		public virtual TEntity CreateNew()
		{
			return Activator.CreateInstance<TEntity>();
		}

		public virtual TEntity Get(object identifier)
		{
			return (TEntity)_session.Get(typeof(TEntity), identifier);
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
