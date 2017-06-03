using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Layout
{
	public partial class CodeWindow : System.Web.UI.UserControl
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!Page.IsPostBack)
			{
				var page = this.Page as ICodeSampleSupport;
				if (page != null)
				{
					var samples = page.GetSamples();

					this.ddlFiles.DataSource = samples;
					this.ddlFiles.DataBind();
				}
			}
		}

		protected void ddlFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			var page = this.Page as ICodeSampleSupport;
			if (page != null)
			{
				var item = page.GetSamples().First(i => i.FileFullName == ((DropDownList)sender).SelectedValue);
				this.Content.Text = "<xmp>" + item.Code + "</xmp>";
			}
		}
	}
}