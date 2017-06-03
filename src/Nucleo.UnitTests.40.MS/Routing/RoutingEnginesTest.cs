using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Routing
{
	[TestClass]
	public class RoutingEnginesTest
	{
		[TestMethod]
		public void GettingRoutingEngineReturnsNull()
		{
			var engine = Isolate.Fake.Instance<IRoutingEngine>();
			Isolate.WhenCalled(() => engine.IsForSource(null)).WillReturn(false);

			var engines = new RoutingEngines();
			engines.Engines.Add(engine);
			var target = new object();

			var output = engines.GetEngine(target);
			Assert.IsNull(output);
		}

		[TestMethod]
		public void GettingRoutingEngineWorksOK()
		{
			var engine = Isolate.Fake.Instance<IRoutingEngine>();
			Isolate.WhenCalled(() => engine.IsForSource(null)).WillReturn(true);

			var engines = new RoutingEngines();
			engines.Engines.Add(engine);
			var target = new object();

			var output = engines.GetEngine(target);
			Assert.AreEqual(engine, output);
		}
	}
}
