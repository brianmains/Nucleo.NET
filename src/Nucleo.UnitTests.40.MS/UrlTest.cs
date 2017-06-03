using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo
{
	[TestClass]
	public class UrlTest
	{
		[TestMethod]
		public void CreatingBaseUrlWithAttributesWorksOK()
		{

			//Act
			var url = new Url("test.aspx", new Dictionary<string, object>
				{
					{ "id", 1 },
					{ "print", true }
				});

			//Assert
			Assert.AreEqual("test.aspx", url.Path);
			Assert.AreEqual(2, url.Attributes.Count);
			Assert.AreEqual(true, url.Attributes["print"]);
		}

		[TestMethod]
		public void CreatingBaseUrlWorksOK()
		{

			//Act
			var url = new Url("test.aspx");

			//Assert
			Assert.AreEqual("test.aspx", url.Path);
		}

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var url = new Url("X");

			//Act
			url.Path = "test.aspx";
			url.Attributes = new Dictionary<string, object>()
			{
				{ "id", 1 }
			};

			//Assert
			Assert.AreEqual("test.aspx", url.Path);
			Assert.AreEqual(1, url.Attributes.Count);
		}

		[TestMethod]
		public void ToStringWithCorePathAndEmptyAttributeReturnsThisPath()
		{
			//Arrange
			var url = new Url("Test.aspx", new Dictionary<string, object>());

			//Act
			var output = url.ToString();

			//Assert
			Assert.AreEqual("Test.aspx", url.ToString());
		}

		[TestMethod]
		public void ToStringWithCorePathAndMultipleAttributeReturnsThisPath()
		{
			//Arrange
			var url = new Url("Test.aspx", new Dictionary<string, object>()
			{
				{ "id", 1 },
				{ "print", true }
			});

			//Act
			var output = url.ToString();

			//Assert
			Assert.AreEqual("Test.aspx?id=1&print=True", url.ToString());
		}

		[TestMethod]
		public void ToStringWithCorePathAndSingleAttributeReturnsThisPath()
		{
			//Arrange
			var url = new Url("Test.aspx", new Dictionary<string, object>()
			{
				{ "id", 1 }
			});

			//Act
			var output = url.ToString();

			//Assert
			Assert.AreEqual("Test.aspx?id=1", url.ToString());
		}

		[TestMethod]
		public void ToStringWithCorePathReturnsThisPath()
		{
			//Arrange
			var url = new Url("Test.aspx");

			//Act
			var output = url.ToString();

			//Assert
			Assert.AreEqual("Test.aspx", url.ToString());			
		}
	}
}
