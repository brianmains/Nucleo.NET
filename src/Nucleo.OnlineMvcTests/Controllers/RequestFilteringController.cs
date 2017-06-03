using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Nucleo.Web.Filters;


namespace Nucleo.Controllers
{
    public class RequestFilteringController : Controller
    {
		[AjaxOnlyRequest]
		public ActionResult AjaxRequest()
		{
			return Content("OK");
		}

		public ActionResult FirstLook()
		{
			return View();
		}

		[StandardOnlyRequest]
        public ActionResult StandardRequest()
        {
            return View();
        }
    }
}
