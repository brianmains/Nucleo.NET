using System;
using System.Web;
using System.Web.UI;

using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsCookieService : ICookieService
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
			get { return this.Context.Response.Cookies.Count; }
		}

		public object this[string key]
		{
			get { return this.Get(key); }
			set
			{

			}
		}

		#endregion



		#region " Constructors "

#if NET20
		public WebFormsCookieService()
			: this(HttpContext.Current) { }

		public WebFormsCookieService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsCookieService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsCookieService(HttpContextBase context)
		{
			_context = context;
		}
#endif

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			this.Context.Response.Cookies.Add(
				new HttpCookie(key, (value != null) ? value.ToString() : default(string)));
		}

		public void Add(string key, object value, DateTime expires, bool secure)
		{
			this.Add(key, value, expires, secure, null);
		}

		public void Add(string key, object value, DateTime expires, bool secure, string domain)
		{
			HttpCookie cookie = new HttpCookie(key, (value != null) ? value.ToString() : default(string));
			cookie.Expires = expires;
			cookie.Secure = secure;

			if (domain != null)
				cookie.Domain = domain;

			this.Context.Response.Cookies.Add(cookie);
		}

		public bool Contains(string key)
		{
			return (this.Context.Request.Cookies.Get(key) != null);
		}

		public object Get(string key)
		{
			HttpCookie cookie = this.Context.Request.Cookies.Get(key);
			if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
				return cookie.Value;

			cookie = this.Context.Response.Cookies.Get(key);
			return (cookie != null) ? cookie.Value : null;
		}

		public object Get(int index)
		{
			HttpCookie cookie = this.Context.Request.Cookies.Get(index);
			if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
				return cookie.Value;

			cookie = this.Context.Response.Cookies.Get(index);
			return (cookie != null) ? cookie.Value : null;
		}

		public HttpCookie GetCookie(string key)
		{
			HttpCookie cookie = this.Context.Request.Cookies.Get(key);
			if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
				return cookie;

			cookie = this.Context.Request.Cookies.Get(key);
			if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
				return cookie;

			return null;
		}

		public void Remove(string key)
		{
			HttpCookie cookie = this.Context.Request.Cookies[key];
			if (cookie != null)
				this.Context.Request.Cookies.Remove(key);

			cookie = this.Context.Response.Cookies[key];
			if (cookie != null)
				this.Context.Response.Cookies.Remove(key);
		}

		public void RemoveAt(int index)
		{
			string key = this.Context.Response.Cookies.AllKeys[index];
			this.Context.Response.Cookies.Remove(key);
		}

		#endregion
	}
}
