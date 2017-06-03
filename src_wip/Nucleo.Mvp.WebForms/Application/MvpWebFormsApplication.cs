using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Application
{
	public class MvpWebFormsApplication : IApplication
	{
		public void Configure(IApplicationConfigurations cfg)
		{
			cfg.Mvp((m) =>
				{
					m.PresenterContextCache = new Nucleo.Web.Presentation.Context.Caching.HttpContextPresenterContextCache();
					m.PresenterCreator = new Nucleo.Presentation.Creation.DefaultPresenterCreator();
					m.PresenterDiscoveryStrategy = new Nucleo.Presentation.Discovery.AttributePresentationDiscoveryStrategy();
				});
		}
	}
}
