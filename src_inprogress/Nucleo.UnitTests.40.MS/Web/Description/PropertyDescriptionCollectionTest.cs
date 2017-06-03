using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Description
{
	[TestClass]
	public class PropertyDescriptionCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingEmptyScriptReturnsCorrectFormat()
		{
			//Arrange
			var props = new PropertyDescriptionCollection();

			//Act
			var script = props.GetScript();

			//Assert
			Assert.AreEqual("{}", script);
		}

		[TestMethod]
		public void GettingScriptReturnsCorrectFormat()
		{
			//Arrange
			var props = new PropertyDescriptionCollection();
			props.Add("text", "A");
			props.Add("value", "1");

			//Act
			var script = props.GetScript();

			//Assert
			Assert.AreEqual("{ text:\"A\", value:\"1\" }", script);
		}

		#endregion
	}
}
