using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.Tags;


namespace Nucleo.Extensions
{
	[TestClass]
	public class TagElementExtensionsTest
	{
		[TestMethod]
		public void AddingAttributesWorksOK()
		{
			var el = new TagElement("Test");

			el.AddAttribute("display", "none").AddAttribute("border", 0);

			Assert.AreEqual(2, el.Attributes.AttributeCount);
			Assert.AreEqual("none", el.Attributes.GetAttributeValue("display"));
		}

		[TestMethod]
		public void AddingChildrenWorksOK()
		{
			var el = new TagElement("Test");

			el.AddChildren(new TagElement("DIV"), new TagElement("SPAN"));

			Assert.AreEqual(2, el.Children.TagCount);
		}

		[TestMethod]
		public void AddingChildWorksOK()
		{
			var el = new TagElement("Test");

			el.AddChild(new TagElement("DIV")).AddChild(new TagElement("SPAN"));

			Assert.AreEqual(2, el.Children.TagCount);
		}

		[TestMethod]
		public void AddingStylesWorksOK()
		{
			var el = new TagElement("Test");

			el.AddStyle("display", "none").AddStyle("border", 0);

			Assert.AreEqual(2, el.Styles.AttributeCount);
			Assert.AreEqual("none", el.Styles.GetAttributeValue("display"));
		}
	}
}
