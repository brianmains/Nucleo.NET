using System;
using System.Web;
using System.Collections.Specialized;

using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsPostDataService : IPostDataService
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

		#endregion



		#region " Constructors "

#if NET20
		public WebFormsPostDataService()
			: this(HttpContext.Current) { }

		public WebFormsPostDataService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsPostDataService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsPostDataService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

		public string Get(string key)
		{
			return this.Context.Request.Form.Get(key);
		}

		public string Get(int index)
		{
			return this.Context.Request.Form.Get(index);
		}

		public NameValueCollection GetAll()
		{
			return this.Context.Request.Form;
		}

		#endregion
	}
}
