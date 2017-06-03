using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Presentation.Configuration
{
	/// <summary>
	/// Represents the settings within the presenter.
	/// </summary>
	public class PresenterWebSettingsSection : ConfigurationSectionBase
	{
		#region " Properties "

		/// <summary>
		/// Gets the instance of the presenter settings.
		/// </summary>
		public static PresenterWebSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo.web.mvp/presenterWebSettings") as PresenterWebSettingsSection; }
		}

		/// <summary>
		/// Gets the collection of presenter settings.
		/// </summary>
		[
		ConfigurationProperty("presenters", IsDefaultCollection = false),
		ConfigurationCollection(typeof(PresenterElementCollection))
		]
		public PresenterElementCollection Presenters
		{
			get { return (PresenterElementCollection)this["presenters"]; }
		}

		/// <summary>
		/// Gets the routing information for the presentation.
		/// </summary>
		[ConfigurationProperty("routing")]
		public RoutingElement Routing
		{
			get { return (RoutingElement)this["routing"]; }
		}

		#endregion
	}
}
