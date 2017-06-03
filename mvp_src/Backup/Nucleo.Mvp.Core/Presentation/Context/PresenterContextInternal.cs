using Nucleo.Presentation;
using Nucleo.Presentation.Context.Caching;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Core;
using Nucleo.EventsManagement;
using Nucleo.Models;
using Nucleo.State;


namespace Nucleo.Presentation.Context
{
	internal static class PresenterContextInternal
	{
		#region " Methods "

		public static PresenterContext CreateContextOrGetFromCache()
		{
			PresenterContext context = null;

			var cache = FrameworkSettings.ContextCache;
			if (cache != null && cache.CanCache)
			{
				context = cache.GetCurrentContext();
				if (context != null)
					return context;
			}

			//Attempt to serve from dependency resolver
			if (FrameworkSettings.Resolver != null)
			{
				var creator = FrameworkSettings.Resolver.GetDependency<IPresenterContextCreator>();
				if (creator != null)
					return creator.Create();
			}

			//PresenterCacheManager mgr = PresenterCacheManager.Create();
			//context = mgr.GetCurrentContext();

			if (context == null)
			{
				lock (typeof(PresenterContextInternal))
				{
					if (context != null)
						return context;

					context = new PresenterContext();
					context.EventRegistry = new EventsRegistry();
					context.ModelInjection = new ModelInjectionManager();
					context.State = new DefaultCurrentExecutionState();

					//mgr.UpdateCurrentContext(context);
					if (cache != null && cache.CanCache)
						cache.UpdateCurrentContext(context);
				}
			}

			return context;
		}

		#endregion
	}
}
