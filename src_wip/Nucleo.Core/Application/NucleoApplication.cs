using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Application
{
	public abstract class NucleoApplication : IApplication
	{
		public abstract void Configure(IApplicationConfigurations cfg);
	}
}
