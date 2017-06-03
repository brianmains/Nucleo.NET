using System;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	/// <summary>
	/// A keyed dictionary of string/object objects.
	/// </summary>
	public class ObjectKeyedDictionary : Dictionary<string, object>, IObjectKeyedDictionary
	{
		#region " Methods "

		public void CopyFrom(ObjectKeyedDictionary dictionary)
		{
			foreach (KeyValuePair<string, object> item in dictionary)
				this.Add(item.Key, item.Value);
		}

		public void CopyFrom<T>(Dictionary<string, T> dictionary)
		{
			foreach (KeyValuePair<string, T> item in dictionary)
				this.Add(item.Key, item.Value);
		}

		public void Remove(string key)
		{
			base.Remove(key);
		}

		#endregion



		
	}
}
