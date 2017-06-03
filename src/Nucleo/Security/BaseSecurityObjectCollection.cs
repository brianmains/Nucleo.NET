using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Security
{
	public class BaseSecurityObjectCollection<T> : ReadonlyCollectionBase<T>
		where T:BaseSecurityObject
	{
		#region " Properties "

		public T this[string key]
		{
			get
			{
				foreach (T item in this)
				{
					if (string.Compare(item.Name, key, StringComparison.CurrentCultureIgnoreCase) == 0)
						return item;
				}

				return null;
			}
		}

		#endregion



		#region " Constructors "

		protected internal BaseSecurityObjectCollection() { }

		#endregion


		#region " Methods "

		new protected internal void Add(T item)
		{
			base.Add(item);
		}

		protected internal void AddRange(IEnumerable<T> items)
		{
			foreach (T item in items)
				base.Add(item);
		}

		protected override void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(string name)
		{
			return (this[name] != null);
		}

		internal T FindByGuid(Guid id)
		{
			foreach (T item in this)
			{
				if (item.ID == id)
					return item;
			}

			return null;
		}

		public T[] FindByNames(params string[] names)
		{
			CollectionBase<T> itemsList = new CollectionBase<T>();

			foreach (T item in this)
			{
				if (Array.IndexOf(names, item.Name) >= 0)
					itemsList.Add(item);
			}

			return itemsList.ToArray();
		}

		new protected internal void Insert(int index, T item)
		{
			base.Insert(index, item);
		}

		new protected internal bool Remove(T item)
		{
			return base.Remove(item);
		}

		#endregion
	}
}
