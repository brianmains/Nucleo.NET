using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Collections;


namespace Nucleo.Web
{
	[TestClass]
	public class ClientPropertyNamingDetailsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingClientPropertyDetailsWithPropertyNameAssignsPropertyCorrectly()
		{
			//Arrange
			var details = default(ClientPropertyNamingDetails);

			//Act
			details = new ClientPropertyNamingDetails("testProperty");

			//Assert
			Assert.AreEqual("testProperty", details.ClientPropertyName);
		}

		#endregion
	}
}
