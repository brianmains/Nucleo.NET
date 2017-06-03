using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Application
{
	public abstract class BaseApplicationConfiguration : IApplicationConfiguration
	{
		protected abstract void Configure();

		void IApplicationConfiguration.Configure()
		{
			this.Configure();	
		}

		protected virtual void Initialize(IApplicationConfigurations cfg)
		{
			cfg.Configurations.Add(this);
		}

		void IApplicationConfiguration.Initialize(IApplicationConfigurations cfg)
		{
			this.Initialize(cfg);	
		}
	}
}
