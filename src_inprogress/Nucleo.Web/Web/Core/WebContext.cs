using System;
using System.Web;
using System.Collections;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Context;
using Nucleo.Web.Context.Services;
using Nucleo.Web.Pages;


namespace Nucleo.Web.Core
{
	/// <summary>
	/// Represents the context for the web.
	/// </summary>
	public class WebContext : IWebContext
	{
		private IContentRegistrar _contentRegistrar = null;
		private ApplicationContext _internalContext = null;
#if NET20
		private HttpContext _internalHttpContext = null;
#else
		private HttpContextBase _internalHttpContext = null;
#endif



		#region " Properties "

		/// <summary>
		/// Gets the application state for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IApplicationStateService ApplicationState
		{
			get
			{
				IApplicationStateService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IApplicationStateService>();
				
				return (service != null) ? service : new WebFormsApplicationStateService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the browser state for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IBrowserCapabilitiesService Browser
		{
			get 
			{
				IBrowserCapabilitiesService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IBrowserCapabilitiesService>();
				
				return (service != null) ? service : new WebFormsBrowserCapabilitiesService(this.InternalHttpContext); 
			}
		}

		/// <summary>
		/// Gets the caching for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public ICachingService Caching
		{
			get
			{
				ICachingService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<ICachingService>();
				
				return (service != null) ? service : new WebFormsCachingService(this.InternalHttpContext); 
			}
		}

		public IContentRegistrar ContentRegistrar
		{
			get
			{
				if (_contentRegistrar == null)
					_contentRegistrar = new ContentRegistrar();

				return _contentRegistrar;
			}
		}

		/// <summary>
		/// Gets the cookies for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public ICookieService Cookies
		{
			get 
			{
				ICookieService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<ICookieService>();
				
				return (service != null) ? service : new WebFormsCookieService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the current handler for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public object CurrentHandler
		{
			get { return this.InternalHttpContext.Handler; }
		}

		/// <summary>
		/// Gets the headers for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IRequestHeaderService Headers
		{
			get 
			{
				IRequestHeaderService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IRequestHeaderService>();
				
				return (service != null) ? service : new WebFormsRequestHeaderService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the health monitoring for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IHealthMonitoringService HealthMonitoring
		{
			get
			{
				IHealthMonitoringService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IHealthMonitoringService>();

				return (service != null) ? service : new WebFormsHealthMonitoringService();
			}
		}

		private ApplicationContext InternalContext
		{
			get { return _internalContext; }
		}

#if NET20
		private HttpContext InternalHttpContext
#else
		private HttpContextBase InternalHttpContext
#endif
		{
			get { return _internalHttpContext; }
		}

		/// <summary>
		/// Gets the local storage for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IDictionary LocalStorage
		{
			get { return this.InternalHttpContext.Items; }
		}

		/// <summary>
		/// Gets the navigation for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public INavigationService Navigation
		{
			get
			{
				INavigationService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<INavigationService>();

				return (service != null) ? service : new WebFormsNavigationService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the posted data for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IPostDataService PostedData
		{
			get 
			{
				IPostDataService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IPostDataService>();
				
				return (service != null) ? service : new WebFormsPostDataService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the posted files for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IPostedFilesService PostedFiles
		{
			get
			{
				IPostedFilesService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IPostedFilesService>();
				
				return (service != null) ? service : new WebFormsPostedFilesService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the query strings for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IQuerystringService QueryStrings
		{
			get 
			{
				IQuerystringService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IQuerystringService>();
				
				return (service != null) ? service : new WebFormsQuerystringService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the server for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IServerUtilityService Server
		{
			get
			{
				IServerUtilityService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IServerUtilityService>();
				
				return (service != null) ? service : new WebFormsServerUtilityService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the server variables for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IServerVariablesService ServerVariables
		{
			get
			{
				IServerVariablesService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IServerVariablesService>();
				
				return (service != null) ? service : new WebFormsServerVariablesService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the session for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public ISessionStateService Session
		{
			get
			{
				ISessionStateService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<ISessionStateService>();
				
				return (service != null) ? service : new WebFormsSessionStateService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the url resolver for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IUrlResolutionService Urls
		{
			get
			{
				IUrlResolutionService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IUrlResolutionService>();
				
				return (service != null) ? service : new WebFormsUrlResolutionService(this.InternalHttpContext);
			}
		}

		/// <summary>
		/// Gets the user security for the context.  It tries to pull from the <see cref="ApplicationContext"/> first if possible.
		/// </summary>
		public IUserSecurityService UserSecurity
		{
			get
			{
				IUserSecurityService service = null;

				if (this.InternalContext != null)
					service = this.InternalContext.GetService<IUserSecurityService>();
				
				return (service != null) ? service : new WebFormsUserSecurityService(this.InternalHttpContext);
			}
		}

		#endregion



		#region " Constructors "

		public WebContext() { }

#if NET20
		public WebContext(HttpContext httpContext, ApplicationContext appContext)
#else
		public WebContext(HttpContextBase httpContext, ApplicationContext appContext)
#endif
		{
			if (httpContext == null)
				throw new ArgumentNullException("httpContext");

			_internalContext = appContext;
			_internalHttpContext = httpContext;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the current web context.  This will probably move to another method.
		/// </summary>
		/// <returns>The <see cref="IWebContext"/> instance.</returns>
		public static IWebContext GetCurrent()
		{
			if (HttpContext.Current == null)
				return null;

			WebContext context = HttpContext.Current.Items[typeof(WebContext)] as WebContext;
			if (context != null)
				return context;
			
			ApplicationContext appContext = ApplicationContext.GetCurrent();
#if NET20
			context = new WebContext(HttpContext.Current, appContext);
#else
			context = new WebContext(new HttpContextWrapper(HttpContext.Current), appContext);
#endif

			HttpContext.Current.Items.Add(typeof(WebContext), context);
			return context;
		}

		#endregion
	}
}
