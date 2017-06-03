using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class ITextControlExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingColorReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "Red";

			//Act
			var color = text.GetColorName();

			//Assert
			Assert.AreEqual(Color.Red, color);
		}

		[TestMethod]
		public void GettingDecimalOrNullReturnsInvalidValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "ABC.23";

			//Act
			var value = text.GetDecimalOrNull();

			//Assert

			Assert.IsNull(value);
		}

		[TestMethod]
		public void GettingDecimalOrNullReturnsValidValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23.3";

			//Act
			var value = text.GetDecimalOrNull();

			//Assert
			Assert.AreEqual(System.Math.Round(23.3M, 1), System.Math.Round(value.Value, 1));
		}

		[TestMethod]
		public void GettingDecimalReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23.3";

			//Act
			var value = text.GetDecimal();

			//Assert

			Assert.AreEqual(System.Math.Round(23.3M, 1), System.Math.Round(value, 1));
		}

		[TestMethod]
		public void GettingDoubleOrNullReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23.3";

			//Act
			var value = text.GetDoubleOrNull();

			//Assert
			Assert.AreEqual(System.Math.Round(23.3, 1), System.Math.Round(value.Value, 1));
		}

		[TestMethod]
		public void GettingDoubleOrNullReturnsIncorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "2ABC3";

			//Act
			var value = text.GetDoubleOrNull();

			//Assert
			Assert.IsNull(value);
		}

		[TestMethod]
		public void GettingDoubleReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23.3";

			//Act
			var value = text.GetDouble();

			//Assert
			Assert.AreEqual(System.Math.Round(23.3, 1), System.Math.Round(value, 1));
		}

		[TestMethod]
		public void GettingFloatOrNullReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23.3";

			//Act
			var value = text.GetFloatOrNull();

			//Assert
			Assert.AreEqual(System.Math.Round(Convert.ToDecimal(23.3), 1), System.Math.Round(Convert.ToDecimal(value), 1));
		}

		[TestMethod]
		public void GettingFloatOrNullReturnsIncorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "2ABC3";

			//Act
			var value = text.GetFloatOrNull();

			//Assert
			Assert.IsNull(value);
		}

		[TestMethod]
		public void GettingFloatReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23.3";

			//Act
			var value = text.GetFloat();

			//Assert
			Assert.AreEqual(System.Math.Round(Convert.ToDecimal(23.3), 1), System.Math.Round(Convert.ToDecimal(value), 1));
		}

		[TestMethod]
		public void GettingIntegerOrNullReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23";

			//Act
			var value = text.GetIntegerOrNull();

			//Assert
			Assert.AreEqual(23, value.Value);
		}

		[TestMethod]
		public void GettingIntegerOrNullReturnsIncorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "2A3";

			//Act
			var value = text.GetIntegerOrNull();

			//Assert
			Assert.IsNull(value);
		}

		[TestMethod]
		public void GettingIntegerReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23";

			//Act
			var value = text.GetInteger();

			//Assert
			Assert.AreEqual(23, value);
		}

		[TestMethod]
		public void GettingShortOrNullReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23";

			//Act
			var value = text.GetShortOrNull();

			//Assert
			Assert.AreEqual(23, value.Value);
		}

		[TestMethod]
		public void GettingShortOrNullReturnsIncorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "2A3";

			//Act
			var value = text.GetShortOrNull();

			//Assert
			Assert.IsNull(value);
		}

		[TestMethod]
		public void GettingShortReturnsCorrectValue()
		{
			//Arrange
			ITextControl text = new TextBox();
			text.Text = "23";

			//Act
			var value = text.GetShort();

			//Assert
			Assert.AreEqual(23, value);
		}

		[TestMethod]
		public void SettingDecimalAssignsEmptyString()
		{
			//Arrange
			ITextControl text = new TextBox();
			
			//Act
			text.SetDecimal(null);

			//Assert
			Assert.AreEqual(string.Empty, text.Text);
		}

		[TestMethod]
		public void SettingDecimalAssignsOK()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetDecimal(12.3M);

			//Assert
			Assert.AreEqual("12.3", text.Text);
		}

		[TestMethod]
		public void SettingDoubleAssignsEmptyString()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetDouble(null);

			//Assert
			Assert.AreEqual(string.Empty, text.Text);
		}

		[TestMethod]
		public void SettingDoubleAssignsOK()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetDouble(12.3);

			//Assert
			Assert.AreEqual("12.3", text.Text);
		}

		[TestMethod]
		public void SettingFloatAssignsEmptyString()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetFloat(null);

			//Assert
			Assert.AreEqual(string.Empty, text.Text);
		}

		[TestMethod]
		public void SettingFloatAssignsOK()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetFloat(12.3F);

			//Assert
			Assert.AreEqual("12.3", text.Text);
		}

		[TestMethod]
		public void SettingIntegerAssignsEmptyString()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetInteger(null);

			//Assert
			Assert.AreEqual(string.Empty, text.Text);
		}

		[TestMethod]
		public void SettingIntegerAssignsOK()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetInteger(12);

			//Assert
			Assert.AreEqual("12", text.Text);
		}

		[TestMethod]
		public void SettingLongAssignsEmptyString()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetLong(null);

			//Assert
			Assert.AreEqual(string.Empty, text.Text);
		}

		[TestMethod]
		public void SettingLongAssignsOK()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetLong(12345);

			//Assert
			Assert.AreEqual("12345", text.Text);
		}

		[TestMethod]
		public void SettingShortAssignsEmptyString()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetShort(null);

			//Assert
			Assert.AreEqual(string.Empty, text.Text);
		}

		[TestMethod]
		public void SettingShortAssignsOK()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetShort(12);

			//Assert
			Assert.AreEqual("12", text.Text);
		}

		[TestMethod]
		public void SettingValueAsConvertibleAssignsOK()
		{
			//Arrange
			ITextControl text = new TextBox();

			//Act
			text.SetValueAs<int>(12);

			//Assert
			Assert.AreEqual("12", text.Text);
		}

		#endregion
	}
}
