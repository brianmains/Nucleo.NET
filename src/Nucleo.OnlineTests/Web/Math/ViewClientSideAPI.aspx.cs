using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.MathControls;


namespace Nucleo.Web.Math
{
	public partial class ViewClientSideAPI : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.btnChangeServerSettings.Click += delegate(object sender, EventArgs arg)
			{
				this.extTotal.Appearance = (CalculatorViewAppearance)(Enum.Parse(typeof(CalculatorViewAppearance), this.ddlAppearance.SelectedValue));
			};
		}
	}
}
