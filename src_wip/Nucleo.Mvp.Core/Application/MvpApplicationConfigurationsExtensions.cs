using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Application
{
	public static class MvpApplicationConfigurationsExtensions
	{
		public static IApplicationConfigurations Mvp(this IApplicationConfigurations cfg, Action<MvpApplicationConfiguration> builder)
		{
			var mvp = new MvpApplicationConfiguration();
			((IApplicationConfiguration)mvp).Initialize(cfg);

			builder(mvp);

			((IApplicationConfiguration)mvp).Configure();

			return cfg;
		}
	}
}
