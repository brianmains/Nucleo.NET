using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web
{
	[TestClass]
	public class BaseControlWriterExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void WritingNullMvcStringWorksOK()
		{
			//Arrange
			var mvcString = default(MvcHtmlString);
			var writer = new StringControlWriter();

			//Act
			writer.Write(mvcString);

			//Assert
			Assert.AreEqual("", writer.ToString());
		}

		[TestMethod]
		public void WritingMvcStringWorksOK()
		{
			//Arrange
			var mvcString = Isolate.Fake.Instance<MvcHtmlString>();
			Isolate.WhenCalled(() => mvcString.ToHtmlString()).WillReturn("<span>Text</span>");
			var writer = new StringControlWriter();

			//Act
			writer.Write(mvcString);

			//Assert
			Assert.AreEqual("<span>Text</span>", writer.ToString());
		}

		#endregion
	}
}
