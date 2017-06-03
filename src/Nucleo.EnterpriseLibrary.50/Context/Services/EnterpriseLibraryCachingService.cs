using System;
using System.Collections.Generic;

using Microsoft.Practices.EnterpriseLibrary.Caching;


namespace Nucleo.Context.Services
{
	public class EnterpriseLibraryCachingService : ICachingService
	{
		private ICacheManager _cache = null;



		#region " Properties "

		public int Count
		{
			get { return _cache.Count; }
		}

		public object this[string key]
		{
			get { return _cache[key]; }
			set { }
		}

		#endregion



		#region " Constructors "

		public EnterpriseLibraryCachingService(ICacheManager cache)
		{
			_cache = cache;
		}

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			_cache.Add(key, value);
		}

		public bool Contains(string key)
		{
			return _cache.Contains(key);
		}

		public object Get(string key)
		{
			return _cache.GetData(key);
		}

		public object Get(int index)
		{
			throw new NotImplementedException("The Get by index is not implemented.");
		}

		public void Remove(string key)
		{
			_cache.Remove(key);
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException("The Get by index is not implemented.");
		}

		#endregion
	}
}
