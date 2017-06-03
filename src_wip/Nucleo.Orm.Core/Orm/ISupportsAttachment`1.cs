using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm
{
	/// <summary>
	/// Represents a unit of work that supports attaching and detaching objects.
	/// </summary>
	/// <typeparam name="TEntity">The entity that is attached/detached.</typeparam>
	public interface ISupportsAttachment<TEntity>
		where TEntity: class
	{
		/// <summary>
		/// Attaches the entity to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to attach.</param>
		void Attach(TEntity entity);

		/// <summary>
		/// Detaches the entity to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to detach.</param>
		void Detach(TEntity entity);
	}
}
