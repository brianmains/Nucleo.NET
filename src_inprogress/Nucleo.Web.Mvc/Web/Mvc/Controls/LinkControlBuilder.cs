using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.Controls;


namespace Nucleo.Web.Mvc.Controls
{
	public class LinkControlBuilder : BaseMvcControlBuilder<Link, LinkControlBuilder>
	{
		#region " Constructors "

		public LinkControlBuilder(NucleoControlFactory controlFactory)
			: base(controlFactory) { }

		#endregion



		#region " Methods "

		public LinkControlBuilder ClickAction(LinkClickAction action)
		{
			if (action == null)
				throw new ArgumentNullException("action");

			this.GetControl().ClickAction = action;
			return this;
		}

		public LinkControlBuilder Content(string text)
		{
			return this.Content(text, null);
		}

		public LinkControlBuilder Content(string text, string textFormat)
		{
			this.GetControl().Text = text;
			this.GetControl().TextFormat = textFormat;

			return this;
		}

		public LinkControlBuilder Navigation(string navigateUrl)
		{
			return this.Navigation(navigateUrl, null);
		}

		public LinkControlBuilder Navigation(string navigateUrl, string formatString)
		{
			this.GetControl().NavigateUrl = navigateUrl;
			this.GetControl().NavigateUrlFormatString = formatString;

			return this;
		}

		public LinkControlBuilder Target(LinkTargetOptions target)
		{
			this.GetControl().Target = target;
			return this;
		}

		#endregion
	}
}
