using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using TypeMock.ArrangeActAssert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Dependencies;
using Nucleo.Presentation.Caching;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;


namespace Nucleo.Core.Options
{
	[TestClass]
	public class FrameworkConfigurationTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			var config = new FrameworkConfiguration
			{
				 Cache = Isolate.Fake.Instance<IPresenterContextCache>(),
				 Creator = Isolate.Fake.Instance<IPresenterCreator>(),
				 DiscoveryStrategy = Isolate.Fake.Instance<IPresentationDiscoveryStrategy>(),
				 Resolver = Isolate.Fake.Instance<IDependencyResolver>()
			};

			Assert.IsNotNull(config.Cache);
			Assert.IsNotNull(config.Creator);
			Assert.IsNotNull(config.DiscoveryStrategy);
			Assert.IsNotNull(config.Resolver);

			Isolate.CleanUp();
		}
	}
}
