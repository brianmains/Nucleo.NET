using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Modules.Discovery
{
	/// <summary>
	/// Represents a discovery strategy to find modules.
	/// </summary>
	public interface IModuleDiscoveryStrategy
	{
		/// <summary>
		/// Returns the collection of modules found.
		/// </summary>
		/// <returns></returns>
		ModuleCollection Find(ModuleDiscoveryOptions options);
	}
}
