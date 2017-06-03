using System;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class WebImageTest
	{
		[TestMethod]
		public void TestCreatingObject()
		{
			WebImage image = new WebImage("~/img/pic.jpg");
			Assert.AreEqual("~/img/pic.jpg", image.Url);
			Assert.IsTrue(string.IsNullOrEmpty(image.AlternateText));
				
			image = new WebImage("~/Images/Test.gif", "Testing");
			Assert.AreEqual("~/Images/Test.gif", image.Url);
			Assert.AreEqual("Testing", image.AlternateText);

			image = new WebImage();
			Assert.IsTrue(string.IsNullOrEmpty(image.Url));
			Assert.IsTrue(string.IsNullOrEmpty(image.AlternateText));

			image.Url = "s.png";
			image.AlternateText = "alt";
			Assert.AreEqual("s.png", image.Url);
			Assert.AreEqual("alt", image.AlternateText);
		}

		[TestMethod]
		public void TestGettingImage()
		{
			WebImage image = new WebImage("~/pic.gif", "Test Image");
			Image picture = image.ToImage();
			Assert.IsNotNull(picture);
			Assert.AreEqual("~/pic.gif", picture.ImageUrl);
			Assert.AreEqual("Test Image", picture.AlternateText);
		}
	}
}
