using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Settings
{
	public class ListSettingsBuilder<TItem>
	{
		private List<TItem> _items = null;



		#region " Properties "

		private List<TItem> Items
		{
			get
			{
				if (_items == null)
					_items = new List<TItem>();

				return _items;
			}
		}

		#endregion



		#region " Methods "

		public TItem Add()
		{
			TItem item = Activator.CreateInstance<TItem>();
			this.Items.Add(item);

			return item;
		}

		/// <summary>
		/// Adds a new item to the list.
		/// </summary>
		/// <param name="item">The item to add.</param>
		/// <returns>The builder.</returns>
		/// <exception cref="ArgumentNullException">Thrown when a null item is added to the list.</exception>
		public ListSettingsBuilder<TItem> Add(TItem item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			this.Items.Add(item);
			return this;
		}

		/// <summary>
		/// Getting all of the items within the list.
		/// </summary>
		/// <returns>The complete list of items.</returns>
		public IEnumerable<TItem> GetAll()
		{
			return this.Items;
		}

		/// <summary>
		/// Inserts a new item to the list.
		/// </summary>
		/// <param name="index">The index to insert in.</param>
		/// <param name="item">The item to insert.</param>
		/// <returns>The builder.</returns>
		/// <exception cref="ArgumentNullException">Thrown when a null item is inserted into the list.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of a valid range.</exception>
		public ListSettingsBuilder<TItem> Insert(int index, TItem item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
			if (index < 0)
				throw new ArgumentOutOfRangeException("index");

			this.Items.Insert(index, item);
			return this;
		}

		/// <summary>
		/// Removes an item from the list.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		/// <returns>The builder.</returns>
		/// <exception cref="ArgumentNullException">Thrown when a null item is attempted to be removed from the list.</exception>
		public ListSettingsBuilder<TItem> Remove(TItem item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			this.Items.Remove(item);
			return this;
		}

		#endregion
	}
}
