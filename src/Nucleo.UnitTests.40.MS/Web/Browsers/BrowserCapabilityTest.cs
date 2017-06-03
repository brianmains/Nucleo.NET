using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Browsers
{
	[TestClass]
	public class BrowserCapabilityTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingBrowserWithEnumerationAssignsValuesCorrectly()
		{
			//Arrange
			var cap = new BrowserCapability(BrowserCapabilityFeature.Beta);

			//Act
			var name = cap.Name;
			var feature = cap.Feature;

			//Assert
			Assert.AreEqual("Beta", name);
			Assert.AreEqual(BrowserCapabilityFeature.Beta, feature);
		}

		[TestMethod]
		public void CreatingBrowserWithNameAssignsValuesCorrectly()
		{
			//Arrange
			var cap = new BrowserCapability("Beta");
			
			//Act
			var name = cap.Name;
			var feature = cap.Feature;

			//Assert
			Assert.AreEqual("Beta", name);
			Assert.AreEqual(BrowserCapabilityFeature.Beta, feature);
		}

		#endregion
	}
}
