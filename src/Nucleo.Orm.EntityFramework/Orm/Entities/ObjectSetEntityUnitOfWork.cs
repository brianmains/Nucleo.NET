using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Objects;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Represents an entity of work that's entity-specific, representing the Entity Framework <see cref="ObjectSet"/> object.
	/// </summary>
	/// <typeparam name="TEntity">The entity.</typeparam>
	public class ObjectSetEntityUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>
		where TEntity : class
	{
		private ObjectSet<TEntity> _entities = null;



		#region " Properties "

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
			if (entities == null)
				throw new ArgumentNullException("entities");

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
		public virtual TEntity Get(object identifier)
		{
			if (identifier is EntityKey)
				return GetByEntityKey((EntityKey)identifier);

			return null;
		}

		protected virtual TEntity GetByEntityKey(EntityKey key)
		{
			if (key == null)
				throw new ArgumentNullException("key");

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


		}

		/// <summary>
		/// Saves the changes to the underlying database.
		/// </summary>
		public virtual void SaveChanges()
		{
			_entities.Context.SaveChanges();
		}

		#endregion
	}
}
