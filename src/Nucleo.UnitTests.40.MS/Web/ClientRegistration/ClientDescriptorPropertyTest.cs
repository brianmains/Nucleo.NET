using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class ClientDescriptorPropertyTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingObjectWithPropertyAssignmentsWorksOK()
		{
			//Arrange
			var prop = default(ClientDescriptorProperty);

			//Act
			prop = new ClientDescriptorProperty("test", "Test");
			prop.ContentType = ClientPropertyContentType.AjaxComponent;
			prop.Value = 456;

			//Assert
			Assert.AreEqual("test", prop.ClientName);
			Assert.AreEqual("Test", prop.ServerName);
			Assert.AreEqual(ClientPropertyContentType.AjaxComponent, prop.ContentType);
			Assert.AreEqual(456, prop.Value);
		}

		[TestMethod]
		public void CreatingObjectWithValueAndContentTypeWorksOK()
		{
			//Arrange
			var prop = default(ClientDescriptorProperty);

			//Act
			prop = new ClientDescriptorProperty("test", "Test", ClientPropertyContentType.ClientElement, 123);

			//Assert
			Assert.AreEqual("test", prop.ClientName);
			Assert.AreEqual("Test", prop.ServerName);
			Assert.AreEqual(ClientPropertyContentType.ClientElement, prop.ContentType);
			Assert.AreEqual(123, prop.Value);
		}

		[TestMethod]
		public void CreatingObjectWithValueWorksOK()
		{
			//Arrange
			var prop = default(ClientDescriptorProperty);

			//Act
			prop = new ClientDescriptorProperty("test", "Test", 123);

			//Assert
			Assert.AreEqual("test", prop.ClientName);
			Assert.AreEqual("Test", prop.ServerName);
			Assert.AreEqual(123, prop.Value);
		}

		[TestMethod]
		public void CreatingObjectWorksOK()
		{
			//Arrange
			var prop = default(ClientDescriptorProperty);

			//Act
			prop = new ClientDescriptorProperty("test", "Test");

			//Assert
			Assert.AreEqual("test", prop.ClientName);
			Assert.AreEqual("Test", prop.ServerName);
		}

		#endregion
	}
}
