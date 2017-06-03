using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Application
{
	public interface IApplication
	{
		/// <summary>
		/// Configures all of the application services being used.
		/// </summary>
		/// <param name="cfg">The configurations available.</param>
		void Configure(IApplicationConfigurations cfg);
	}
}
