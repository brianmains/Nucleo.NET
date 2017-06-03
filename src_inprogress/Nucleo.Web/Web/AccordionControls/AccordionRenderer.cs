using System;
using Nucleo.Web.Tags;

namespace Nucleo.Web.AccordionControls
{
	public class AccordionRenderer : WebLegacyRenderer
	{
		#region " Properties "

		new public Accordion Component
		{
			get { return (Accordion)base.Component; }
		}

		#endregion



		#region " Methods "

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("div");
			CommonTagSettings.SetIdentifiers(tag, this.Component);

			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

			foreach (AccordionItem item in this.Component.Items)
				((IRenderableControl)item).RenderUI(writer);

			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
		}

		//protected void RenderItem(AccordionItem accordion, TagElement parent)
		//{
		//    TagElement tag = TagElementBuilder.Create("h3");

		//    TagElement link = TagElementBuilder.Create("a");
		//    link.Attributes.AppendAttribute("href", "#");
		//    link.Content = accordion.Title;

		//    tag.Children.AppendTag(link);
		//    parent.Children.AppendTag(tag);

		//    TagElement contentOuter = TagElementBuilder.Create("div");
		//    TagElement contentInner = TagElementBuilder.Create("div");

		//    contentOuter.Children.AppendTag(contentInner);
		//    parent.Children.AppendTag(contentOuter);
		//}

		#endregion
	}
}