using System;
using System.Collections.Generic;

using Nucleo.DataServices.Modules;


namespace Nucleo.DataServices.Modules
{
	/// <summary>
	/// Represents the loader for modules.
	/// </summary>
	public abstract class BaseModuleLoader
	{
		#region " Methods "

		/// <summary>
		/// Gets the collection of modules to load.
		/// </summary>
		/// <param name="identifiers">The unique identifiers used to match modules to load.s</param>
		/// <returns>The collection of modules matching their identifiers.</returns>
		public abstract DataServiceModuleCollection GetModules(IEnumerable<ModuleIdentifier> identifiers);

		#endregion
	}
}
