using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Collections
{
	/// <summary>
	/// Represents the chainable collection.
	/// </summary>
	/// <typeparam name="T">The type of object in the collection.</typeparam>
	public class ChainableCollection<T> : IEnumerable<T>
	{
		private List<T> _items = null;



		#region " Properties "

		/// <summary>
		/// Gets the total number of items in the list.
		/// </summary>
		public int Count
		{
			get { return this.Items.Count; }
		}

		/// <summary>
		/// Gets the list of items internally in the collection.
		/// </summary>
		private List<T> Items
		{
			get
			{
				if (_items == null)
					_items = new List<T>();
				return _items;
			}
		}

		/// <summary>
		/// Gets an instance of an item via the collection.
		/// </summary>
		/// <param name="index">The index of the item to retrieve out of the list.</param>
		/// <returns>The item in the list.</returns>
		public T this[int index]
		{
			get
			{
				if (index < 0 || this.Items.Count <= index)
					return default(T);

				return this.Items[index];
			}
		}

		#endregion



		#region " Constructors "

		private ChainableCollection() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an item to the collection, and returns the collection in a chainable format.
		/// </summary>
		/// <param name="item">The item to add.</param>
		/// <returns>The collection of items with the item added.</returns>
		public ChainableCollection<T> Add(T item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			this.Items.Add(item);
			return this;
		}

		/// <summary>
		/// Clears all of the items out of the list.
		/// </summary>
		/// <returns>The collection of items with no items in the list.</returns>
		public ChainableCollection<T> Clear()
		{
			this.Items.Clear();
			return this;
		}

		/// <summary>
		/// Returns whether the item exists within the list.
		/// </summary>
		/// <param name="item">The item to check to see whether it is in the list.</param>
		/// <returns>Whether the item is in the list.</returns>
		public bool Contains(T item)
		{
			return this.Items.Contains(item);
		}

		/// <summary>
		/// Returns whether the item exists within the list.
		/// </summary>
		/// <param name="item">The item to check to see whether it is in the list.</param>
		/// <param name="result">Whether the item is in the list.</param>
		/// <returns>The list of items.</returns>
		public ChainableCollection<T> Contains(T item, out bool result)
		{
			result = this.Items.Contains(item);
			return this;
		}
		
		/// <summary>
		/// Copies items in the list to an array.
		/// </summary>
		/// <param name="array">The array to copy to.</param>
		/// <returns>The list of items.</returns>
		public ChainableCollection<T> CopyTo(T[] array)
		{
			this.Items.CopyTo(array);
			return this;
		}

		/// <summary>
		/// Copies items in the list to an array.
		/// </summary>
		/// <param name="array">The array to copy to.</param>
		/// <param name="arrayIndex">The index of the array to copy items to.</param>
		/// <returns>The list of items.</returns>
		public ChainableCollection<T> CopyTo(T[] array, int arrayIndex)
		{
			this.Items.CopyTo(array, arrayIndex);
			return this;
		}

		/// <summary>
		/// Creates a new instance of the collection.
		/// </summary>
		/// <returns>The new collection instance.</returns>
		public static ChainableCollection<T> Create()
		{
			return new ChainableCollection<T>();
		}

		/// <summary>
		/// Creates a new instance of the collection, with one item added to the list.
		/// </summary>
		/// <returns>The new collection instance.</returns>
		public static ChainableCollection<T> Create(T item)
		{
			ChainableCollection<T> list = new ChainableCollection<T>();
			list.Items.Add(item);

			return list;
		}

		/// <summary>
		/// Creates a new instance of the collection, with many items added to the list.
		/// </summary>
		/// <returns>The new collection instance.</returns>
		public static ChainableCollection<T> Create(IEnumerable<T> items)
		{
			ChainableCollection<T> list = new ChainableCollection<T>();
			list.Items.AddRange(items);

			return list;
		}

		/// <summary>
		/// Iterates through the list.
		/// </summary>
		/// <returns>The enumerator for the list.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		/// <summary>
		/// Iterates through the list.
		/// </summary>
		/// <returns>The enumerator for the list.</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Removes an item to the collection.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		/// <returns>The collection of items with the item removed.</returns>
		public ChainableCollection<T> Remove(T item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			this.Items.Remove(item);
			return this;
		}

		/// <summary>
		/// Removes an item to the collection.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		/// <param name="wasRemoved">Whether the item was removed from the collection.</param>
		/// <returns>The collection of items with the item removed.</returns>
		public ChainableCollection<T> Remove(T item, out bool wasRemoved)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			wasRemoved = this.Items.Remove(item);
			return this;
		}

		#endregion
	}
}
