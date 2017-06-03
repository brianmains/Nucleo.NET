using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class ClientPropertyAttributeTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingPropertyWithContentTypeWorksOK()
		{
			//Arrange
			var prop = default(ClientPropertyAttribute);

			//Act
			prop = new ClientPropertyAttribute("text", "value");
			prop.ContentType = ClientPropertyContentType.AjaxComponent;

			//Assert
			Assert.AreEqual("text", prop.ClientName);
			Assert.AreEqual("value", prop.DefaultValue);
			Assert.AreEqual(ClientPropertyContentType.AjaxComponent, prop.ContentType);
		}

		[TestMethod]
		public void CreatingPropertyWithConverterAndValueWorksOK()
		{
			//Arrange
			var prop = default(ClientPropertyAttribute);

			//Act
			prop = new ClientPropertyAttribute("text", "value", typeof(JavaScriptConverter));

			//Assert
			Assert.AreEqual("text", prop.ClientName);
			Assert.AreEqual("value", prop.DefaultValue);
			Assert.AreEqual(typeof(JavaScriptConverter).AssemblyQualifiedName, prop.JavascriptConverterType);
		}

		[TestMethod]
		public void CreatingPropertyWithValueWorksOK()
		{
			//Arrange
			var prop = default(ClientPropertyAttribute);

			//Act
			prop = new ClientPropertyAttribute("text", "value");

			//Assert
			Assert.AreEqual("text", prop.ClientName);
			Assert.AreEqual("value", prop.DefaultValue);
		}

		[TestMethod]
		public void CreatingPropertyWorksOK()
		{
			//Arrange
			var prop = default(ClientPropertyAttribute);

			//Act
			prop = new ClientPropertyAttribute("text");

			//Assert
			Assert.AreEqual("text", prop.ClientName);
		}

		#endregion
	}
}
