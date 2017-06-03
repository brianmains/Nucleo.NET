using System;


namespace Nucleo.Models.Cache
{
	/// <summary>
	/// Represents caching of data within a model.
	/// </summary>
	public interface IModelCache
	{
		/// <summary>
		/// Gets the availability of the cache.
		/// </summary>
		/// <param name="options">The current options.</param>
		/// <returns>The information about the cache.</returns>
		CacheInformation GetCacheAvailability(ModelInspectorOptions options);

		/// <summary>
		/// Gets the model value from the cache.
		/// </summary>
		/// <param name="metadata">The metadata of the model's property.</param>
		/// <param name="key">The key used to vary the caching.</param>
		/// <returns>The cached value, or null if not cached.</returns>
		ModelCacheResults GetFromCache(ModelInspectorOptions metadata, string key);

		/// <summary>
		/// Saves the updated value to the model cache.
		/// </summary>
		/// <param name="metadata">The metadata of the model's property.</param>
		/// <param name="key">The key used to vary the caching.</param>
		/// <param name="value">The updated value.</param>
		void SaveToCache(ModelInspectorOptions metadata, string key, object value);
	}
}
