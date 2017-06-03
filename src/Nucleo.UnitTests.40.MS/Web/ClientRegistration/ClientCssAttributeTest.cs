using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class ClientCssAttributeTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingAttributeWithPathAndAssemblyWorksOK()
		{
			//Arrange
			var attrib = default(ClientCssAttribute);

			//Act
			attrib = new ClientCssAttribute("styles.css", "My.Assembly");

			//Assert
			Assert.AreEqual("styles.css", attrib.Path);
			Assert.AreEqual("My.Assembly", attrib.Assembly);
		}

		[TestMethod]
		public void CreatingAttributeWithPathWorksOK()
		{
			//Arrange
			var attrib = default(ClientCssAttribute);

			//Act
			attrib = new ClientCssAttribute("styles.css");

			//Assert
			Assert.AreEqual("styles.css", attrib.Path);
		}

		#endregion
	}
}
