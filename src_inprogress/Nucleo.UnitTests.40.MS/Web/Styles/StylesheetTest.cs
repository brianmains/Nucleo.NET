using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Styles
{
	[TestClass]
	public class StylesheetTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var styles = new Stylesheet();

			//Act
			styles.Path = "xyz.css";
			styles.ReferenceName = "X";
			styles.ReferenceType = typeof(object);
			
			//Assert
			Assert.AreEqual("xyz.css", styles.Path);
			Assert.AreEqual("X", styles.ReferenceName);
			Assert.AreEqual(typeof(object), styles.ReferenceType);
		}
	}
}
