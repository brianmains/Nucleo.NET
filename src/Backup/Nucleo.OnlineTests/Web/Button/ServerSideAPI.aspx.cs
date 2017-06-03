using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Button
{
	public partial class ServerSideAPI : Nucleo.Framework.TestPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			btnChangeServerSettings.Click += new EventHandler(btnChangeServerSettings_Click);

			this.btnControl.Click += new EventHandler(btnControl_Click);
			this.btnControl.Command += new CommandEventHandler(btnControl_Command);
		}

		void btnChangeServerSettings_Click(object sender, EventArgs e)
		{
			this.btnControl.Mode = (ButtonType)(Enum.Parse(typeof(ButtonType), this.ddlMode.SelectedValue));
			this.btnControl.Text = this.txtText.Text;
			this.btnControl.Enabled = this.chkEnabled.Checked;
			this.btnControl.ValidationGroup = this.txtValidationGroup.Text;
			this.btnControl.CommandArgument = this.txtCommandArgument.Text;
			this.btnControl.CommandName = this.txtCommandName.Text;
			this.btnControl.DisableOnFirstClick = this.chkDisableFirstClick.Checked;
			this.btnControl.DisableUntilPageLoad = this.chkDisableUntilPageLoad.Checked;
			this.btnControl.DisableOnFirstClickTimeout = !string.IsNullOrEmpty(this.txtDisableFirstClickTimeout.Text)
				? int.Parse(this.txtDisableFirstClickTimeout.Text) : 0;
			this.btnControl.CausesValidation = this.chkCausesValidation.Checked;
			this.btnControl.PostBackAlways = this.chkPostbackAlways.Checked;
			this.btnControl.PostBackUrl = this.txtPostbackUrl.Text;
			this.btnControl.OnClientClick = this.txtOnClientClick.Text;
			this.btnControl.ImageAlternateText = this.txtImageAlternateText.Text;
			this.btnControl.ImageUrl = this.txtImageUrl.Text;
		}

		void btnControl_Command(object sender, CommandEventArgs e)
		{
			this.lblOutput.Text += "Command fired from the server, with values: " +
				e.CommandName + "/" + ((e.CommandArgument != null) ? e.CommandArgument.ToString() : "NULL") + "<br />";
		}

		void btnControl_Click(object sender, EventArgs e)
		{
			this.lblOutput.Text += "Click fired from the server<br/>";
		}
	}
}
