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
		protected class TestClass { }

		protected class TestRoutingEngine : IRoutingEngine, IRoutingSecurity
		{
			public bool Allow { get; set; }

			public bool Navigated { get; set; }

			public bool IsForSource(object routingSource)
			{
				return true;
			}

			public void Navigate(object routingSource)
			{
				this.Navigated = true;
			}

			public bool HasPermission(object routingSource)
			{
				return Allow;
			}
		}


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

			Isolate.CleanUp();
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

			Isolate.CleanUp();
		}

		[TestMethod]
		public void NavigatingWithMissingEngineDoesntNavigate()
		{
			var engine = Isolate.Fake.Instance<IRoutingEngine>();
			Isolate.WhenCalled(() => engine.IsForSource(null)).WillReturn(false);
			Isolate.WhenCalled(() => engine.Navigate(null)).IgnoreCall();

			var engines = new RoutingEngines();
			engines.Engines.Add(engine);
			var target = new object();

			engines.Navigate(target);

			Isolate.Verify.WasCalledWithAnyArguments(() => engine.IsForSource(null));
			Isolate.Verify.WasNotCalled(() => engine.Navigate(null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void NavigatingWorksOK()
		{
			var engine = Isolate.Fake.Instance<IRoutingEngine>();
			Isolate.WhenCalled(() => engine.IsForSource(null)).WillReturn(true);
			Isolate.WhenCalled(() => engine.Navigate(null)).IgnoreCall();

			var engines = new RoutingEngines();
			engines.Engines.Add(engine);
			var target = new object();

			engines.Navigate(target);

			Isolate.Verify.WasCalledWithAnyArguments(() => engine.IsForSource(null));
			Isolate.Verify.WasCalledWithAnyArguments(() => engine.Navigate(null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SecuringRouteAllowsRoutingToOccur()
		{
			var engine = new TestRoutingEngine { Allow = true };
			var handler = Isolate.Fake.Instance<IRoutingFailureHandler>();
			Isolate.WhenCalled(() => handler.HandleFailure(null, null, RoutingFailureReason.Error)).IgnoreCall();

			var engines = new RoutingEngines { FailureHandler = handler };
			engines.Engines.Add(engine);
			var target = new object();

			engines.Navigate(target);

			Assert.AreEqual(true, engine.Navigated);
			Isolate.Verify.WasNotCalled(() => handler.HandleFailure(null, null, RoutingFailureReason.Error));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SecuringRouteFails()
		{
			var engine = new TestRoutingEngine { Allow = false };
			var handler = Isolate.Fake.Instance<IRoutingFailureHandler>();
			Isolate.WhenCalled(() => handler.HandleFailure(null, null, RoutingFailureReason.Error)).IgnoreCall();

			var engines = new RoutingEngines { FailureHandler = handler };
			engines.Engines.Add(engine);
			var target = new object();

			engines.Navigate(target);

			Assert.AreEqual(false, engine.Navigated);
			Isolate.Verify.WasCalledWithAnyArguments(() => handler.HandleFailure(null, null, RoutingFailureReason.Error));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingFailureHandlerWOrksOK()
		{
			var handler = Isolate.Fake.Instance<IRoutingFailureHandler>();

			var engines = new RoutingEngines() { FailureHandler = handler };

			Assert.AreEqual(handler, engines.FailureHandler);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ThrowingExceptionsIsCaughtByErrorHandler()
		{
			var target = Isolate.Fake.Instance<TestClass>();

			var engine = Isolate.Fake.Instance<TestRoutingEngine>();
			Isolate.WhenCalled(() => engine.Allow).WillReturn(true);
			Isolate.WhenCalled(() => engine.IsForSource(null)).WillReturn(true);
			Isolate.WhenCalled(() => engine.Navigate(null)).WillThrow(new InvalidCastException());
			var handler = Isolate.Fake.Instance<IRoutingFailureHandler>();
			Isolate.WhenCalled(() => handler.HandleFailure(engine, target, RoutingFailureReason.Error))
				.IgnoreCall();

			var engines = new RoutingEngines { FailureHandler = handler };
			engines.Engines.Add(engine);
			
			engines.Navigate(target);

			Assert.AreEqual(false, engine.Navigated);
			Isolate.Verify.WasCalledWithAnyArguments(() => handler.HandleFailure(engine, target, RoutingFailureReason.Error));

			Isolate.CleanUp();
		}
	}
}
