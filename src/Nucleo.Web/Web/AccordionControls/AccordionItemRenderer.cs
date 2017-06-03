using System;

using Nucleo.Web.Tags;


namespace Nucleo.Web.AccordionControls
{
	public class AccordionItemRenderer : WebLegacyRenderer
	{
		#region " Properties "

		new protected AccordionItem Component
		{
			get { return (AccordionItem)base.Component; }
		}

		#endregion



		#region " Methods "

		private string GetClassName(string region)
		{
			return "NucleoAccordion" + region + (this.Component.IsSelected ? "Selected" : "");
		}

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("div");
			CommonTagSettings.SetIdentifiers(tag, this.Component);
			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

			writer.Write(this.RenderHeader().ToHtmlString());
			writer.Write(this.RenderContent().ToHtmlString());

			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
		}

		private TagElement RenderContent()
		{
			TagElement tag = TagElementBuilder.Create("div");
			tag.Attributes.AppendAttribute("class", this.GetClassName("Content"));
			tag.Styles.AppendAttribute("display", this.Component.IsSelected ? "block" : "none");

			tag.Content = this.Component.GetTemplateContent();

			return tag;
		}

		private TagElement RenderHeader()
		{
			TagElement tag = TagElementBuilder.Create("h3");
			tag.Attributes.AppendAttribute("class", this.GetClassName("Header"));

			TagElement link = TagElementBuilder.Create("a");
			link.Attributes.AppendAttribute("href", "#")
				.AppendAttribute("class", this.GetClassName("HeaderLink"));
			link.Content = this.Component.Title;
			tag.Children.AppendTag(link);

			return tag;
		}

		#endregion
	}
}
