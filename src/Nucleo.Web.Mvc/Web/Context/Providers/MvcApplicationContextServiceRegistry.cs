using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Collections;
using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Context.Providers;
using Nucleo.Web.Context.Services;


namespace Nucleo.Web.Context.Providers
{
	public class MvcApplicationContextServiceRegistry : IApplicationContextServiceRegistry
	{
		#region " Methods "

		public virtual void LoadServices(TypeRegistry registry)
		{
			registry.Register<IApplicationStateService>(new WebFormsApplicationStateService());
			registry.Register<IBrowserCapabilitiesService>(new WebFormsBrowserCapabilitiesService());
			registry.Register<ICookieService>(new WebFormsCookieService());
			registry.Register<INavigationService>(new MvcNavigationService());
			registry.Register<IPostDataService>(new WebFormsPostDataService());
			registry.Register<ISessionStateService>(new WebFormsSessionStateService());
			registry.Register<IServerUtilityService>(new WebFormsServerUtilityService());
			registry.Register<IUrlResolutionService>(new MvcUrlResolutionService());
		}

		#endregion
	}
}
