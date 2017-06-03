using System;
using System.Configuration;
using Nucleo.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Controllers.Configuration
{
	[TestClass]
	public class ControllerSettingsSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesAssignsOK()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<ControllerSettingsSection>();

			//Act
			sectionFake.DefaultActionInvokerType = "Test";
			sectionFake.DefaultServerType = "Serve";

			//Assert
			Assert.AreEqual("Test", sectionFake.DefaultActionInvokerType);
			Assert.AreEqual("Serve", sectionFake.DefaultServerType);
		}

		#endregion
	}
}
