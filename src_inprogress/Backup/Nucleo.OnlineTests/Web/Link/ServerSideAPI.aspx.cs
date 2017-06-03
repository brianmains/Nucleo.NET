using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Controls;


namespace Nucleo.Web.Link
{
	public partial class ServerSideAPI : Nucleo.Framework.TestPage
	{
		#region " Methods "

		protected void btnChangeServerSettings_Click(object sender, EventArgs e)
		{
			this.lnkControl.Text = this.txtText.Text;
			this.lnkControl.TextFormat = this.txtTextFormat.Text;
			this.lnkControl.NavigateUrl = this.txtNavigateUrl.Text;
			this.lnkControl.NavigateUrlFormatString = this.txtNavigateUrlFormatSring.Text;
			this.lnkControl.ClickAction = (LinkClickAction)(Enum.Parse(typeof(LinkClickAction), this.ddlClickAction.SelectedValue));
			this.lnkControl.Target = (LinkTargetOptions)(Enum.Parse(typeof(LinkTargetOptions), this.ddlTarget.SelectedValue));
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.lnkControl.Clicked += new EventHandler(lnkControl_Clicked);
		}

		void lnkControl_Clicked(object sender, EventArgs e)
		{
			this.lblOutput.Text += "Click Event Fired From Server<br/>";
		}

		#endregion
	}
}
