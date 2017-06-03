using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Mvc.Content
{
	[TestClass]
	public class ContentHelperTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingCssReturnsOK()
		{
			//Arrange
			var helperFake = Isolate.Fake.Instance<HtmlHelper>();

			//Act
			var css = ContentHelper.Css(helperFake, "styles.css");
			
			//Assert
			Assert.AreEqual("<link rel=\"stylesheet\" type=\"text/css\" src=\"styles.css\"></link>", css);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingDebugScriptsReturnsOK()
		{
			//Arrange
			var helperFake = Isolate.Fake.Instance<HtmlHelper>();

			//Act
			var script = ContentHelper.Script(helperFake, "myscript.js");
			var script2 = ContentHelper.Script(helperFake, "myscript.js", "myscript.min.js");

			//Assert
			Assert.AreEqual("<script type=\"text/javascript\" language=\"javascript\" src=\"myscript.js\"></script>", script);
			Assert.AreEqual("<script type=\"text/javascript\" language=\"javascript\" src=\"myscript.js\"></script>", script2);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingImageWithUrlOnlyReturnsOK()
		{
			//Arrange
			var helperFake = Isolate.Fake.Instance<HtmlHelper>();

			//Act
			var image = ContentHelper.Image(helperFake, "logo.png");

			//Assert
			Assert.AreEqual("<img src=\"logo.png\"></img>", image);

			Isolate.CleanUp();
		}

		#endregion
	}
}
