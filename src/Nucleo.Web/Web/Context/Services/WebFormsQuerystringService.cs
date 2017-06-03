using System;
using System.Web;
using System.Collections.Specialized;

using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsQuerystringService : IQuerystringService
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
			get { return this.Context.Request.QueryString.Count; }
		}

		public object this[string key]
		{
			get { return this.Context.Request.QueryString.Get(key); }
			set { }
		}

		#endregion


		#region " Constructors "

#if NET20
		public WebFormsQuerystringService()
			: this(HttpContext.Current) { }

		public WebFormsQuerystringService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsQuerystringService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsQuerystringService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			this.Context.Request.QueryString.Add(key, (value != null) ? value.ToString() : default(string));
		}

		public bool Contains(string key)
		{
			return (this.Context.Request.QueryString.Get(key) != null);
		}

		public object Get(string key)
		{
			return this.Context.Request.QueryString.Get(key);
		}

		public object Get(int index)
		{
			return this.Context.Request.QueryString.Get(index);
		}

		public NameValueCollection GetAll()
		{
			return this.Context.Request.QueryString;
		}

		public void Remove(string key)
		{
			this.Context.Request.QueryString.Remove(key);
		}

		public void RemoveAt(int index)
		{
			string key = this.Context.Request.QueryString.Keys[index];
			this.Context.Request.QueryString.Remove(key);
		}

		#endregion
	}
}
