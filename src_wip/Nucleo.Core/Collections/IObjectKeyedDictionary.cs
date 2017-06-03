using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Collections
{
	public interface IObjectKeyedDictionary : IEnumerable<KeyValuePair<string,object>>
	{
		#region " Properties "

		int Count { get; }
		object this[string key] { get; }

		#endregion



		#region " Methods "

		void Add(string key, object value);
		bool ContainsKey(string key);
		bool ContainsValue(object value);
		bool Remove(string key);

		#endregion
	}
}
