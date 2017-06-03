using System;
using System.Configuration;


namespace Nucleo.Providers.Configuration
{
	/// <summary>
	/// Represents the base class for a configuration section that contains the provider configuration.
	/// </summary>
	[CLSCompliant(true)]
	public abstract class ProviderConfigurationSectionBase : ConfigurationSection
	{
		/// <summary>
		/// Gets or sets the default provider.
		/// </summary>
		[ConfigurationProperty("defaultProvider", IsRequired=true)]
		public virtual string DefaultProvider
		{
			get { return (string)this["defaultProvider"]; }
			set { this["defaultProvider"] = value; }
		}

		/// <summary>
		/// Gets the collection of providers.
		/// </summary>
		[ConfigurationProperty("providers")]
		public ProviderSettingsCollection Providers
		{
			get { return (ProviderSettingsCollection)this["providers"]; }
		}
	}
}
