using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.ValidationControls;


namespace Nucleo.Web.Validation
{
	public partial class ValidatorsFirstLook : System.Web.UI.Page
	{
		protected void btnSave_Click(object sender, EventArgs e)
		{
			vm.ValidateEmptyGroup();

			if (!vm.IsValid)
				return;

			this.lblOutput.Text = "Data saved";
		}
	}
}