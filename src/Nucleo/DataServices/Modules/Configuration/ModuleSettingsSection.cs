using System;
using System.Configuration;

using Nucleo.Configuration;
using Nucleo.DataServices.Modules.Configuration;


namespace Nucleo.DataServices.Modules.Configuration
{
	/// <summary>
	/// Represents the configuration of data store configurations stored in the configuration file.  This is the primary source of data for the <see cref="Nucleo.DataServices.Stores.ConfigurationDataServiceStore">Configuration data store</see>.
	/// </summary>
	public class ModuleSettingsSection : ConfigurationSectionBase
	{
		#region " Properties "

		[
		ConfigurationProperty("executingModules", IsDefaultCollection = false),
		ConfigurationCollection(typeof(ExecutingModuleElementCollection))
		]
		public ExecutingModuleElementCollection ExecutingModules
		{
			get { return (ExecutingModuleElementCollection)this["executingModules"]; }
		}

		/// <summary>
		/// Gets the instance of the configuration file stored in the &lt;nucleo>&lt;dataServiceStoreSettings> element.
		/// </summary>
		public static ModuleSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/dataServiceStoreSettings") as ModuleSettingsSection; }
		}

		[ConfigurationProperty("moduleLoaderType")]
		public string ModuleLoaderType
		{
			get { return (string)this["moduleLoaderType"]; }
			set { this["moduleLoaderType"] = value; }
		}

		[ConfigurationProperty("moduleSchedulerType")]
		public string ModuleSchedulerType
		{
			get { return (string)this["moduleSchedulerType"]; }
			set { this["moduleSchedulerType"] = value; }
		}

		[
		ConfigurationProperty("modules", IsDefaultCollection = false),
		ConfigurationCollection(typeof(ModuleElementCollection))
		]
		public ModuleElementCollection Modules
		{
			get { return (ModuleElementCollection)this["modules"]; }
		}

		#endregion
	}
}
