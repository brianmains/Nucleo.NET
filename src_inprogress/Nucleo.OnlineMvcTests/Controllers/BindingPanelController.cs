using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using Nucleo.Models.BindingPanel;


namespace Nucleo.Controllers
{
    public class BindingPanelController : Controller
    {
        public ActionResult FirstLook()
        {
            return View(new BindingPanelModel());
        }

    }
}
