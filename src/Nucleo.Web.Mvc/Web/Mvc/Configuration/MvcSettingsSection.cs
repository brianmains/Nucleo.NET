using System;
using System.Configuration;

using Nucleo.Configuration;
using Nucleo.Providers.Configuration;
using Nucleo.Web.Action.Configuration;
using Nucleo.Web.Views.Configuration;


namespace Nucleo.Web.Mvc.Configuration
{
	public class MvcSettingsSection : ConfigurationSectionBase
	{
		#region " Properties "		

		[ConfigurationProperty("defaultRouteConfiguredActionProviderType")]
		public string DefaultRouteConfiguredActionProviderType
		{
			get { return (string)this["defaultRouteConfiguredActionProviderType"]; }
		}

		[ConfigurationProperty("errorViewName")]
		public string ErrorViewName
		{
			get { return (string)this["errorViewName"]; }
			set { this["errorViewName"] = value; }
		}

		public static MvcSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo.web.mvc/mvcSettings") as MvcSettingsSection; }
		}

		[
		ConfigurationProperty("routeConfiguredActions", IsDefaultCollection = false),
		ConfigurationCollection(typeof(RouteConfiguredActionElementCollection))
		]
		public RouteConfiguredActionElementCollection RouteConfiguredActions
		{
			get { return (RouteConfiguredActionElementCollection)this["routeConfiguredActions"]; }
		}

		[ConfigurationProperty("viewSettings")]
		public ViewSettingsElement ViewSettings
		{
			get { return (ViewSettingsElement)this["viewSettings"]; }
		}

		#endregion
	}
}
