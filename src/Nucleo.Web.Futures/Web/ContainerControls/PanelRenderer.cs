using System;

using Nucleo.Web.Tags;
using Nucleo.Web.Templates;


namespace Nucleo.Web.ContainerControls
{
	/// <summary>
	/// Represents the rendering feature for the panel.
	/// </summary>
	public class PanelRenderer : WebLegacyRenderer
	{
		private IElementTemplate _template = null;



		#region " Properties "

		/// <summary>
		/// Gets the reference to the drop down component.
		/// </summary>
		new public Panel Component
		{
			get { return (Panel)base.Component; }
		}

		/// <summary>
		/// Gets or sets the template to use.
		/// </summary>
		public IElementTemplate Template
		{
			get { return _template; }
			set { _template = value; }
		}

		#endregion



		#region " Methods "

		private void CreateTitleTag(TagElement parent)
		{
			TagElement titleChild = TagElementBuilder.Create("DIV");
			parent.Children.AppendTag(titleChild);

			titleChild.Attributes.AppendAttribute("class", "NucleoPanelTitleBar");

			titleChild.Content = this.Component.Title;
			if (string.IsNullOrEmpty(this.Component.Title))
				titleChild.Styles.AppendAttribute("display", "none");
		}

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("DIV");
			CommonTagSettings.SetIdentifiers(tag, this.Component);
			tag.Attributes.AppendAttribute("class", "NucleoPanelWrapper");

			this.CreateTitleTag(tag);

			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));
			writer.Write(tag.ToHtmlString(TagRenderingMode.Children));

			TagElement contentChild = TagElementBuilder.Create("DIV");
			//tag.Children.AppendTag(contentChild);
			contentChild.Attributes.AppendAttribute("class", "NucleoPanelContent");

			if (!this.Component.Height.IsEmpty)
				contentChild.Styles.AppendAttribute("height", this.Component.Height.ToString());
			if (!this.Component.Width.IsEmpty)
				contentChild.Styles.AppendAttribute("width", this.Component.Width.ToString());
			writer.Write(contentChild.ToHtmlString(TagRenderingMode.BeginTag));

			if (this.Template == null)
				this.Template = this.Component.Content;

			if (this.Template != null)
				ControlRendering.RenderTemplate(this.Template, writer);

			writer.Write(contentChild.ToHtmlString(TagRenderingMode.EndTag));
			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
		}

		#endregion
	}
}