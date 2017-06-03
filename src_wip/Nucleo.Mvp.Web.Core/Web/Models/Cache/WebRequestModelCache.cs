using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Models;
using Nucleo.Models.Cache;


namespace Nucleo.Web.Models.Cache
{
	/// <summary>
	/// Represents a model cache that uses the current HTTP request as the data store.
	/// </summary>
	public class WebRequestModelCache : IModelCache
	{
		private HttpContextBase _context = null;



		#region " Constructors "

		public WebRequestModelCache()
		{
			_context = new HttpContextWrapper(HttpContext.Current);
		}

		public WebRequestModelCache(HttpContextBase context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		private string GenerateKey(ICacheableModel model, string key, ShareAccessLevel level)
		{
			if (level == ShareAccessLevel.PerModel)
				return "PerModel_" + model.GetType().FullName + "_$_" + key;
			else if (level == ShareAccessLevel.Global)
				return "Global_$_" + key;
			else
				return null;
		}

		private IDictionary<string, object> GetDictionary(ICacheableModel model, string key, ShareAccessLevel level)
		{
			var dict = _context.Items[typeof(WebRequestModelCache)] as IDictionary<string, object>;

			if (dict == null)
				dict = new Dictionary<string, object>();

			return dict;
		}

		/// <summary>
		/// Gets the value from cache by using the current HTTP context.
		/// </summary>
		/// <param name="model">The cacheable model.</param>
		/// <param name="key">The key of the model.</param>
		/// <param name="level">The current sharing level.</param>
		/// <returns>The object found.</returns>
		public object GetValueFromCache(ICacheableModel model, string key, ShareAccessLevel level)
		{
			if (level == ShareAccessLevel.None)
				throw new InvalidOperationException("A share level of None is not allowed.");

			var dict = _context.Items[typeof(WebRequestModelCache)] as IDictionary<string, object>;
			if (dict == null)
				return null;

			var identifier = this.GenerateKey(model, key, level);
			return dict.ContainsKey(identifier) ? dict[identifier] : null;
		}

		private void SaveUpdates(IDictionary<string, object> dict)
		{
			_context.Items[typeof(WebRequestModelCache)] = dict;
		}

		public void SetValueToCache(ICacheableModel model, string key, object value, ShareAccessLevel level)
		{
			if (level == ShareAccessLevel.None)
				throw new InvalidOperationException("A share level of None is not allowed.");

			var dict = _context.Items[typeof(WebRequestModelCache)] as IDictionary<string, object>;
			if (dict == null)
				dict = new Dictionary<string, object>();

			dict.Add(this.GenerateKey(model, key, level), value);
			this.SaveUpdates(dict);
		}

		#endregion
	}
}
