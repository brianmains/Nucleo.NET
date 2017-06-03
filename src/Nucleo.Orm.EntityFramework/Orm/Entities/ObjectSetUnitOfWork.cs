using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Data;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Represents the unit of work for an <see cref="ObjectSet"/> instance.
	/// </summary>
	/// <typeparam name="TEntity">The entity instance.</typeparam>
	public class ObjectSetUnitOfWork<TEntity> : ObjectSetEntityUnitOfWork<TEntity>, IObjectSetUnitOfWork<TEntity>
		where TEntity : class
	{
		#region " Properties "

		/// <summary>
		/// Gets the name of the entity set.
		/// </summary>
		public virtual string EntitySetName
		{
			get { return ObjectSet.Context.DefaultContainerName + "." + ObjectSet.EntitySet.Name; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the unit of work specific to the <see cref="ObjectSet"/>.
		/// </summary>
		/// <param name="entities">The object set.</param>
		public ObjectSetUnitOfWork(ObjectSet<TEntity> entities)
			: base(entities) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Attaches the entity to the object context.
		/// </summary>
		/// <param name="entity">The entity to attach.</param>
		public virtual void Attach(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			ObjectSet.Attach(entity);
		}

		/// <summary>
		/// Detaches the entity to the object context.
		/// </summary>
		/// <param name="entity">The entity to detach.</param>
		public virtual void Detach(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			ObjectSet.Detach(entity);
		}

		private TUnitOfWork GetUnitOfWork<TUnitOfWork>()
		{
			object uow = null;

			if (ObjectSet.Context is TUnitOfWork)
				uow = ObjectSet.Context;
			else if (ObjectSet is TUnitOfWork)
				uow = ObjectSet;
			else uow = default(TUnitOfWork);

			return (TUnitOfWork)uow;
		}

		/// <summary>
		/// Queries the entity collection, seeking to return one or more of a collection type.  If expecting only one result, after the Query method, return FirstOrDefault or SingleOrDefault().
		/// </summary>
		/// <param name="source">The source of the query.</param>
		/// <returns>The query results.</returns>
		public virtual IQueryable<TEntity> Query(Func<ObjectSet<TEntity>, IQueryable<TEntity>> source)
		{
			if (source == null)
				throw new ArgumentNullException("source");

			return source(ObjectSet);
		}

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		public virtual IQueryable<TEntity> Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable<TEntity>> source)
			where TUnitOfWork : IUnitOfWork
		{
			if (source == null)
				throw new ArgumentNullException("source");

			return source(ObjectSet, this.GetUnitOfWork<TUnitOfWork>());
		}

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <typeparam name="TEntityOut">The entity type to return.</typeparam>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		public virtual IQueryable<TEntityOut> Query<TEntityOut>(Func<ObjectSet<TEntity>, IQueryable<TEntityOut>> source)
			where TEntityOut: class
		{
			if (source == null)
				throw new ArgumentNullException("source");

			return source(ObjectSet);
		}

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <typeparam name="TEntityOut">The entity type to return.</typeparam>
		/// <typeparam name="TUnitOfWork">The unit of work type.</typeparam>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		public IQueryable<TEntityOut> Query<TEntityOut, TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable<TEntityOut>> source)
			where TEntityOut : class
			where TUnitOfWork : IUnitOfWork
		{
			if (source == null)
				throw new ArgumentNullException("source");

			return source(ObjectSet, this.GetUnitOfWork<TUnitOfWork>());
		}

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		public IQueryable Query(Func<ObjectSet<TEntity>, IQueryable> source)
		{
			if (source == null)
				throw new ArgumentNullException("source");

			return source(ObjectSet);
		}

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		public IQueryable Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable> source)
			where TUnitOfWork : IUnitOfWork
		{
			if (source == null)
				throw new ArgumentNullException("source");

			return source(ObjectSet, this.GetUnitOfWork<TUnitOfWork>());
		}

		#endregion
	}
}
