using System;
using System.Web.UI;

using Nucleo.Web.Tags;


namespace Nucleo.Web.NavigationControls
{
	public class NavigationBarContainerRenderer : WebLegacyRenderer
	{
		#region " Properties "

		new public NavigationBarContainer Component
		{
			get { return (NavigationBarContainer)base.Component; }
		}

		#endregion



		#region " Methods "

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("table");
			CommonTagSettings.SetIdentifiers(tag, this.Component);

			if (!this.Component.Width.IsEmpty)
				tag.Styles.AppendAttribute("width", this.Component.Width.ToString());
			if (!this.Component.Height.IsEmpty)
				tag.Styles.AppendAttribute("height", this.Component.Height.ToString());

			tag.Children.AppendTag(TagElementBuilder.Create("THEAD"));

			TagElement body = TagElementBuilder.Create("TBODY");
			tag.Children.AppendTag(body);

			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

			foreach (NavigationBar bar in this.Component.Bars)
			{
				writer.Write("<tr><td>");

				((IRenderableControl)bar).RenderUI(writer);

				writer.Write("</td></tr>");
			}

			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
		}

		#endregion
	}
}
