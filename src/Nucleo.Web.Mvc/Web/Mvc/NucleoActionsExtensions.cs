using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Nucleo.Web.Mvc
{
	public static class NucleoActionsExtensions
	{
		#region " Methods "

		/// <summary>
		/// Represents actions that can be peformed.
		/// </summary>
		/// <param name="html">The html helper.</param>
		/// <returns>The object specifying the custom actions.</returns>
		public static NucleoActions NucleoActions(this HtmlHelper html)
		{
			NucleoActions actions = html.ViewContext.HttpContext.Items[typeof(NucleoActions)] as NucleoActions;

			if (actions == null)
			{
				actions = new NucleoActions(html);
				html.ViewContext.HttpContext.Items[typeof(NucleoActions)] = actions;
			}

			return actions;
		}

		#endregion
	}
}
