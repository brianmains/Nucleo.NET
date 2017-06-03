using Nucleo.Presentation;
using Nucleo.Presentation.Context.Caching;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Core;
using Nucleo.Collections;
using Nucleo.Context;
using Nucleo.EventsManagement;
using Nucleo.Models;
using Nucleo.Presentation.Context;
using Nucleo.Web.Presentation.Context;
using Nucleo.State;
using Nucleo.Views;
using Nucleo.Services;
using Nucleo.Navigation;


namespace Nucleo.Web.Presentation.Context
{
	internal static class PresenterWebContextCreator
	{
		public static PresenterWebContext Create()
		{
			PresenterWebContext context = null;

			var cache = FrameworkSettings.ContextCache;
			if (cache != null && cache.CanCache)
			{
				context = cache.GetCurrentContext() as PresenterWebContext;
				if (context != null)
					return context;
			}

			//Attempt to serve from dependency resolver
			if (FrameworkSettings.Resolver != null)
			{
				var creator = FrameworkSettings.Resolver.GetDependency<IPresenterContextCreator>();
				if (creator != null)
					return (PresenterWebContext)creator.Create();
			}

			if (context == null)
			{
				lock (typeof(PresenterWebContextCreator))
				{
					if (context != null)
						return context;

					context = new PresenterWebContext();
					context.ModelInjection = new ModelInjectionManager();
					context.EventRegistry = new EventsRegistry();
					context.Singletons = new WebStaticInstanceManager(new HttpContextWrapper(HttpContext.Current));
					context.HttpContext = new HttpContextWrapper(HttpContext.Current);

					//mgr.UpdateCurrentContext(context);
					if (cache != null && cache.CanCache)
						cache.UpdateCurrentContext(context);
				}
			}

			return context;
		}
	}
}
