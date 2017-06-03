using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class RouteTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingRouteWithoutValuesWorksOK()
		{
			//Arrange
			var route = default(Route);

			//Act
			route = new Route("Messages", "Inbox");

			//Assert
			Assert.AreEqual("Messages", route.ControllerName);
			Assert.AreEqual("Inbox", route.ActionName);
		}

		[TestMethod]
		public void CreatingRouteWithValuesAsDictionaryWorksOK()
		{
			//Arrange
			var route = default(Route);
			var values = new Dictionary<string, object>();
			values.Add("area", "Test");

			//Act
			route = new Route("Messages", "Inbox", values);

			//Assert
			Assert.AreEqual("Messages", route.ControllerName);
			Assert.AreEqual("Inbox", route.ActionName);
			Assert.AreEqual(values, route.Values);
		}

		[TestMethod]
		public void CreatingRouteWithValuesWorksOK()
		{
			//Arrange
			var route = default(Route);
			var obj = new { area = "Test" };

			//Act
			route = new Route("Messages", "Inbox", obj);

			//Assert
			Assert.AreEqual("Messages", route.ControllerName);
			Assert.AreEqual("Inbox", route.ActionName);
			Assert.AreEqual(1, route.Values.Count);
			Assert.AreEqual("Test", route.Values["area"]);
		}

		#endregion
	}
}
