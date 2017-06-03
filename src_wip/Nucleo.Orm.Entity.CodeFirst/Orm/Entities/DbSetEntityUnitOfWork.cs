using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using Nucleo.Orm.Entities;
using Nucleo.Orm.Entities.Queries;
using Nucleo.Orm.Queries;
using System.Data.Entity.Infrastructure;
using System.Data;


namespace Nucleo.Orm.Entities
{
	public class DbSetEntityUnitOfWork : IEntityUnitOfWork
	{
		private DbContext _context = null;
		private DbSet _entities = null;


		/// <summary>
		/// Gets the underlying ObjectSet reference.
		/// </summary>
		protected DbSet Set
		{
			get { return _entities; }
		}



		/// <summary>
		/// Creates the DB set with the current DbContext instance and DbSet representing the current class type.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="entities">The set given for the current entities.</param>
		public DbSetEntityUnitOfWork(DbContext context, DbSet entities)
		{
			Guard.NotNull(context);
			Guard.NotNull(entities);

			_context = context;
			_entities = entities;
		}



		/// <summary>
		/// Creates a new entity.
		/// </summary>
		/// <returns>The new entity.</returns>
		public virtual object CreateNew()
		{
			return _entities.Create(_entities.ElementType);
		}

		/// <summary>
		/// Gets an object by its ID.
		/// </summary>
		/// <param name="identifier">The ID of the object.</param>
		/// <returns>The instance, or null if not found.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the identifier is null.</exception>
		public virtual object Get(object identifier)
		{
			Guard.NotNull(identifier);
			return _entities.Find(identifier);
		}

		/// <summary>
		/// Queues a delete option up to the underlying object set.
		/// </summary>
		/// <param name="obj">The object to delete.</param>
		public virtual void QueueDelete(object obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			_entities.Remove(obj);
		}

		/// <summary>
		/// Queues an insert operation up to the underlying object set.
		/// </summary>
		/// <param name="obj">The object to insert.</param>
		public virtual void QueueInsert(object obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			_entities.Add(obj);
		}

		/// <summary>
		/// Queues an update operation up to the underlying object set.
		/// </summary>
		/// <param name="obj">The object to update.</param>
		public virtual void QueueUpdate(object obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

		}

		/// <summary>
		/// Saves the changes to the underlying database.
		/// </summary>
		public virtual void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
