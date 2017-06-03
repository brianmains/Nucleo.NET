using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents the URL resolution service for use with web forms.
	/// </summary>
	public class WebUrlResolutionService : IUrlResolutionService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		public WebUrlResolutionService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebUrlResolutionService(HttpContextBase context)
		{
			_context = context;
		}

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
