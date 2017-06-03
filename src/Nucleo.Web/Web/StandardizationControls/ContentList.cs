using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.StandardizationControls
{
	[
	ParseChildren(true, "Items")
	]
	public class ContentList : BaseWebControl
	{
		#region " Properties "

		public override string CssClass
		{
			get { return "NucleoContentList"; }
			set { }
		}

		public ContentListItemCollection Items
		{
			get { return (ContentListItemCollection)base.Controls; }
		}

		#endregion



		#region " Methods "

		protected override ControlCollection CreateControlCollection()
		{
			return new ContentListItemCollection(this);
		}

		public override void RenderUI(BaseControlWriter writer)
		{
			writer.WriteUnclosedBeginTag("div");
			writer.Write("class='" + this.CssClass + "'>");

			foreach (ContentListItem item in this.Items)
			{
				
			}

			writer.WriteEndTag("div");
		}

		#endregion
	}
}
