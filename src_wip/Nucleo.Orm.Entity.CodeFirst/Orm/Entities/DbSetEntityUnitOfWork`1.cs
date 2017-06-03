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
	/// <summary>
	/// Represents the DB Set unit of work for a given entity.
	/// </summary>
	/// <typeparam name="TEntity">The type of entity represented by the DB set.</typeparam>
	public class DbSetEntityUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>, ISupportsQueries<TEntity>, IEntityUnitOfWork
		where TEntity: class
	{
		private DbContext _context = null;
		private DbSet<TEntity> _entities = null;


		/// <summary>
		/// Gets the underlying ObjectSet reference.
		/// </summary>
		protected DbSet<TEntity> Set
		{
			get { return _entities; }
		}



		/// <summary>
		/// Creates the DB set with the current DbContext instance and DbSet representing the current class type.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="entities">The set given for the current entities.</param>
		public DbSetEntityUnitOfWork(DbContext context, DbSet<TEntity> entities)
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
		public virtual TEntity CreateNew()
		{
			return _entities.Create<TEntity>();
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

			return _entities.Find(identifier);
		}

		/// <summary>
		/// Used to create a query against the given DB set.
		/// </summary>
		/// <returns>The current query provider.</returns>
		public QueryProvider<TEntity> Queries()
		{
			return new QueryProvider<TEntity>(new DbSetQuerySource<TEntity>(_context, _entities));
		}

		/// <summary>
		/// Queues a delete option up to the underlying object set.
		/// </summary>
		/// <param name="obj">The object to delete.</param>
		public virtual void QueueDelete(TEntity obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			_entities.Remove(obj);
		}

		/// <summary>
		/// Queues an insert operation up to the underlying object set.
		/// </summary>
		/// <param name="obj">The object to insert.</param>
		public virtual void QueueInsert(TEntity obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			_entities.Add(obj);
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
			_context.SaveChanges();
		}



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
