using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.IO;
using Nucleo.Sitemaps;
using Nucleo.Web.Sitemaps;


namespace Nucleo.Sitemaps
{
	public static class SitemapRenderer
	{
		private static string GetDisplayName(string name)
		{
			if (name.EndsWith(".aspx"))
				return name.Replace(".aspx", "");
			else
				return name;
		}

		public static void RenderSitemap(Control parent, SitemapItemCollection items, int index)
		{
			foreach (var item in items)
				RenderSiteMapItem(parent, item, index);
		}

		private static void RenderSiteMapItem(Control parent, SitemapItem item, int index)
		{
			int margin = (20 * index);

			if (item.Location is WebDirectorySitemapLocation)
			{
				var dir = new Label { Text = item.Name };
				dir.Style["display"] = "block";
				dir.Style["margin-left"] = Unit.Pixel(margin).ToString();

				parent.Controls.Add(dir);

				RenderSitemap(parent, item.Items, index + 1);
			}
			else if (item.Location is WebFileSitemapLocation)
			{
				HyperLink link = new HyperLink();
				link.Style["display"] = "block";
				link.Style["margin-left"] = Unit.Pixel(margin).ToString();

				var file = (WebFileSitemapLocation)item.Location;
				link.NavigateUrl = file.WebPath;
				link.Text = GetDisplayName(file.WebName);

				parent.Controls.Add(link);

				RenderSitemap(parent, item.Items, index + 1);
			}
		}
	}
}