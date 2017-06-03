using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.StandardizationControls
{
	public abstract class BaseHeader : BaseWebControl
	{
		#region " Properties "

		public override string CssClass
		{
			get { return this.RootCssClass; }
			set {  }
		}

		[
		UrlProperty
		]
		public string ImageUrl
		{
			get { return (string)ViewState["ImageUrl"]; }
			set { ViewState["ImageUrl"] = value; }
		}

		protected abstract string RootCssClass
		{
			get;
		}

		protected abstract string RootTag
		{
			get;
		}

		[
		System.ComponentModel.Description("The text to display in the page title")
		]
		public string Text
		{
			get { return (string)ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		#endregion



		#region " Methods "

		protected virtual void RenderImage(BaseControlWriter writer)
		{
			writer.Write("<img class='" + this.RootCssClass + "Image' src='" + this.ImageUrl + "' alt='Header' />");
		}

		protected virtual void RenderText(BaseControlWriter writer)
		{
			writer.Write("<div class='" + this.RootCssClass + "Text'>" + this.Text + "</div>");
		}

		public override void RenderUI(BaseControlWriter writer)
		{
			writer.WriteUnclosedBeginTag(this.RootTag);
			writer.Write(" class='" + RootCssClass);
			if (!string.IsNullOrEmpty(this.CssClass))
				writer.Write(" " + this.CssClass);
			writer.Write("'>");

			if (!string.IsNullOrEmpty(this.ImageUrl))
				this.RenderImage(writer);
			if (!string.IsNullOrEmpty(this.Text))
				this.RenderText(writer);

			writer.WriteEndTag(this.RootTag);
		}

		#endregion
	}
}
