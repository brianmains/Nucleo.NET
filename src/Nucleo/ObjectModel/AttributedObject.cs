using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.ObjectModel
{
	/// <summary>
	/// Represents an attributed object that uses attributes to store property values.  This can help 
	/// </summary>
	public class AttributedObject
	{
		private Dictionary<string, object> _values = null;



		#region " Properties "

		/// <summary>
		/// Represents the inner collection of values.
		/// </summary>
		private Dictionary<string, object> Values
		{
			get
			{
				if (_values == null)
					_values = new Dictionary<string, object>();
				return _values;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a value to the inner collection of values.
		/// </summary>
		/// <param name="name">The name of the key/value pair to add.</param>
		/// <param name="value">The value of the key/value pair to add.</param>
		protected void AddOrUpdateValue(string name, object value)
		{
			if (this.Values.ContainsKey(name))
				this.Values[name] = value;
			else
				this.Values.Add(name, value);
		}

		protected void FromValuesList(IDictionary<string, object> values)
		{
			foreach (KeyValuePair<string, object> value in values)
				this.AddOrUpdateValue(value.Key, value.Value);
		}

		protected Nullable<T> GetNullableValue<T>(string name)
			where T: struct
		{
			return (Nullable<T>)GetValue(name);
		}

		/// <summary>
		/// Gets a value by the key.
		/// </summary>
		/// <param name="name">The key of the value to get.</param>
		/// <returns>The value tied to the specified key.</returns>
		protected object GetValue(string name)
		{
			if (this.Values.ContainsKey(name))
				return this.Values[name];
			else
				return null;
		}

		/// <summary>
		/// Gets a value in strongly-typed form by the key.
		/// </summary>
		/// <typeparam name="T">The type to convert the value for.</typeparam>
		/// <param name="name">The key of the value to get.</param>
		/// <returns>The value tied to the specified key.</returns>
		protected T GetValue<T>(string name)
		{
			object value = GetValue(name);

			if (value != null)
				return (T)Convert.ChangeType(value, typeof(T));
			else
				return default(T);
		}

		protected T GetValue<T>(string name, T defaultValue)
		{
			object value = GetValue(name);

			if (value != null)
				return (T)Convert.ChangeType(value, typeof(T));
			else
				return defaultValue;
		}

		/// <summary>
		/// Removes an entry by its key.
		/// </summary>
		/// <param name="name">The key of the item to remove.</param>
		protected void RemoveValue(string name)
		{
			if (this.Values.ContainsKey(name))
				this.Values.Remove(name);
		}

		/// <summary>
		/// Converts the object to the list of values.
		/// </summary>
		/// <returns>The dictionary collection of values.</returns>
		public IDictionary<string, object> ToValuesList()
		{
			return this.Values;
		}

		#endregion
	}
}
