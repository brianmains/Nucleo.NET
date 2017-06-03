using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Services;


namespace System.Web.UI
{
	public static class HttpContextExtensions
	{

		public static ServicesContainer GetServices(this HttpContext context)
		{
			return GetServices(new HttpContextWrapper(context));
		}

		public static ServicesContainer GetServices(this HttpContextBase context)
		{
			var container = context.Items[typeof(ServicesContainer)] as ServicesContainer;

			if (container == null)
			{
				container = new ServicesContainer();
				context.Items.Add(typeof(ServicesContainer), container);
			}

			return container;
		}

	}
}
