using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using Nucleo.EventArguments;


namespace Nucleo.Collections
{
	/// <summary>
	/// This class is a functional collection-base class that offers more than the standard base class.  It also includes a series of events and other methods that fire whenever any interaction takes place with it: adding, inserting, or deleting.
	/// </summary>
	/// <typeparam name="T">The type of item to store in the collection.</typeparam>
	[CLSCompliant(true)]
	public class CollectionBase<T> : IList<T>
	{
		private bool _ascending = true;
		private List<T> _list = null;



		#region " Events "

		/// <summary>
		/// Fires after an item is added to the list.
		/// </summary>
		public event DataEventHandler<T> ItemAdded;
		
		/// <summary>
		/// Fires whenever an item is about to be added to the list.
		/// </summary>
		public event CancellationEventHandler ItemAdding;

		/// <summary>
		/// Fires after the list was cleared.
		/// </summary>
		public event EventHandler ItemCleared;

		/// <summary>
		/// Fires whenever the list was being cleared, before it is being cleared.
		/// </summary>
		public event CancellationEventHandler ItemClearing;

		/// <summary>
		/// Fires after the item is being inserted into the list.
		/// </summary>
		public event InsertDataEventHandler<T> ItemInserted;

		/// <summary>
		/// Fires whenever the item is about to be inserted into the list.
		/// </summary>
		public event CancellationEventHandler ItemInserting;

		/// <summary>
		/// Fires after the item is being removed from the list.
		/// </summary>
		public event DataEventHandler<T> ItemRemoved;

		/// <summary>
		/// Fires whenever the item is about to be removed from the list.
		/// </summary>
		public event CancellationEventHandler ItemRemoving;

		#endregion



		#region " Properties "

		public int Count
		{
			get { return this.List.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		protected List<T> List
		{
			get
			{
				if (_list == null)
					_list = new List<T>();
				return _list;
			}
		}

		public T this[int index]
		{
			get { return this.List[index]; }
			set { this.List[index] = value; }
		}

		#endregion



		#region " Constructors "

		public CollectionBase()
		{
			_list = new List<T>();
		}

		public CollectionBase(T item)
		{
			_list = new List<T>(new T[] { item });
		}

		public CollectionBase(IEnumerable<T> list)
		{
			_list = new List<T>(list);
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an item to the list.
		/// </summary>
		/// <param name="item">The item to add.</param>
		/// <remarks>Fires the <see cref="ItemAdding" /> event; if the action is not cancelled, the <see cref="ItemAdded" /> event is fired after the item is added to the collection.</remarks>
		public virtual void Add(T item)
		{	
			var args = new CancellationEventArgs(false);
			this.OnItemAdding(args);

			if (!args.Cancel)
			{
				this.List.Add(item);
				this.OnItemAdded(new DataEventArgs<T>(item));
			}
		}

		public void AddRange(T[] items)
		{
			foreach (T item in items)
				this.Add(item);
		}

		public void AddRange(IEnumerable items)
		{
			IEnumerator list = items.GetEnumerator();
			while (list.MoveNext())
			{
				if (list.Current != null && list.Current is T)
					this.Add((T)list.Current);
			}
		}

		public void AddRange(IEnumerable<T> items)
		{
			IEnumerator<T> list = items.GetEnumerator();
			while (list.MoveNext())
			{
				if (list.Current != null)
					this.Add(list.Current);
			}
		}

		/// <summary>
		/// Clears all of the items out of the list.
		/// </summary>
		/// <remarks>The method fires the <see cref="ItemClearing"/> event.  If the action isn't cancelled, the <see cref="ItemCleared" /> event is fired after the collection is cleared.</remarks>
		public virtual void Clear()
		{
			var args = new CancellationEventArgs(false);
			this.OnItemClearing(args);

			if (!args.Cancel)
			{
				this.List.Clear();
				this.OnItemCleared(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Determines whether an item in the list exists.
		/// </summary>
		/// <param name="item">The item to check for.</param>
		/// <returns>Whether the item exists in the list.</returns>
		public bool Contains(T item)
		{
			return this.List.Contains(item);
		}

		/// <summary>
		/// Copies this collection to another array.
		/// </summary>
		/// <param name="array">The array to copy to.</param>
		/// <param name="arrayIndex">The index of the item for which copying begins.</param>
		public virtual void CopyTo(T[] array, int arrayIndex)
		{
			this.List.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this.List.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.List.GetEnumerator();
		}

		/// <summary>
		/// Gets a range of items out of the collection using a starting index and total count, and returns it as an array.
		/// </summary>
		/// <param name="start">The index of the item to start at.</param>
		/// <param name="count">The total count of items to collect.</param>
		/// <returns>An array of items to return.</returns>
		/// <remarks>If start is 1 and count is 20, the method loops from index 1 to index 21.  If the total count is greater than the collection count, the maximum count value is used.</remarks>
		/// <exception cref="ArgumentOutOfRangeException">Thrown if the starting index is outside the array of index values.</exception>
		public T[] GetRange(int start, int count)
		{
			if (start < 0 || start > this.Count)
				throw new ArgumentOutOfRangeException("start");

			List<T> itemsList = new List<T>();
			for (int i = start; i <= (start + (count - 1)); i++)
			{
				if (i < this.Count)
					itemsList.Add(this[i]);
				else
					return itemsList.ToArray();
			}

			return itemsList.ToArray();
		}

		/// <summary>
		/// Gets the index of the item in the collection.
		/// </summary>
		/// <param name="item">The item to look for.</param>
		/// <returns>The index of the item in the list.</returns>
		public int IndexOf(T item)
		{
			return this.List.IndexOf(item);
		}

		/// <summary>
		/// Inserts an item to the list.
		/// </summary>
		/// <param name="index">The index of the item to insert.</param>
		/// <param name="item">The item to insert.</param>
		/// <remarks>Fires the <see cref="ItemInserting" /> event; if the action is not cancelled, the <see cref="ItemInserted" /> event is fired after the item is inserted to the collection.</remarks>
		public virtual void Insert(int index, T item)
		{
			var args = new CancellationEventArgs(false);
			this.OnItemInserting(args);

			if (!args.Cancel)
			{
				this.List.Insert(index, item);
				this.OnItemInserted(index, new DataEventArgs<T>(item));
			}
		}

		public void InsertRange(int index, T[] items)
		{
			for (int i = items.Length - 1; i >= 0; i--)
				this.List.Insert(index, items[i]);
		}

		public void InsertRange(int index, IEnumerable items)
		{
			IEnumerator list = items.GetEnumerator();
			List<T> newList = new List<T>();

			while (list.MoveNext())
			{
				if (list.Current != null && list.Current is T)
					newList.Add((T)list.Current);
			}

			this.InsertRange(index, newList.ToArray());
		}

		public void InsertRange(int index, IEnumerable<T> items)
		{
			IEnumerator<T> list = items.GetEnumerator();
			List<T> newList = new List<T>();

			while (list.MoveNext())
			{
				if (list.Current != null)
					newList.Add(list.Current);
			}

			this.InsertRange(index, newList.ToArray());
		}

		protected virtual void OnItemAdded(DataEventArgs<T> e)
		{
			if (ItemAdded != null)
				ItemAdded(this, e);
		}

		protected virtual void OnItemAdding(CancellationEventArgs e)
		{
			if (ItemAdding != null)
				ItemAdding(this, e);
		}

		protected virtual void OnItemCleared(EventArgs e)
		{
			if (ItemCleared != null)
				ItemCleared(this, e);
		}

		protected virtual void OnItemClearing(CancellationEventArgs e)
		{
			if (ItemClearing != null)
				ItemClearing(this, e);
		}

		protected virtual void OnItemInserted(int index, DataEventArgs<T> e)
		{
			if (ItemInserted != null)
				ItemInserted(this, index, e);
		}

		protected virtual void OnItemInserting(CancellationEventArgs e)
		{
			if (ItemInserting != null)
				ItemInserting(this, e);
		}

		protected virtual void OnItemRemoved(DataEventArgs<T> e)
		{
			if (ItemRemoved != null)
				ItemRemoved(this, e);
		}

		protected virtual void OnItemRemoving(CancellationEventArgs e)
		{
			if (ItemRemoving != null)
				ItemRemoving(this, e);
		}

		public virtual bool Remove(T item)
		{
			bool removed = false;
			var args = new CancellationEventArgs(false);
			this.OnItemRemoving(args);

			if (!args.Cancel)
			{
				removed = this.List.Remove(item);
				this.OnItemRemoved(new DataEventArgs<T>(item));
			}

			return removed;
		}

		public void RemoveAt(int index)
		{
			T item = this.List[index];
			this.Remove(item);
		}

		/// <summary>
		/// Converts the list to an array of items.
		/// </summary>
		/// <returns>The list in an array form.</returns>
		public T[] ToArray()
		{
			return this.List.ToArray();
		}

		#endregion
	}


	public delegate void InsertDataEventHandler<T>(object sender, int index, DataEventArgs<T> data);
}
