using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.ButtonControls.ClientSettings;
using Nucleo.Web.Tags;


namespace Nucleo.Web.ButtonControls
{
	public class ButtonRenderer : WebRenderer
	{
		#region " Properties "

		new public Button Component
		{
			get { return (Button)base.Component; }
		}

		#endregion



		#region " Methods "

		public override TagElement Render()
		{
			TagElement tag = null;

			if (this.Component.Mode == ButtonType.Button)
				tag = this.RenderButton();
			else if (this.Component.Mode == ButtonType.Link)
				tag = this.RenderLinkButton();
			else
				tag = this.RenderImageButton();

			if (this.Component.DisableUntilPageLoad)
				tag.Attributes.AppendAttribute("disabled", "disabled");


			TagElement parent = TagElementBuilder.Create("SPAN");
			CommonTagSettings.SetIdentifiers(parent, this.Component);
			parent.Children.AppendTag(tag);

			return parent;
		}

		private TagElement RenderButton()
		{
			TagElement tag = TagElementBuilder.Create("INPUT");

			tag.Attributes.AppendAttribute("type", this.Component.UseSubmitBehavior ? "submit" : "button")
				.AppendAttribute("value", this.Component.Text);

			string clickScript = this.Component.GetOnClickScript();
			if (!string.IsNullOrEmpty(clickScript))
				tag.Attributes.AppendAttribute("onclick", clickScript);

			return tag;
		}

		private TagElement RenderImageButton()
		{
			if (this.Component.UseSubmitBehavior || this.Component.RenderingMode == RenderMode.ServerOnly)
			{
				TagElement tag = new TagElement("INPUT");
				tag.Attributes.AppendAttribute("src", this.Component.Page.ResolveClientUrl(this.Component.ImageUrl))
					.AppendAttribute("alt", this.Component.ImageAlternateText)
					.AppendAttribute("type", "image");

				return tag;
			}
			else
			{
				TagElement tag = new TagElement("IMG");
				tag.Attributes.AppendAttribute("src", this.Component.Page.ResolveClientUrl(this.Component.ImageUrl));
				tag.Attributes.AppendAttribute("alt", this.Component.ImageAlternateText);
				tag.Attributes.AppendAttribute("onclick", this.Component.GetPostbackScript());

				return tag;
			}
		}

		private TagElement RenderLinkButton()
		{
			TagElement tag = TagElementBuilder.Create("A");
			tag.Content = this.Component.Text;

			string script = this.Component.GetOnClickScript();

			if (string.IsNullOrEmpty(script))
			{
				script = "javascript:void(0);";
			}
			else if (!script.StartsWith("javascript"))
				script = "javascript:" + script;

			tag.Attributes.AppendAttribute("href", script);

			return tag;
		}

		#endregion
	}
}
