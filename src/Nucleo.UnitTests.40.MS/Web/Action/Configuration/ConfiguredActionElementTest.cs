using System;
using System.Configuration;
using Nucleo.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Action.Configuration
{
	[TestClass]
	public class ConfiguredActionElementTest
	{
		#region " Properties "

		[TestMethod]
		public void AddingDefaultValuesWorksOK()
		{
			//Arrange
			var element = new RouteConfiguredActionElement();

			//Act
			element.DefaultRouteValues.Add(new NameValueElement { Name = "Area", Value = "Test" });

			//Assert
			Assert.AreEqual(1, element.DefaultRouteValues.Count);
		}

		[TestMethod]
		public void CreatingElementWorksOK()
		{
			//Arrange
			var element = default(RouteConfiguredActionElement);

			//Act
			element = new RouteConfiguredActionElement
			{
				 Name = "Test",
				 ControllerName = "TestCtl",
				 ActionName = "Index"
			};

			//Assert
			Assert.AreEqual("Test", element.Name);
			Assert.AreEqual("TestCtl", element.ControllerName);
			Assert.AreEqual("Index", element.ActionName);
		}

		#endregion
	}
}
