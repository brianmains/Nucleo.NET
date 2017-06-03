using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Models
{
	/// <summary>
	/// Represents the core functionality for a model object in MVC or other.
	/// </summary>
	public abstract class BaseModel
	{
		private IDictionary<string, ModelValueEntry> _values = null;



		#region " Properties "

		/// <summary>
		/// Gets the internal collection of values.
		/// </summary>
		private IDictionary<string, ModelValueEntry> Values
		{
			get
			{
				if (_values == null)
					_values = this.CreateValues();

				return _values;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds or updates a value to the underlying dictionary.
		/// </summary>
		/// <param name="name">The name of the value pair.</param>
		/// <param name="value">The value of the value pair.</param>
		protected internal void AddOrUpdateValue(string name, object value)
		{
			if (this.Values.ContainsKey(name))
				this.Values[name].Value = value;
			else
			{
				ModelValueEntry entry = new ModelValueEntry
				{
					Name = name,
					Value = value
				};

				this.Values.Add(name, entry);
			}
		}

		/// <summary>
		/// Adds or updates a value to the underlying dictionary.
		/// </summary>
		/// <param name="name">The name of the value pair.</param>
		/// <param name="value">The entry within.</param>
		protected internal void AddOrUpdateValue(string name, ModelValueEntry value)
		{
			if (this.Values.ContainsKey(name))
				this.Values[name] = value;
			else
			{
				value.Name = name;
				this.Values.Add(name, value);
			}
		}

		protected internal void AddOrUpdateValue(string name, Action<ModelValueEntry> value)
		{
			ModelValueEntry entry = null;

			if (this.Values.ContainsKey(name))
			{
				entry = this.Values[name];
				value(entry);

				this.Values[name] = entry;
			}
			else
			{
				entry = new ModelValueEntry { Name = name };
				value(entry);
				this.Values.Add(name, entry);
			}
		}

		/// <summary>
		/// Creates the dictionary of values.
		/// </summary>
		/// <returns>The values of dictionary.</returns>
		protected internal virtual IDictionary<string, ModelValueEntry> CreateValues()
		{
			return new Dictionary<string, ModelValueEntry>();
		}

		protected internal IEnumerable<ModelValueEntry> GetEntries()
		{
			return this.Values.Values;
		}

		/// <summary>
		/// Gets the value of the name/value pair, using the name.  This may return null if not found.
		/// </summary>
		/// <param name="name">The name of the pairing.</param>
		/// <returns>The value of the pairing.</returns>
		public object GetValue(string name)
		{
			if (this.Values.ContainsKey(name))
				return this.Values[name].Value;
			else
				return null;
		}

		public T GetValue<T>(string name)
		{
			if (this.Values.ContainsKey(name))
				return this.Values[name].GetValue<T>();
			else
				return default(T);
		}

		/// <summary>
		/// Returns whether the model has a value for the specified property.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		/// <returns>Whether the model has a value for the property.</returns>
		public bool HasValue(string name)
		{
			return this.Values.ContainsKey(name);
		}

		/// <summary>
		/// Removes a value by its key.
		/// </summary>
		/// <param name="name">The key to remove by.</param>
		/// <returns>Whether it was successful.</returns>
		protected internal bool RemoveValue(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			if (this.Values.ContainsKey(name))
				return this.Values.Remove(name);

			return false;
		}

		#endregion
	}
}
