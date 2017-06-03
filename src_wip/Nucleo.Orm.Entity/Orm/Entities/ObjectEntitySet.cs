using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Represents the object set for an entity, loosely around a dynamic reference to the object set.
	/// </summary>
	public class ObjectEntitySet : IQueryable, IObjectSet
	{
		#region " Properties "

		/// <summary>
		/// Gets the element type.
		/// </summary>
		public Type ElementType
		{
			get { return this.ObjectSet.ElementType; }
		}

		/// <summary>
		/// Gets the dynamic expression.
		/// </summary>
		public System.Linq.Expressions.Expression Expression
		{
			get { return this.ObjectSet.Expression; }
		}

		/// <summary>
		/// Gets the reference to the underlying object set.
		/// </summary>
		public dynamic ObjectSet
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the reference to the LINQ query provider.
		/// </summary>
		public IQueryProvider Provider
		{
			get { return this.ObjectSet.Provider; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the object set with the given dynamic expression.
		/// </summary>
		/// <param name="objectSet">The object set reference.</param>
		/// <exception cref="ArgumentNullException">Thrown when the object set is null.</exception>
		public ObjectEntitySet(dynamic objectSet)
		{
			Guard.NotNull(objectSet);

			this.ObjectSet = objectSet;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an object to the entity set.
		/// </summary>
		/// <param name="entity">The entity to add; must be of the correct underlying type; otherwise, an error may occur..</param>
		public void AddObject(object entity)
		{
			this.ObjectSet.AddObject(entity);
		}

		/// <summary>
		/// Attaches an object to the entity set.
		/// </summary>
		/// <param name="entity">The type of entity to attach; must be of the correct underlying type; otherwise, an error may occur..</param>
		public void Attach(object entity)
		{
			this.ObjectSet.Attach(entity);
		}

		/// <summary>
		/// Deletes an object from the entity set.
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		public void DeleteObject(object entity)
		{
			this.ObjectSet.DeleteObject(entity);
		}

		/// <summary>
		/// Gets the enumeration of the collection.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public System.Collections.IEnumerator GetEnumerator()
		{
			return this.ObjectSet.GetEnumerator();
		}

		#endregion
	}
}
