using System;
using System.Collections.Generic;
using System.Linq;
using Nucleo.Extensions;


namespace Nucleo.Web.ControlStorage
{
	/// <summary>
	/// Represents a dictionary of property values for a control.
	/// </summary>
	public class ControlPropertyValuesDictionary
	{
		private Dictionary<string, ControlPropertyValue> _values = new Dictionary<string,ControlPropertyValue>();



		#region " Properties "

		public IEnumerable<string> PropertyNames
		{
			get { return _values.Keys; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds or updates a value to the dictionary.
		/// </summary>
		/// <param name="key">The key to add or update.</param>
		/// <param name="value">The value to add or update.</param>
		public void AddOrUpdate(string key, object value)
		{
			if (_values.ContainsKey(key))
				_values[key] = new ControlPropertyValue { Key = key, Value = value };
			else
				_values.Add(key, new ControlPropertyValue { Key = key, Value = value });
		}

		/// <summary>
		/// Adds or updates a value to the dictionary.
		/// </summary>
		/// <param name="key">The key to add or update.</param>
		/// <param name="value">The value to add or update.</param>
		/// <param name="storage">The storage options for the property.</param>
		public void AddOrUpdate(string key, object value, ControlPropertyOptions options)
		{
			if (_values.ContainsKey(key))
				_values[key] = new ControlPropertyValue { Key = key, Value = value, Options = options };
			else
				_values.Add(key, new ControlPropertyValue { Key = key, Value = value, Options = options });
		}

		/// <summary>
		/// Gets a value out of the dictionary.
		/// </summary>
		/// <param name="key">The key to get a value for.</param>
		/// <returns>The property value.</returns>
		public ControlPropertyValue Get(string key)
		{
			return (_values.ContainsKey(key)) ? _values[key] : null;
		}

		#endregion
	}
}
