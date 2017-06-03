using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.ButtonList
{
	public partial class ServerSideAPI : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		
			this.btnChangeServerSettings.Click += delegate(object s, EventArgs arg)
			{
				this.blControl.DisableOnFirstClick = string.IsNullOrEmpty(this.ddlDisableOnFirstClick.SelectedValue)
					? (bool?)null : bool.Parse(this.ddlDisableOnFirstClick.SelectedValue);
				this.blControl.DisableUntilPageLoad = string.IsNullOrEmpty(this.ddlDisableUntilPageLoad.SelectedValue)
					? (bool?)null : bool.Parse(this.ddlDisableUntilPageLoad.SelectedValue);
				this.blControl.DisableOnFirstClickTimeout = string.IsNullOrEmpty(this.txtDisableOnFirstClickTimeout.Text)
					? (int?)null : int.Parse(this.txtDisableOnFirstClickTimeout.Text);
				this.blControl.Orientation = (Orientation)Enum.Parse(typeof(Orientation), this.ddlOrientation.SelectedValue);
			};

			this.btnToggleFirst.Click += delegate(object s, EventArgs arg)
			{
				this.blControl.ToggleVisibility("First");
			};

			this.btnToggleSecond.Click += delegate(object s, EventArgs arg)
			{
				this.blControl.ToggleVisibility("Second");
			};

			this.btnToggleThird.Click += delegate(object s, EventArgs arg)
			{
				this.blControl.ToggleVisibility("Third");
			};
		}
	}
}
