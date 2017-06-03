using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Button
{
	public partial class FirstLook : Nucleo.Framework.TestPage
	{
		#region " Event Handlers "

		protected void btnClientOnlyPostback_Click(object sender, EventArgs e)
		{
			this.lblOutput.Text += "Client With Postback: Click event raised<br/>";
		}

		protected void btnMixed_Click(object sender, EventArgs e)
		{
			this.lblOutput.Text += "Server: Click event raised<br />";
		}

		protected void btnServerSide_Click(object sender, EventArgs e)
		{
			this.AddTraceStatement("Server: Click event raised");
			this.lblOutput.Text += "Server: Click event raised<br />";
		}

		#endregion
	}
}
