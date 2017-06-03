using System;
using Nucleo.Web.Tags;


namespace Nucleo.Web.ValidationControls
{
	public class BaseValidatorRenderer : WebLegacyRenderer
	{
		#region " Properties "

		new public BaseValidator Component
		{
			get { return (BaseValidator)base.Component; }
		}

		#endregion



		#region " Methods "

		protected virtual void AddContent(TagElement tag)
		{
			if (!string.IsNullOrEmpty(this.Component.DisplayText))
				tag.Content = this.Component.DisplayText;
			else
				tag.Content = this.Component.Message;
		}

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("div")
				.AddStyle("display", "none")
				.AddAttribute("class", "NucleoValidator");
			CommonTagSettings.SetIdentifiers(tag, this.Component);

			this.AddContent(tag);

			writer.Write(tag.ToHtmlString());
		}

		#endregion
	}
}
