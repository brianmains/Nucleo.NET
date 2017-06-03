using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class IDictionaryExtensionsTest
	{
		[TestMethod]
		public void GettingAttributesAsHTMLStringWithCustomSeparatorAndWithoutQuotesWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, object>();
			dict.Add("key", 1);
			dict.Add("name", "Test");
			dict.Add("print", true);

			//Act
			string text = dict.ToHtmlAttributeString("@", "$", false);

			//Assert
			Assert.AreEqual("key@1$name@Test$print@True", text);
		}

		[TestMethod]
		public void GettingAttributesAsHTMLStringWithCustomSeparatorWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, object>();
			dict.Add("key", 1);
			dict.Add("name", "Test");
			dict.Add("print", true);

			//Act
			string text = dict.ToHtmlAttributeString("@", "$");

			//Assert
			Assert.AreEqual("key@\"1\"$name@\"Test\"$print@\"True\"", text);
		}

		[TestMethod]
		public void GettingAttributesAsHTMLStringWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, object>();
			dict.Add("key", 1);
			dict.Add("name", "Test");
			dict.Add("print", true);

			//Act
			string text = dict.ToHtmlAttributeString();

			//Assert
			Assert.AreEqual("key=\"1\" name=\"Test\" print=\"True\"", text);
		}
	}
}
