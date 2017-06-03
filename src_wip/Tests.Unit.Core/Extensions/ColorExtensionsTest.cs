using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class ColorExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingForEmptyColorReturnsFalse()
		{
			//Arrange
			var color = Color.Red;

			//Act
			var result = ColorExtensions.IsEmptyColor(color);

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void CheckingForEmptyColorReturnsTrue()
		{
			//Arrange
			var color = Color.Empty;

			//Act
			var result = ColorExtensions.IsEmptyColor(color);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void GettingColorFromNameReturnsOK()
		{
			//Arrange
			var color = "Red";

			//Act
			var output = ColorExtensions.ToColor(color);

			//Assert
			Assert.AreEqual(Color.Red, output);
		}

		[TestMethod]
		public void GettingColorNameReturnsCorrectValue()
		{
			//Arrange
			var color = Color.Red;

			//Act
			var name = ColorExtensions.GetColorName(color);

			//Assert
			Assert.AreEqual("Red", name);
		}

		#endregion
	}
}
