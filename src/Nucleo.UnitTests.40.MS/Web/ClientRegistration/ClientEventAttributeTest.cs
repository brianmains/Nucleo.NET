using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class ClientEventAttributeTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingAttributeWithEventHandlerPropertyWorksOK()
		{
			//Arrange
			var attrib = default(ClientEventAttribute);

			//Act
			attrib = new ClientEventAttribute("textChanged", "OnClientTextChanged");

			//Assert
			Assert.AreEqual("textChanged", attrib.ClientName);
			Assert.AreEqual("OnClientTextChanged", attrib.ClientEventHandlerPropertyName);
		}

		[TestMethod]
		public void CreatingAttributeWithPropertyWorksOK()
		{
			//Arrange
			var attrib = default(ClientEventAttribute);

			//Act
			attrib = new ClientEventAttribute("textChanged");
			attrib.ClientEventHandlerPropertyName = "OnClientTextChanged";

			//Assert
			Assert.AreEqual("textChanged", attrib.ClientName);
			Assert.AreEqual("OnClientTextChanged", attrib.ClientEventHandlerPropertyName);
		}

		[TestMethod]
		public void CreatingAttributeWorksOK()
		{
			//Arrange
			var attrib = default(ClientEventAttribute);

			//Act
			attrib = new ClientEventAttribute("textChanged");

			//Assert
			Assert.AreEqual("textChanged", attrib.ClientName);
		}

		#endregion
	}
}
