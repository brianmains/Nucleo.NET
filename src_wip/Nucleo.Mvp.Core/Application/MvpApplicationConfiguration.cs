using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Nucleo.Dependencies;
using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Presentation.Context.Caching;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;
using Nucleo.Presentation.Initialization;

using Nucleo.Views.Initialization;

using Nucleo.Models.Cache;
using Nucleo.Core;



namespace Nucleo.Application
{
	public class MvpApplicationConfiguration : IApplicationConfiguration
	{
		public IModelCache ModelCache { get; set; }

		public IPresenterContextCache PresenterContextCache { get; set; }

		public IPresenterCreator PresenterCreator { get; set; }

		public IPresentationDiscoveryStrategy PresenterDiscoveryStrategy { get; set; }

		public IPresenterInitializer PresenterInitializer { get; set; }

		public IDependencyResolver Resolver { get; set; }

		public IViewInitializer ViewInitializer { get; set; }



		void IApplicationConfiguration.Configure()
		{
			if (this.PresenterContextCache != null)
				FrameworkSettings.ContextCache = this.PresenterContextCache;
			if (this.PresenterCreator != null)
				FrameworkSettings.Creator = this.PresenterCreator;
			if (this.PresenterDiscoveryStrategy != null)
				FrameworkSettings.DiscoveryStrategy = this.PresenterDiscoveryStrategy;
			if (this.ModelCache != null)
				FrameworkSettings.ModelCache = this.ModelCache;
			if (this.Resolver != null)
				FrameworkSettings.Resolver = this.Resolver;
			if (this.PresenterInitializer != null)
				FrameworkSettings.PresenterInitializer = this.PresenterInitializer;
			if (this.ViewInitializer != null)
				FrameworkSettings.ViewInitializer = this.ViewInitializer;
		}

		void IApplicationConfiguration.Initialize(IApplicationConfigurations cfg)
		{
			cfg.Configurations.Add(this);
		}


	}
}
