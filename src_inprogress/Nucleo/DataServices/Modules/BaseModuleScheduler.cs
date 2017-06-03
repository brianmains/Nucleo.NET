using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.DataServices.Modules
{
	/// <summary>
	/// Represents the scheduler that controls the modules to execute.
	/// </summary>
	public abstract class BaseModuleScheduler
	{
		#region " Methods "

		/// <summary>
		/// Gets the modules that should be executed.
		/// </summary>
		/// <returns>The collection of module identifiers to be scheduled.</returns>
		public abstract ModuleIdentifierCollection GetModulesForExecution();

		#endregion
	}
}
