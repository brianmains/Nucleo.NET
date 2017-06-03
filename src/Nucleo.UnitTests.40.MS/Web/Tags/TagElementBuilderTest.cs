using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class TagElementBuilderTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingSingleTagElementMapsToCorrectObject()
		{
			var tag = TagElementBuilder.Create("A");
			Assert.AreEqual("A", tag.TagName);
		}

		[TestMethod]
		public void CreatingSingleTagElementAndAttributeDictionaryMapToCorrectObjects()
		{
			var attributes = new Dictionary<string, object>();
			attributes.Add("Href", "http://www.yahoo.com");
			attributes.Add("Target", "_blank");

			var tag = TagElementBuilder.Create("A", attributes);
			Assert.AreEqual("<A Href=\"http://www.yahoo.com\" Target=\"_blank\"></A>", tag.ToHtmlString());
		}

		[TestMethod]
		public void CreatingSingleTagElementAndAttributesMapToCorrectObjects()
		{
			var tag = TagElementBuilder.Create("A", new { Href = "http://www.yahoo.com", Target = "_blank" });
			Assert.AreEqual("<A Href=\"http://www.yahoo.com\" Target=\"_blank\"></A>", tag.ToHtmlString());
		}

		[TestMethod]
		public void CreatingTagAndContentAssignsValuesCorrectly()
		{
			//Arrange
			var tag = default(TagElement);

			//Act
			tag = TagElementBuilder.Create("A", "Test");

			//Assert
			Assert.AreEqual("A", tag.TagName);
			Assert.AreEqual("Test", tag.Content);
		}

		[TestMethod]
		public void CreatingTagGroupCreatesGroupOfElementsCorrectly()
		{
			//Arrange/Act
			var tagList = TagElementBuilder.CreateGroup(new string[] { "A", "STRONG", "SPAN", "DIV" });

			//Assert
			Assert.AreEqual(4, tagList.Tags.Count);
			Assert.IsTrue(tagList.Tags.Select(i => i.TagName).AreEqual(new string[] { "A", "STRONG", "SPAN", "DIV" }), "The tag list doesn't match");
		}

		[TestMethod]
		public void CreatingTagGroupUsingCountsAndAttributesCreatesGroupOfElementsCorrectly()
		{
			//Arrange/Act
			var tagList = TagElementBuilder.CreateGroup("A", 5,
				new { Href = "http://www.yahoo.com", Target = "_blank" });

			//Assert
			Assert.IsTrue(tagList.Tags.IsAll(i => i.Attributes.GetAttribute("Target").Value.ToString() == "_blank", ValidationIsAllCheck.True), "Target's don't match");
		}

		[TestMethod]
		public void CreatingTagGroupUsingCountsCreatesGroupOfElementsCorrectly()
		{
			//Arrange/Act
			var tagList = TagElementBuilder.CreateGroup("A", 5);

			//Assert
			Assert.AreEqual(5, tagList.Tags.Count);
			Assert.IsTrue(tagList.Tags.Select(i => i.TagName).AreEqual(new string[] { "A", "A", "A", "A", "A" }), "The tag list doesn't match");
		}

		#endregion
	}
}
