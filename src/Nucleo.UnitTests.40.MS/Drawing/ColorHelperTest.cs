using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Drawing
{
	[TestClass]
	public class ColorHelperTest
	{
		#region " Tests "

		[TestMethod]
		public void ConvertingColorToLightYellowReturnsCorrectName()
		{
			//Arrange
			var color = Color.LightYellow;

			//Act
			var colorName = ColorHelper.GetColorName(color);

			//Assert
			Assert.AreEqual("LightYellow", colorName, "Color isn't light yellow");
		}

		[TestMethod]
		public void ConvertingColorToWhiteReturnsCorrectName()
		{
			//Arrange
			var color = Color.White;

			//Act
			var colorName = ColorHelper.GetColorName(color);

			//Assert
			Assert.AreEqual("White", colorName, "Color isn't white");
		}

		[TestMethod]
		public void ConvertingEmptyNameToColorReturnsCorrectColor()
		{
			//Arrange
			var colorName1 = "";
			var colorName2 = default(string);

			//Act
			var color1 = ColorHelper.ToColor(colorName1);
			var color2 = ColorHelper.ToColor(colorName2);

			//Assert
			Assert.AreEqual(Color.Empty, color1, "Color isn't empty");
			Assert.AreEqual(Color.Empty, color2, "Color isn't empty");
		}

		[TestMethod]
		public void ConvertingLightYellowNameToColorReturnsCorrectColor()
		{
			//Arrange
			var colorName = "lightyellow";

			//Act
			var color = ColorHelper.ToColor(colorName);

			//Assert
			Assert.AreEqual(Color.LightYellow, color, "Color's don't match");
		}

		[TestMethod]
		public void ConvertingWhiteNameToColorReturnsCorrectColor()
		{
			//Arrange
			var colorName = "White";

			//Act
			var color = ColorHelper.ToColor(colorName);

			//Assert
			Assert.AreEqual(Color.White, color, "Color's don't match");
		}

		[TestMethod]
		public void IsColorEmptyReturnsFalse()
		{
			//Arrange
			var color = Color.Lime;

			//Act
			var isEmpty = ColorHelper.IsEmptyColor(color);

			//Assert
			Assert.IsFalse(isEmpty, "Color isn't non-empty");
		}

		[TestMethod]
		public void IsColorEmptyReturnsTrue()
		{
			//Arrange
			var color = Color.Empty;

			//Act
			var isEmpty = ColorHelper.IsEmptyColor(color);

			//Assert
			Assert.IsTrue(isEmpty, "Color isn't empty");
		}

		#endregion
	}
}
