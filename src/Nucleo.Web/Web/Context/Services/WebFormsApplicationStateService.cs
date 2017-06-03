using System;
using System.Web;

using Nucleo.Context.Services;
using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsApplicationStateService : IApplicationStateService
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
			get { return this.Context.Application.Count; }
		}

		public object this[string key]
		{
			get { return this.Context.Application[key]; }
			set { this.Context.Application[key] = value; }
		}

		#endregion



		#region " Constructors "

#if NET20
		public WebFormsApplicationStateService()
			: this(HttpContext.Current) { }

		public WebFormsApplicationStateService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsApplicationStateService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsApplicationStateService(HttpContextBase context)
		{
			_context = context;
		}
#endif

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			WebContext.GetCurrent().ApplicationState.Add(key, value);
		}

		public void Clear()
		{
			this.Context.Application.Clear();
		}

		public bool Contains(string key)
		{
			return (this.Context.Application[key] != null);
		}

		public object Get(string key)
		{
			return this.Context.Application.Get(key);
		}

		public object Get(int index)
		{
			return this.Context.Application[index];
		}

		public void Remove(string key)
		{
			this.Context.Application.Remove(key);
		}

		public void RemoveAt(int index)
		{
			this.Context.Application.RemoveAt(index);
		}

		#endregion
	}
}
