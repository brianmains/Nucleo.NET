using System;
using System.Configuration;
using Nucleo.Providers;
using Nucleo.Configuration;


namespace Nucleo.Providers.Configuration
{
	/// <summary>
	/// Represents the base class for an element that's a provider.
	/// </summary>
	[CLSCompliant(true)]
	public abstract class ProviderConfigurationElementBase : ConfigurationElementBase
	{
		/// <summary>
		/// Gets or sets the default provider.
		/// </summary>
		[ConfigurationProperty("defaultProvider", IsRequired = true)]
		public virtual string DefaultProvider
		{
			get { return (string)this["defaultProvider"]; }
			set { this["defaultProvider"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.DefaultProvider; }
		}

		/// <summary>
		/// Gets or sets the collection of providers.
		/// </summary>
		[ConfigurationProperty("providers")]
		public ProviderSettingsCollection Providers
		{
			get { return (ProviderSettingsCollection)this["providers"]; }
		}
	}


	[CLSCompliant(true)]
	public class ProviderConfigurationCollectionBase<T> : ConfigurationCollectionBase<T>
		where T : ProviderConfigurationElementBase
	{

	}
}
