using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Represents an object set.
	/// </summary>
	public interface IObjectSet
	{
		/// <summary>
		/// Gets the expression for the object set.
		/// </summary>
		Expression Expression { get; }

		/// <summary>
		/// Gets the query provider.
		/// </summary>
		IQueryProvider Provider { get; }



		/// <summary>
		/// Adds an object to the object set.
		/// </summary>
		/// <param name="entity">The entity to add.</param>
		void AddObject(object entity);

		/// <summary>
		/// Attaches the entity to the object set.
		/// </summary>
		/// <param name="entity">The entity to attach.</param>
		void Attach(object entity);

		/// <summary>
		/// Deletes an object from the object set.
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		void DeleteObject(object entity);
	}
}
