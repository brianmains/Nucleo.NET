using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Core.Configuration
{
	/// <summary>
	/// Gets the core settings for the MVP framework.
	/// </summary>
	public class FrameworkSettingsSection : ConfigurationSectionBase
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the <see cref="Nucleo.Presentation.Discovery.IPresentationDiscoveryStrategy"/> instance.
		/// </summary>
		[ConfigurationProperty("discoveryStrategyTypeName")]
		public string DiscoveryStrategyTypeName
		{
			get { return (string)this["discoveryStrategyTypeName"]; }
			set { this["discoveryStrategyTypeName"] = value; }
		}

		/// <summary>
		/// Gets the default pattern for dicovery of a presenter.
		/// </summary>
		/// <remarks>Can be in the format of "Nucleo.Tests.Presentation.{0}Presenter,NucleoTests", where the framework will inject the name of the presenter.</remarks>
		[ConfigurationProperty("discoveryTypeNames")]
		public PresenterTypeElementCollection DiscoveryTypeNames
		{
			get { return (PresenterTypeElementCollection)this["discoveryTypeNames"]; }
		}
		
		public static FrameworkSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo.mvp/frameworkSettings") as FrameworkSettingsSection; }
		}

		/// <summary>
		/// Gets or sets the name of the <see cref="Nucleo.Presentation.IPresenterContextCache"/> instance.
		/// </summary>
		[ConfigurationProperty("presenterCacheTypeName")]
		public string PresenterCacheTypeName
		{
			get { return (string)this["presenterCacheTypeName"]; }
			set { this["presenterCacheTypeName"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the <see cref="Nucleo.Presentation.IPresenterCreator"/> instance.
		/// </summary>
		[ConfigurationProperty("presenterCreatorTypeName")]
		public string PresenterCreatorTypeName
		{
			get { return (string)this["presenterCreatorTypeName"]; }
			set { this["presenterCreatorTypeName"] = value; }
		}

		#endregion
	}
}
