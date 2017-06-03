using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Application
{
	public interface IApplicationConfigurations
	{
		ApplicationConfigurationCollection Configurations { get; }
	}
}
