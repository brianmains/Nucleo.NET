using System;
using System.Collections;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	public static class DictionaryExtensions
	{
		#region " Methods "

		public static object GetOrDefault(this IDictionary dictionary, object key)
		{
			if (dictionary.Contains(key))
				return dictionary[key];
			else
				return null;
		}

		#endregion
	}
}
