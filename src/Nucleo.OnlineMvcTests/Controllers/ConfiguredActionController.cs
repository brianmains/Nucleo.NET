using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Nucleo.Controllers
{
    public class ConfiguredActionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Test()
		{
			return View();
		}
    }
}
