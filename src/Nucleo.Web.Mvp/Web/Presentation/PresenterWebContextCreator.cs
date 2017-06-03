using Nucleo.Presentation;
using Nucleo.Presentation.Caching;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Collections;
using Nucleo.Context;
using Nucleo.EventsManagement;
using Nucleo.Models;
using Nucleo.Presentation;
using Nucleo.State;
using Nucleo.Views;
using Nucleo.Web.Context;
using Nucleo.Web.Core;
using Nucleo.Navigation;

namespace Nucleo.Web.Presentation
{
	internal static class PresenterWebContextCreator
	{
		public static PresenterWebContext Create()
		{
			PresenterCacheManager mgr = PresenterCacheManager.Create();
			PresenterWebContext context = mgr.GetCurrentContext() as PresenterWebContext;

			if (context == null)
			{
				lock (typeof(PresenterCacheManager))
				{
					if (context != null)
						return context;

					context = new PresenterWebContext();
					context.Context = WebContext.GetCurrent();
					context.ModelInjection = new ModelInjectionManager();
					context.EventRegistry = new EventsRegistry();
					context.Singletons = new WebSingletonManager(context.Context);
					context.HttpContext = new HttpContextWrapper(HttpContext.Current);

					mgr.UpdateCurrentContext(context);
				}
			}

			return context;
		}
	}
}
