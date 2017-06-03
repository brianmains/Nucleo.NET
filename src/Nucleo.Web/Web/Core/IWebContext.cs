using System;
using System.Web;
using System.Collections;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Context.Services;
using Nucleo.Web.Pages;


namespace Nucleo.Web.Core
{
	public interface IWebContext
	{
		#region " Properties "

		/// <summary>
		/// Gets the application state for the context.
		/// </summary>
		IApplicationStateService ApplicationState { get; }

		/// <summary>
		/// Gets the browser state for the context.
		/// </summary>
		IBrowserCapabilitiesService Browser { get; }

		/// <summary>
		/// Gets the cache for the context.
		/// </summary>
		ICachingService Caching { get; }

		/// <summary>
		/// Gets the content registrar.
		/// </summary>
		IContentRegistrar ContentRegistrar { get; }

		/// <summary>
		/// Gets the cookies for the context.
		/// </summary>
		ICookieService Cookies { get; }

		/// <summary>
		/// Gets the current handler for the context.
		/// </summary>
		object CurrentHandler { get; }

		/// <summary>
		/// Gets the headers for the context.
		/// </summary>
		IRequestHeaderService Headers { get; }

		/// <summary>
		/// Gets the health monitoring service for the context.
		/// </summary>
		IHealthMonitoringService HealthMonitoring { get; }

		/// <summary>
		/// Gets the local storage for the context.
		/// </summary>
		IDictionary LocalStorage { get; }

		/// <summary>
		/// Gets the navigation for the context.
		/// </summary>
		INavigationService Navigation { get; }

		/// <summary>
		/// Gets the posted data for the context.
		/// </summary>
		IPostDataService PostedData { get; }

		/// <summary>
		/// Gets the posted files for the context.
		/// </summary>
		IPostedFilesService PostedFiles { get; }

		/// <summary>
		/// Gets the query strings for the context.
		/// </summary>
		IQuerystringService QueryStrings { get; }

		/// <summary>
		/// Gets the server for the context.
		/// </summary>
		IServerUtilityService Server { get; }

		/// <summary>
		/// Gets the server variables for the context.
		/// </summary>
		IServerVariablesService ServerVariables { get; }

		/// <summary>
		/// Gets the session for the context.
		/// </summary>
		ISessionStateService Session { get; }

		/// <summary>
		/// Gets the url resolver for the context.
		/// </summary>
		IUrlResolutionService Urls { get; }

		/// <summary>
		/// Gets the user security for the context.
		/// </summary>
		IUserSecurityService UserSecurity { get; }

		#endregion
	}
}
