using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Collections
{
	public interface ISimpleCollection<T> : IEnumerable<T>
	{
		#region " Properties "

		int Count { get; }

		T this[int index] { get; }

		#endregion



		#region " Methods "

		void Add(T item);
		bool Contains(T item);
		void Remove(T item);
		void RemoveAt(int index);

		#endregion
	}
}
