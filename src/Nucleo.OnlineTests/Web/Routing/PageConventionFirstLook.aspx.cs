using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Routing;


namespace Nucleo.Web.Routing
{
	public partial class PageConventionFirstLook : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var engine = new RoutingEngines();
			engine.Engines.Add(new PageConventionRoutingEngine("~/Web", "Web"));

			engine.Navigate(typeof(RoutingTarget));
		}
	}
}