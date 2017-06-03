using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Nucleo.OnlineMvcTests.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		#region " Methods "

		public ActionResult GenError()
		{
			throw new Exception();
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Partial()
		{
			return PartialView("Partial");
		}

		public ActionResult SharedTest()
		{
			return PartialView("SharedTest");
		}

		#endregion
	}
}
