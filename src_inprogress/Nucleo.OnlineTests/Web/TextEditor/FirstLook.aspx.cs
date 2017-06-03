using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.EditorControls;


namespace Nucleo.Web.TextEditor
{
	public partial class FirstLook : Nucleo.Framework.TestPage
	{
		protected void btnChangeSettings_Click(object sender, EventArgs e)
		{
			this.txtEditor.CurrentState = this.chkIsInErrorState.Checked
				? EditorCurrentState.Error : EditorCurrentState.Normal;
		}

		protected void txtEditor_TextChanged(object sender, EventArgs e)
		{
			this.btnPostback.Text = "Postback (Text Changed)";
		}
	}
}
