using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Layout
{
	public partial class DemoLayout : System.Web.UI.MasterPage, Nucleo.Demos.IDemoMasterPage
	{
		private void AddStyle(string styleName)
		{
			
		}

		public void AddTraceStatement(string message)
		{
			this.TraceConsole.InnerHtml += message + "<br/>";
		}
	}
}