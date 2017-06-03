using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Formatting
{
	[TestClass]
	public class HungarianFormPostKeyFormatterTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingLowerCaseIDReturnsSame()
		{
			//Arrange
			var id1 = "btnsave";
			var id2 = "hlnext";
			var format = new HungarianFormPostKeyFormatter();

			//Act
			var result1 = format.GetId(id1);
			var result2 = format.GetId(id2);

			//Act
			Assert.AreEqual("btnsave", result1);
			Assert.AreEqual("hlnext", result2);
		}

		[TestMethod]
		public void CreatingNullIDReturnsNull()
		{
			//Arrange
			var format = new HungarianFormPostKeyFormatter();

			//Act
			var result1 = format.GetId(null);

			//Act
			Assert.AreEqual(null, result1);
		}

		[TestMethod]
		public void CreatingValidIDWorksOK()
		{
			//Arrange
			var id1 = "btnSave";
			var id2 = "hlNext";
			var format = new HungarianFormPostKeyFormatter();

			//Act
			var result1 = format.GetId(id1);
			var result2 = format.GetId(id2);

			//Act
			Assert.AreEqual("Save", result1);
			Assert.AreEqual("Next", result2);
		}

		#endregion
	}
}
