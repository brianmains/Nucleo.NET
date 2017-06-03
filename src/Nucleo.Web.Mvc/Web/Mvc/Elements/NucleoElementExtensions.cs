using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Nucleo.Web.Mvc.Elements
{
	public static class NucleoElementExtensions
	{
		#region " Methods "

		public static NucleoElementFactory NucleoElements(this HtmlHelper html)
		{
			NucleoElementFactory factory = html.ViewContext.HttpContext.Items[typeof(NucleoElementExtensions)] as NucleoElementFactory;
			
			if (factory == null)
			{
				factory = new NucleoElementFactory(html);
				html.ViewContext.HttpContext.Items.Add(typeof(NucleoElementExtensions), factory);
			}

			return factory;
		}

		#endregion
	}
}
