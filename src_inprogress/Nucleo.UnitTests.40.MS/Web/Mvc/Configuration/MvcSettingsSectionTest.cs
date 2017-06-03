using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.Action.Configuration;


namespace Nucleo.Web.Mvc.Configuration
{
	[TestClass]
	public class MvcSettingsSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void WorkingWithConfiguredActionsWorksOK()
		{
			//Arrange
			var section = new MvcSettingsSection();
			
			//Act
			section.RouteConfiguredActions.Add(new RouteConfiguredActionElement
			{
				Name = "Test",
				ControllerName = "Test",
				ActionName = "Index"
			});
			section.RouteConfiguredActions.Add(new RouteConfiguredActionElement
			{
				Name = "Test2",
				ControllerName = "Test",
				ActionName = "List"
			});

			//Assert
			Assert.IsNotNull(section.RouteConfiguredActions["Test"], "Configuration is null");
			Assert.AreEqual("List", section.RouteConfiguredActions["Test2"].ActionName, "Action name is not List");
		}

		#endregion
	}
}
