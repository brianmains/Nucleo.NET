using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Modules.Discovery
{
	[TestClass]
	public class ModuleDiscoveryOptionsTest
	{
		[TestMethod]
		public void SettingOptionsAssignsOK()
		{
			var source = Isolate.Fake.Instance<IModuleDiscoverySource>();

			var options = new ModuleDiscoveryOptions { Source = source };

			Assert.AreEqual(source, options.Source);
		}
	}
}
