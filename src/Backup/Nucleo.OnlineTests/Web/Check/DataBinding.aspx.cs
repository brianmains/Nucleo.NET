using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Check
{
	public partial class DataBinding : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.rpt1.DataSource = new[]
			{
				new { Checked = new Nullable<bool>(true), Text = "donkey" },	
				new { Checked = new Nullable<bool>(false), Text = "elephant" },
				new { Checked = new Nullable<bool>(), Text = "rhino" },
				new { Checked = new Nullable<bool>(true), Text = "giraffe" }
			};
			this.rpt1.DataBind();
		}
	}
}