using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Modules
{
	/// <summary>
	/// Represents a module container.
	/// </summary>
	public interface IModule
	{
		/// <summary>
		/// Initializes the module.
		/// </summary>
		void Initialize();
	}
}
