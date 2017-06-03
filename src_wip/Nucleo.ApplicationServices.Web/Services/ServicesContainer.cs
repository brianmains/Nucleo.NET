using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Dependencies;


namespace Nucleo.Services
{
	public class ServicesContainer
	{
		private IApplicationStateService _applicationState = null;
		private IBrowserCapabilitiesService _browser = null;
		private ICachingService _caching = null;
		private ICookieService _cookies = null;
		private ICurrentRequestService _currentRequest = null;
		private IHealthMonitoringService _healthMonitoring = null;
		private IPostDataService _postData = null;
		private IPostedFilesService _postedFiles = null;
		private IQuerystringService _querystring = null;
		private IRequestHeaderService _requestHeaders = null;
		private IServerUtilityService _server = null;
		private ISessionStateService _sessionState = null;
		private IStaticInstanceManager _staticInstances = null;
		private IUrlResolutionService _urlResolution = null;
		private IUserSecurityService _userSecurity = null;

		private static IHttpContextLocatorService _locator = null;



		private static IDependencyResolver Resolver
		{
			get
			{
				return DependencyStore.Resolver;
			}
		}

		public IApplicationStateService ApplicationState
		{
			get 
			{
				if (_applicationState == null)
				{
					if (Resolver != null)
						_applicationState = Resolver.GetDependency<IApplicationStateService>();
					else
						_applicationState = new WebApplicationStateService(_locator);
				}

				return _applicationState; 
			}
		}

		public IBrowserCapabilitiesService Browser
		{
			get
			{
				if (_browser == null)
				{
					if (Resolver != null)
						_browser = Resolver.GetDependency<IBrowserCapabilitiesService>();
					else
						_browser = new WebBrowserCapabilitiesService();
				}

				return _browser;
			}
		}

		public ICachingService Caching
		{
			get
			{
				if (_caching == null)
				{
					if (Resolver != null)
						_caching = Resolver.GetDependency<ICachingService>();
					else
						_caching = new WebCachingService();
				}

				return _caching;
			}
		}

		public ICookieService Cookies
		{
			get
			{
				if (_cookies == null)
				{
					if (Resolver != null)
						_cookies = Resolver.GetDependency<ICookieService>();
					else
						_cookies = new WebCookieService();
				}

				return _cookies;
			}
		}

		public ICurrentRequestService CurrentRequest
		{
			get
			{
				if (_currentRequest == null)
				{
					if (Resolver != null)
						_currentRequest = Resolver.GetDependency<ICurrentRequestService>();
					else
						_currentRequest = new WebCurrentRequestService();
				}

				return _currentRequest;
			}
		}

		public IHealthMonitoringService HealthMonitoring
		{
			get
			{
				if (_healthMonitoring == null)
				{
					if (Resolver != null)
						_healthMonitoring = Resolver.GetDependency<IHealthMonitoringService>();
					else
						_healthMonitoring = new WebHealthMonitoringService();
				}

				return _healthMonitoring;
			}
		}

		public IPostDataService PostData
		{
			get
			{
				if (_postData == null)
				{
					if (Resolver != null)
						_postData = Resolver.GetDependency<IPostDataService>();
					else
						_postData = new WebPostDataService();
				}

				return _postData;
			}
		}

		public IPostedFilesService PostedFiles
		{
			get
			{
				if (_postedFiles == null)
				{
					if (Resolver != null)
						_postedFiles = Resolver.GetDependency<IPostedFilesService>();
					else
						_postedFiles = new WebPostedFilesService();
				}

				return _postedFiles;
			}
		}

		public IQuerystringService Querystring
		{
			get
			{
				if (_querystring == null)
				{
					if (Resolver != null)
						_querystring = Resolver.GetDependency<IQuerystringService>();
					else
						_querystring = new WebQuerystringService();
				}

				return _querystring;
			}
		}

		public IRequestHeaderService RequestHeaders
		{
			get
			{
				if (_requestHeaders == null)
				{
					if (Resolver != null)
						_requestHeaders = Resolver.GetDependency<IRequestHeaderService>();
					else
						_requestHeaders = new WebRequestHeaderService();
				}

				return _requestHeaders;
			}
		}

		public IServerUtilityService Server
		{
			get
			{
				if (_server == null)
				{
					if (Resolver != null)
						_server = Resolver.GetDependency<IServerUtilityService>();
					else
						_server = new WebServerUtilityService();
				}

				return _server;
			}
		}

		public ISessionStateService SessionState
		{
			get
			{
				if (_sessionState == null)
				{
					if (Resolver != null)
						_sessionState = Resolver.GetDependency<ISessionStateService>();
					else
						_sessionState = new WebSessionStateService();
				}

				return _sessionState;
			}
		}

		public IStaticInstanceManager StaticInstances
		{
			get
			{
				if (_staticInstances == null)
				{
					if (Resolver != null)
						_staticInstances = Resolver.GetDependency<IStaticInstanceManager>();
					else
						_staticInstances = new WebStaticInstanceManager();
				}

				return _staticInstances;
			}
		}

		public IUrlResolutionService UrlResolution
		{
			get
			{
				if (_urlResolution == null)
				{
					if (Resolver != null)
						_urlResolution = Resolver.GetDependency<IUrlResolutionService>();
					else
						_urlResolution = new WebUrlResolutionService();
				}

				return _urlResolution;
			}
		}

		public IUserSecurityService UserSecurity
		{
			get
			{
				if (_userSecurity == null)
				{
					if (Resolver != null)
						_userSecurity = Resolver.GetDependency<IUserSecurityService>();
					else
						_userSecurity = new WebUserSecurityService();
				}

				return _userSecurity;
			}
		}


		public static IHttpContextLocatorService HttpContextLocator
		{
			get
			{
				if (_locator == null)
				{
					lock (typeof(IHttpContextLocatorService))
					{
						if (_locator == null)
							_locator = new WebHttpContextLocatorService();
					}
				}

				return _locator;
			}
		}

	}
}
