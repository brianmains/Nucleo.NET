using System;
using System.Web.UI;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Controls
{
	[TestClass]
	public class CheckTest
	{
		#region " Tests "

		[TestMethod]
		public void AllowingEmptyCheckStateReturnsNullCheckStatusByDefault()
		{
			//Arrange
			Check check = new Check();

			//Act
			check.AllowEmptyCheckState = true;

			//Assert
			Assert.IsNull(check.Checked, "Not null");
		}

		[TestMethod]
		public void ChangingEmptyCheckStateChangesCheckValue()
		{
			//Arrange
			Check check = new Check();

			//Act
			check.AllowEmptyCheckState = true;
			check.Checked = null;

			check.AllowEmptyCheckState = false;

			//Assert
			Assert.AreEqual(false, check.Checked, "Checked doesn't return false when check state has changed");
		}

		[TestMethod]
		public void DisallowingEmptyCheckStateReturnsFalseCheckStatusByDefault()
		{
			//Arrange
			Check check = new Check();

			//Act
			check.AllowEmptyCheckState = false;

			//Assert
			Assert.AreEqual(false, check.Checked, "Not false");
		}

		[TestMethod]
		public void GettingAllButEmptyCheckImagesReturnsCollection()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();
			check.AllowEmptyCheckState = false;

			//Act
			var list = check.GetCheckImages();

			//Assert
			Assert.AreEqual(2, list.Count);
			Assert.AreEqual(check.TrueImage, list[0]);
			Assert.AreEqual(check.FalseImage, list[1]);
		}

		[TestMethod]
		public void GettingAllCheckImagesReturnsCollection()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();
			check.AllowEmptyCheckState = true;

			//Act
			var list = check.GetCheckImages();

			//Assert
			Assert.AreEqual(3, list.Count);
			Assert.AreEqual(check.TrueImage, list[0]);
			Assert.AreEqual(check.FalseImage, list[1]);
			Assert.AreEqual(check.EmptyImage, list[2]);
		}

		[TestMethod]
		public void GettingFalseSelectedImageReturnsCorrectObject()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();

			//Act
			check.Checked = false;
			var selectedImage = check.SelectedImage;

			//Assert
			Assert.AreEqual(check.FalseImage, selectedImage);
		}

		[TestMethod]
		public void GettingNullSelectedImageReturnsCorrectObject()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();
			check.AllowEmptyCheckState = true;

			//Act
			check.Checked = null;
			var selectedImage = check.SelectedImage;

			//Assert
			Assert.AreEqual(check.EmptyImage, selectedImage);
		}

		[TestMethod]
		public void GettingTrueSelectedImageReturnsCorrectObject()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();

			//Act
			check.Checked = true;
			var selectedImage = check.SelectedImage;
			
			//Assert
			Assert.AreEqual(check.TrueImage, selectedImage);
		}

		[TestMethod]
		public void GettingSelectedImageUrlWhenDisabledReturnsCorrectUrl()
		{
			//Arrange
			Check check = ControlTestingUtility.CreateControl<Check>();
			check.TrueImage.ImageUrl = "trueimage.png";
			check.TrueImage.DisabledImageUrl = "trueimage_d.png";

			//Act
			check.Checked = true;
			check.Enabled = false;
			string url = check.GetSelectedImageUrl();

			//Assert
			Assert.AreEqual("trueimage_d.png", url, "Url isn't true enabled image");
		}

		[TestMethod]
		public void GettingSelectedImageUrlWhenEnabledReturnsCorrectUrl()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();
			check.TrueImage.ImageUrl = "trueimage.png";
			check.TrueImage.DisabledImageUrl = "trueimage_d.png";

			//Act
			check.Checked = true;
			check.Enabled = true;
			string url = check.GetSelectedImageUrl();

			//Assert
			Assert.AreEqual("trueimage.png", url, "Url isn't true enabled image");
		}

		[TestMethod]
		public void GettingTextWithFormatWorksCorrectly()
		{
			//Arrange
			Check check = new Check();

			//Act
			check.Text = "Some Text";
			check.TextFormat = "My formatted text: {0}";

			//Assert
			Assert.AreEqual("My formatted text: Some Text", check.GetText());
		}

		[TestMethod]
		public void GettingTextWorksCorrectly()
		{
			//Arrange
			Check check = new Check();

			//Act
			check.Text = "Some Text";

			//Assert
			Assert.AreEqual("Some Text", check.Text);
			Assert.AreEqual("Some Text", check.GetText());
		}

		[TestMethod]
		public void HasEmptyImageReturnsFalseWhenNull()
		{
			//Arrange
			var check = new Check();

			//Act
			var result = check.HasEmptyImage;

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void HasFalseImageReturnsFalseWhenNull()
		{
			//Arrange
			var check = new Check();

			//Act
			var result = check.HasFalseImage;

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void HasTrueImageReturnsFalseWhenNull()
		{
			//Arrange
			var check = new Check();

			//Act
			var result = check.HasTrueImage;

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void RaisingPostbackToggles()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();
			check.Checked = true;

			//Act
			((IPostBackEventHandler)check).RaisePostBackEvent("toggle");

			//Assert
			Assert.AreEqual(false, check.Checked, "Postback event didn't toggle");
		}

		[TestMethod]
		public void SettingCheckedToNullWhenDisallowedDefaultsToFalse()
		{
			//Arrange
			Check check = new Check();
			check.AllowEmptyCheckState = false;

			//Act
			check.Checked = null;

			//Assert
			Assert.AreEqual(false, check.Checked);
		}

		[TestMethod]
		public void TogglingImageFromFalseWithEmptyCheckStateWorksCorrectly()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();
			check.Checked = false;
			check.AllowEmptyCheckState = true;

			//Act
			check.ToggleCheckedValue();

			//Assert
			Assert.AreEqual(null, check.Checked);
		}

		[TestMethod]
		public void TogglingImageFromFalseWithoutEmptyCheckStateWorksCorrectly()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();
			check.Checked = false;
			check.AllowEmptyCheckState = false;

			//Act
			check.ToggleCheckedValue();

			//Assert
			Assert.AreEqual(true, check.Checked);
		}

		[TestMethod]
		public void TogglingImageFromNullWorksCorrectly()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();
			check.AllowEmptyCheckState = true;
			check.Checked = null;

			//Act
			check.ToggleCheckedValue();

			//Assert
			Assert.AreEqual(true, check.Checked);
		}

		[TestMethod]
		public void TogglingImageFromTrueWorksCorrectly()
		{
			//Arrange
			Check check = new Check();
			check.Page = new Page();
			check.Checked = true;

			//Act
			check.ToggleCheckedValue();

			//Assert
			Assert.AreEqual(false, check.Checked);
		}

		#endregion
	}
}
