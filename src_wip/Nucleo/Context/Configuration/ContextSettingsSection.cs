using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Context.Configuration
{
	/// <summary>
	/// Represents the settings to use for the <see cref="ApplicationContext">context</see>.
	/// </summary>
	/// <seealso cref="ApplicationContext"/>
	public class ContextSettingsSection : ConfigurationSection
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the service registry that will load the respective services.
		/// </summary>
		[ConfigurationProperty("serviceRegistryType")]
		public string ServiceRegistryType
		{
			get { return (string)this["serviceRegistryType"]; }
			set { this["serviceRegistryType"] = value; }
		}

		/// <summary>
		/// Gets an instance of this configuration file.
		/// </summary>
		/// <example>
		/// var section = ContextSettingsSection.Instance;
		/// </example>
		public static ContextSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/contextSettings") as ContextSettingsSection; }
		}

		/// <summary>
		/// Gets or sets the services that are registered in the config file, only if the configuration loader is used.
		/// </summary>
		[
		ConfigurationProperty("services", IsDefaultCollection=false),
		ConfigurationCollection(typeof(TypeRegistrationElementCollection))
		]
		public TypeRegistrationElementCollection Services
		{
			get { return (TypeRegistrationElementCollection)this["services"]; }
		}

		#endregion
	}
}
