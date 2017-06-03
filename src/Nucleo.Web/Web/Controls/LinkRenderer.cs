using System;
using System.Collections.Generic;

using Nucleo.Web.Tags;


namespace Nucleo.Web.Controls
{
	public class LinkRenderer : WebRenderer
	{
		#region " Properties "

		new public Link Component
		{
			get { return (Link)base.Component; }
		}

		#endregion


		public override TagElement Render()
		{
			TagElement parent = TagElementBuilder.Create("SPAN");
			CommonTagSettings.SetIdentifiers(parent, this.Component);

			TagElement child = null;

			if (this.Component.ClickAction == LinkClickAction.Redirect)
				child = this.RenderRedirectLink();
			else
				child = this.RenderDefaultLink();

			parent.Children.AppendTag(child);

			return parent;
		}

		private TagElement RenderDefaultLink()
		{
			TagElement element = TagElementBuilder.Create("A");

			if (this.Component.RenderingMode != RenderMode.ClientOnly)
				element.Attributes.AppendAttribute("href", NucleoAjaxManager.GetPostbackClientHyperlink(this.Component, "click"));
			else
				//Attached to on client component, don't need href
				element.Attributes.AppendAttribute("href", "javascript:void(0);");

			element.Content = this.Component.GetText();

			return element;
		}

		private TagElement RenderRedirectLink()
		{
			TagElement element = TagElementBuilder.Create("A");
			element.Attributes.AppendAttribute("href", this.Component.GetUrl())
				.AppendAttribute("target", this.Component.GetTarget());
			element.Content = this.Component.GetText();

			return element;
		}
	}
}
