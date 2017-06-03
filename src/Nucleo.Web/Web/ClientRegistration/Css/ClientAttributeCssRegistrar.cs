using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Reflection;

using Nucleo.Reflection;


namespace Nucleo.Web.ClientRegistration.Css
{
	public class ClientAttributeCssRegistrar : ICssRegistrar
	{

		#region " Methods "

		public CssReferenceRequestDetailsCollection GetPrimaryDetails(object target)
		{
			ClientCssAttribute[] attributes = Reflect.Public(target).Type().GetAttributes<ClientCssAttribute>(true);
			Control control = (Control)target;
			var list = new CssReferenceRequestDetailsCollection();

			foreach (ClientCssAttribute attribute in attributes)
				list.Add(new CssReferenceRequestDetails(control.Page.ClientScript.GetWebResourceUrl(control.GetType(), attribute.Path)));

			return list;
		}

		#endregion
	}
}
