using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Action.Configuration
{
	/// <summary>
	/// Represents a route definition within the configuration file.
	/// </summary>
	/// <example>
	/// &lt;add name="CreateProject" controllerName="Projects" actionName="Create">
	///		&lt;defaultRouteValues>
	///			&lt;add name="area" value="Management" />
	///		&lt;/defaultRouteValues>
	/// &lt;/add>
	/// </example>
	public class RouteConfiguredActionElement : ConfigurationElementBase
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the action for the route.
		/// </summary>
		[ConfigurationProperty("actionName", IsRequired = true)]
		public string ActionName
		{
			get { return (string)this["actionName"]; }
			set { this["actionName"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the controller for the route.
		/// </summary>
		[ConfigurationProperty("controllerName", IsRequired = true)]
		public string ControllerName
		{
			get { return (string)this["controllerName"]; }
			set { this["controllerName"] = value; }
		}

		/// <summary>
		/// Gets the collection of default routing values.
		/// </summary>
		[
		ConfigurationProperty("defaultRouteValues", IsDefaultCollection = false),
		ConfigurationCollection(typeof(NameValueElementCollection))
		]
		public NameValueElementCollection DefaultRouteValues
		{
			get { return (NameValueElementCollection)this["defaultRouteValues"]; }
		}

		/// <summary>
		/// Gets or sets the name of the route.  Used to identify the specific route.
		/// </summary>
		[ConfigurationProperty("name", IsRequired=true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		/// <summary>
		/// Gets the unique key for the element.
		/// </summary>
		protected override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion
	}
}
