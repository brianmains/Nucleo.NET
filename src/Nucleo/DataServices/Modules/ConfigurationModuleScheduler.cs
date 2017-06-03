using System;
using System.Collections.Generic;

using Nucleo.DataServices.Modules.Configuration;


namespace Nucleo.DataServices.Modules
{
	/// <summary>
	/// Represents the scheduler that loads the schedule from the configuration file.
	/// </summary>
	public class ConfigurationModuleScheduler : BaseModuleScheduler
	{
		#region " Methods "

		/// <summary>
		/// Gets the modules scheduled for execution out of the configuration file.
		/// </summary>
		/// <returns>The collection of identifiers scheduled.</returns>
		public override ModuleIdentifierCollection GetModulesForExecution()
		{
			ModuleSettingsSection section = ModuleSettingsSection.Instance;
			ModuleIdentifierCollection identifiers = new ModuleIdentifierCollection();

			foreach (ExecutingModuleElement executingModule in section.ExecutingModules)
				identifiers.Add(new ModuleIdentifier(executingModule.Name));

			return identifiers;
		}

		#endregion
	}
}
