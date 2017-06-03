using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Nucleo.Web.Tags;
using Nucleo.Web.Templates;


namespace Nucleo.Web.NavigationControls
{
	public class NavigationBarItemRenderer : WebLegacyRenderer
	{
		private IElementTemplate _template = null;



		#region " Properties "

		new public NavigationBarItem Component
		{
			get { return (NavigationBarItem)base.Component; }
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
			TagElement element = TagElementBuilder.Create("SPAN");
			CommonTagSettings.SetIdentifiers(element, this.Component);

			if (this.Component.IsSelected)
				element.Attributes.AppendAttribute("class", "NavigationBarItemSelected");
			else
				element.Attributes.AppendAttribute("class", "NavigationBarItem");

			if (this.Component.RenderingMode == RenderMode.ServerOnly)
				element.Attributes.AppendAttribute("onclick",
					ControlUtility.GetPostbackClientMethod(this.Component.UniqueID, "Click"));

			writer.Write(element.ToHtmlString(TagRenderingMode.BeginTag));

			if (this.Template == null)
				this.Template = this.Component.Content;

			if (this.Template != null)
			{
				if (this.Template.ReturnsContent)
					writer.Write(this.Template.GetTemplate());
				else
					this.Template.InvokeTemplate();
			}
			else
				writer.Write(this.Component.Text ?? "&nbsp;");

			writer.Write(element.ToHtmlString(TagRenderingMode.EndTag));
		}

		//public override TagElement Render()
		//{
		//    TagElement element = TagElementBuilder.Create("DIV");
		//    CommonTagSettings.SetIdentifiers(element, this.Component);
		//    CommonTagSettings.SetStyles(element, this.Component.Styling);

		//    if (this.Component.IsSelected)
		//        element.Attributes.AppendAttribute("class", "NavigationBarItemSelected");
		//    else
		//        element.Attributes.AppendAttribute("class", "NavigationBarItem");

		//    if (this.Component.RenderingMode != RenderMode.ClientOnly)
		//    {
		//        if (this.Component.ContentTemplate != null &&
		//            this.Component.ContentTemplate.ServerTemplate != null)
		//        {
		//            Label container = new Label();
		//            element.Content = this.Component.ContentTemplate.ServerTemplate.GetTemplate();
		//        }
		//        else
		//            element.Content = this.Component.Text ?? "&nbsp;";
		//    }

		//    if (this.Component.RenderingMode == RenderMode.ServerOnly)
		//        element.Attributes.AppendAttribute("onclick",
		//            ControlUtility.GetPostbackClientMethod(this.Component.UniqueID, "Click"));

		//    return element;
		//}

		#endregion
	}
}
