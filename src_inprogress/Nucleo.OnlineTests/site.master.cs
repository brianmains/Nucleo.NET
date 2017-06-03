using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Nucleo.Web;
using Nucleo.Framework;
using Nucleo.Web.Scripts;


namespace Nucleo.OnlineTests
{
	public partial class site : System.Web.UI.MasterPage
	{
		#region " Methods "

		private SitemapItem BindCategories(SiteMapCategoryCollection cats)
		{
			this.rptSidebar.DataSource = cats;
			this.rptSidebar.DataBind();

			foreach (var cat in cats)
			{
				var item = cat.Items.FirstOrDefault(j => string.Compare(j.File, this.GetCurrentFile(), true) == 0);
				if (item != null)
					return item;
			}

			return null;
		}

		private void CreateIndex()
		{
			SitemapItem item = null;

			if (SiteMapGeneration.Categories != null)
			{
				item = this.BindCategories(SiteMapGeneration.Categories);
				this.LoadItem(item);
				return;
			}

			lock (typeof(site))
			{
				if (SiteMapGeneration.Categories != null)
				{
					item = this.BindCategories(SiteMapGeneration.Categories);
					this.LoadItem(item);
					return;
				}

				string pageName = Request.ServerVariables.Get("Script_name");

				SiteMapGenerator gen = SiteMapGenerator.Create(
					Server.MapPath("~/Web"), "http://" + Request.ServerVariables.Get("SERVER_NAME") +
						pageName.Substring(0, pageName.IndexOf("/", 2)) + "/Web");
				SiteMapGeneration.Categories = gen.GenerateSitemapHierarchy();

				item = this.BindCategories(SiteMapGeneration.Categories);
				this.LoadItem(item);
			}
		}

		private string GetCurrentFile()
		{
			string rootPath = HttpContext.Current.Request.ServerVariables.Get("APPL_PHYSICAL_PATH");
			string folder = HttpContext.Current.Request.ServerVariables.Get("SCRIPT_NAME");
			folder = folder.Substring(folder.IndexOf("/", 2) + 1).Replace(@"/", @"\");

			return string.Concat(rootPath, folder);
		}

		private void LoadItem(SitemapItem currentItem)
		{
			if (this.Page is ITestPage)
				((ITestPage)this.Page).Item = currentItem;
			if (currentItem == null)
				return;

			var index = SiteMapGeneration.Categories.IndexOf(currentItem.Category);

			if (index >= 0)
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "selected index assignment",
					string.Concat("_selectedIndex = ", index.ToString(), ";"), true);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			ScriptManager mgr = ScriptManager.GetCurrent(this.Page);
			mgr.Scripts.Add(ReferenceScriptManager.GetExternalScript("jquery"));
			mgr.Scripts.Add(ReferenceScriptManager.GetExternalScript("jqueryui"));

			this.CreateIndex();
		}

		#endregion
	}
}
