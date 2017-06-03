using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace System.Web.UI.WebControls
{
	public static class IButtonControlExtensions
	{
		public static void CopyAttributes(this IButtonControl baseButton, IButtonControl newButton)
		{
			newButton.CausesValidation = baseButton.CausesValidation;
			newButton.CommandArgument = baseButton.CommandArgument;
			newButton.CommandName = baseButton.CommandName;
			newButton.PostBackUrl = baseButton.PostBackUrl;
			newButton.Text = baseButton.Text;
			newButton.ValidationGroup = baseButton.ValidationGroup;
		}

		public static Button ToButton(this IButtonControl button)
		{
			Button newButton = new Button();
			newButton.CopyBaseAttributes((WebControl)button);
			CopyAttributes(button, newButton);
			return newButton;
		}

		public static ImageButton ToImageButton(this IButtonControl button)
		{
			ImageButton newButton = new ImageButton();
			newButton.CopyBaseAttributes((WebControl)button);
			CopyAttributes(button, newButton);
			return newButton;
		}

		public static LinkButton ToLinkButton(this IButtonControl button)
		{
			LinkButton newButton = new LinkButton();
			newButton.CopyBaseAttributes((WebControl)button);
			CopyAttributes(button, newButton);
			return newButton;
		}
	}
}
