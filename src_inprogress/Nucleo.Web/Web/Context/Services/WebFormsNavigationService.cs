using System;
using System.Web;
using System.Web.UI;
using System.Threading;

using Nucleo.Context.Services;
using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsNavigationService : INavigationService
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
		public WebFormsNavigationService()
			: this(HttpContext.Current) { }

		public WebFormsNavigationService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsNavigationService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsNavigationService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

		public void NavigateTo(INavigationRoute route)
		{
			try
			{
				this.Context.Response.Redirect(route.GetRouteText());
			}
			catch { }
		}

		#endregion
	}
}
