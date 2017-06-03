using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

using Nucleo.Web.ButtonControls;
using Nucleo.Web.Styles;


namespace Nucleo.Web.Mvc.ButtonControls
{
	/// <summary>
	/// Represents the control builder for the button.
	/// </summary>
	public class ButtonControlBuilder : BaseMvcControlBuilder<Nucleo.Web.ButtonControls.Button, ButtonControlBuilder>
	{
		#region " Constructors "

		/// <summary>
		/// Creates the control builder.
		/// </summary>
		/// <param name="controlFactory">The factory.</param>
		public ButtonControlBuilder(NucleoControlFactory controlFactory)
			: base(controlFactory) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Internally assigns the button options.
		/// </summary>
		/// <param name="options">The options to set.</param>
		private void AssignOptions(ButtonViewOptions options)
		{
			if (options.Command != null)
			{
				this.GetControl().CommandName = options.Command.Name;
				this.GetControl().CommandArgument = options.Command.Argument;
			}

			this.GetControl().OnClientClick = options.OnClientClick;
			this.GetControl().PostBackAlways = options.PostBackAlways;
			this.GetControl().PostBackUrl = options.PostBackUrl;
			this.GetControl().ValidationGroup = options.ValidationGroup;
			this.GetControl().VisibilityGroup = options.VisibilityGroup;
		}

		/// <summary>
		/// Specifies the options used to disable the button, if disabling is desired on click.  Disabling options aren't necessarily a permanent disabling of the button.
		/// </summary>
		/// <param name="disableOnFirstClick">Whether to disable the button once it's first clicked.</param>
		/// <param name="disableOnFirstClickTimeout">Whether to re-enable the button after that first click.</param>
		/// <param name="disableUntilPageLoad">Whether to disable the button until the page load event has fired.</param>
		/// <returns>The builder control reference.</returns>
		public ButtonControlBuilder DisablingOptions(bool disableOnFirstClick, int disableOnFirstClickTimeout, bool disableUntilPageLoad)
		{
			this.GetControl().DisableOnFirstClick = disableOnFirstClick;
			this.GetControl().DisableOnFirstClickTimeout = disableOnFirstClickTimeout;
			this.GetControl().DisableUntilPageLoad = disableUntilPageLoad;

			return this;
		}

		protected override void Initialize()
		{
			this.GetControl().Mode = ButtonType.Button;
		}

		/// <summary>
		/// Sets the text of the button.
		/// </summary>
		/// <param name="text">The text of the button.</param>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder Text(string text)
		{
			this.GetControl().Text = text;
			return this;
		}

		/// <summary>
		/// Specify that the button uses a standard push button as its interface.
		/// </summary>
		/// <param name="options">The options for the button.</param>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseButton()
		{
			return UseButton(default(ButtonViewOptions));
		}

		/// <summary>
		/// Specify that the button uses a standard push button as its interface.
		/// </summary>
		/// <param name="options">The options for the button.</param>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseButton(ButtonViewOptions options)
		{
			this.GetControl().Mode = ButtonType.Button;

			if (options != null)
				this.AssignOptions(options);

			return this;
		}

		/// <summary>
		/// Specify that the button uses a standard push button as its interface.
		/// </summary>
		/// <param name="builder">The options for the button.</param>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseButton(Action<ButtonViewOptions> builder)
		{
			ButtonViewOptions options = new ButtonViewOptions();
			builder(options);

			return this.UseButton(options);
		}

		/// <summary>
		/// Specifies the button to use an image button interface.
		/// </summary>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseImageButton()
		{
			return this.UseButton(default(ImageButtonViewOptions));
		}

		/// <summary>
		/// Specifies the button to use an image button interface.
		/// </summary>
		/// <param name="options">The options for the image button.</param>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseImageButton(ImageButtonViewOptions options)
		{
			this.GetControl().Mode = ButtonType.Image;

			if (options != null)
			{
				this.AssignOptions(options);

				this.GetControl().ImageUrl = options.ImageUrl;
				this.GetControl().ImageAlternateText = options.ImageAlternateText;
			}

			return this;
		}

		/// <summary>
		/// Specifies the button to use an image button interface.
		/// </summary>
		/// <param name="options">The options for the image button.</param>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseImageButton(Action<ImageButtonViewOptions> builder)
		{
			ImageButtonViewOptions options = new ImageButtonViewOptions();
			builder(options);

			return this.UseImageButton(builder);
		}

		/// <summary>
		/// Specifies the button to use an link button interface.
		/// </summary>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseLinkButton()
		{
			return this.UseLinkButton(default(ButtonViewOptions));
		}

		/// <summary>
		/// Specifies the button to use an link button interface.
		/// </summary>
		/// <param name="options">The options for the link button.</param>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseLinkButton(ButtonViewOptions options)
		{
			this.GetControl().Mode = ButtonType.Link;

			if (options != null)
				this.AssignOptions(options);

			return this;
		}

		/// <summary>
		/// Specifies the button to use an link button interface.
		/// </summary>
		/// <param name="builder">The options for the link button.</param>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseLinkButton(Action<ButtonViewOptions> builder)
		{
			ButtonViewOptions options = new ButtonViewOptions();
			builder(options);

			return this.UseLinkButton(options);
		}

		/// <summary>
		/// Sets the submit behavior of the button.
		/// </summary>
		/// <param name="useSubmitBehavior">Whether to use submit behavior.</param>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder UseSubmitBehavior(bool useSubmitBehavior)
		{
			this.GetControl().UseSubmitBehavior = useSubmitBehavior;
			return this;
		}

		#endregion
	}
}
