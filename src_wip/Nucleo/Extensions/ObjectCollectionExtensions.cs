using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Collections
{
	public static class ObjectCollectionExtensions
	{
		/// <summary>
		/// Adds the array list to the collection.
		/// </summary>
		/// <param name="coll">The collection of items.</param>
		/// <param name="list">The list of items to add.</param>
		public static void AddRange(this ObjectCollection coll, ArrayList list)
		{
			foreach (object item in list)
				coll.Add(item);
		}
	}
}
