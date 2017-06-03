using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Controllers
{
	[TestClass]
	public class FakeControllerFactoryTest
	{
		[TestMethod]
		public void ServingControllersWorksOK()
		{
			//Arrange
			var ctlr = Isolate.Fake.Instance<IController>();

			var factory = new FakeControllerFactory();
			factory.ControllerMappings.Add("Home", ctlr);

			var request = new RequestContext();

			//Act
			var output = factory.CreateController(request, "Home");

			//Assert
			Assert.AreEqual(ctlr, output, "Controllers don't match");
		}
	}
}
