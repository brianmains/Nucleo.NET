using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class ClientScriptAttributeTest
	{
		#region " Test Classes "

		protected class TestComponent : BaseAjaxControl { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingAttributeWithModeWorksOK()
		{
			//Arrange
			var attrib = default(ClientScriptAttribute);

			//Act
			attrib = new ClientScriptAttribute(typeof(TestComponent), ScriptMode.Debug);

			//Assert
			Assert.AreEqual(typeof(TestComponent).FullName, attrib.Type);
			Assert.AreEqual(ScriptMode.Debug, attrib.Mode);
		}

		[TestMethod]
		public void CreatingAttributeWithTypeAndAssemblyWorksOK()
		{
			//Arrange
			var attrib = default(ClientScriptAttribute);

			//Act
			attrib = new ClientScriptAttribute("TestComponent", "Nucleo");

			//Assert
			Assert.AreEqual("TestComponent", attrib.Type);
			Assert.AreEqual("Nucleo", attrib.Assembly);
		}

		[TestMethod]
		public void CreatingAttributeWithTypeAssemblyAndModeWorksOK()
		{
			//Arrange
			var attrib = default(ClientScriptAttribute);

			//Act
			attrib = new ClientScriptAttribute("TestComponent", "Nucleo", ScriptMode.Release);

			//Assert
			Assert.AreEqual("TestComponent", attrib.Type);
			Assert.AreEqual("Nucleo", attrib.Assembly);
			Assert.AreEqual(ScriptMode.Release, attrib.Mode);
		}

		[TestMethod]
		public void CreatingAttributeWorksOK()
		{
			//Arrange
			var attrib = default(ClientScriptAttribute);

			//Act
			attrib = new ClientScriptAttribute(typeof(TestComponent));

			//Assert
			Assert.AreEqual(typeof(TestComponent).FullName, attrib.Type);
		}

		#endregion
	}
}
