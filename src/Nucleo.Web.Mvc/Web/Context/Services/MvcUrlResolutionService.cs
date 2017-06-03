using System;
using System.Web;
using System.Web.UI;
using System.Web.Routing;
using System.Web.Mvc;


namespace Nucleo.Web.Context.Services
{
	public class MvcUrlResolutionService : IUrlResolutionService
	{
		private HttpContextBase _context = null;



		#region " Constructors "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		public MvcUrlResolutionService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public MvcUrlResolutionService(HttpContextBase context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		public string GetClientBasedUrl(string relativeUrl)
		{
			if (this.Context.Handler is Page)
			{
				Page page = (Page)this.Context.Handler;
				return page.ResolveClientUrl(relativeUrl);
			}
			else
			{
				MvcHandler handler = (MvcHandler)this.Context.Handler;
				return new UrlHelper(handler.RequestContext).Content(relativeUrl);
			}
		}

		public string GetWebServerUrl(string relativeUrl)
		{
			return this.Context.Server.MapPath(relativeUrl);
		}

		#endregion
	}
}
