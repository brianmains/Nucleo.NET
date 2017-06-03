using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Context;
using Nucleo.Web.Context.Services;


namespace Nucleo.Web.Context
{
	public partial class ServerUtilityServiceFirstLook : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			IServerUtilityService service = ApplicationContext.GetCurrent().GetService<IServerUtilityService>();
			this.lblMapPath.Text = service.MapPath("~/Web/test.txt");
			this.lblMachineName.Text = service.MachineName;
			this.lblScriptTimeout.Text = service.ScriptTimeout.ToString();

			this.lblEncodedText.Text = service.HtmlEncode("<b>My Text</b>");
			this.lblDecodedText.Text = service.HtmlDecode("My&amp;nbsp;Text%20Now");
		}
	}
}
