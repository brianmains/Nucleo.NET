using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class ClientDescriptorEventTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingTheEventWithoutTheEventHandlerPropertyWorksOK()
		{
			//Arrange
			var evt = default(ClientDescriptorEvent);

			//Act
			evt = new ClientDescriptorEvent("textChanged", "TextChanged");

			//Assert
			Assert.AreEqual("textChanged", evt.ClientName);
			Assert.AreEqual("TextChanged", evt.ServerName);
		}

		[TestMethod]
		public void CreatingTheEventWithTheEventHandlerPropertyWorksOK()
		{
			//Arrange
			var evt = default(ClientDescriptorEvent);

			//Act
			evt = new ClientDescriptorEvent("textChanged", "TextChanged", "OnClientTextChanged");

			//Assert
			Assert.AreEqual("textChanged", evt.ClientName);
			Assert.AreEqual("TextChanged", evt.ServerName);
			Assert.AreEqual("OnClientTextChanged", evt.ClientEventHandlerPropertyName);
		}

		#endregion
	}
}
