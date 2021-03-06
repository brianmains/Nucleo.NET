﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.IO;
using Nucleo.Sitemaps;
using Nucleo.Web.Sitemaps;


namespace Nucleo.Demos.MvpScenarios
{
	public partial class Home : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			var dir = Server.MapPath(this.AppRelativeVirtualPath).Replace(@"Home.aspx", "");
			var webroot = "/Demos/MvpScenarios";

			var provider = new WebFormsDirectorySitemapProvider(new DirectorySearcher(), dir, webroot);

			var items = provider.GetAllItems();
			SitemapRenderer.RenderSitemap(this.pnlSitemap, items, 0);
		}
	}
}