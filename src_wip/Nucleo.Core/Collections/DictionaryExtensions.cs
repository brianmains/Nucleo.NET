using System;
using System.Collections;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	public static class DictionaryExtensions
	{
		#region " Methods "

		/// <summary>
		/// Adds or updates a value in the dictionary.
		/// </summary>
		/// <typeparam name="K">The key value type.</typeparam>
		/// <typeparam name="V">The value value type.</typeparam>
		/// <param name="dictionary">The extended dictionary.</param>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public static void AddOrUpdate<K, V>(this IDictionary<K, V> dictionary, K key, V value)
		{
			if (dictionary.ContainsKey(key))
				dictionary[key] = value;
			else
				dictionary.Add(key, value);
		}

		/// <summary>
		/// Gets the value from the dictionary, or returns a default value if none found.
		/// </summary>
		/// <typeparam name="K">The key value type.</typeparam>
		/// <typeparam name="V">The value value type.</typeparam>
		/// <param name="dictionary">The extended dictionary.</param>
		/// <param name="key">The key to find by.</param>
		/// <returns>The value from the dictionary, or the type's default.</returns>
		public static V GetOrDefault<K, V>(this IDictionary<K, V> dictionary, K key)
		{
			if (dictionary.ContainsKey(key))
				return dictionary[key];
			else
				return default(V);
		}

		/// <summary>
		/// Gets the value from the dictionary, or returns a default value if none found.
		/// </summary>
		/// <typeparam name="K">The key value type.</typeparam>
		/// <typeparam name="V">The value value type.</typeparam>
		/// <param name="dictionary">The extended dictionary.</param>
		/// <param name="key">The key to find by.</param>
		/// <param name="defaultValue">The default value to return if not in the dictionary.</param>
		/// <returns>The value from the dictionary, or the default.</returns>
		public static V GetOrDefault<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue)
		{
			if (dictionary.ContainsKey(key))
				return dictionary[key];
			else
				return defaultValue;
		}

		/// <summary>
		/// Converts a dictionary of items to a list by only getting its values out of the dictionary, and returning it as a list.
		/// </summary>
		/// <typeparam name="K">The key type for the dictionary.</typeparam>
		/// <typeparam name="V">The value type for the dictionary.</typeparam>
		/// <param name="dictionary">The dictionary of items, using the key/value type, to convert.</param>
		/// <returns>A <see cref="CollectionBase"/> of values only.</returns>
		public static CollectionBase<V> ToCollectionBase<K, V>(this IDictionary<K, V> dictionary)
		{
			CollectionBase<V> list = new CollectionBase<V>();

			foreach (KeyValuePair<K, V> pair in dictionary)
				list.Add(pair.Value);

			return list;
		}

		/// <summary>
		/// Converts a dictionary of items to a list by only getting its values out of the dictionary, and returning it as a list.
		/// </summary>
		/// <typeparam name="K">The key type for the dictionary.</typeparam>
		/// <typeparam name="V">The value type for the dictionary.</typeparam>
		/// <param name="dictionary">The dictionary of items, using the key/value type, to convert.</param>
		/// <returns>A <see cref="List"/> of values only.</returns>
		public static List<V> ToList<K, V>(this IDictionary<K, V> dictionary)
		{
			List<V> list = new List<V>();

			foreach (KeyValuePair<K, V> pair in dictionary)
				list.Add(pair.Value);

			return list;
		}

		#endregion
	}
}
