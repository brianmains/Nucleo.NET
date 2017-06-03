using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Modules.Discovery;


namespace Nucleo.Modules
{
	[TestClass]
	public class ModuleFactoryTest
	{
		[TestMethod]
		public void InitializingModulesFindsModules()
		{
			var source = Isolate.Fake.Instance<IModuleDiscoverySource>();
			ModuleFactory.Discovery = new AssemblyAttributedModuleDiscoveryStrategy();
			ModuleFactory.Initialize(source);

			Assert.IsTrue(ModuleFactory.Modules.Count > 0);
		}
	}
}
