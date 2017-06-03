using System;
using System.Collections;
using System.Collections.Generic;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents an event arguments for dictionary values.
	/// </summary>
	public class DictionaryEventArgs : EventArgs
	{
		private IDictionary _dictionary = null;



		#region " Properties "

		private IDictionary Dictionary
		{
			get
			{
				if (_dictionary == null)
					_dictionary = new Dictionary<object, object>();

				return _dictionary;
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the dictionary args with an empty collection.
		/// </summary>
		public DictionaryEventArgs() { }

		/// <summary>
		/// Creates the dictionary args with a preset collection of dictionary values.
		/// </summary>
		/// <param name="dictionary">The dictionary to use.</param>
		public DictionaryEventArgs(IDictionary dictionary)
		{
			_dictionary = dictionary;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an item to the event args dictionary; if it already exists, it is updated.
		/// </summary>
		/// <param name="key">The key to add.</param>
		/// <param name="value">The value to add.</param>
		public void Add(string key, object value)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException("key");

			if (this.Dictionary.Contains(key))
				this.Dictionary[key] = value;
			else
				this.Dictionary.Add(key, value);
		}

		/// <summary>
		/// Gets a value out of the dictionary by key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="defaultValue">The default value to return if the key doesn't exist.</param>
		/// <returns>The value found, or the default value.</returns>
		public object Get(string key, object defaultValue)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException("key");

			if (this.Dictionary.Contains(key))
				return this.Dictionary[key];
			else
				return defaultValue;
		}

		/// <summary>
		/// Gets a value out of the dictionary by key, in a generic fashion.
		/// </summary>
		/// <typeparam name="T">The type of the parameter in the dictionary.</typeparam>
		/// <param name="key">The key.</param>
		/// <param name="defaultValue">The default value to return if the key doesn't exist.</param>
		/// <returns>The value found, or the default value.</returns>
		public T Get<T>(string key, T defaultValue)
		{
			return (T)Get(key, (object)defaultValue);
		}

		public ICollection GetKeys()
		{
			return this.Dictionary.Keys;
		}
	
		/// <summary>
		/// Removes an item by its key.
		/// </summary>
		/// <param name="key">The key of the item to remove.</param>
		/// <returns>Whether the item was removed successfully.</returns>
		public bool Remove(string key)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException("key");

			if (this.Dictionary.Contains(key))
			{
				this.Dictionary.Remove(key);
				return true;
			}
			else
				return false;
		}

		#endregion
	}


	public delegate void DictionaryEventHandler(object sender, DictionaryEventArgs e);
}
