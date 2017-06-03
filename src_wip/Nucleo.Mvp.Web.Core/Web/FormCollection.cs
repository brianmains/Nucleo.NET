using System;
using System.Collections.Generic;
using System.Collections.Specialized;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a form collection of values from the form.
	/// </summary>
	[Serializable]
	public class FormCollection : Dictionary<string, string>
	{
		#region " Constructors "

		/// <summary>
		/// Creates the dictionary.
		/// </summary>
		public FormCollection() { }

		/// <summary>
		/// Creates the dictionary with an initial dictionary list.
		/// </summary>
		/// <param name="items">The dictionary list.</param>
		public FormCollection(IDictionary<string, string> items)
			: base(items) { }

		/// <summary>
		/// Creates the dictionary with an initial name/value collection list.
		/// </summary>
		/// <param name="values">The name/value collection list.</param>
		public FormCollection(NameValueCollection values)
		{
			if (values == null)
				throw new ArgumentNullException("values");

			foreach (string key in values.Keys)
				this.Add(key, values[key]);
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds or updates a value in the dictionary.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public void AddOrUpdate(string key, string value)
		{
			if (this.ContainsKey(key))
				this[key] = value;
			else
				this.Add(key, value);
		}

		/// <summary>
		/// Adds a range of items to the underlying dictionary.
		/// </summary>
		/// <param name="items">The collection of items to add in bulk.</param>
		public void AddRange(IDictionary<string, string> items)
		{
			if (items == null)
				throw new ArgumentNullException("items");

			foreach (string key in items.Keys)
				this.AddOrUpdate(key, items[key]);
		}

		/// <summary>
		/// Gets the value from the dictionary, or returns a default value if none found.
		/// </summary>
		/// <param name="key">The key to find by.</param>
		/// <param name="defaultValue">The default value to return if not in the dictionary.</param>
		/// <returns>The value from the dictionary, or the default.</returns>
		public object GetOrDefault(string key, string defaultValue)
		{
			if (this.ContainsKey(key))
				return this[key];
			else
				return defaultValue;
		}

		#endregion
	}
}
