using System;
using System.Linq;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

using Nucleo.Orm.Entities.Queries;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Represents a unit of work that works with an ObjectSet.
	/// </summary>
	/// <typeparam name="TEntity">The entity type.</typeparam>
	public interface IObjectSetUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>, ISupportsAttachment<TEntity>
		where TEntity : class
	{
		/// <summary>
		/// Gets the reference to the context.
		/// </summary>
		ObjectContext Context { get; }

		/// <summary>
		/// Gets the name of the entity set.
		/// </summary>
		string EntitySetName { get; }
	}
}
