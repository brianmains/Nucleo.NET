using System;
using System.Web;


namespace Nucleo.Services
{
	public class WebHttpContextLocatorService : IHttpContextLocatorService
	{
		public System.Web.HttpContextBase GetContext()
		{
			return new HttpContextWrapper(HttpContext.Current);
		}
	}
}
