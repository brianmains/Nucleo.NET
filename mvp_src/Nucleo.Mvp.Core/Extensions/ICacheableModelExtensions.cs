using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Core;
using Nucleo.Presentation;


namespace Nucleo.Models
{
	/// <summary>
	/// Extensions for <see cref="ICacheableModel"/> interface.
	/// </summary>
	public static class ICacheableModelExtensions
	{
		#region " Methods "

		/// <summary>
		/// Gets an object out of the cache with the given cache key and share access level.  Uses the <see cref="FrameworkSettings.ModelCache"/> object to operate with the cache.
		/// </summary>
		/// <param name="model">The model to extend.</param>
		/// <param name="key">The key of the item stored in cache.</param>
		/// <param name="defaultValue">The default value to return if the model cache is null, or if the item returned is null.</param>
		/// <param name="level">The access level to share.</param>
		/// <returns>The object returned from cache, or the default value.</returns>
		public static object GetFromCache(this ICacheableModel model, string key, object defaultValue, ShareAccessLevel level)
		{
			var context = FrameworkSettings.ModelCache;
			if (context == null)
				return defaultValue;

			return (context.GetValueFromCache(model, key, level) ?? defaultValue);
		}

		/// <summary>
		/// Gets an object out of the cache with the given cache key and share access level.  Uses the <see cref="FrameworkSettings.ModelCache"/> object to operate with the cache.
		/// </summary>
		/// <typeparam name="T">The type of model object to extract.</typeparam>
		/// <param name="model">The model to extend.</param>
		/// <param name="key">The key of the item stored in cache.</param>
		/// <param name="defaultValue">The default value to return if the model cache is null, or if the item returned is null.</param>
		/// <param name="level">The access level to share.</param>
		/// <returns>The object returned from cache, or the default value.</returns>
		public static T GetFromCache<T>(this ICacheableModel model, string key, T defaultValue, ShareAccessLevel level)
		{
			return (T)GetFromCache(model, key, (object)defaultValue, level);
		}

		/// <summary>
		/// Sets a value into the cache using the <see cref="FrameworkSettings.ModelCache"/> as the caching store.  If the cache is null, setting the object is avoided.
		/// </summary>
		/// <param name="model">The model to work with.</param>
		/// <param name="key">The key of the item.</param>
		/// <param name="value">The value of the item to insert.</param>
		/// <param name="level">The access level.</param>
		public static void SetToCache(this ICacheableModel model, string key, object value, ShareAccessLevel level)
		{
			var context = FrameworkSettings.ModelCache;
			if (context == null)
				return;

			context.SetValueToCache(model, key, value, level);
		}

		#endregion
	}
}
