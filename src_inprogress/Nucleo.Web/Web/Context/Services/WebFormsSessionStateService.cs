using System;
using System.Web;
using System.Web.SessionState;

using Nucleo.Context.Services;
using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsSessionStateService : ISessionStateService
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
			get { return this.Context.Session.Count; }
		}

		public object this[string key]
		{
			get { return this.Context.Session[key]; }
			set { this.Context.Session[key] = value; }
		}

		public string UniqueKey
		{
			get { return this.Context.Session.SessionID; }
		}

		#endregion



		#region " Constructors "

#if NET20
		public WebFormsSessionStateService()
			: this(HttpContext.Current) { }

		public WebFormsSessionStateService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsSessionStateService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsSessionStateService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			this.Context.Session.Add(key, value);
		}

		public void Clear()
		{
			this.Context.Session.Clear();
		}

		public bool Contains(string key)
		{
			return (this.Context.Session[key] != null);
		}

		public object Get(string key)
		{
			return this.Context.Session[key];
		}

		public object Get(int index)
		{
			return this.Context.Session[index];
		}

		public void Remove(string key)
		{
			this.Context.Session.Remove(key);
		}

		public void RemoveAt(int index)
		{
			this.Context.Session.RemoveAt(index);
		}

		#endregion
	}
}
