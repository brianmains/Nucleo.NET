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
	public partial class PostDataServiceFirstLook : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			IPostDataService service = ApplicationContext.GetCurrent().GetService<IPostDataService>();
			var postData = service.GetAll();

			foreach (string key in postData.AllKeys)
			{
				if (key.StartsWith("ctl"))
					this.lblOutput.Text += string.Concat(key, "=", postData.Get(key), "<br/>");
			}
		}
	}
}
