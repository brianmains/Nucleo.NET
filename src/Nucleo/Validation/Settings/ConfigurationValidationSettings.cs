using System;
using System.Collections.Generic;

using Nucleo.Providers;
using Nucleo.Validation.Configuration;


namespace Nucleo.Validation.Settings
{
	public class ConfigurationValidationSettings : IValidationSettings
	{
		private bool _throwOnInvalid = false;
		private bool _useFirstFoundProviderOnly = false;



		#region " Properties "

		public bool ThrowOnInvalid
		{
			get { return _throwOnInvalid; }
			set { _throwOnInvalid = value; }
		}

		public bool UseFirstFoundProviderOnly
		{
			get { return _useFirstFoundProviderOnly; }
			set { _useFirstFoundProviderOnly = value; }
		}

		#endregion



		#region " Constructors "

		private ConfigurationValidationSettings() { }

		#endregion



		#region " Methods "

		public static ConfigurationValidationSettings Create()
		{
			ValidationSettingsSection section = ValidationSettingsSection.Instance;
			ConfigurationValidationSettings settings = new ConfigurationValidationSettings();

			settings.ThrowOnInvalid = section.ThrowOnInvalid;
			settings.UseFirstFoundProviderOnly = section.UseFirstFoundProviderOnly;

			return settings;
		}

		public ValidationProviderCollection GetProviders()
		{
			ValidationSettingsSection section = ValidationSettingsSection.Instance;
			return ProviderHelper.InitializeProviders<ValidationProviderCollection>(section);
		}

		#endregion
	}
}
