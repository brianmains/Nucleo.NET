using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Check
{
	public partial class ServerSideAPI : Nucleo.Framework.TestPage
	{
		#region " Methods "

		private bool? GetCheckedValue()
		{
			if (string.IsNullOrEmpty(this.ddlChecked.SelectedValue))
				return null;
			else
				return bool.Parse(this.ddlChecked.SelectedValue);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!Page.IsPostBack)
			{
				if (!this.chkControl.Checked.HasValue)
					this.ddlChecked.SelectedValue = "";
				else
					this.ddlChecked.SelectedValue = this.chkControl.Checked.Value.ToString();

				this.ddlAllowEmptyCheckState.SelectedValue = this.chkControl.AllowEmptyCheckState.ToString();
				this.ddlEnabled.SelectedValue = this.chkControl.Enabled.ToString();
				this.txtText.Text = this.chkControl.Text;
				this.txtTextFormat.Text = this.chkControl.TextFormat;
			}
		}

		#endregion



		#region " Event Arguments "

		protected void btnChange_Click(object sender, EventArgs e)
		{
			this.chkControl.Checked = this.GetCheckedValue();
			this.chkControl.AllowEmptyCheckState = bool.Parse(this.ddlAllowEmptyCheckState.SelectedValue);
			this.chkControl.Enabled = bool.Parse(this.ddlEnabled.SelectedValue);
			this.chkControl.Text = this.txtText.Text;
			this.chkControl.TextFormat = this.txtTextFormat.Text;
		}

		#endregion
	}
}
