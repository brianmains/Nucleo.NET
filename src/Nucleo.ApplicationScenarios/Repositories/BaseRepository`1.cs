using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Orm;

namespace Nucleo.Repositories
{
	public abstract class BaseRepository<TEntity> : IRepository<TEntity>, IRepository
		where TEntity: class
	{
		private IEntityUnitOfWork<TEntity> _unitOfWork = null;



		#region " Properties "

		protected IEntityUnitOfWork<TEntity> UnitOfWork
		{
			get { return _unitOfWork; }
		}

		#endregion



		#region " Constructors "

		public BaseRepository() { }

		#endregion



		#region " Methods "

		public virtual void CreateNew(TEntity entity)
		{
			_unitOfWork.QueueInsert(entity);
		}

		void IRepository.CreateNew(object entity)
		{
			if (!(entity is TEntity))
				throw new InvalidCastException("Could not cast the entity to type: " + typeof(TEntity).FullName);

			this.CreateNew((TEntity)entity);
		}

		public abstract TEntity Get(object identifier);

		object IRepository.Get(object identifier)
		{
			return this.Get(identifier);
		}

		public virtual void Initialize(IEntityUnitOfWork<TEntity> uow)
		{
			if (uow == null)
				throw new ArgumentNullException("uow");

			_unitOfWork = uow;
		}
		
		public virtual void Remove(TEntity entity)
		{
			_unitOfWork.QueueDelete(entity);
		}

		void IRepository.Remove(object entity)
		{
			if (!(entity is TEntity))
				throw new InvalidCastException("Could not cast the entity to type: " + typeof(TEntity).FullName);

			this.Remove((TEntity)entity);
		}

		public virtual void Update(TEntity entity)
		{
			_unitOfWork.QueueUpdate(entity);
		}

		void IRepository.Update(object entity)
		{
			if (!(entity is TEntity))
				throw new InvalidCastException("Could not cast the entity to type: " + typeof(TEntity).FullName);

			this.Update((TEntity)entity);
		}

		#endregion
	}
}
