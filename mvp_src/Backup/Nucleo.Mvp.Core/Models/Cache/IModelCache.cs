using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Models.Cache
{
	/// <summary>
	/// Represents a provider that interacts with a cache for properties of a model.
	/// </summary>
	public interface IModelCache
	{
		/// <summary>
		/// Gets a value from the cache with a given key.
		/// </summary>
		/// <param name="model">The model instance.</param>
		/// <param name="key">The key.</param>
		/// <param name="level">The level of sharing.</param>
		/// <returns>The value from the cache.</returns>
		object GetValueFromCache(ICacheableModel model, string key, ShareAccessLevel level);

		/// <summary>
		/// Sets a value to the cache with a given key.
		/// </summary>
		/// <param name="model">The model instance.</param>
		/// <param name="key">The key.</param>
		/// <param name="value">The value to set to the cache.</param>
		/// <param name="level">The level of sharing.</param>
		void SetValueToCache(ICacheableModel model, string key, object value, ShareAccessLevel level);
	}
}
