using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Nucleo.Web;
using Nucleo.Web.Mvc;
using Nucleo.Web.DropDownControls;
using Nucleo.Web.Templates;


namespace Nucleo.Web.Mvc.DropDownControls
{
	/// <summary>
	/// Represents the control builder for the ASP.NET AJAX drop down control.  The <see cref="Nucleo.Web.DropDownControls.DropDown">DropDown control</see> provides the core functionality; the two use the same framework and features to provide the user interface.
	/// </summary>
    public class DropDownControlBuilder : BaseMvcControlBuilder<DropDown, DropDownControlBuilder>
	{
		private IElementTemplate _template = null;



		#region " Constructors "

		/// <summary>
		/// Creates the control builder, using the control factory reference for internal configuration.
		/// </summary>
		/// <param name="controlFactory">The base control factory.</param>
		public DropDownControlBuilder(NucleoControlFactory controlFactory)
			: base(controlFactory) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Sets the content of the drop down, using an action to supply the content.
		/// </summary>
		/// <param name="content">The content of the drop down.</param>
		/// <returns>Returns the control builder.</returns>
		public DropDownControlBuilder Content(System.Action content)
		{
			if (content == null)
				throw new NullReferenceException("The server and client template are both null.");

			_template = new ActionElementTemplate(content);
			return this;
		}

		/// <summary>
		/// Sets the input options for the drop down (the input text box).  Use this to configure specific settings about the drop down.
		/// </summary>
		/// <param name="builder">The input options for the control.</param>
		/// <returns>Returns the control builder.</returns>
		public DropDownControlBuilder InputOptions(DropDownInputOptions builder)
		{
			if (builder == null)
				return this;

			this.GetControl().InputOptions = builder;
			return this;
		}

		/// <summary>
		/// Sets the input options for the drop down (the input text box).  Use this to configure specific settings about the drop down.
		/// </summary>
		/// <param name="builder">The input options for the control.</param>
		/// <returns>Returns the control builder.</returns>
		public DropDownControlBuilder InputOptions(Action<DropDownInputOptions> builder)
		{
			DropDownInputOptions options = new DropDownInputOptions();
			builder(options);

			return this.InputOptions(options);
		}

		/// <summary>
		/// Sets the menu options for the drop down (the drop down area).  Use this to configure specific settings about the drop down.
		/// </summary>
		/// <param name="builder">The menu options for the control.</param>
		/// <returns>Returns the control builder.</returns>
		public DropDownControlBuilder MenuOptions(DropDownMenuOptions builder)
		{
			if (builder == null)
				return this;

			this.GetControl().MenuOptions = builder;
			return this;
		}

		/// <summary>
		/// Sets the menu options for the drop down (the drop down area).  Use this to configure specific settings about the drop down.
		/// </summary>
		/// <param name="builder">The menu options for the control.</param>
		/// <returns>Returns the control builder.</returns>
		public DropDownControlBuilder MenuOptions(Action<DropDownMenuOptions> builder)
		{
			DropDownMenuOptions options = new DropDownMenuOptions();
			builder(options);

			return this.MenuOptions(options);
		}

		/// <summary>
		/// Renders the drop down UI in a custom way to take advantage of the action template.
		/// </summary>
		/// <param name="writer">The writer to write to the output stream.</param>
		protected override void RenderUI(BaseControlWriter writer)
		{
			DropDownRenderer renderer = new DropDownRenderer();
			renderer.Initialize(this.GetControl(), this.GetControl().Page);

			renderer.Template = _template;

			renderer.Render(writer);
		}

		/// <summary>
		/// Sets the menu options for the drop down selector (the image for the drop down).  Use this to configure specific settings about the drop down selector.
		/// </summary>
		/// <param name="builder">The selector options for the control.</param>
		/// <returns>Returns the control builder.</returns>
		public DropDownControlBuilder SelectorOptions(DropDownSelectorOptions builder)
		{
			if (builder == null)
				return this;

			this.GetControl().SelectorOptions = builder;
			return this;
		}

		/// <summary>
		/// Sets the menu options for the drop down selector (the image for the drop down).  Use this to configure specific settings about the drop down selector.
		/// </summary>
		/// <param name="builder">The selector options for the control.</param>
		/// <returns>Returns the control builder.</returns>
		public DropDownControlBuilder SelectorOptions(Action<DropDownSelectorOptions> builder)
		{
			DropDownSelectorOptions options = new DropDownSelectorOptions();
			builder(options);

			return this.SelectorOptions(options);
		}

		/// <summary>
		/// Sets the text for the drop down, which is the text of the input control itself.
		/// </summary>
		/// <param name="text">The text of the control.</param>
		/// <returns>Returns the control builder.</returns>
		public DropDownControlBuilder Text(string text)
		{
			this.GetControl().Text = text;
			return this;
		}

		#endregion
	}
}