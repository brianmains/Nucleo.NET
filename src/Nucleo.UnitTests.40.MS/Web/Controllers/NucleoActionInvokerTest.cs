using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Logs;
using Nucleo.TestingTools;
using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Views;


namespace Nucleo.Web.Controllers
{
	[TestClass]
	public class NucleoActionInvokerTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingForAppOfflineViewReturnsView()
		{
			//Arrange
			var engine = new FakeViewEngine();
			engine.Result = new ViewEngineResult(new FakeView("App_Offline"), engine);

			var invokerFake = Isolate.Fake.Instance<NucleoActionInvoker>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(invokerFake, "InvokeActionResult").IgnoreCall();
			invokerFake.Engine = engine;

			var contextFake = Isolate.Fake.Instance<ApplicationContext>();
			Isolate.Fake.StaticMethods(typeof(ApplicationContext));
			Isolate.WhenCalled(() => ApplicationContext.GetCurrent()).WillReturn(contextFake);
			Isolate.WhenCalled(() => contextFake.GetService<ILoggerService>()).WillReturn(null);

			var webContext = new ControllerContext
			{
				RouteData = new System.Web.Routing.RouteData()
			};
			webContext.RouteData.Values.Add("Controller", "Ctlr");

			//Act
			var result = invokerFake.InvokeAction(webContext, "MyAction");

			//Assert
			Assert.IsTrue(result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingAndSettingEngineWorksOK()
		{
			//Arrange
			var engine = Isolate.Fake.Instance<IViewEngine>();
			var invoker = new NucleoActionInvoker();

			//Act
			invoker.Engine = engine;

			//Assert
			Assert.AreEqual(engine, invoker.Engine);
		}

		[TestMethod]
		public void InvokingActionWhenMethodReturnsFalseLogsMessage()
		{
			//Arrange
			var engine = new FakeViewEngine();
			engine.Result = new ViewEngineResult(new FakeView("Test"), engine);

			var invokerFake = Isolate.Fake.Instance<NucleoActionInvoker>(Members.CallOriginal);
			invokerFake.Engine = engine;
			Isolate.NonPublic.WhenCalled(invokerFake, "InvokeActionResult").IgnoreCall();

			var loggerFake = new FakeLoggerService();
			var contextFake = Isolate.Fake.Instance<ApplicationContext>();
			Isolate.Fake.StaticMethods(typeof(ApplicationContext));
			Isolate.WhenCalled(() => ApplicationContext.GetCurrent()).WillReturn(contextFake);
			Isolate.WhenCalled(() => contextFake.GetService<ILoggerService>()).WillReturn(loggerFake);
			Isolate.NonPublic.WhenCalled(invokerFake, "DoInvokeAction").WillReturn(false);

			var route = Isolate.Fake.Instance<RouteData>();
			Isolate.WhenCalled(() => route.Values).WillReturn(new RouteValueDictionary(new { controller = "Home" }));

			var ctx = new ControllerContext
			{
				RouteData = route
			};

			var result = invokerFake.InvokeAction(ctx, "MyAction");

			//Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual(1, loggerFake.Entries.Count);
			//Isolate.Verify.WasCalledWithAnyArguments(() => loggerFake.LogMessage(default(string), default(string), default(LogMessageType), default(LogVerbosityType)));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void InvokingActionWhenMethodThrowsExceptionLogsMessage()
		{
			//Arrange
			var engine = new FakeViewEngine();
			engine.Result = new ViewEngineResult(new FakeView("Test"), engine);

			var invokerFake = Isolate.Fake.Instance<NucleoActionInvoker>(Members.CallOriginal);
			invokerFake.Engine = engine;
			Isolate.NonPublic.WhenCalled(invokerFake, "InvokeActionResult").IgnoreCall();

			var loggerFake = new FakeLoggerService();
			var contextFake = Isolate.Fake.Instance<ApplicationContext>();
			Isolate.WhenCalled(() => ApplicationContext.GetCurrent()).WillReturn(contextFake);
			Isolate.WhenCalled(() => contextFake.GetService<ILoggerService>()).WillReturn(loggerFake);
			Isolate.NonPublic.WhenCalled(invokerFake, "DoInvokeAction").WillThrow(new NotSupportedException());

			//Act
			ExceptionTester.CheckException(true, (src) => { invokerFake.InvokeAction(new ControllerContext(), "MyAction"); });

			//Assert
			Assert.AreEqual(1, loggerFake.Entries.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void InvokingActionWithValidActionReturnsActionResult()
		{
			//Arrange
			var engine = new FakeViewEngine();
			engine.Result = new ViewEngineResult(new FakeView("MyAction"), engine);

			var invokerFake = Isolate.Fake.Instance<NucleoActionInvoker>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(invokerFake, "InvokeActionResult").IgnoreCall();
			invokerFake.Engine = engine;

			var loggerFake = new FakeLoggerService();
			var contextFake = Isolate.Fake.Instance<ApplicationContext>();

			Isolate.WhenCalled(() => ApplicationContext.GetCurrent()).WillReturn(contextFake);
			Isolate.WhenCalled(() => contextFake.GetService<ILoggerService>()).WillReturn(loggerFake);
			Isolate.NonPublic.WhenCalled(invokerFake, "DoInvokeAction").WillReturn(true);

			var webContext = new ControllerContext
			{
				RouteData = new System.Web.Routing.RouteData()
			};
			webContext.RouteData.Values.Add("Controller", "Ctlr");

			//Act
			var result = invokerFake.InvokeAction(webContext, "MyAction");

			//Assert
			Assert.IsTrue(result);
			Assert.AreEqual(0, loggerFake.Entries.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void NoViewEngineReturnsFalse()
		{
			//Arrange
			var invokerFake = Isolate.Fake.Instance<NucleoActionInvoker>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(invokerFake, "InvokeActionResult").IgnoreCall();
		}

		#endregion
	}
}
