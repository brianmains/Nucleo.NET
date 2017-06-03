using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

using Nucleo.Orm.Queries;
using Nucleo.Orm.Entities.Queries;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Represents an entity of work that's entity-specific, representing the Entity Framework <see cref="ObjectSet"/> object.
	/// </summary>
	/// <typeparam name="TEntity">The entity.</typeparam>
	public class ObjectSetEntityUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>, ISupportsQueries<TEntity>, IEntityUnitOfWork
		where TEntity : class
	{
		private ObjectSet<TEntity> _entities = null;



		#region " Properties "

		/// <summary>
		/// Gets the underlying ObjectSet reference.
		/// </summary>
		protected ObjectSet<TEntity> ObjectSet
		{
			get { return _entities; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the unit of work specific to entities that's for a <see cref="ObjectSet"/>.
		/// </summary>
		/// <param name="entities">The object set.</param>
		public ObjectSetEntityUnitOfWork(ObjectSet<TEntity> entities)
		{
			Guard.NotNull(entities);

			_entities = entities;
		}

		#endregion




		#region IEntityUnitOfWork<TEntity> Members

		/// <summary>
		/// Creates a new entity.
		/// </summary>
		/// <returns>The new entity.</returns>
		public virtual TEntity CreateNew()
		{
			return _entities.CreateObject<TEntity>();
		}

		/// <summary>
		/// Gets an object by its ID.
		/// </summary>
		/// <param name="identifier">The ID of the object.</param>
		/// <returns>The instance, or null if not found.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the identifier is null.</exception>
		public virtual TEntity Get(object identifier)
		{
			Guard.NotNull(identifier);

			if (identifier is EntityKey)
				return GetByEntityKey((EntityKey)identifier);

			return null;
		}

		protected virtual TEntity GetByEntityKey(EntityKey key)
		{
			object entity = null;

			if (ObjectSet.Context.TryGetObjectByKey(key, out entity))
			{
				if (!(entity is TEntity))
					throw new InvalidCastException("The entity loaded with the entity key is not of type: " + typeof(TEntity).Name);

				return (TEntity)entity;
			}
			else
				return null;
		}

		public QueryProvider<TEntity> Queries()
		{
			return new QueryProvider<TEntity>(new ObjectSetQuerySource<TEntity>(_entities));
		}

		/// <summary>
		/// Queues a delete option up to the underlying object set.
		/// </summary>
		/// <param name="obj">The object to delete.</param>
		public virtual void QueueDelete(TEntity obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			_entities.DeleteObject(obj);
		}

		/// <summary>
		/// Queues an insert operation up to the underlying object set.
		/// </summary>
		/// <param name="obj">The object to insert.</param>
		public virtual void QueueInsert(TEntity obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			_entities.AddObject(obj);
		}

		/// <summary>
		/// Queues an update operation up to the underlying object set.
		/// </summary>
		/// <param name="obj">The object to update.</param>
		public virtual void QueueUpdate(TEntity obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			if (obj is EntityObject)
			{
				if (((EntityObject)((object)obj)).EntityState == EntityState.Detached)
					_entities.Attach(obj);
			}
			else
			{
				var key = _entities.Context.CreateEntityKey(_entities.EntitySet.Name, obj);
				ObjectStateEntry entry = null;

				if (!_entities.Context.ObjectStateManager.TryGetObjectStateEntry(key, out entry))
				{
					_entities.Attach(obj);
				}
			}
		}

		/// <summary>
		/// Saves the changes to the underlying database.
		/// </summary>
		public virtual void SaveChanges()
		{
			_entities.Context.SaveChanges();
		}

		#endregion




		#region " IEntityUnitOfWork Members "

		object IEntityUnitOfWork.CreateNew()
		{
			return this.CreateNew();
		}

		object IEntityUnitOfWork.Get(object identifier)
		{
			return this.Get(identifier);
		}

		void IEntityUnitOfWork.QueueDelete(object entity)
		{
			this.QueueDelete((TEntity)entity);
		}

		void IEntityUnitOfWork.QueueInsert(object entity)
		{
			this.QueueInsert((TEntity)entity);
		}

		void IEntityUnitOfWork.QueueUpdate(object entity)
		{
			this.QueueUpdate((TEntity)entity);
		}

		void IUnitOfWork.SaveChanges()
		{
			this.SaveChanges();
		}

		#endregion
	}
}
