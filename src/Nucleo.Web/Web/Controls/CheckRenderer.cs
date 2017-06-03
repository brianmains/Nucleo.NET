using System;
using System.Collections.Generic;

using Nucleo.Web.Tags;


namespace Nucleo.Web.Controls
{
	public class CheckRenderer : WebRenderer
	{
		#region " Properties "

		new public Check Component
		{
			get { return (Check)base.Component; }
		}

		#endregion



		#region " Methods "

		public override TagElement Render()
		{
			TagElement parent = TagElementBuilder.Create("SPAN");
			CommonTagSettings.SetIdentifiers(parent, this.Component);
			parent.Attributes.AppendAttribute("class", "NucleoCheck");

			parent.Children.AppendTags(
				this.RenderCheckboxImage(),
				this.RenderLabel()
			);

			return parent;
		}

		private TagElement RenderCheckboxImage()
		{
			TagElement element = TagElementBuilder.Create("IMG");
			element.Attributes.AppendAttribute("src", this.Component.GetSelectedImageUrl())
				.AppendAttribute("alt", "");
			
			if (this.Component.RenderingMode == RenderMode.ServerOnly && this.Component.Enabled)
				element.Attributes.AppendAttribute("onclick", ControlUtility.GetPostbackClientMethod(this.Component.UniqueID, "toggle"));

			return element;
		}

		private TagElement RenderLabel()
		{
			TagElement element = TagElementBuilder.Create("LABEL");
			element.Attributes.AppendAttribute("for", this.Component.ClientID);
			element.Content = this.Component.GetText();

			return element;
		}

		#endregion
	}
}
