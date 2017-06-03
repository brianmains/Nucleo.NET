using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Tags;
using Nucleo.Web.Templates;


namespace Nucleo.Web.ListControls
{
	public class PageableListItemRenderer : WebLegacyRenderer
	{
		private IElementTemplate _template = null;



		#region " Properties "

		new public PageableListItem Component
		{
			get { return (PageableListItem)base.Component; }
		}

		public IElementTemplate Template
		{
			get { return _template; }
			set { _template = value; }
		}

		#endregion



		#region " Methods "

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("LABEL");
			CommonTagSettings.SetIdentifiers(tag, this.Component);
			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

			if (this.Template == null)
				this.Template = this.Component.Content;
			ControlRendering.RenderTemplate(this.Template, writer);

			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
		}

		//public override TagElement Render()
		//{
		//    TagElement tag = TagElementBuilder.Create("LABEL");
		//    CommonTagSettings.SetIdentifiers(tag, this.Component);

		//    if (this.Component.RenderingMode == RenderMode.ClientOnly)
		//        return tag;
		//    else
		//    {
		//        IElementTemplate template = this.Component.ControlTemplate.ServerTemplate;
		//        if (template == null)
		//            throw new ArgumentNullException("The server template of the PageableListItem's content is required.");

		//        if (template.ReturnsContent)
		//        {
		//            Label label = new Label();
		//            label.ID = this.Component.ClientID;

		//            tag.Content = ControlUtility.GetTemplateMarkup(label, this.Component.ControlTemplate.ServerTemplate);
		//        }
		//        else
		//            template.InvokeTemplate();
		//    }

		//    return tag;
		//}

		#endregion
	}
}
