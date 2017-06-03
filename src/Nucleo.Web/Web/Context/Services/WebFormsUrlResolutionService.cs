using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;

using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsUrlResolutionService : IUrlResolutionService
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
		public WebFormsUrlResolutionService()
			: this(HttpContext.Current) { }

		public WebFormsUrlResolutionService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsUrlResolutionService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsUrlResolutionService(HttpContextBase context)
		{
			_context = context;
		}
#endif

		#endregion



		#region " Methods "

		public string GetClientBasedUrl(string relativeUrl)
		{
			System.Web.UI.IUrlResolutionService url = this.Context.Handler as System.Web.UI.IUrlResolutionService;
			return url.ResolveClientUrl(relativeUrl);
		}

		public string GetWebServerUrl(string relativeUrl)
		{
			return this.Context.Server.MapPath(relativeUrl);
		}

		#endregion
	}
}
