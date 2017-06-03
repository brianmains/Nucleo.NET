using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Action.Configuration;
using Nucleo.Web.Mvc.Configuration;


namespace Nucleo.Web.Action
{
	[TestClass]
	public class ConfigurationFileConfiguredActionProviderTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingProvidersWorksOK()
		{
			//Arrange
			var section = new MvcSettingsSection();
			section.RouteConfiguredActions.Add(new RouteConfiguredActionElement
			{
				Name = "Test",
				ControllerName = "TestAction",
				ActionName = "Index"
			});
			section.RouteConfiguredActions.Add(new RouteConfiguredActionElement
			{
				Name = "TestList",
				ControllerName = "TestAction",
				ActionName = "List"
			});
			Isolate.WhenCalled(() => MvcSettingsSection.Instance).WillReturn(section);
			

			var provider = new ConfigurationFileConfiguredActionProvider();
			provider.Initialize();

			//Act
			var route = provider.GetRoute("TestList");

			//Assert
			Assert.IsNotNull(route, "Route is null");
			Assert.AreEqual("TestAction", route.ControllerName);
			Assert.AreEqual("List", route.ActionName);

			Isolate.CleanUp();
		}

		#endregion
	}
}
