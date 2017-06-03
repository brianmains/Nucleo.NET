using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class WebLegacyRendererAttributeTest
	{
		#region " Tests "

		[TestMethod]
		public void AssigningAttributeUsingTypeAssignsCorrectly()
		{
			//Arrange
			var attrib = new WebLegacyRendererAttribute();

			//Act
			attrib.RendererType = typeof(WebLegacyRendererAttributeTest);

			//Assert
			Assert.AreEqual(typeof(WebLegacyRendererAttributeTest), attrib.RendererType);
		}

		[TestMethod]
		public void AssigningAttributeUsingTypeNameAssignsCorrectly()
		{
			//Arrange
			var attrib = new WebLegacyRendererAttribute();

			//Act
			attrib.RendererTypeName = typeof(WebLegacyRendererAttribute).FullName;

			//Assert
			Assert.AreEqual(typeof(WebLegacyRendererAttribute).FullName, attrib.RendererTypeName);
		}

		[TestMethod]
		public void CreatingAttributeUsingTypeAssignsCorrectly()
		{
			//Arrange


			//Act
			var attrib = new WebLegacyRendererAttribute(typeof(WebLegacyRendererAttributeTest));

			//Assert
			Assert.AreEqual(typeof(WebLegacyRendererAttributeTest), attrib.RendererType);
		}

		[TestMethod]
		public void CreatingAttributeUsingTypeNameAssignsCorrectly()
		{
			//Arrange
			

			//Act
			var attrib = new WebLegacyRendererAttribute(typeof(WebLegacyRendererAttribute).FullName);

			//Assert
			Assert.AreEqual(typeof(WebLegacyRendererAttribute).FullName, attrib.RendererTypeName);
		}

		#endregion
	}
}
