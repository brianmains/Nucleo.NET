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
	public partial class UrlResolutionServiceFirstLook : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			var service = ApplicationContext.GetCurrent().GetService<Nucleo.Web.Context.Services.IUrlResolutionService>();
			this.lblResolvedUrl.Text = service.GetClientBasedUrl("~/App_Data/ImageServices.xml");
			this.lblMappedUrl.Text = service.GetWebServerUrl("~/App_Data/ImageServices.xml");
		}
	}
}
