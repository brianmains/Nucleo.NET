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

		public static void Each<T>(this IEnumerable<T> list, Action<T> fn)
		{
			foreach (T item in list)
				fn(item);
		}

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
		/// Checks to see if an entry in the list is not null.  If it is, it returns true.
		/// </summary>
		/// <typeparam name="T">The type of the object within the list.</typeparam>
		/// <param name="list">The list to compare.</param>
		/// <param name="func">The lambda expression that returns the entry in the list, to determine if its null.</param>
		/// <returns>Whether an entry in the list is null, using the lamdba expression.</returns>
		public static bool HasNotNullEntry<T>(this IEnumerable<T> list, Func<T, object> func)
		{
			foreach (T item in list)
			{
				object value = func(item);

				if (value != null && !DBNull.Value.Equals(value))
					return true;
			}

			return false;
		}

		/// <summary>
		/// Checks to see if an entry in the list is null.  If it is, it returns true.
		/// </summary>
		/// <typeparam name="T">The type of the object within the list.</typeparam>
		/// <param name="list">The list to compare.</param>
		/// <param name="func">The lambda expression that returns the entry in the list, to determine if its null.</param>
		/// <returns>Whether an entry in the list is null, using the lamdba expression.</returns>
		public static bool HasNullEntry<T>(this IEnumerable<T> list, Func<T, object> func)
		{
			foreach (T item in list)
			{
				object value = func(item);
				if (value == null || DBNull.Value.Equals(value))
					return true;
			}

			return false;
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
		/// Converts a base enumerable list to a generic version.
		/// </summary>
		/// <typeparam name="T">The base type for the list.</typeparam>
		/// <param name="list">The list to convert.</param>
		/// <returns>An enumerated list.</returns>
		public static IEnumerable<T> ToEnumerable<T>(this System.Collections.IEnumerable list)
		{
			List<T> items = new List<T>();
			foreach (object item in list)
				items.Add((T)item);

			return items.ToArray();
		}

		/// <summary>
		/// Returns an observable collection with the list of items in the source.
		/// </summary>
		/// <typeparam name="T">The base item in the list.</typeparam>
		/// <param name="list">The list to convert.</param>
		/// <returns>An observable collection.</returns>
		//public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
		//{
		//    return new ObservableCollection<T>(new List<T>(list));
		//}

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
