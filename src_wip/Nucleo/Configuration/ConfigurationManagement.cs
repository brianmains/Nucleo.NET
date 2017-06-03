using System;
using System.Configuration;


namespace Nucleo.Configuration
{
	/// <summary>
	/// Represents the class to use for configuration management.
	/// </summary>
	public class ConfigurationManagement
	{
		public static T LoadConfigurationSection<T>(string sectionLocation)
			where T: ConfigurationSection
		{
			Guard.NotNullOrEmpty(sectionLocation);

			return ConfigurationManager.GetSection(sectionLocation) as T;
		}
	}
}
