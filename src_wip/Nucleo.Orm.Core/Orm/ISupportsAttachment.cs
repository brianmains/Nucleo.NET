using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm
{
	/// <summary>
	/// Represents the ability to attach/detach an object.
	/// </summary>
	public interface ISupportsAttachment
	{
		/// <summary>
		/// Attaches the entity to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to attach.</param>
		void Attach(object entity);

		/// <summary>
		/// Detaches the entity to the underlying unit of work.
		/// </summary>
		/// <param name="entity">The entity to detach.</param>
		void Detach(object entity);
	}
}
