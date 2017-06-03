using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Accordions
{
	public partial class BubblingEvents : Nucleo.Framework.TestPage
	{
		protected void ac_Command(object sender, CommandEventArgs e)
		{
			this.lblOutput.Controls.Add(new LiteralControl(string.Format("Accordion.ItemCommand fired with command: '{0}'.<br/>", e.CommandName)));
		}
	}
}