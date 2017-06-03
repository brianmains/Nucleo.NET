using System;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents a service to store temporary data.
	/// </summary>
	public interface ITemporaryDataService : IService
	{
		#region " Methods "

		/// <summary>
		/// Adds an item to the underlying service.
		/// </summary>
		/// <param name="key">The key of the item to add.</param>
		/// <param name="value">The value of the item to add.</param>
		void AddItem(string key, object value);

		/// <summary>
		/// Gets the item by its key, or null.
		/// </summary>
		/// <param name="key">The key of the item to get.</param>
		/// <returns>The value.</returns>
		object GetItem(string key);

		/// <summary>
		/// Gets the item by its key, or null.
		/// </summary>
		/// <typeparam name="T">The type of the item to convert to.</typeparam>
		/// <param name="key">The key of the item to get.</param>
		/// <returns>The value.</returns>
		T GetItem<T>(string key);

		/// <summary>
		/// Removes an item from temporary data storage.
		/// </summary>
		/// <param name="key">The key to remove.</param>
		void RemoveItem(string key);

		#endregion
	}
}
