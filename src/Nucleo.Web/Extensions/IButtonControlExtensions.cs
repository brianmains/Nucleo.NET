using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace System.Web.UI.WebControls
{
	public static class IButtonControlExtensions
	{
#if NET20
		public static void CopyAttributes(IButtonControl baseButton, IButtonControl newButton)
#else
		public static void CopyAttributes(this IButtonControl baseButton, IButtonControl newButton)
#endif
		{
			newButton.CausesValidation = baseButton.CausesValidation;
			newButton.CommandArgument = baseButton.CommandArgument;
			newButton.CommandName = baseButton.CommandName;
			newButton.PostBackUrl = baseButton.PostBackUrl;
			newButton.Text = baseButton.Text;
			newButton.ValidationGroup = baseButton.ValidationGroup;
		}

#if NET20
		public static Button ToButton(IButtonControl button)
#else
		public static Button ToButton(this IButtonControl button)
#endif
		{
			Button newButton = new Button();
			newButton.CopyBaseAttributes((WebControl)button);
			CopyAttributes(button, newButton);
			return newButton;
		}

#if NET20
		public static ImageButton ToImageButton(IButtonControl button)
#else
		public static ImageButton ToImageButton(this IButtonControl button)
#endif
		{
			ImageButton newButton = new ImageButton();
			newButton.CopyBaseAttributes((WebControl)button);
			CopyAttributes(button, newButton);
			return newButton;
		}

#if NET20
		public static LinkButton ToLinkButton(IButtonControl button)
#else
		public static LinkButton ToLinkButton(this IButtonControl button)
#endif
		{
			LinkButton newButton = new LinkButton();
			newButton.CopyBaseAttributes((WebControl)button);
			CopyAttributes(button, newButton);
			return newButton;
		}
	}
}
