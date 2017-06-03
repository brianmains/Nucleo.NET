using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class UrlTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingUrlWithAttributesWorksOK()
		{
			//Arrange
			var url = default(Url);
			var dict = new Dictionary<string, object>();
			dict.Add("A", 1);
			dict.Add("B", 2);
			dict.Add("C", 3);

			//Act
			url = new Url("default.aspx", dict);

			//Assert
			Assert.AreEqual("default.aspx", url.Path);
			Assert.AreEqual(3, url.Attributes.Count);
			Assert.AreEqual(1, url.Attributes["A"]);
			Assert.AreEqual(3, url.Attributes["C"]);
		}

		[TestMethod]
		public void CreatingUrlWithoutAttributesWorksOK()
		{
			//Arrange
			var url = default(Url);

			//Act
			url = new Url("default.aspx");

			//Assert
			Assert.AreEqual("default.aspx", url.Path);
		}

		[TestMethod]
		public void GeneratingUrlCreatesValidUrlString()
		{
			//Arrange
			var url = default(Url);
			var dict = new Dictionary<string, object>();
			dict.Add("A", 1);
			dict.Add("B", 2);
			dict.Add("C", 3);

			//Act
			url = new Url("default.aspx", dict);
			string text = url.ToString();

			//Assert
			Assert.AreEqual("default.aspx?A=1&B=2&C=3", text);
		}

		#endregion
	}
}
