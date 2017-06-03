using System;
using System.Configuration;
using Nucleo.Providers.Configuration;


namespace Nucleo.State.Configuration
{
	public class StateManagementSection : ConfigurationSection
	{
		#region " Properties "

		public static StateManagementSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/stateManagement") as StateManagementSection; }
		}

		/// <summary>
		/// Gets the collection of state properties to use for the configuration file.
		/// </summary>
		[
		ConfigurationProperty("stateProperties", IsDefaultCollection=false),
		ConfigurationCollection(typeof(StatePropertyElementCollection))
		]
		public StatePropertyElementCollection StateProperties
		{
			get { return (StatePropertyElementCollection) this["stateProperties"]; }
		}

		[
		ConfigurationProperty("stateRegions", IsDefaultCollection = false),
		ConfigurationCollection(typeof(StateRegionElementCollection))
		]
		public StateRegionElementCollection StateRegions
		{
			get { return (StateRegionElementCollection)this["stateRegions"]; }
		}

		[ConfigurationProperty("valueProviders")]
		public ValueProvidersElement ValueProviders
		{
			get { return (ValueProvidersElement) this["valueProviders"]; }
		}

		#endregion
	}
}
