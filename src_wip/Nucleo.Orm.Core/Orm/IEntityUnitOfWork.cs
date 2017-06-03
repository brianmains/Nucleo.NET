using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Orm
{
	/// <summary>
	/// Represents a unit of work specific to entities.
	/// </summary>
	public interface IEntityUnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// Creates a new entity.
		/// </summary>
		/// <returns>The new entity.</returns>
		object CreateNew();

		/// <summary>
		/// Gets an object by its ID.
		/// </summary>
		/// <param name="identifier">The ID of the object.</param>
		/// <returns>The instance, or null if not found.</returns>
		object Get(object identifier);

		/// <summary>
		/// Queues a deletion to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		void QueueDelete(object entity);

		/// <summary>
		/// Queues an insertion to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to insert.</param>
		void QueueInsert(object entity);

		/// <summary>
		/// Queues an update to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to update.</param>
		void QueueUpdate(object entity);
	}
}
