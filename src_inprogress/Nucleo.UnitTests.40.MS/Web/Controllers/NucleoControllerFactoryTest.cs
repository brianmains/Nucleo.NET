using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Configuration;
using Nucleo.Web.Controllers.Configuration;


namespace Nucleo.Web.Controllers
{
	[TestClass]
	public class NucleoControllerFactoryTest : NucleoControllerFactory
	{
		#region " Classes "

		protected class TestController : Controller
		{
			public string TestName { get; set; }

			public ActionResult Index()
			{
				return View();
			}
		}

		protected class TestNucleoController : NucleoController
		{
			public ActionResult Index()
			{
				return View();
			}
		}

		protected class TestActionInvoker : ControllerActionInvoker
		{
			public bool InvokeAction(ControllerContext controllerContext, string actionName)
			{
				return true;
			}
		}

		protected class TestControllerServer : IControllerServer
		{
			public IController GetControllerReference(RequestContext context, string controllerName)
			{
				return null;
			}
		}

		#endregion



		#region " Constructors "

		public NucleoControllerFactoryTest()
			: base() { }

		#endregion



		#region " Methods "

		protected override Type GetControllerType(RequestContext context, string controllerName)
		{
			return typeof(TestController);
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingFromCustomWorksOK()
		{
			//Arrange
			var actionInvoker = Isolate.Fake.Instance<ControllerActionInvoker>();
			var server = Isolate.Fake.Instance<IControllerServer>();

			//Act
			var factory = NucleoControllerFactory.Create(actionInvoker, server);

			//Assert
			Assert.AreEqual(actionInvoker, factory.ActionInvoker);
			Assert.AreEqual(server, factory.Server);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingControllerInstanceLoadsConfigurationBuildAction()
		{
			//Arrange
			var controllerFactory = new NucleoControllerFactoryTest();
			var contextFake = Isolate.Fake.Instance<RequestContext>();

			//Act
			var controller = controllerFactory.CreateController(contextFake, "Test");

			//Assert
			Assert.IsInstanceOfType(controller, typeof(TestController));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingControllerReferenceWithServerReturnsServedController()
		{
			//Arrange
			var server = Isolate.Fake.Instance<IControllerServer>();
			var controller = Isolate.Fake.Instance<Controller>();
			Isolate.WhenCalled(() => controller.ModelState.IsValid).WillReturn(true);
			Isolate.WhenCalled(() => server.GetControllerReference(null, null)).WillReturn(controller);

			var factory = new NucleoControllerFactoryTest();
			factory.Server = server;

			//Act
			var ctlr = factory.CreateController(new RequestContext(), "Test");

			//Assert
			Assert.IsInstanceOfType(ctlr, typeof(Controller));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoadingFromConfigurationAssignsOK()
		{
			//Arrange
			var config = new ControllerSettingsSection
			{
				DefaultActionInvokerType = TypeNameGenerator.GetLocalTypeName<TestActionInvoker>(),
				DefaultServerType = TypeNameGenerator.GetLocalTypeName<TestControllerServer>()
			};
			Isolate.Fake.StaticMethods(typeof(ControllerSettingsSection));
			Isolate.WhenCalled(() => ControllerSettingsSection.Instance).WillReturn(config);

			//act
			var factory = NucleoControllerFactory.Create();

			//Assert
			Assert.IsNotNull(factory.ActionInvoker);
			Assert.IsInstanceOfType(factory.ActionInvoker, typeof(TestActionInvoker));
			Assert.IsNotNull(factory.Server);
			Assert.IsInstanceOfType(factory.Server, typeof(TestControllerServer));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingActionInvokerAssignsCorrectInvokerObject()
		{
			//Arrange
			var controllerFactory = new NucleoControllerFactoryTest();
			var controllerFake = Isolate.Fake.Instance<Controller>();
			Isolate.WhenCalled(() => controllerFake.ActionInvoker).CallOriginal();
			Isolate.WhenCalled(() => controllerFake.ActionInvoker = null).CallOriginal();

			//Act
			controllerFactory.SetupControllerActionInvoker(controllerFake);

			//Assert
			Assert.IsNotNull(controllerFake.ActionInvoker, "ActionInvoker is null");
			Assert.IsInstanceOfType(controllerFake.ActionInvoker, typeof(NucleoActionInvoker), "ActionInvoker is wrong type");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingContextAssignsOK()
		{
			//Arrange
			var controllerFactory = new NucleoControllerFactoryTest();
			var controller = new TestNucleoController();

			//Act
			controllerFactory.SetupContext(controller);

			//Assert
			Assert.IsNotNull(controller.Context);
		}

		#endregion
	}
}
