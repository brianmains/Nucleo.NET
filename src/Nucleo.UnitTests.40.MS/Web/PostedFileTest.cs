using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web
{
	[TestClass]
	public class PostedFileTest
	{
		[TestMethod]
		public void CreatingWithPostedFileReturnsCorrectValues()
		{
			//Arrange
			var postedFile = Isolate.Fake.Instance<HttpPostedFileBase>();
			Isolate.WhenCalled(() => postedFile.ContentLength).WillReturn(30);
			Isolate.WhenCalled(() => postedFile.ContentType).WillReturn("json");
			Isolate.WhenCalled(() => postedFile.FileName).WillReturn("Test");
			Isolate.WhenCalled(() => postedFile.InputStream).WillReturn(null);

			//Act
			var file = new PostedFile(postedFile);

			//Assert
			Assert.AreEqual(30, file.ContentLength);
			Assert.AreEqual("json", file.ContentType);
			Assert.AreEqual("Test", file.FileName);
			Assert.AreEqual(null, file.FileContents);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SavingAFileWorksOK()
		{
			//Arrange
			var postedFile = Isolate.Fake.Instance<HttpPostedFileBase>();
			Isolate.WhenCalled(() => postedFile.SaveAs(null)).IgnoreCall();

			//Act
			var file = new PostedFile(postedFile);
			file.SaveAs("XYZ");

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => postedFile.SaveAs(null));

			Isolate.CleanUp();
		}
	}
}
