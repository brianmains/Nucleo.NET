using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;



namespace Nucleo.Modules.Discovery
{
	[TestClass]
	public class AssemblyAttributedModuleDiscoveryStrategyTest
	{
		[TestMethod]
		public void FindingModulesFindsRecords()
		{
			var options = Isolate.Fake.Instance<ModuleDiscoveryOptions>();
			var strategy = new AssemblyAttributedModuleDiscoveryStrategy();

			var modules = strategy.Find(options);

			Assert.IsTrue(modules.Count > 0);
		}
	}
}
