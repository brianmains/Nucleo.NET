using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Button
{
	public partial class LinkButtons : Nucleo.Framework.TestPage
	{
		#region " Event Handlers "

		protected void b2_Click(object sender, EventArgs e)
		{
			this.AddTraceStatement("Button 2 clicked from server");
		}

		protected void b3_Click(object sender, EventArgs e)
		{
			this.AddTraceStatement("Button 3 clicked from server");
		}

		protected void b4_Click(object sender, EventArgs e)
		{
			this.AddTraceStatement("Button 4 clicked from server");
		}

		protected void b5_Click(object sender, EventArgs e)
		{
			this.AddTraceStatement("Button 5 clicked from server");
		}

		#endregion
	}
}