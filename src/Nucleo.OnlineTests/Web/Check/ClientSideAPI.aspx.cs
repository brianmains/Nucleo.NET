using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Check
{
	public partial class ClientSideAPI : Nucleo.Framework.TestPage
	{
		#region " Methods "

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!Page.IsPostBack)
			{
				if (!this.chkControl.Checked.HasValue)
					this.ddlChecked.SelectedValue = "";
				else
					this.ddlChecked.SelectedValue = this.chkControl.Checked.Value.ToString();

				this.chkAllowEmptyState.Checked = this.chkControl.AllowEmptyCheckState;
				this.chkEnabled.Checked = this.chkControl.Enabled;
				this.txtText.Text = this.chkControl.Text;
			}
		}

		#endregion
	}
}
