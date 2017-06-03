using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Collections
{
	/// <summary>
	/// Represents a collection that works with fluency.
	/// </summary>
	/// <typeparam name="TItem"></typeparam>
	/// <typeparam name="TCollection"></typeparam>
	/// <example>
	/// //Collection:
	/// public class TestCollection&lt;TestClass, TestCollection>
	/// {
	///		//Any custom methods; to support chaining, return TestCollection like this:
	///		public TestCollection First()
	///		{
	///			return null;
	///		}
	/// }
	/// 
	/// //Using the class
	/// var collection = new TestCollection()
	///	   .Add(new TestClass())
	///    .Add((t) => { t.Name = "X"; }) //instantiates behind the scenes, assumes an empty constructor
	///    .Add(() => new TestClass { Name = "Y" });
	/// </example>
	public class FluentCollection<TItem, TCollection> : IEnumerable<TItem>
		where TItem: class
		where TCollection: FluentCollection<TItem, TCollection>
	{
		private List<TItem> _items = null;



		#region " Properties "

		/// <summary>
		/// Gets the count of items stored in the collection.
		/// </summary>
		public int Count
		{
			get
			{
				if (_items == null)
					return 0;
				return _items.Count;
			}
		}

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



		#region " Constructors "
		
		/// <summary>
		/// Creates an empty collection.
		/// </summary>
		public FluentCollection() { }

		/// <summary>
		/// Creates a pre-populated collection.
		/// </summary>
		/// <param name="items">The list of items.</param>
		public FluentCollection(IEnumerable<TItem> items)
		{
			foreach (var item in items)
				this.Add(item);
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an item to the collection.
		/// </summary>
		/// <param name="item">The item to add.</param>
		/// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
		/// <returns>The collection.</returns>
		public TCollection Add(TItem item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			this.Items.Add(item);

			return this as TCollection;
		}

		/// <summary>
		/// Adds an item to the collection.  Creates the item behind the scenes by constructing it (assuming it has an empty constructor).
		/// </summary>
		/// <param name="item">The item to set values for.</param>
		/// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
		/// <returns>The collection.</returns>
		public TCollection Add(Action<TItem> item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			var addedItem = this.CreateItem();
			item(addedItem);

			this.Items.Add(addedItem);

			return this as TCollection;
		}

		/// <summary>
		/// Adds an item to the collection, returning the item from the lambda.
		/// </summary>
		/// <param name="item">The lambda to create the item.</param>
		/// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
		/// <returns>The collection.</returns>
		public TCollection Add(Func<TItem> item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			var addedItem = item();
			this.Items.Add(addedItem);

			return this as TCollection;
		}

		protected virtual TItem CreateItem()
		{
			return Activator.CreateInstance<TItem>();
		}

		/// <summary>
		/// Gets an item by its index.
		/// </summary>
		/// <param name="index">The index of the item.</param>
		/// <returns>The item at the specified index.</returns>
		public TItem Get(int index)
		{
			return this.Items[index];
		}

		/// <summary>
		/// Gets all of the items in the collection.
		/// </summary>
		/// <returns>The list of items.</returns>
		public IEnumerable<TItem> GetAll()
		{
			return this.Items;
		}

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns>The list of items.</returns>
		public IEnumerator<TItem> GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		/// <summary>
		/// Removes the item from the collection.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		/// <returns>The collection.</returns>
		public TCollection Remove(TItem item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			this.Items.Remove(item);

			return this as TCollection;
		}

		/// <summary>
		/// Removes the item from the collection, using the specified lambda.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		/// <returns>The collection.</returns>
		public TCollection Remove(Func<TItem> item)
		{
			if (item == null)
				throw new ArgumentNullException("item");

			var removeItem = item();
			this.Items.Remove(removeItem);

			return this as TCollection;
		}

		#endregion
	}
}
