using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Application
{
	public interface IApplicationConfiguration
	{
		void Configure();

		void Initialize(IApplicationConfigurations cfg);
	}
}
