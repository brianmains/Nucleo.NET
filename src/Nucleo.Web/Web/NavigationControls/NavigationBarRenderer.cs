using System;
using System.Web.UI;

using Nucleo.Web.Tags;


namespace Nucleo.Web.NavigationControls
{
	public class NavigationBarRenderer : WebLegacyRenderer
	{
		#region " Properties "

		new public NavigationBar Component
		{
			get { return (NavigationBar)base.Component; }
		}

		#endregion



		#region " Methods "

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("DIV");
			CommonTagSettings.SetIdentifiers(tag, this.Component);
			tag.Attributes.AppendAttribute("class", "NavigationBarItemContainer");

			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

			foreach (NavigationBarItem item in this.Component.Items)
			{
				((IRenderableControl)item).RenderUI(writer);
			}

			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
		}
		
		#endregion
	}
}
