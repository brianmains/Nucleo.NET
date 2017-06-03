using System;


namespace Nucleo.Context
{
	/// <summary>
	/// Represents a specific service that acts like a dictionary, adding and removing items as they need.
	/// </summary>
	public interface IServiceDictionary : IService
	{
		/// <summary>
		/// Gets the total number of items in the underlying source.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Gets a value using the key from the underlying source.
		/// </summary>
		/// <param name="key">The key to get the value for.</param>
		/// <returns>The value.</returns>
		object this[string key] { get; set; }

		/// <summary>
		/// Adds a key/value pair to the underlying source.
		/// </summary>
		/// <param name="key">The key to use to add.</param>
		/// <param name="value">The value to add.</param>
		void Add(string key, object value);

		/// <summary>
		/// Whether the key to add.
		/// </summary>
		/// <param name="key">The key to check for existence.</param>
		/// <returns>Whether the item exists.</returns>
		/// <remarks>Most implementations use the get method and check for a non-null value, so using this method may not be the most efficient.  It depends on the implementation of the service.</remarks>
		bool Contains(string key);

		/// <summary>
		/// Gets the item by its key.
		/// </summary>
		/// <param name="key">The key of the item to get.</param>
		/// <returns>The item found by the key, or null.</returns>
		object Get(string key);

		/// <summary>
		/// Gets the item by its index.
		/// </summary>
		/// <param name="index">The index of the item to get.</param>
		/// <returns>The item found by the index, or null.</returns>
		object Get(int index);

		/// <summary>
		/// Removes an entry by using its key.
		/// </summary>
		/// <param name="key">The key of the item to remove.</param>
		void Remove(string key);

		/// <summary>
		/// Removes an entry by using its index.
		/// </summary>
		/// <param name="index">The index of the item to remove.</param>
		void RemoveAt(int index);
	}
}
