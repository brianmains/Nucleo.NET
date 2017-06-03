using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Modules.Initialization
{
	/// <summary>
	/// Represents a component to initialize a module.
	/// </summary>
	public interface IModuleInitializer
	{
		/// <summary>
		/// Initializes the module.
		/// </summary>
		/// <param name="module">The module to initialize.</param>
		void Initialize(IModule module);
	}
}
