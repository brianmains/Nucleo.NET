using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Images
{
	[TestClass]
	public class ImageItemTest
	{
		#region " Tests "

		[TestMethod]
		public void ChangingImageWorksOK()
		{
			//Arrange
			var item = new ImageItem("a.jpg");

			//Act
			item.ImageUrl = "b.gif";

			//Assert
			Assert.AreEqual("b.gif", item.ImageUrl);
		}

		[TestMethod]
		public void CreatingImageWorksOK()
		{
			//Arrange
			var item = default(ImageItem);

			//Act
			item = new ImageItem("test.jpg");

			//Assert
			Assert.AreEqual("test.jpg", item.ImageUrl);
		}

		#endregion
	}
}
