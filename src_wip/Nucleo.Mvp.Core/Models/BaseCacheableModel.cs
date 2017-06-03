using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Models
{
	/// <summary>
	/// Represents the base class for a cacheable model.
	/// </summary>
	public abstract class BaseCacheableModel : ICacheableModel
	{
		private Dictionary<string, object> _items = null;



		#region " Properties "

		private Dictionary<string, object> Items
		{
			get 
			{
				if (_items == null)
					_items = new Dictionary<string, object>();
				return _items; 
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the value.  Otherwise, this process gets the value locally.
		/// </summary>
		/// <param name="key">The key to get.</param>
		/// <returns>The value.</returns>
		protected object GetValue(string key)
		{
			if (this.Items.ContainsKey(key))
				return this.Items[key];

			return null;
		}

		/// <summary>
		/// Gets the value, trying to extract it from cache when cache is present.  Otherwise, this process gets the value locally.
		/// </summary>
		/// <param name="key">The key to get.</param>
		/// <param name="cacheable">Whether the property is cacheable.</param>
		/// <returns>The value.</returns>
		protected object GetValue(string key, ShareAccessLevel cacheSetting)
		{
			if (cacheSetting != ShareAccessLevel.None)
			{
				object value = this.GetFromCache(key, null, cacheSetting);
				return (value != null) ? value : null;
			}
			else
				return GetValue(key);
		}

		/// <summary>
		/// Sets the value locally.
		/// </summary>
		/// <param name="key">The key to set.</param>
		/// <param name="value">The value to set.</param>
		protected void SetValue(string key, object value)
		{
			this.Items[key] = value;
		}

		/// <summary>
		/// Sets the value locally and in cache.
		/// </summary>
		/// <param name="key">The key to set.</param>
		/// <param name="value">The value to set.</param>
		/// <param name="cacheable">Whether to set in cache or locally.</param>
		protected void SetValue(string key, object value, ShareAccessLevel cacheSetting)
		{
			if (cacheSetting != ShareAccessLevel.None)
				this.SetToCache(key, value, cacheSetting);
			else
				this.SetValue(key, value);
		}

		#endregion
	}
}
