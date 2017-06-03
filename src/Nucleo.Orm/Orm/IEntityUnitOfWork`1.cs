using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm
{
	/// <summary>
	/// Represents a unit of work interface that works with entity instances.
	/// </summary>
	/// <typeparam name="TEntity">The entity type.</typeparam>
	public interface IEntityUnitOfWork<TEntity> : IUnitOfWork
		where TEntity: class
	{
		/// <summary>
		/// Creates a new entity.
		/// </summary>
		/// <returns>The new entity.</returns>
		TEntity CreateNew();

		/// <summary>
		/// Gets an object by its ID.
		/// </summary>
		/// <param name="identifier">The ID of the object.</param>
		/// <returns>The instance, or null if not found.</returns>
		TEntity Get(object identifier);

		/// <summary>
		/// Queues a deletion to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		void QueueDelete(TEntity entity);

		/// <summary>
		/// Queues an insertion to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to insert.</param>
		void QueueInsert(TEntity entity);

		/// <summary>
		/// Queues an update to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to update.</param>
		void QueueUpdate(TEntity entity);
	}
}
