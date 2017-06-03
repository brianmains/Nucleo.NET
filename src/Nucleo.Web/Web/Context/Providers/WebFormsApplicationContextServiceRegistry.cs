using System;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Collections;
using Nucleo.Web.Browsers;
using Nucleo.Web.Context.Services;
using Nucleo.Context.Providers;


namespace Nucleo.Web.Context.Providers
{
	/// <summary>
	/// Represents the core service loader object that will load services for the web forms environment.  This object loads services for web forms only.  If you need to add additional services, inherit from this class, override LoadServices and call base.LoadServices, and then add your additional services.
	/// </summary>
	public class WebFormsApplicationContextServiceRegistry : IApplicationContextServiceRegistry
	{
		#region " Methods "

		/// <summary>
		/// Loads the typical services into the registry.
		/// </summary>
		/// <param name="registry">The registry to load into.</param>
		public virtual void LoadServices(TypeRegistry registry)
		{
			registry.Register<IApplicationStateService>(new WebFormsApplicationStateService());
			registry.Register<IBrowserCapabilitiesService>(new WebFormsBrowserCapabilitiesService());
			registry.Register<ICookieService>(new WebFormsCookieService());
			registry.Register<INavigationService>(new WebFormsNavigationService());
			registry.Register<IPostDataService>(new WebFormsPostDataService());
			registry.Register<IQuerystringService>(new WebFormsQuerystringService());
			registry.Register<IRequestHeaderService>(new WebFormsRequestHeaderService());
			registry.Register<ISessionStateService>(new WebFormsSessionStateService());
			registry.Register<IServerUtilityService>(new WebFormsServerUtilityService());
			registry.Register<IServerVariablesService>(new WebFormsServerVariablesService());
			registry.Register<IUrlResolutionService>(new WebFormsUrlResolutionService());
		}

		#endregion
	}
}
