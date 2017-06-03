using System;
using System.ComponentModel;
using System.Collections.Generic;

using Nucleo.Collections;
using Nucleo.EventArguments;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.UI
{
	public abstract class UIElementCollection<T> : IEnumerable<T>, IElementCollection
	where T : UIElement
	{
		private List<T> _items = null;



		#region " Events "

		public event DataEventHandler<T> ItemAdded;
		public event CancelEventHandler ItemAdding;
		public event DataEventHandler<T> ItemInserted;
		public event CancelEventHandler ItemInserting;
		public event DataEventHandler<T> ItemRemoved;
		public event CancelEventHandler ItemRemoving;

		#endregion



		#region " Properties "

		/// <summary>
		/// The total number of items in the collection.
		/// </summary>
		public int Count
		{
			get { return this.Items.Count; }
		}

		/// <summary>
		/// The underlying list that is storing the items in the collection.
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
		/// References an item in the collection at a specified index.
		/// </summary>
		/// <param name="i">The index of the item.</param>
		/// <returns>A reference to the item found in the collection.</returns>
		public T this[int i]
		{
			get { return this.Items[i]; }
		}

		/// <summary>
		/// Gets the item that is in the collection by the name that was provided.
		/// </summary>
		/// <param name="name">The name of the item in the collection to retrieve.</param>
		/// <returns>An instance of the item that contains the target name.</returns>
		/// <remarks>This method uses the <seealso cref="IndexOf"/> method to get the index of the item in the collection.</remarks>
		public T this[string name]
		{
			get
			{
				int i = this.IndexOf(name);
				if (i >= 0)
					return this.Items[i];
				else
					return null;
			}
		}

		/// <summary>
		/// Gets an item in the collection based on the path.
		/// </summary>
		/// <param name="path">The path to navigate through.</param>
		/// <returns>The item to get through the value path.</returns>
		public T this[ValuePath path]
		{
			get
			{
				UIElement parent = null;
				UIElement child = null;
				this.GetItem(path, ref parent, ref child);

				return (T)child;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// This method adds an already created item to the collection of items.
		/// </summary>
		/// <param name="item">The item to add to the collection.</param>
		/// <remarks>This method fires the <seealso cref="ItemAdding"/> and the <seealso cref="ItemAdded"/> events.</remarks>
		public virtual void Add(T item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			CancelEventArgs args = new CancelEventArgs(false);
			this.OnItemAdding(args);

			if (!args.Cancel)
			{
				this.Items.Add(item);
				this.OnItemAdded(new DataEventArgs<T>(item));
				ApplicationEventsManager.FireEventNotification(ApplicationEventKeys.AddedEventName, this, item);
			}
		}

		/// <summary>
		/// Determines whether a named item exists in the collection.
		/// </summary>
		/// <param name="name">The name of the item in the collection.</param>
		/// <returns>A flag for whether the item exists in the collection.</returns>
		public bool Contains(string name)
		{
			return (this.IndexOf(name) >= 0);
		}

		/// <summary>
		/// Determines whether a item exists in the collection.
		/// </summary>
		/// <param name="item">The item in the collection.</param>
		/// <returns>A flag for whether the item exists in the collection.</returns>
		public bool Contains(T item)
		{
			return this.Items.Contains(item);
		}

		/// <summary>
		/// Determines whether an item exists in the collection, using a value path to navigate the collection.
		/// </summary>
		/// <param name="path">The path to navigate through.</param>
		/// <returns>Whether the item is in the collection.</returns>
		public bool Contains(ValuePath path)
		{
			if (path == null)
				throw new ArgumentNullException("path");

			UIElement parent = null;
			UIElement child = null;

			this.GetItem(path, ref parent, ref child);
			return (child != null);
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		/// <summary>
		/// Gets an item in the list using the value path.
		/// </summary>
		/// <param name="path">The value path to navigate through.</param>
		/// <param name="parent">The object that's the parent to get information about.</param>
		/// <param name="child">The child to get get infomration about.</param>
		private void GetItem(ValuePath path, ref UIElement parent, ref UIElement child)
		{
			for (int i = 0; i < path.Values.Count; i++)
			{
				if (i != 0)
					parent = child;

				if (parent != null)
				{
					IParentElement parentItem = parent as IParentElement;
					if (parentItem == null)
						return;

					child = parentItem.Items[path.Values[i]];
				}
				else
					child = this[path.Values[i]];

				//current = (parent != null) ? parent.Items[path.Values[i]] : this[path.Values[i]];
			}
		}

		/// <summary>
		/// The index of the item corresponding to the name.
		/// </summary>
		/// <param name="name">The name of the item to find the index of.</param>
		/// <returns>The index of the item or -1 for an item not found.</returns>
		public int IndexOf(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			for (int i = 0; i < this.Items.Count; i++)
			{
				if (string.Compare(this.Items[i].Name, name, StringComparison.CurrentCultureIgnoreCase) == 0)
					return i;
			}

			return -1;
		}

		/// <summary>
		/// The index of the item.
		/// </summary>
		/// <param name="item">The item to find the index of.</param>
		/// <returns>The index of the item or -1 for an item not found.</returns>
		public int IndexOf(T item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			return this.IndexOf(item.Name);
		}

		/// <summary>
		/// Inserts an item at the specified index into the collection.
		/// </summary>
		/// <param name="index">The index of the item to insert.</param>
		/// <param name="item">The item to insert into.</param>
		public virtual void Insert(int index, T item)
		{
			CancelEventArgs args = new CancelEventArgs(false);
			this.OnItemInserting(args);

			if (!args.Cancel)
			{
				this.Items.Insert(index, item);
				this.OnItemInserted(new DataEventArgs<T>(item));
				ApplicationEventsManager.FireEventNotification(ApplicationEventKeys.InsertedEventName, this, item);
			}
		}

		protected virtual void OnItemAdded(DataEventArgs<T> e)
		{
			if (ItemAdded != null)
				ItemAdded(this, e);
		}

		protected virtual void OnItemAdding(CancelEventArgs e)
		{
			if (ItemAdding != null)
				ItemAdding(this, e);
		}

		protected virtual void OnItemInserted(DataEventArgs<T> data)
		{
			if (ItemInserted != null)
				ItemInserted(this, data);
		}

		protected virtual void OnItemInserting(CancelEventArgs e)
		{
			if (ItemInserting != null)
				ItemInserting(this, e);
		}

		protected virtual void OnItemRemoved(DataEventArgs<T> e)
		{
			if (ItemRemoved != null)
				ItemRemoved(this, e);
		}

		protected virtual void OnItemRemoving(CancelEventArgs e)
		{
			if (ItemRemoving != null)
				ItemRemoving(this, e);
		}

		/// <summary>
		/// This method removes an item from the collection.
		/// </summary>
		/// <param name="item">The item to remove from the collection.</param>
		/// <returns>A flag for whether the item was removed successfully.</returns>
		/// <remarks>This method fires the <seealso cref="ItemRemoving"/> and the <seealso cref="ItemRemoved"/> events.</remarks>
		public virtual bool Remove(T item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			CancelEventArgs args = new CancelEventArgs(false);
			this.OnItemRemoving(args);

			if (!args.Cancel)
			{
				bool value = this.Items.Remove(item);
				this.OnItemRemoved(new DataEventArgs<T>(item));
				ApplicationEventsManager.FireEventNotification(ApplicationEventKeys.RemovedEventName, this, item);
				return value;
			}

			return false;
		}

		/// <summary>
		/// This method removes items based on the name.
		/// </summary>
		/// <param name="name">The name of the item to remove.</param>
		/// <returns>A boolean value stating whether the item was removed from the collection.</returns>
		/// <remarks>This method uses the item version of the Remove overload to remove the item.</remarks>
		/// <exception cref="ArgumentNullException">Thrown whenever the name provides is null.</exception>
		/// <exception cref="NullReferenceException">Thrown when the item retrieved through the name is null.</exception>
		public bool Remove(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			T item = this[name];
			if (item == null) return false;

			return this.Remove(item);
		}

		/// <summary>
		/// Removes the item in the collection, using the specified path.
		/// </summary>
		/// <param name="path">The path to remove an item at.</param>
		/// <returns>Whether the item was successfully removed.</returns>
		/// <remarks>If more than one item, than the last item is removed from its parent.  Otherwise, a root level item is removed if at least one value is provided.</remarks>
		/// <exception cref="ArgumentNullException">Thrown when the path is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the value path doesn't have any path items in it (length of zero).</exception>
		public bool Remove(ValuePath path)
		{
			if (path == null)
				throw new ArgumentNullException("path");
			if (path.Values.Count == 0)
				throw new ArgumentException("The value path does not have any items in it", "path");

			UIElement parent = null;
			UIElement child = null;
			this.GetItem(path, ref parent, ref child);
			bool fireEvent = false;

			if (parent != null && child != null)
			{
				if (((IParentElement)parent).Items.Remove(child))
					fireEvent = true;
			}
			else if (child != null)
			{
				if (this.Items.Remove((T)child))
					fireEvent = true;
			}

			if (fireEvent)
				ApplicationEventsManager.FireEventNotification(ApplicationEventKeys.RemovedEventName, this, child);
			return fireEvent;
		}

		#endregion



		#region " IElementCollection Members "

		int IElementCollection.Count
		{
			get { return this.Count; }
		}

		UIElement IElementCollection.this[int i]
		{
			get { return this[i]; }
		}

		UIElement IElementCollection.this[string name]
		{
			get { return this[name]; }
		}

		UIElement IElementCollection.this[ValuePath path]
		{
			get { return this[path]; }
		}

		void IElementCollection.Add(UIElement element)
		{
			this.Add((T)element);
		}

		bool IElementCollection.Contains(UIElement element)
		{
			return this.Contains((T)element);
		}

		bool IElementCollection.Contains(ValuePath path)
		{
			return this.Contains(path);
		}

		void IElementCollection.Insert(int index, UIElement element)
		{
			this.Insert(index, (T)element);
		}

		bool IElementCollection.Remove(UIElement element)
		{
			return this.Remove((T)element);
		}

		bool IElementCollection.Remove(ValuePath path)
		{
			return this.Remove(path);
		}

		#endregion
	}
}
