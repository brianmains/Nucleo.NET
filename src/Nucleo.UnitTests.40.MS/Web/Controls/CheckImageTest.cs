using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Controls
{
	[TestClass]
	public class CheckImageTest
	{
		#region " Tests "

		[TestMethod]
		public void CopyingDataWorksOK()
		{
			//Arrange
			var check1 = Isolate.Fake.Instance<CheckImage>();
			Isolate.WhenCalled(() => check1.AssociatedValue).WillReturn(true);
			Isolate.WhenCalled(() => check1.DisabledImageUrl).WillReturn("d");
			Isolate.WhenCalled(() => check1.ImageUrl).WillReturn("i");

			//Act
			var check2 = new CheckImage(false);
			check2.CopyFrom(check1);

			//Assert
			Assert.AreEqual(true, check2.AssociatedValue);
			Assert.AreEqual("d", check2.DisabledImageUrl);
			Assert.AreEqual("i", check2.ImageUrl);
		}

		[TestMethod]
		public void CreatingSingleCtorCreatesOK()
		{
			//Arrange
			

			//Act
			var image = new CheckImage(true);

			//Assert
			Assert.AreEqual(true, image.AssociatedValue);
			Assert.IsNull(image.ImageUrl);
			Assert.IsNull(image.DisabledImageUrl);
		}

		[TestMethod]
		public void CreatingThreeParamCtorCreatesOK()
		{
			//Arrange

			//Act
			var image = new CheckImage("test.png", "testdisabled.png", false);

			//Assert
			Assert.AreEqual("test.png", image.ImageUrl);
			Assert.AreEqual("testdisabled.png", image.DisabledImageUrl);
			Assert.AreEqual(false, image.AssociatedValue);
		}

		[TestMethod]
		public void GettingAndSettingWorksOK()
		{
			//Arrange
			var image = Isolate.Fake.Instance<CheckImage>(Members.CallOriginal);

			//Act
			image.DisabledImageUrl = "d";
			image.ImageUrl = "i";

			//Assert
			Assert.AreEqual("d", image.DisabledImageUrl);
			Assert.AreEqual("i", image.ImageUrl);
		}

		#endregion
	}
}
