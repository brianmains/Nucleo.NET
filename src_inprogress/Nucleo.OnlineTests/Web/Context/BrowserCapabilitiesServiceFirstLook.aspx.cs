using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Context;
using Nucleo.Web.Context.Services;
using Nucleo.Web.Browsers;


namespace Nucleo.Web.Context
{
	public partial class BrowserCapabilitiesServiceFirstLook : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			var service = ApplicationContext.GetCurrent().GetService<IBrowserCapabilitiesService>();
			var values = service.GetAll();

			foreach (KeyValuePair<BrowserCapability, object> value in values)
				this.lblOutput.Text += string.Format("<div>{0}={1}</div>",
					value.Key.Name, value.Value);
		}
	}
}
