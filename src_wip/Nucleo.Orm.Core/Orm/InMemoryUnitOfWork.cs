using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Nucleo.Orm.Identification;

namespace Nucleo.Orm
{
	public class InMemoryUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>, IEntityUnitOfWork
		where TEntity: class
	{
		private List<TEntity> _data = null;
		private List<ChangedObject> _changes = null;
        private Func<TEntity, object> _keySelector = null;



		#region " Properties "

		protected virtual List<ChangedObject> Changes
		{
			get
			{
				if (_changes == null)
                    _changes = new List<ChangedObject>();

				return _changes;
			}
		}

        public int ChangeCount
        {
            get { return _changes.Count; }
        }

        public int ItemCount
        {
            get { return _data.Count; }
        }

		#endregion



		#region " Constructors "

		public InMemoryUnitOfWork()
		{
			
		}

        public InMemoryUnitOfWork(IEnumerable<TEntity> initialUnchangedResults)
        {
            if (initialUnchangedResults == null)
                throw new ArgumentNullException("initialUnchangedResults");

            _data = initialUnchangedResults.ToList();
        }

        public InMemoryUnitOfWork(Func<TEntity, object> keySelector)
        {
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");

            _keySelector = keySelector;
        }

        public InMemoryUnitOfWork(IEnumerable<TEntity> initialUnchangedResults, Func<TEntity, object> keySelector)
        {
            if (initialUnchangedResults == null)
                throw new ArgumentNullException("initialUnchangedResults");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");

            _data = initialUnchangedResults.ToList();
            _keySelector = keySelector;
        }

		#endregion



		#region " Methods "

		public virtual TEntity CreateNew()
		{
			return Activator.CreateInstance<TEntity>();
		}

		object IEntityUnitOfWork.CreateNew()
		{
			return this.CreateNew();
		}

		public virtual TEntity Get(object identifier)
		{
			if (identifier == null)
				throw new ArgumentNullException("identifier");

            //PropertyInfo[] props = typeof(TEntity).GetProperties();
            //var prop = props.FirstOrDefault(i => i.GetCustomAttributes(typeof(PrimaryRecordIdentifierAttribute), false).Length > 0);
            //if (prop == null)
            //    prop = props[0];
			
            //var param = Expression.Parameter(typeof(TEntity), "e");
            //var equals = Expression.Equal(Expression.Property(param, prop.Name), Expression.Constant(identifier));

            //return _data.AsQueryable().FirstOrDefault(Expression.Lambda<Func<TEntity, bool>>(equals));

            return _data.FirstOrDefault(i => Object.Equals(this.GetKeyValue(i), identifier));
		}

		object IEntityUnitOfWork.Get(object identifier)
		{
			return this.Get(identifier);
		}

        public IEnumerable<TEntity> GetAll()
        {
            return _data.AsEnumerable();
        }

        protected virtual object GetKeyValue(TEntity entity)
        {
            if (_keySelector != null)
                return _keySelector(entity);

            PropertyInfo[] props = typeof(TEntity).GetProperties();
            var prop = props.FirstOrDefault(i => i.GetCustomAttributes(typeof(PrimaryRecordIdentifierAttribute), false).Length > 0);
            if (prop == null)
                prop = props[0];

            return prop.GetValue(entity, null);
        }

		public virtual void QueueDelete(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

            this.Changes.Add(new ChangedObject { Entity = entity, Modification = ModificationType.Removed, Key = GetKeyValue(entity) });
		}

		void IEntityUnitOfWork.QueueDelete(object entity)
		{
			if (!(entity is TEntity))
				throw new InvalidCastException("Entity provided is not of type: " + typeof(TEntity).Name);

			this.QueueDelete((TEntity)entity);
		}

		public virtual void QueueInsert(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

            this.Changes.Add(new ChangedObject { Entity = entity, Modification = ModificationType.Added, Key = GetKeyValue(entity) });
		}

		void IEntityUnitOfWork.QueueInsert(object entity)
		{
			if (!(entity is TEntity))
				throw new InvalidCastException("Entity provided is not of type: " + typeof(TEntity).Name);

			this.QueueInsert((TEntity)entity);
		}

		public virtual void QueueUpdate(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

            var change = Changes.FirstOrDefault(i => i.Key == GetKeyValue(entity));

            if (change != null)
            {
                if (change.Modification == ModificationType.Removed)
                    throw new InvalidOperationException("Cannot update an entity marked for deletion.");
                else if (change.Modification == ModificationType.Added)
                    return;
            }

            this.Changes.Add(new ChangedObject { Entity = entity, Modification = ModificationType.Updated, Key = GetKeyValue(entity) });
		}

		void IEntityUnitOfWork.QueueUpdate(object entity)
		{
			if (!(entity is TEntity))
				throw new InvalidCastException("Entity provided is not of type: " + typeof(TEntity).Name);

			this.QueueUpdate((TEntity)entity);
		}

		public virtual void SaveChanges()
		{
			if (_changes == null || _changes.Count == 0)
				return;
            if (_data == null)
                _data = new List<TEntity>();

            foreach (var change in _changes)
            {
                if (change.Modification == ModificationType.Removed)
                {
                    _data.Remove((TEntity)change.Entity);
                }
                else if (change.Modification == ModificationType.Added)
                {
                    _data.Add((TEntity)change.Entity);
                }
                else if (change.Modification == ModificationType.Updated)
                {
                    for (int i = 0, len = _data.Count; i < len; i++)
                    {
                        if (Object.Equals(GetKeyValue(_data[i]), change.Key))
                            _data[i] = (TEntity)change.Entity;
                    }
                }
            }

            _changes.Clear();
		}

		void IUnitOfWork.SaveChanges()
		{
			this.SaveChanges();
		}

		#endregion	
	}
}
