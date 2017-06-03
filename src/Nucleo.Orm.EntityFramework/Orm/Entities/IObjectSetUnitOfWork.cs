using System;
using System.Linq;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Represents a unit of work that works with an ObjectSet.
	/// </summary>
	/// <typeparam name="TEntity">The entity type.</typeparam>
	public interface IObjectSetUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>
		where TEntity : class
	{
		/// <summary>
		/// Gets the name of the entity set.
		/// </summary>
		string EntitySetName { get; }

		/// <summary>
		/// Attaches the entity to the object context.
		/// </summary>
		/// <param name="entity">The entity to attach.</param>
		void Attach(TEntity entity);

		/// <summary>
		/// Detaches the entity to the object context.
		/// </summary>
		/// <param name="entity">The entity to detach.</param>
		void Detach(TEntity entity);

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		IQueryable<TEntity> Query(Func<ObjectSet<TEntity>, IQueryable<TEntity>> source);

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		IQueryable<TEntity> Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable<TEntity>> source)
			where TUnitOfWork: IUnitOfWork;

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <typeparam name="TEntityOut">The entity type to return.</typeparam>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		IQueryable<TEntityOut> Query<TEntityOut>(Func<ObjectSet<TEntity>, IQueryable<TEntityOut>> source)
			where TEntityOut : class;

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <typeparam name="TEntityOut">The entity type to return.</typeparam>
		/// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		IQueryable<TEntityOut> Query<TEntityOut, TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable<TEntityOut>> source)
			where TEntityOut : class
			where TUnitOfWork: IUnitOfWork;

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		IQueryable Query(Func<ObjectSet<TEntity>, IQueryable> source);

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		IQueryable Query<TUnitOfWork>(Func<ObjectSet<TEntity>, TUnitOfWork, IQueryable> source)
			where TUnitOfWork : IUnitOfWork;
	}
}
