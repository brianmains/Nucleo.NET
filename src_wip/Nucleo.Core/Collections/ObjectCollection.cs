using System;
using System.Collections;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	/// <summary>
	/// A collection of objects to use in general situations.
	/// </summary>
	public class ObjectCollection : CollectionBase<Object>
	{
		#region " Constructors "

		/// <summary>
		/// Creates an empty collection.
		/// </summary>
		public ObjectCollection() { }

		/// <summary>
		/// Creates with a prepopulated collection.
		/// </summary>
		/// <param name="obj">The initial list of objects.</param>
		public ObjectCollection(IEnumerable<object> obj)
		{
			this.AddRange(obj);
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an enumerable list of items to the collection.
		/// </summary>
		/// <param name="list">The list to add.</param>
		public void AddRange(IEnumerable list)
		{
			IEnumerator en = list.GetEnumerator();

			while (en.MoveNext())
				this.Add(en.Current);
		}

		/// <summary>
		/// Adds a generic list of items to the collection.
		/// </summary>
		/// <typeparam name="T">The type of items in the list.</typeparam>
		/// <param name="list">The list of items to add, which will be unboxed.</param>
		public void AddRange<T>(IEnumerable<T> list)
		{
			IEnumerator<T> en = list.GetEnumerator();

			while (en.MoveNext())
				this.Add(en.Current);
		}

		#endregion
	}
}
