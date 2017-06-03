using System;
using System.Web.UI;
using System.Collections.Generic;


namespace Nucleo.Web.ClientRegistration.Css
{
	public class SelfTypeCssRegistrar : ICssRegistrar
	{
		#region " Methods "

		public CssReferenceRequestDetailsCollection GetPrimaryDetails(object target)
		{
			Control control = (Control)target;
			return new CssReferenceRequestDetailsCollection(
				new CssReferenceRequestDetails(control.Page.ClientScript.GetWebResourceUrl(control.GetType(), target.GetType().FullName + ".css")));
		}

		#endregion
	}
}
