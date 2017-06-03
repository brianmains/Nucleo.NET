using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class XElementExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingElementValueReturnsCorrectValue()
		{
			//Arrange
			var element = new XElement("Test", new XElement("First", "1"), new XElement("Second", "2"));

			//Act
			var value = XElementExtensions.ElementValue(element, "First");

			//Assert
			Assert.AreEqual("1", value);
		}

		[TestMethod]
		public void GettingMissingElementValueReturnsDefault()
		{
			//Arrange
			var element = new XElement("Test", new XElement("First", "1"), new XElement("Second", "2"));

			//Act
			var value = XElementExtensions.ElementValue(element, "Third", "3rd");

			//Assert
			Assert.AreEqual("3rd", value);
		}

		#endregion
	}
}
