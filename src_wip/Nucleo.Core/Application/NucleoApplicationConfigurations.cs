using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Application
{
	public class NucleoApplicationConfigurations : IApplicationConfigurations
	{
		ApplicationConfigurationCollection _configurations = null;



		public ApplicationConfigurationCollection Configurations 
		{
			get
			{
				if (_configurations == null)
					_configurations = new ApplicationConfigurationCollection();

				return _configurations;
			}
		}
	}
}
