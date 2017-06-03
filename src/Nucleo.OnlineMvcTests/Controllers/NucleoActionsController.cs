using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using Nucleo.Models.NucleoActions;


namespace Nucleo.Controllers
{
    public class NucleoActionsController : Controller
    {
        public ActionResult FirstLook()
        {
			return View(new FirstLookModel
				{
					FirstPartial = new FirstPartialModel { Name = "First Partial" },
					FirstPartialLookupTest = new FirstPartialModel { Name = "First Partial" },
					SecondPartial = new SecondPartial { Name = "Second Partial" },
					ThirdPartial = new ThirdPartialViewModel { Name = "Third Partial" }
				});
        }
    }
}
