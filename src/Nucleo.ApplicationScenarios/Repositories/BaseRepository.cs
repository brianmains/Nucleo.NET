using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Orm;


namespace Nucleo.Repositories
{
	public abstract class BaseRepository : IRepository
	{
		private IEntityUnitOfWork _unitOfWork = null;



		#region " Properties "

		protected IEntityUnitOfWork UnitOfWork
		{
			get { return _unitOfWork; }
		}

		#endregion



		#region " Constructors "

		public BaseRepository() { }

		#endregion



		#region " Methods "

		public virtual void CreateNew(object entity)
		{
			this.UnitOfWork.QueueInsert(entity);
		}

		public virtual object Get(object identifier)
		{
			return this.UnitOfWork.Get(identifier);
		}

		public virtual void Initialize(IEntityUnitOfWork uow)
		{
			_unitOfWork = uow;
		}

		public virtual void Remove(object entity)
		{
			this.UnitOfWork.QueueDelete(entity);
		}

		public virtual void Update(object entity)
		{
			this.UnitOfWork.QueueUpdate(entity);
		}

		#endregion
	}
}
