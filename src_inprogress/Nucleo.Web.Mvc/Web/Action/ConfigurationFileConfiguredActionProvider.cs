using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web;
using Nucleo.Web.Action.Configuration;
using Nucleo.Web.Mvc.Configuration;


namespace Nucleo.Web.Action
{
	/// <summary>
	/// Represents the configured actions that are registered in the configuration file.
	/// </summary>
	public class ConfigurationFileConfiguredActionProvider : ConfiguredActionProvider
	{
		private RouteConfiguredActionElementCollection _actions = null;



		#region " Methods "

		/// <summary>
		/// Gets the route specified in the configuration file using the route name.
		/// </summary>
		/// <param name="routeName">The name of the route.</param>
		/// <returns>The route information.</returns>
		public override Route GetRoute(string routeName)
		{
			RouteConfiguredActionElement action = _actions[routeName];
			if (action == null)
				return null;

			return new Route(action.ControllerName, action.ActionName);
		}

		/// <summary>
		/// Initializes the provider using the settings defined in the <see cref="MvcSettingsSection">MvcSettingsSection configuration file</see>.
		/// </summary>
		public override void Initialize()
		{
			MvcSettingsSection section = MvcSettingsSection.Instance;
			if (section == null)
				throw new NullReferenceException("The section hasn't been configured");

			_actions = section.RouteConfiguredActions;
		}

		#endregion
	}
}
