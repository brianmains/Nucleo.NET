using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

using Nucleo.Context.Services;
using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsCachingService : ICachingService
	{
#if NET20
		private HttpContext _context = null;
#else
		private HttpContextBase _context = null;
#endif



		#region " Properties "

#if NET20
		private HttpContext Context
		{
			get { return _context; }
		}
#else
		private HttpContextBase Context
		{
			get { return _context; }
		}
#endif

		public int Count
		{
			get { return this.Context.Cache.Count; }
		}

		public object this[string key]
		{
			get { return this.Context.Cache[key]; }
			set { this.Context.Cache[key] = value; }
		}

		#endregion



		#region " Constructors "

#if NET20
		public WebFormsCachingService()
			: this(HttpContext.Current) { }

		public WebFormsCachingService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsCachingService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsCachingService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			if (this.Context.Cache.Get(key) == null)
				this.Context.Cache.Add(key, value, null, DateTime.MaxValue, TimeSpan.FromMinutes(20), System.Web.Caching.CacheItemPriority.Default, null);
			else
				this.Context.Cache.Insert(key, value);
		}

		public bool Contains(string key)
		{
			return (Get(key) != null);
		}

		public object Get(string key)
		{
			return this.Context.Cache.Get(key);
		}

		public object Get(int index)
		{
			throw new NotImplementedException();
		}

		public string GetSafeKey(string key)
		{
			return string.Format("{0}_{1}", this.Context.User.Identity.Name, key);
		}

		public void Remove(string key)
		{
			this.Context.Cache.Remove(key);
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
