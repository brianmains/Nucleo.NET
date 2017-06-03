using System;
using System.Configuration;
using Nucleo.Configuration;
using Nucleo.Providers.Configuration;


namespace Nucleo.Security.Configuration
{
	public class SecuritySettingsSection : ProviderConfigurationSectionBase
	{
		[
		ConfigurationProperty("defaultProvider", DefaultValue="NucleoDatabaseSecurityManagementProvider"),
		StringValidator(MinLength=1)
		]
		public override string DefaultProvider
		{
			get { return (string)this["defaultProvider"]; }
			set { this["defaultProvider"] = value; }
		}

		[ConfigurationProperty("disableValidationDuringTesting", DefaultValue = false)]
		public bool DisableValidationDuringTesting
		{
			get { return (bool)this["disableValidationDuringTesting"]; }
			set { this["disableValidationDuringTesting"] = value; }
		}

		public static SecuritySettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/securitySettings") as SecuritySettingsSection; }
		}

		[ConfigurationProperty("passwords")]
		public PasswordsElement Passwords
		{
			get { return this["passwords"] as PasswordsElement; }
		}
	}
}
