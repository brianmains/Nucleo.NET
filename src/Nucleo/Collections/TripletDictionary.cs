using System;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	/// <summary>
	/// The triplet dictionary, which is a dictionary but with two values, instead of one.  It allows an extra value for certain purposes.
	/// </summary>
	/// <typeparam name="TKey">The type to use for the key.</typeparam>
	/// <typeparam name="TValue1">The type for the first value to use.</typeparam>
	/// <typeparam name="TValue2">The type for the second value to use.</typeparam>
	public class TripletDictionary<TKey, TValue1, TValue2> : IEnumerable<TripletItem<TKey, TValue1, TValue2>>
	{
		private List<TripletItem<TKey, TValue1, TValue2>> _items = null;



		#region " Properties "

		/// <summary>
		/// Gets the count of the items in the dictionary.
		/// </summary>
		public int Count
		{
			get { return this.Items.Count; }
		}

		/// <summary>
		/// Gets the internal list for the triplet dictionary.  If not already loaded, the object is instantiated.
		/// </summary>
		private List<TripletItem<TKey, TValue1, TValue2>> Items
		{
			get
			{
				if (_items == null)
					_items = new List<TripletItem<TKey, TValue1, TValue2>>();
				return _items;
			}
		}

		/// <summary>
		/// Gets the item in the list based on the key value.
		/// </summary>
		/// <param name="key">The key to use to locate an item.</param>
		/// <returns>The item that was found, or null if no item was found.</returns>
		public TripletItem<TKey, TValue1, TValue2> this[TKey key]
		{
			get
			{
				foreach (TripletItem<TKey, TValue1, TValue2> item in this.Items)
				{
					if (item.Key.Equals(key))
						return item;
				}

				return null;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an item to the dictionary.
		/// </summary>
		/// <param name="key">The key to add.</param>
		/// <param name="value1">The first value to add.</param>
		/// <param name="value2">The second value to add.</param>
		public void Add(TKey key, TValue1 value1, TValue2 value2)
		{
			this.Items.Add(new TripletItem<TKey, TValue1, TValue2>(key, value1, value2));
		}

		/// <summary>
		/// Determines whether an item with the specified key exists in the collection.
		/// </summary>
		/// <param name="key">The key of the item to find.</param>
		/// <returns>Whether the item exists in the collection.</returns>
		public bool ContainsKey(TKey key)
		{
			return (this[key] != null);
		}

		/// <summary>
		/// Gets the enumerator of the list to loop through the dictionary.
		/// </summary>
		/// <returns>The enumerator to loop through.</returns>
		public IEnumerator<TripletItem<TKey, TValue1, TValue2>> GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		/// <summary>
		/// Gets the enumerator of the list to loop through the dictionary.
		/// </summary>
		/// <returns>The enumerator to loop through.</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		/// <summary>
		/// Removes an item using the specified key.
		/// </summary>
		/// <param name="key">The key to use to remove an item.</param>
		/// <returns>Whether the remove occurred successfully.</returns>
		public bool Remove(TKey key)
		{
			TripletItem<TKey, TValue1, TValue2> item = this[key];
			if (item == null)
				return false;

			return this.Items.Remove(item);
		}

		#endregion
	}
}
