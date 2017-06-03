using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Collections
{
	public static class IEnumerableExtensions
	{
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
	}
}
