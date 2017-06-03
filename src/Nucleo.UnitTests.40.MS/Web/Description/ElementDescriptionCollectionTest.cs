using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;


namespace Nucleo.Web.Description
{
	[TestClass]
	public class ElementDescriptionCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingEmptyScriptReturnsEmpty()
		{
			//Arrange
			var elements = new ElementDescriptionCollection();

			//Act
			var script = elements.GetScript();

			//Assert
			Assert.AreEqual("{}", script);
		}

		[TestMethod]
		public void GettingEmptyScriptWithNullFormatterReturnsEmpty()
		{
			//Arrange
			var elements = new ElementDescriptionCollection();

			//Act
			var script = elements.GetScript(null);

			//Assert
			Assert.AreEqual("{}", script);
		}

		[TestMethod]
		public void GettingScriptWithCustomFormatterWorksOK()
		{
			//Arrange
			var elements = new ElementDescriptionCollection();
			elements.Add("loginName", "LoginNameControl");
			elements.Add("password", "PasswordControl");

			//Act
			var script = elements.GetScript(new CustomScriptIDFormatter("$(", ")"));

			//Assert
			Assert.AreEqual("{ loginName:$(LoginNameControl), password:$(PasswordControl) }", script);
		}

		[TestMethod]
		public void GettingScriptWithNullFormatterThrowsException()
		{
			//Arrange
			var elements = new ElementDescriptionCollection();
			elements.Add("Test", "1");

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { elements.GetScript(null); });
		}

		[TestMethod]
		public void GettingScriptWorksOK()
		{
			//Arrange
			var elements = new ElementDescriptionCollection();
			elements.Add("loginName", "LoginNameControl");
			elements.Add("password", "PasswordControl");

			//Act
			var script = elements.GetScript();

			//Assert
			Assert.AreEqual("{ loginName:$get(\"LoginNameControl\"), password:$get(\"PasswordControl\") }", script);
		}

		#endregion
	}
}
