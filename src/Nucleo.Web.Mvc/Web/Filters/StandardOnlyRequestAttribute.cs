using System;
using System.Reflection;
using System.Web.Mvc;

using Nucleo.Context;
using Nucleo.Logs;


namespace Nucleo.Web.Filters
{
	public class StandardOnlyRequestAttribute : ActionMethodSelectorAttribute
	{
		#region " Methods "

		public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
		{
			return !controllerContext.HttpContext.Request.IsAjaxRequest();
		}

		#endregion
	}
}
