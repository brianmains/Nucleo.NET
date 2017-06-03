using System;
using System.Web.UI;


namespace Nucleo.Web.Tags
{
	public static class CommonTagSettingsExtensions
	{
		public static void SetIdentifiers(this TagElement tag, Control control)
		{
			CommonTagSettings.SetIdentifiers(tag, control);
		}
	}
}
