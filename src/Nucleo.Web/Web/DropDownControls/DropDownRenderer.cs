using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Nucleo.Web.Tags;
using Nucleo.Web.Templates;


namespace Nucleo.Web.DropDownControls
{
	/// <summary>
	/// Renders the content of the drop down.
	/// </summary>
	public class DropDownRenderer : WebLegacyRenderer
	{
		private IElementTemplate _template = null;



		#region " Properties "

		/// <summary>
		/// Gets the reference to the drop down component.
		/// </summary>
		new public DropDown Component
		{
			get { return (DropDown)base.Component; }
		}

		public IElementTemplate Template
		{
			get { return _template; }
			set { _template = value; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Renders the control, returning the HTML markup in a tag.
		/// </summary>
		/// <returns>The tag of the drop down.</returns>
		//public override TagElement Render()
		//{
		//    TagElement tag = TagElementBuilder.Create("DIV");
		//    CommonTagSettings.SetIdentifiers(tag, this.Component);

		//    this.RenderTagInputElement(tag);
		//    this.RenderTagSelectorElement(tag);
		//    this.RenderTagMenuElement(tag);

		//    return tag;
		//}

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("DIV");
			CommonTagSettings.SetIdentifiers(tag, this.Component);
			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

			this.RenderTagInputElement(tag, writer);
			this.RenderTagSelectorElement(tag, writer);
			this.RenderTagMenuElement(tag, writer);

			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
		}

		/// <summary>
		/// Renders the input element of the drop down.
		/// </summary>
		/// <param name="parent">The parent element to append to.s</param>
		public virtual void RenderTagInputElement(TagElement parent, BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("INPUT");
			CommonTagSettings.SetIdentifiers(tag, this.Component, this.Component.InputOptions.ControlID);

			tag.Attributes
				.AppendAttribute("type", "text")
				.AppendAttribute("value", this.Component.Text ?? "")
				.AppendAttribute("class", "DropDownInput")
				.AppendAttribute("disabled", this.Component.InputOptions.Enabled ? "" : "disabled");

			writer.Write(tag.ToHtmlString());
			//parent.Children.AppendTag(tag);
		}

		/// <summary>
		/// Renders the menu's content, which consists of the content panel, followed by the close button panel, and then ensures the float options are closed.
		/// </summary>
		/// <param name="parent">The parent element to add to.</param>
		/// <remarks>The float options are specified within the CSS.</remarks>
		public virtual void RenderTagMenuContentElement(TagElement parent, BaseControlWriter writer)
		{
			//***************
			//Render the main content
			//***************
			TagElement child = TagElementBuilder.Create("DIV");
			child.Attributes.AppendAttribute("class", "DropDownMenuContent");
			child.Styles.AppendAttribute("width", (this.Component.MenuOptions.Width > 0 ? this.Component.MenuOptions.Width : 300).ToString() + "px");
			writer.Write(child.ToHtmlString(TagRenderingMode.BeginTag));

			if (this.Template == null)
				this.Template = this.Component.GetContent();
			ControlRendering.RenderTemplate(this.Template, writer);

			writer.Write(child.ToHtmlString(TagRenderingMode.EndTag));
			//parent.Children.AppendTag(child);
			
			//***************
			//Render the close tag on the right.
			//***************
			child = TagElementBuilder.Create("DIV");
			child.Attributes.AppendAttribute("class", "DropDownMenuClose");

			//Create and add a close button
			TagElement closeButton = TagElementBuilder.Create("DIV");
			CommonTagSettings.SetIdentifiers(closeButton, this.Component, this.Component.MenuOptions.CloseButtonControlID);

			closeButton.Attributes.AppendAttribute("class", "DropDownMenuCloseImage");
			child.Children.AppendTag(closeButton);

			writer.Write(child.ToHtmlString());
			//parent.Children.AppendTag(child);

			//***************
			//Clearing then pushes content down
			//***************
			child = TagElementBuilder.Create("DIV");
			child.Styles.AppendAttribute("clear", "both");

			writer.Write(child.ToHtmlString());
			//parent.Children.AppendTag(child);
		}

		/// <summary>
		/// Renders the menu, minus the content.
		/// </summary>
		/// <param name="parent">The parent element to append to.</param>
		public virtual void RenderTagMenuElement(TagElement parent, BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("DIV");
			CommonTagSettings.SetIdentifiers(tag, this.Component, this.Component.MenuOptions.ControlID);

			tag.Styles.AppendAttribute("display", "none");
			tag.Attributes.AppendAttribute("class", "DropDownMenu");

			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

			this.RenderTagMenuContentElement(tag, writer);

			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
			//parent.Children.AppendTag(tag);
		}

		/// <summary>
		/// Renders the selector element, which is the drop down trigger to show/hide the menu.
		/// </summary>
		/// <param name="parent">The parent to append to.</param>
		public virtual void RenderTagSelectorElement(TagElement parent, BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("IMG");
			CommonTagSettings.SetIdentifiers(tag, this.Component, this.Component.SelectorOptions.ControlID);

			if (!string.IsNullOrEmpty(this.Component.SelectorOptions.ImageUrl))
				tag.Attributes.AppendAttribute("src", this.Component.SelectorOptions.ImageUrl)
					.AppendAttribute("class", "DropDownSelector");
			else
				tag.Attributes.AppendAttribute("class", "DropDownSelector DropDownSelectorImage");

			writer.Write(tag.ToHtmlString());
			//parent.Children.AppendTag(tag);
		}

		#endregion
	}
}