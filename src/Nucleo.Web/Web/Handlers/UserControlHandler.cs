using System;
using System.Web;
using System.Web.UI;


namespace Nucleo.Web.Handlers
{
	public class UserControlHandler : HttpHandlerBase
	{
		#region " Methods "

		private Control GetControl(HttpContextBase context, Page page)
		{
			// URL path given by load(fn) method on click of button
			string strPath = context.Request.Url.LocalPath;

			if (!strPath.EndsWith(".ascx"))
				strPath = context.Request.QueryString.Get("UserControl");

			return page.LoadControl(strPath) as UserControl;
		}

		public override void ProcessRequest(HttpContextBase context)
		{
			// We add control in Page tree collection
			using (var page = new Page())
			{
				page.Controls.Add(GetControl(context, page));
				context.Server.Execute(page, context.Response.Output, true);
			}
		}

		#endregion
	}
}
