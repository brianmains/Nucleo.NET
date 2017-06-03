using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.TestingTools;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class TagElementTest
	{
		#region " Tests "

		[TestMethod]
		public void CloningTagWithChildrenCopiesChildrenToo()
		{
			//Arrange
			var tag = new TagElement("SPAN", "My Content");
			tag.Attributes.AppendAttribute("width", "100");
			tag.Children.AppendTag(new TagElement("DIV"));
			tag.Children.AppendTag(new TagElement("DIV"));

			//Act
			var clone = tag.CloneTag(true);

			//Assert
			Assert.AreEqual("SPAN", clone.TagName);
			Assert.AreEqual("My Content", clone.Content);
			Assert.IsNotNull(clone.Attributes.GetAttribute("width"));
			Assert.AreEqual(2, clone.Children.Count);
			Assert.IsTrue(clone.Children.IsAll(i => i.TagName == "DIV", ValidationIsAllCheck.True), "Children aren't DIV's");
		}

		[TestMethod]
		public void CloningTagWithoutChildrenCopiesCorrectly()
		{
			//Arrange
			var tag = new TagElement("SPAN", "My Content");
			tag.Attributes.AppendAttribute("width", "100");
			tag.Styles.AppendAttribute("display", "none");

			//Act
			var clone = tag.CloneTag();

			//Assert
			Assert.AreEqual("SPAN", clone.TagName);
			Assert.AreEqual("My Content", clone.Content);
			Assert.IsNotNull(clone.Attributes.GetAttribute("width"));
			Assert.IsNotNull(clone.Styles.GetAttribute("display"));
		}

		[TestMethod]
		public void CreatingInLinqToXmlStyleWithTagsAddsOK()
		{
			//Arrange
			//Act
			var tag = new TagElement("SPAN",
				new TagElement("DIV"),
				new TagElement("DIV"));

			//Assert
			Assert.AreEqual(2, tag.Children.TagCount);
		}

		[TestMethod]
		public void CreatingInLinqToXmlStyleWithTagsAndAttributesAddsOK()
		{
			//Arrange
			//Act
			var tag = new TagElement("SPAN",
				new TagElement("DIV"),
				new TagElement("DIV"),
				new TagAttribute("display", "none"));

			//Assert
			Assert.AreEqual(2, tag.Children.TagCount);
			Assert.AreEqual(1, tag.Attributes.AttributeCount);
		}

		[TestMethod]
		public void CreatingTagChildrenCreatesCorrectObjects()
		{
			//Arrange
			var tag = new TagElement("DIV");

			//Act
			tag.Children.AppendTag(new TagElement("DIV"));
			tag.Children.AppendTag(new TagElement("SPAN"));

			//Assert
			Assert.AreEqual(2, tag.Children.TagCount);
		}

		[TestMethod]
		public void CreatingTagElementAssignsElementTag()
		{
			//Arrange
			var tag = default(TagElement);
			
			//Act
			tag = new TagElement("A");

			//Assert
			Assert.AreEqual("A", tag.TagName);
		}

		[TestMethod]
		public void CreatingTagElementWithContentAssignsCorrectly()
		{
			var tag = new TagElement("SPAN", "My content");

			Assert.AreEqual("SPAN", tag.TagName);
			Assert.AreEqual("My content", tag.Content);
		}

		[TestMethod]
		public void RenderingEmptyHtmlStringsRendersEmptyElement()
		{
			TagElement tag = new TagElement("SPAN");
			Assert.AreEqual("<SPAN></SPAN>", tag.ToHtmlString());
		}

		[TestMethod]
		public void RenderingHtmlStringsWithAttributesRendersCorrectHtml()
		{
			//Arrange
			TagElement tag = new TagElement("SPAN");

			//Act
			tag.Attributes.AppendAttribute("margin", "0px");
			tag.Content = "This is my content";

			//Assert
			Assert.AreEqual("<SPAN margin=\"0px\">This is my content</SPAN>", tag.ToHtmlString());
		}

		[TestMethod]
		public void RenderingHtmlStringsWithAttributesAndContentRendersCorrectHtml()
		{
			var tag = new TagElement("TABLE");
			tag.Attributes.AppendAttribute("cellspacing", "0px");

			Assert.AreEqual("<TABLE cellspacing=\"0px\"></TABLE>", tag.ToHtmlString());
		}

		[TestMethod]
		public void RenderingHtmlStringsWithAttributesAndStylesRendersCorrectHtml()
		{
			var tag = new TagElement("TABLE");
			tag.Attributes.AppendAttribute("cellspacing", "0px");
			tag.Styles.AppendAttribute("border", "1px solid black");
			tag.Styles.AppendAttribute("margin", "3px");

			Assert.AreEqual("<TABLE cellspacing=\"0px\" style=\"border:1px solid black;margin:3px;\"></TABLE>", tag.ToHtmlString());
		}

		[TestMethod]
		public void RenderingHtmlStringsWithChildrenRendersCorrectHtml()
		{
			//Arrange
			TagElement tag = new TagElement("DIV");

			//Act
			tag.Children.AppendTag(new TagElement("SPAN"));

			//Assert
			Assert.AreEqual("<DIV><SPAN></SPAN></DIV>", tag.ToHtmlString());
		}

		[TestMethod]
		public void RenderingHtmlStringsWithContentRendersCorrectHtml()
		{
			var tag = new TagElement("SPAN");
			tag.Content = "This is my content";

			Assert.AreEqual("<SPAN>This is my content</SPAN>", tag.ToHtmlString());
		}

		[TestMethod]
		public void RenderingHtmlStringsWithStylesRendersCorrectHtml()
		{
			var tag = new TagElement("SPAN");
			tag.Styles.AppendAttribute("display", "none");
			tag.Styles.AppendAttribute("color", "navy");

			Assert.AreEqual("<SPAN style=\"display:none;color:navy;\"></SPAN>", tag.ToHtmlString());
		}

		#endregion
	}
}
