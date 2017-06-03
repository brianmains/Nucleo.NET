using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Presentation.Configuration
{
	[TestClass]
	public class RoutingElementTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var el = new RoutingElement();

			//Act
			el.BaseUrl = "localhost";
			el.ViewPath = "~/Views";

			//Assert
			Assert.AreEqual("localhost", el.BaseUrl);
			Assert.AreEqual("~/Views", el.ViewPath);
		}
	}
}
