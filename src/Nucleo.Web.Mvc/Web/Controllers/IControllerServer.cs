using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace Nucleo.Web.Controllers
{
	public interface IControllerServer
	{
		IController GetControllerReference(RequestContext context, string controllerName);
	}
}
