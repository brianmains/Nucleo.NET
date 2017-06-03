using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.Web
{
	[TestClass]
	public class ControlUtilityTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingEmptyAttributeListReturnsEmptyDictionary()
		{
			//Arrange

			//Act
			var attribsNull = ControlUtility.GetAttributes(null);
			var attribsEmpty = ControlUtility.GetAttributes(string.Empty);

			//Assert
			Assert.IsNotNull(attribsNull);
			Assert.AreEqual(0, attribsNull.Count);

			Assert.IsNotNull(attribsEmpty);
			Assert.AreEqual(0, attribsEmpty.Count);
		}

		[TestMethod]
		public void GettingFullAttributeListReturnsPopulatedDictionary()
		{
			//Arrange
			string attributes = "font-weight:bold;text-decoration:underline;";

			//Act
			var attribs = ControlUtility.GetAttributes(attributes);

			//Assert
			Assert.IsNotNull(attribs);
			Assert.AreEqual(2, attribs.Count);
			Assert.AreEqual("bold", attribs["font-weight"]);
			Assert.AreEqual("underline", attribs["text-decoration"]);
		}

		[TestMethod]
		public void GettingMarkupOfControlWorksCorrectly()
		{
			//Arrange
			Label label = new Label();
			label.Text = "Test";

			//Act
			string text = ControlUtility.GetControlMarkup(label);

			//Assert
			Assert.IsTrue(text.Contains("Test</span>"));
		}

		[TestMethod]
		public void GettingPostbackMethodReturnsCorrectMethodReference()
		{
			//Arrange
			string id = "btn";
			string args = "Click";

			//Act
			string url = ControlUtility.GetPostbackClientMethod(id, args);

			//Assert
			Assert.AreEqual(url, string.Format("__doPostBack('{0}', '{1}');", id, args));
		}

		[TestMethod]
		public void GettingPostbackMethodWithEmptyArgsWorksOK()
		{
			//Arrange
			string id = "btn";

			//Act
			string url1 = ControlUtility.GetPostbackClientMethod(id, null);
			string url2 = ControlUtility.GetPostbackClientMethod(id, string.Empty);

			//Assert
			Assert.AreEqual(url1, string.Format("__doPostBack('{0}', '');", id));
			Assert.AreEqual(url2, string.Format("__doPostBack('{0}', '');", id));
		}

		[TestMethod]
		public void GettingPostbackMethodWithNoControlThrowsException()
		{
			//Arrange
			string id = null;

			//Act/Assert
			ExceptionTester.CheckException(true, (src) => { ControlUtility.GetPostbackClientMethod(id, ""); });
		}

		[TestMethod]
		public void GettingTemplateMarkupReturnsCorrectHTML()
		{
			//Arrange
			var panel = new Panel();
			var template = new FakeTemplate();

			//Act
			var markup = ControlUtility.GetTemplateMarkup(panel, template);

			//Assert
			Assert.AreEqual(1, panel.Controls.Count);
			StringAssert.StartsWith(markup, "<div>");
			StringAssert.Contains(markup, "Fake!!!");
		}

		[TestMethod]
		public void HandlingNullsInListWorksCorrectly()
		{
			//Arrange
			string attributes = "font-weight:bold;text-decoration:;width:;";

			//Act
			var attribs = ControlUtility.GetAttributes(attributes);

			//Assert
			Assert.AreEqual(3, attribs.Count);
			Assert.IsNull(attribs["text-decoration"]);
			Assert.IsNull(attribs["width"]);
		}

		#endregion
	}
}
