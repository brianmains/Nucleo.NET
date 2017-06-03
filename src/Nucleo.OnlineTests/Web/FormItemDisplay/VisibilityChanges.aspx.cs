using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.FormItemDisplay
{
	public partial class VisibilityChanges : System.Web.UI.Page
	{
		protected void btnToggle_Click(object sender, EventArgs e)
		{
			var num = (new Random(DateTime.Now.Second)).Next(0, 3);
			foreach (var item in this.s1.Items)
				((WebControl)item).Visible = true;

			this.s1.Controls[num].Visible = false;
		}
	}
}