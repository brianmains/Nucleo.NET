using System;
using System.Collections.Generic;

using Nucleo.Configuration;
using Nucleo.DataServices.Modules;
using Nucleo.DataServices.Modules.Configuration;


namespace Nucleo.DataServices.Modules
{
	/// <summary>
	/// Represents a loader used to load modules from the configuration file.
	/// </summary>
	public class ConfigurationModuleLoader : BaseModuleLoader
	{
		#region " Methods "

		/// <summary>
		/// Creates a module from the element.
		/// </summary>
		/// <param name="moduleElement">The module element definition.</param>
		/// <returns>The module instance.</returns>
		private IDataServiceModule CreateModuleFromElement(ModuleElement moduleElement)
		{
			if (moduleElement == null)
				return null;

			IDataServiceModule moduleInstance = Activator.CreateInstance(Type.GetType(moduleElement.Type)) as IDataServiceModule;
			if (moduleInstance == null)
				throw new NullReferenceException("The module for " + moduleElement.Name + " could not be created");

			return moduleInstance;
		}

		/// <summary>
		/// Gets the modules based upon the module identifiers.
		/// </summary>
		/// <param name="identifiers">The identifiers used to match the modules from the configuration file.</param>
		/// <returns>The collection of modules.</returns>
		public override DataServiceModuleCollection GetModules(IEnumerable<ModuleIdentifier> identifiers)
		{
			ModuleSettingsSection storeSettings = ModuleSettingsSection.Instance;
			if (storeSettings == null)
				return null;

			DataServiceModuleCollection modulesList = new DataServiceModuleCollection();

			foreach (ModuleIdentifier identifier in identifiers)
			{
				IDataServiceModule moduleInstance = this.CreateModuleFromElement(storeSettings.Modules[identifier.Name]);
				if (moduleInstance != null)
					modulesList.Add(moduleInstance);
			}

			return modulesList;
		}

		#endregion
	}
}
