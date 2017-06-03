using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;


namespace Nucleo.Configuration
{
	/// <summary>
	/// Rpresents the core collection base class 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class ConfigurationCollectionBase<T> : ConfigurationElementCollection, IEnumerable<T>
		where T:ConfigurationElementBase
	{
		#region " Properties "

		/// <summary>
		/// Gets the type of collection that's built into the .NET framework.  By default, this supports using the &lt;add />, &lt;remove />, and &lt;clear /> element definitions to modify the collection.  Override this method to change type of collection.
		/// </summary>
		public override ConfigurationElementCollectionType CollectionType
		{
			get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
		}

		/// <summary>
		/// Gets a configuration element by is index value.
		/// </summary>
		/// <param name="index">The index of the item.</param>
		/// <returns>The item found at that index, or null.</returns>
		public T this[int index]
		{
			get { return (T)this.BaseGet(index); }
			set
			{
				if (this.BaseGet(index) != null)
					this.BaseRemoveAt(index);
				this.BaseAdd(index, value);
			}
		}

		/// <summary>
		/// Gets the item using the specified key, which maps to the <see cref="ConfigurationElementBase.UniqueKey">unique key</see> of the ConfigurationElementBase class.
		/// </summary>
		/// <param name="key">The key of the entry.</param>
		/// <returns>The instance of the entry, or null if not found.</returns>
		new public T this[string key]
		{
			get { return (T)this.BaseGet(key); }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a new configuration item to the list.  This comes in through the configuration file &lt;add /> statement.
		/// </summary>
		/// <param name="element">The element to add.</param>
		public void Add(T element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			this.BaseAdd(element);
		}

		/// <summary>
		/// Adds a range of elements to the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the list.</param>
		public void AddRange(IEnumerable<T> elements)
		{
			if (elements == null)
				throw new ArgumentNullException("elements");

			this.AddRange(elements, false);
		}

		/// <summary>
		/// Adds a range of items that may or may not be duplicates.  Ignoring duplicates allows someone to concatenate collections without having to worry about whether duplicate items exist.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <param name="ignoreDuplicateKeys">Whether to ignore duplicate keys, which is a violation.</param>
		public void AddRange(IEnumerable<T> elements, bool ignoreDuplicateKeys)
		{
			if (elements == null)
				throw new ArgumentNullException("elements");

			foreach (T element in elements)
			{
				if (!ignoreDuplicateKeys || !this.Contains(element.UniqueKey))
					this.Add(element);
			}
		}

		/// <summary>
		/// Clears the entries from the list.  This can be triggered from the configuration file's &lt;clear /> element.
		/// </summary>
		public void Clear()
		{
			this.BaseClear();
		}

		/// <summary>
		/// Checks whether an item exists in the collection, using the specified key.
		/// </summary>
		/// <param name="key">The key of the item to check for existence.</param>
		/// <returns>Whether the item exists.</returns>
		/// <remarks>Uses the BaseGet method to check for existence, and if not null, returns true.  May not be as efficent as getting the item directly and doing your own null check.</remarks>
		public bool Contains(string key)
		{
			return (this.BaseGet(key) != null);
		}

		/// <summary>
		/// Creates a new instance of the generic element.
		/// </summary>
		/// <returns></returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return Activator.CreateInstance<T>();
		}

		/// <summary>
		/// Gets the element's key using the configuration element.
		/// </summary>
		/// <param name="element">The element to get the key for.</param>
		/// <returns>The key value.</returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((T)element).UniqueKey;
		}

		/// <summary>
		/// Gets the enumerated list of elements.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public new IEnumerator<T> GetEnumerator()
		{
			List<T> items = new List<T>();
			IEnumerator enumeratorList = base.GetEnumerator();

			while (enumeratorList.MoveNext())
				items.Add((T)enumeratorList.Current);

			return items.GetEnumerator();
		}

		/// <summary>
		/// Removes an element from the base collection.
		/// </summary>
		/// <param name="element">The element to remove.</param>
		public void Remove(T element)
		{
			this.Remove(element.UniqueKey);
		}

		/// <summary>
		/// Removes an element using a key.
		/// </summary>
		/// <param name="key">The key to remove.</param>
		public void Remove(string key)
		{
			this.BaseRemove(key);
		}

		/// <summary>
		/// Removes an element using an index.
		/// </summary>
		/// <param name="index">The index.</param>
		public void RemoveAt(int index)
		{
			this.BaseRemoveAt(index);
		}

		#endregion
	}
}
