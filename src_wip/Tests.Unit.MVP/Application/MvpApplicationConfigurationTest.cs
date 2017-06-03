using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Models.Cache;
using Nucleo.Core;
using Nucleo.Presentation.Context.Caching;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;
using Nucleo.Presentation.Initialization;
using Nucleo.Dependencies;
using Nucleo.Views.Initialization;


namespace Nucleo.Application
{
	[TestClass]
	public class MvpApplicationConfigurationTest
	{
		[TestMethod]
		public void InitializingWorksOK()
		{
			var parent = Isolate.Fake.Instance<IApplicationConfigurations>();
			var cfg = new MvpApplicationConfiguration();

			((IApplicationConfiguration)cfg).Initialize(parent);
		}

		[TestMethod]
		public void ConfiguringModelCacheAssignsOK()
		{
			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			var obj = Isolate.Fake.Instance<IModelCache>();

			var cfg = new MvpApplicationConfiguration();
			cfg.ModelCache = obj;

			((IApplicationConfiguration)cfg).Configure();

			Isolate.Verify.WasCalledWithExactArguments(() => { FrameworkSettings.ModelCache = obj; });
			Isolate.CleanUp();
		}

		[TestMethod]
		public void ConfiguringPresenterContextCacheAssignsOK()
		{
			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			var obj = Isolate.Fake.Instance<IPresenterContextCache>();

			var cfg = new MvpApplicationConfiguration();
			cfg.PresenterContextCache = obj;

			((IApplicationConfiguration)cfg).Configure();

			Isolate.Verify.WasCalledWithExactArguments(() => { FrameworkSettings.ContextCache = obj; });
			Isolate.CleanUp();
		}

		[TestMethod]
		public void ConfiguringPresenterCreatorAssignsOK()
		{
			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			var obj = Isolate.Fake.Instance<IPresenterCreator>();

			var cfg = new MvpApplicationConfiguration();
			cfg.PresenterCreator = obj;

			((IApplicationConfiguration)cfg).Configure();

			Isolate.Verify.WasCalledWithExactArguments(() => { FrameworkSettings.Creator = obj; });
			Isolate.CleanUp();
		}

		[TestMethod]
		public void ConfiguringPresenterDiscoveryStrategyAssignsOK()
		{
			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			var obj = Isolate.Fake.Instance<IPresentationDiscoveryStrategy>();

			var cfg = new MvpApplicationConfiguration();
			cfg.PresenterDiscoveryStrategy = obj;

			((IApplicationConfiguration)cfg).Configure();

			Isolate.Verify.WasCalledWithExactArguments(() => { FrameworkSettings.DiscoveryStrategy = obj; });
			Isolate.CleanUp();
		}

		[TestMethod]
		public void ConfiguringPresenterInitializerAssignsOK()
		{
			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			var obj = Isolate.Fake.Instance<IPresenterInitializer>();

			var cfg = new MvpApplicationConfiguration();
			cfg.PresenterInitializer = obj;

			((IApplicationConfiguration)cfg).Configure();

			Isolate.Verify.WasCalledWithExactArguments(() => { FrameworkSettings.PresenterInitializer = obj; });
			Isolate.CleanUp();
		}

		[TestMethod]
		public void ConfiguringResolverAssignsOK()
		{
			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			var obj = Isolate.Fake.Instance<IDependencyResolver>();

			var cfg = new MvpApplicationConfiguration();
			cfg.Resolver = obj;

			((IApplicationConfiguration)cfg).Configure();

			Isolate.Verify.WasCalledWithExactArguments(() => { FrameworkSettings.Resolver = obj; });
			Isolate.CleanUp();
		}

		[TestMethod]
		public void ConfiguringViewInitializerAssignsOK()
		{
			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			var obj = Isolate.Fake.Instance<IViewInitializer>();

			var cfg = new MvpApplicationConfiguration();
			cfg.ViewInitializer = obj;

			((IApplicationConfiguration)cfg).Configure();

			Isolate.Verify.WasCalledWithExactArguments(() => { FrameworkSettings.ViewInitializer = obj; });
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingModelCacheAssignsOK()
		{
			var cfg = new MvpApplicationConfiguration();
			cfg.ModelCache = Isolate.Fake.Instance<IModelCache>();

			Assert.IsNotNull(cfg.ModelCache);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingPresenterContextCacheAssignsOK()
		{
			var cfg = new MvpApplicationConfiguration();
			cfg.PresenterContextCache = Isolate.Fake.Instance<IPresenterContextCache>();

			Assert.IsNotNull(cfg.PresenterContextCache);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingPresenterCreatorAssignsOK()
		{
			var cfg = new MvpApplicationConfiguration();
			cfg.PresenterCreator = Isolate.Fake.Instance<IPresenterCreator>();

			Assert.IsNotNull(cfg.PresenterCreator);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingPresenterDiscoveryStrategyAssignsOK()
		{
			var cfg = new MvpApplicationConfiguration();
			cfg.PresenterDiscoveryStrategy = Isolate.Fake.Instance<IPresentationDiscoveryStrategy>();

			Assert.IsNotNull(cfg.PresenterDiscoveryStrategy);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingPresenterInitializerAssignsOK()
		{
			var cfg = new MvpApplicationConfiguration();
			cfg.PresenterInitializer = Isolate.Fake.Instance<IPresenterInitializer>();

			Assert.IsNotNull(cfg.PresenterInitializer);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingResolverAssignsOK()
		{
			var cfg = new MvpApplicationConfiguration();
			cfg.Resolver = Isolate.Fake.Instance<IDependencyResolver>();

			Assert.IsNotNull(cfg.Resolver);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingViewInitializerAssignsOK()
		{
			var cfg = new MvpApplicationConfiguration();
			cfg.ViewInitializer = Isolate.Fake.Instance<IViewInitializer>();

			Assert.IsNotNull(cfg.ViewInitializer);
			Isolate.CleanUp();
		}
	}
}
