using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Nucleo.Collections
{
	public static class IEnumerableExtensions
	{
		#region " Methods "

		/// <summary>
		/// Adds a range of items to the list.  Calls the <see cref="IList.Add">Add method</see>.
		/// </summary>
		/// <typeparam name="T">The type of item to add to the list.</typeparam>
		/// <param name="list">The list to add.</param>
		/// <param name="items">The items to add.</param>
		public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
		{
			foreach (T item in items)
				list.Add(item);
		}

		/// <summary>
		/// Processes each items within the enumerable list, using an action statement to update the object.
		/// </summary>
		/// <typeparam name="T">The type of item in the list.</typeparam>
		/// <param name="list">The list of items.</param>
		/// <param name="fn">The action that processes the object.</param>
		public static void Each<T>(this IEnumerable<T> list, Action<T> fn)
		{
			foreach (T item in list)
				fn(item);
		}

		/// <summary>
		/// Processes each items within the enumerable list, using an action statement to update the object.
		/// </summary>
		/// <typeparam name="T">The type of item in the list.</typeparam>
		/// <typeparam name="V">The output result.</typeparam>
		/// <param name="list">The list of items.</param>
		/// <param name="fn">The lambda that processes the object.</param>
		public static IEnumerable<V> Each<T, V>(this IEnumerable<T> list, Func<T, V> fn)
		{
			List<V> outputList = new List<V>();

			foreach (T item in list)
				outputList.Add(fn(item));

			return outputList;
		}

		public static IEnumerable<T> GetAlternatingItems<T>(this IEnumerable<T> list, bool retrieveEvenItems)
		{
			List<T> outputList = new List<T>();
			int index = 0;

			foreach (T item in list)
			{
				if (!retrieveEvenItems)
				{
					if (index % 2 == 0)
						outputList.Add(item);
				}
				else
				{
					if (index % 2 == 1)
						outputList.Add(item);
				}

				index++;
			}

			return outputList;
		}

		/// <summary>
		/// Gets a subset of items based on a start/count value.
		/// </summary>
		/// <typeparam name="T">The type of items being dealth with.</typeparam>
		/// <param name="list">The list of items to extend.</param>
		/// <param name="start">The index value to start at.</param>
		/// <param name="count">The total number of items to iterate.</param>
		/// <returns>A list of items matching those results.</returns>
		public static IEnumerable<T> Subset<T>(this IEnumerable<T> list, int start, int count)
		{
			List<T> subset = new List<T>(list);
			return subset.GetRange(start, count);
		}

		/// <summary>
		/// Returns a collection of enumerable items back as an instance of the <see cref="CollectionBase"/> class.
		/// </summary>
		/// <typeparam name="T">The type for the item that is in the collection.</typeparam>
		/// <param name="list">The list of items to convert.</param>
		/// <returns>A converted list of items in the form of a <see cref="CollectionBase" /> class.</returns>
		public static CollectionBase<T> ToCollectionBase<T>(this IEnumerable<T> list)
		{
			return new CollectionBase<T>(list);
		}

		/// <summary>
		/// Returns a collection of enumerable items back as an instance of the <see cref="SimpleCollection"/> class.
		/// </summary>
		/// <typeparam name="T">The type for the item that is in the collection.</typeparam>
		/// <param name="list">The list of items to convert.</param>
		/// <returns>A converted list of items in the form of a <see cref="SimpleCollection" /> class.</returns>
		public static SimpleCollection<T> ToSimpleCollection<T>(this IEnumerable<T> list)
		{
			return new SimpleCollection<T>(list);
		}

		#endregion
	}
}
