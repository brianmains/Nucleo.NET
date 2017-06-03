using System;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	/// <summary>
	/// A more simpler collection base class that doesn't have all of the extra functionality.
	/// </summary>
	/// <typeparam name="T">The generic type of object to use for the collection, to make it strongly-typed.</typeparam>
	public class SimpleCollection<T> : ISimpleCollection<T>
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
		/// Gets the internal list of items in the collection.
		/// </summary>
		protected List<T> Items
		{
			get
			{
				if (_items == null)
					_items = new List<T>();
				return _items;
			}
		}

		/// <summary>
		/// Gets an item in the list based on the index.  An exception may be thrown if the index is out of the range of items.
		/// </summary>
		/// <param name="index">The index of the item to return.</param>
		/// <returns>The item that was found by the index.</returns>
		public T this[int index]
		{
			get { return this.Items[index]; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the collection.
		/// </summary>
		public SimpleCollection() { }

		/// <summary>
		/// Creates the collection with an initial list of items.
		/// </summary>
		/// <param name="items">The items.</param>
		public SimpleCollection(IEnumerable<T> items)
		{
			foreach (T item in items)
				this.Add(item);
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an item to the collection.
		/// </summary>
		/// <param name="item">The item to add to the collection.</param>
		public virtual void Add(T item)
		{
			this.Items.Add(item);
		}

		/// <summary>
		/// Returns whether the item exists in the collection.
		/// </summary>
		/// <param name="item">The item to find.</param>
		/// <returns>Whether an item exists in the collection.</returns>
		public bool Contains(T item)
		{
			return this.Items.Contains(item);
		}

		/// <summary>
		/// Returns an enumerator so the list can be enumerated through.
		/// </summary>
		/// <returns>An instance of an enumerator.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator so the list can be enumerated through.
		/// </summary>
		/// <returns>An instance of an enumerator.</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		/// <summary>
		/// Removes an item from the list.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		public virtual void Remove(T item)
		{
			this.Items.Remove(item);
		}

		/// <summary>
		/// Removes an item from the list at the specified index.
		/// </summary>
		/// <param name="index">The index to remove an item at.</param>
		public void RemoveAt(int index)
		{
			this.Items.RemoveAt(index);
		}

		/// <summary>
		/// Returns a collection of items in an array form.
		/// </summary>
		/// <returns>An array of items.</returns>
		public T[] ToArray()
		{
			return this.Items.ToArray();
		}

		#endregion
	}
}
