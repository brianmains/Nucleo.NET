using System;


namespace System.Collections.Generic
{
	public static class IDictionaryExtensions
	{
		#region " Methods "

		/// <summary>
		/// Converts a dictionary to an HTML attributed string.
		/// </summary>
		/// <typeparam name="TKey">The key type.</typeparam>
		/// <typeparam name="TValue">The value type.</typeparam>
		/// <param name="dictionary">The extended. dictionary.</param>
		/// <returns>The attributed string as in: border="0" width="0" height="0".</returns>
		public static string ToHtmlAttributeString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
		{
			return ToHtmlAttributeString(dictionary, "=", " ");
		}

		public static string ToHtmlAttributeString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, string pairSeparator, string separator)
		{
			return ToHtmlAttributeString(dictionary, pairSeparator, separator, true);
		}

		public static string ToHtmlAttributeString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, string pairSeparator, string separator, bool includeQuotes)
		{
			if (dictionary.Count == 0)
				return null;

			string output = "";
			string quote = includeQuotes ? "\"" : "";

			foreach (TKey key in dictionary.Keys)
			{
				if (output != "")
					output += separator;

				object value = dictionary[key];
				output += key + pairSeparator + quote + ((value != null) ? value.ToString() : "") + quote;
			}

			return output;
		}

		#endregion
	}
}
