using System;
using System.IO;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

namespace Nucleo.Web.Views
{
	[TestClass]
	public class FakeViewTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			FakeView view = new FakeView();

			//Act
			view.ViewContent = "<h1>This is my content</h1>";

			//Assert
			Assert.AreEqual("<h1>This is my content</h1>", view.ViewContent);
		}

		[TestMethod]
		public void RenderingFakeViewRendersContent()
		{
			//Arrange
			FakeView view = new FakeView();
			view.ViewContent = "<html><body>This is my content.</body></html>";
			var viewContextFake = Isolate.Fake.Instance<ViewContext>();

			string content = null;

			//Act
			using (StringWriter writer = new StringWriter())
			{
				view.Render(viewContextFake, writer);
				content = writer.ToString();
			}

			//Assert
			Assert.AreEqual("<html><body>This is my content.</body></html>", content);
		}

		#endregion
	}
}
