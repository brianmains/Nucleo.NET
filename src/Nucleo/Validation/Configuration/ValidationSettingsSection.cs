using System;
using System.Configuration;
using Nucleo.Configuration;
using Nucleo.Providers.Configuration;


namespace Nucleo.Validation.Configuration
{
	public class ValidationSettingsSection : ProviderConfigurationSectionBase
	{
		#region " Properties "

		public static ValidationSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/validationSettings") as ValidationSettingsSection; }
		}

		[ConfigurationProperty("throwOnInvalid", DefaultValue=false)]
		public bool ThrowOnInvalid
		{
			get { return (bool)this["throwOnInvalid"]; }
			set { this["throwOnInvalid"] = value; }
		}

		[ConfigurationProperty("useFirstFoundProviderOnly", DefaultValue = false)]
		public bool UseFirstFoundProviderOnly
		{
			get { return (bool)this["useFirstFoundProviderOnly"]; }
			set { this["useFirstFoundProviderOnly"] = value; }
		}

		#endregion
	}
}
