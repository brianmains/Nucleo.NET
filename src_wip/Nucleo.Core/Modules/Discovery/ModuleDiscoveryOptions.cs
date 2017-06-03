using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Modules.Discovery
{
	/// <summary>
	/// Represents the options used for module discovery.
	/// </summary>
	public class ModuleDiscoveryOptions
	{
		/// <summary>
		/// Gets or sets the source object reponsible for module discovery.
		/// </summary>
		public IModuleDiscoverySource Source
		{
			get;
			set;
		}
	}
}
