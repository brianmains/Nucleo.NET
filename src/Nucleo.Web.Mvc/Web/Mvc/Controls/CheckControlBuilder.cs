using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.Controls;
using Nucleo.Web.Settings;


namespace Nucleo.Web.Mvc.Controls
{
	public class CheckControlBuilder : BaseMvcControlBuilder<Check, CheckControlBuilder>
	{
		#region " Constructors "

		public CheckControlBuilder(NucleoControlFactory controlFactory)
			: base(controlFactory) { }

		#endregion



		#region " Methods "

		public CheckControlBuilder AllowEmptyCheckState(bool allowEmpty)
		{
			this.GetControl().AllowEmptyCheckState = allowEmpty;
			return this;
		}

		public CheckControlBuilder Checked(bool? check)
		{
			this.GetControl().Checked = check;
			return this;
		}

		public CheckControlBuilder Content(string text)
		{
			return this.Content(text, null);
		}

		public CheckControlBuilder Content(string text, string textFormat)
		{
			this.GetControl().Text = text;
			this.GetControl().TextFormat = textFormat;

			return this;
		}

		public CheckControlBuilder ImageOptions(CheckImageOptions options)
		{
			if (options == null)
				throw new ArgumentNullException("options");

			this.GetControl().EmptyImage.CopyFrom(options.EmptyImage);
			this.GetControl().FalseImage.CopyFrom(options.FalseImage);
			this.GetControl().TrueImage.CopyFrom(options.TrueImage);

			return this;
		}

		public CheckControlBuilder ImageOptions(Action<CheckImageOptions> builder)
		{
			if (builder == null)
				throw new ArgumentNullException("builder");

			CheckImageOptions options = new CheckImageOptions();
			builder(options);

			return this;
		}

		public CheckControlBuilder UseDefaultImageOptions()
		{
			this.GetControl().EmptyImage.ImageUrl = Check.GetDefaultEmptyImageUrl(this.GetControl().Page);

			this.GetControl().FalseImage.ImageUrl = Check.GetDefaultNoImageUrl(this.GetControl().Page);
			this.GetControl().FalseImage.DisabledImageUrl = Check.GetDefaultDisabledNoImageUrl(this.GetControl().Page);

			this.GetControl().TrueImage.ImageUrl = Check.GetDefaultYesImageUrl(this.GetControl().Page);
			this.GetControl().TrueImage.DisabledImageUrl = Check.GetDefaultDisabledYesImageUrl(this.GetControl().Page);

			return this;
		}

		#endregion
	}
}
