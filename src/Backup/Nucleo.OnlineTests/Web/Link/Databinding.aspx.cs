using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Link
{
	public partial class Databinding : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!Page.IsPostBack)
			{
				ArrayList list = new ArrayList();
				list.Add(new { Key = 1, Text = "First Item" });
				list.Add(new { Key = 2, Text = "Second Item" });
				list.Add(new { Key = 3, Text = "Third Item" });
				list.Add(new { Key = 4, Text = "Fourth Item" });
				list.Add(new { Key = 5, Text = "Fifth Item" });

				this.rpt1.DataSource = list;
				this.rpt1.DataBind();

				this.rpt2.DataSource = list;
				this.rpt2.DataBind();
			}
		}

		protected void rpt2_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			this.AddTraceStatement(e.CommandName + " fired from repeater");
		}
	}
}