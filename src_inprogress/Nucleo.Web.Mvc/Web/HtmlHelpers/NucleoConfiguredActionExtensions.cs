using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Nucleo.Configuration;
using Nucleo.Web.Action;
using Nucleo.Web.Mvc.Configuration;
using Nucleo.Web.Tags;


namespace System.Web.Mvc
{
	/// <summary>
	/// Represents extension methods to add on to the URL helper.
	/// </summary>
	public static class NucleoConfiguredActionExtensions
	{
		#region " Methods "

		/// <summary>
		/// Pulls a route using the route name, which loads the routing information from an underlying provider (which pulls this information from <see cref="MvcSettingsSection">MvcSettingsSection configuration section</see>.
		/// </summary>
		/// <param name="url">The url helper to use to create the action URL.</param>
		/// <param name="routeName">The name of the route to pull information for.</param>
		/// <returns>The URL for the action.</returns>
		public static string ConfiguredAction(this UrlHelper url, string routeName)
		{
			return ConfiguredAction(url, routeName, null);
		}

		/// <summary>
		/// Pulls a route using the route name, which loads the routing information from an underlying provider (which pulls this information from <see cref="MvcSettingsSection">MvcSettingsSection configuration section</see>.  If the route values are not null, these will override the default for the routes defined within the configuration source.
		/// </summary>
		/// <param name="url">The url helper to use to create the action URL.</param>
		/// <param name="routeName">The name of the route to pull information for.</param>
		/// <param name="routeValues">The routing values for the action; if not null, these override the default routing values in the source.</param>
		/// <returns>The URL for the action.</returns>
		public static string ConfiguredAction(this UrlHelper url, string routeName, object routeValues)
		{
			return ConfiguredAction(url, routeName, routeValues);
		}

		/// <summary>
		/// Pulls a route using the route name, which loads the routing information from an underlying provider (which pulls this information from <see cref="MvcSettingsSection">MvcSettingsSection configuration section</see>.  If the route values are not null, these will override the default for the routes defined within the configuration source.
		/// </summary>
		/// <param name="url">The url helper to use to create the action URL.</param>
		/// <param name="routeName">The name of the route to pull information for.</param>
		/// <param name="routeValues">The routing values for the action; if not null, these override the default routing values in the source.</param>
		/// <returns>The URL for the action.</returns>
		public static string ConfiguredAction(this UrlHelper url, string routeName, RouteValueDictionary routeValues)
		{
			MvcSettingsSection section = MvcSettingsSection.Instance;
			ConfiguredActionProvider provider = null;

			if (section != null && !string.IsNullOrEmpty(section.DefaultRouteConfiguredActionProviderType))
				provider = section.Create<ConfiguredActionProvider>("DefaultRouteConfiguredActionProviderType");
			else
				provider = new ConfigurationFileConfiguredActionProvider();
			
			provider.Initialize();

			Nucleo.Web.Route route = provider.GetRoute(routeName);
			if (route == null)
				throw new NullReferenceException("Could not find route: " + routeName);

			//If no supplied route values, use the default for the route.
			if (routeValues == null)
				routeValues = new RouteValueDictionary();

			return url.Action(route.ActionName, route.ControllerName, routeValues);
		}

		/// <summary>
		/// Creates an action link using the configured route.
		/// </summary>
		/// <param name="html">The html helper.</param>
		/// <param name="routeName">The name of the route in the configuration source.</param>
		/// <param name="text">The text to use for the link.</param>
		/// <returns>The route HTML.</returns>
		public static string ConfiguredActionLink(this HtmlHelper html, string routeName, string text)
		{
			return ConfiguredActionLink(html, routeName, text, null);
		}

		/// <summary>
		/// Creates an action link using the configured route.
		/// </summary>
		/// <param name="html">The html helper.</param>
		/// <param name="routeName">The name of the route in the configuration source.</param>
		/// <param name="text">The text to use for the link.</param>
		/// <param name="htmlAttributes">The HTML attributes for the link.</param>
		/// <returns>The route HTML.</returns>
		public static string ConfiguredActionLink(this HtmlHelper html, string routeName, string text, object htmlAttributes)
		{
			return ConfiguredActionLink(html, routeName, null, text, htmlAttributes);
		}

		/// <summary>
		/// Creates an action link using the configured route.
		/// </summary>
		/// <param name="html">The html helper.</param>
		/// <param name="routeName">The name of the route in the configuration source.</param>
		/// <param name="routeValues">The routing values for the link; if not null, these override the default source.</param>
		/// <param name="text">The text to use for the link.</param>
		/// <param name="htmlAttributes">The HTML attributes for the link.</param>
		/// <returns>The route HTML.</returns>
		public static string ConfiguredActionLink(this HtmlHelper html, string routeName, object routeValues, string text, object htmlAttributes)
		{
			return ConfiguredActionLink(html, routeName, new RouteValueDictionary(routeValues), text, htmlAttributes);
		}

		/// <summary>
		/// Creates an action link using the configured route.
		/// </summary>
		/// <param name="html">The html helper.</param>
		/// <param name="routeName">The name of the route in the configuration source.</param>
		/// <param name="routeValues">The routing values for the link; if not null, these override the default source.</param>
		/// <param name="text">The text to use for the link.</param>
		/// <param name="htmlAttributes">The HTML attributes for the link.</param>
		/// <returns>The route HTML.</returns>
		public static string ConfiguredActionLink(this HtmlHelper html, string routeName, RouteValueDictionary routeValues, string text, object htmlAttributes)
		{
			UrlHelper helper = new UrlHelper(html.ViewContext.RequestContext);
			string url = ConfiguredAction(helper, routeName, routeValues);

			TagElement element = TagElementBuilder.Create("a");
			element.Attributes.AppendAttribute("href", url);
			element.Content = html.ViewContext.HttpContext.Server.HtmlEncode(text);

			if (htmlAttributes != null)
				element.Attributes.CopyFrom(htmlAttributes);

			return element.ToHtmlString();
		}

		#endregion
	}
}
