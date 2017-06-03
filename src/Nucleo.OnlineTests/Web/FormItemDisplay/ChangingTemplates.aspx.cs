using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.FormControls;


namespace Nucleo.Web.FormItemDisplay
{
	public partial class ChangingTemplates : Framework.TestPage
	{
		private void ChangeServerTemplate()
		{
			var mode = (FormCurrentView)Enum.Parse(typeof(FormCurrentView), ddlNewServerMode.SelectedValue);
			f1.ChangeView(mode);
		}

		protected void ddlNewServerMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ChangeServerTemplate();
		}
	}
}