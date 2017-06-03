using Nucleo.Presentation;
using Nucleo.Presentation.Caching;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#if SILVERLIGHT
#else
using Nucleo.Context;
#endif
using Nucleo.EventsManagement;
using Nucleo.Models;
using Nucleo.State;


namespace Nucleo.Presentation
{
	internal static class PresenterContextInternal
	{
		#region " Methods "

		public static PresenterContext CreateContextOrGetFromCache()
		{
			PresenterCacheManager mgr = PresenterCacheManager.Create();
			PresenterContext context = mgr.GetCurrentContext();

			if (context == null)
			{
				lock (typeof(PresenterCacheManager))
				{
					if (context != null)
						return context;

					context = new PresenterContext();
					context.EventRegistry = new EventsRegistry();
					context.ModelInjection = new ModelInjectionManager();
					context.State = new DefaultCurrentExecutionState();

					mgr.UpdateCurrentContext(context);
				}
			}

			return context;
		}

		#endregion
	}
}
