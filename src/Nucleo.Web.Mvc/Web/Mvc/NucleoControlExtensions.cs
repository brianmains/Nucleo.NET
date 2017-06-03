using System;
using System.Web.UI;
using System.Web.Mvc;


namespace Nucleo.Web.Mvc
{
	public static class NucleoControlExtensions
	{
		#region " Methods "

		public static NucleoControlFactory NucleoControls(this HtmlHelper html)
		{
			NucleoControlFactory factory = html.ViewContext.HttpContext.Items[typeof(NucleoControlExtensions)] as NucleoControlFactory;

			if (factory == null)
			{
				factory = new NucleoControlFactory(html);
				html.ViewContext.HttpContext.Items.Add(typeof(NucleoControlExtensions), factory);
			}

			return factory;
		}

		#endregion
	}
}
