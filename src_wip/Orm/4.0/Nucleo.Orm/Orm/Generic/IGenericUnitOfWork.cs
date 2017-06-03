using System;
using System.Linq;

using Nucleo.Orm;


namespace Nucleo.Orm.Generic
{
	/// <summary>
	/// Represents a genericized version of the unit of work.
	/// </summary>
	public interface IGenericUnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// Creates a new entity.
		/// </summary>
		/// <returns>The new entity.</returns>
		object CreateNew(EntityKeyInformation info);

		/// <summary>
		/// Gets an object by its ID.
		/// </summary>
		/// <param name="identifier">The ID of the object.</param>
		/// <returns>The instance, or null if not found.</returns>
		object Get(EntityKeyInformation info);

		IQueryable Query<TUnitOfWork>(Func<TUnitOfWork, IQueryable> action)
			where TUnitOfWork : IUnitOfWork;

		IQueryable<TEntity> Query<TUnitOfWork, TEntity>(Func<TUnitOfWork, IQueryable<TEntity>> action)
			where TUnitOfWork : IUnitOfWork
			where TEntity : class;

		/// <summary>
		/// Queues a deletion to the underlying unit of work.
		/// </summary>
		/// <param name="info">The information about the key.</param>
		/// <param name="entity">The entity to delete.</param>
		void QueueDelete(EntityKeyInformation info, object entity);

		/// <summary>
		/// Queues an insertion to the underlying unit of work.
		/// </summary>
		/// <param name="info">The information about the key.</param>
		/// <param name="entity">The entity to insert.</param>
		void QueueInsert(EntityKeyInformation info, object entity);

		/// <summary>
		/// Queues an update to the underlying unit of work.
		/// </summary>
		/// <param name="info">The information about the key.</param>
		/// <param name="entity">The entity to update.</param>
		void QueueUpdate(EntityKeyInformation info, object entity);
	}
}
