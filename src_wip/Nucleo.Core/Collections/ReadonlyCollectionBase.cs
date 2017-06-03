using System;
using System.ComponentModel;
using System.Collections.Generic;
using Nucleo.Collections;
using Nucleo.EventArguments;


namespace Nucleo.Collections
{
	/// <summary>
	/// A collection that is readonly; this means that all creating of items happens internally.  The collection is passed in through the constructor.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ReadonlyCollectionBase<T> : IEnumerable<T>
	{
		private CollectionBase<T> _list = null;



		#region " Properties "

		public int Count
		{
			get { return this.List.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		protected CollectionBase<T> List
		{
			get
			{
				if (_list == null)
					_list = new CollectionBase<T>();
				return _list;
			}
		}

		public T this[int index]
		{
			get { return this.List[index]; }
			set { this.List[index] = value; }
		}

		#endregion



		#region " Methods "

		protected virtual void Add(T item)
		{
			this.Insert(this.Count, item);
		}

		protected void AddRange(IEnumerable<T> items)
		{
			this.List.AddRange(items);
		}

		protected virtual void Clear()
		{
			this.List.Clear();
		}

		public bool Contains(T item)
		{
			return this.List.Contains(item);
		}

		protected virtual void CopyTo(T[] array, int arrayIndex)
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

		public int IndexOf(T item)
		{
			return this.List.IndexOf(item);
		}

		protected virtual void Insert(int index, T item)
		{
			this.List.Insert(index, item);
		}

		protected virtual bool Remove(T item)
		{
			return this.List.Remove(item);
		}

		protected void RemoveAt(int index)
		{
			T item = this.List[index];
			this.Remove(item);
		}

		public T[] ToArray()
		{
			return this.List.ToArray();
		}

		#endregion
	}
}
