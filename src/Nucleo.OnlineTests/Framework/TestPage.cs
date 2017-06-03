using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web;
using Nucleo.Web.Pages;


namespace Nucleo.Framework
{
	public class TestPage : PageBase, ITestPage
	{
		private SitemapItem _item = null;



		#region " Properties "

		protected virtual string Description
		{
			get { return "No description."; }
		}

		string ITestPage.Description
		{
			get { return this.Description; }
		}

		public SitemapItem Item
		{
			get { return _item; }
			set { _item = value; }
		}

		#endregion



		#region " Methods "

		public void AddTraceStatement(string statement)
		{
			var master = this.Master as TestMasterPage;
			if (master != null)
				master.AddTraceStatement(statement);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			var master = this.Master as TestMasterPage;
			if (master != null)
			{
				master.Description = this.Description;
				master.Aspx = string.Format("<xmp>{0}</xmp>", this.Item.Aspx);
				master.Code = string.Format("<xmp>{0}</xmp>", this.Item.Code);
			}
		}

		#endregion
	}

	public interface ITestPage
	{
		string Description { get; }
		SitemapItem Item { get; set; }
	}
}