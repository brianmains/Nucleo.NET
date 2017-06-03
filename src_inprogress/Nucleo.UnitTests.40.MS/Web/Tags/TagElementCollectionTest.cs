using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.TestingTools;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class TagElementCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingNullChildThrowsException()
		{
			//Arrange
			var tagList = new TagElementCollection();

			//Act/Assert
			ExceptionTester.CheckException(true, (src) => tagList.AppendTag(null));
		}

		[TestMethod]
		public void AddingNullTagsInBulkThrowsException()
		{
			//Arrange
			var tagList = new TagElementCollection();

			//Act/Assert
			ExceptionTester.CheckException(true, (src) => tagList.AppendTags((TagElement[])null));

			ExceptionTester.CheckException(true, (src) => tagList.AppendTags((TagElementCollection)null));
		}

		[TestMethod]
		public void AddingTagAddsChildrenToList()
		{
			//Arrange
			var tagList = new TagElementCollection();

			//Act
			tagList.AppendTag(new TagElement("THEAD"));
			tagList.AppendTag(new TagElement("TBODY"));

			//Assert
			Assert.AreEqual(2, tagList.TagCount);
			Assert.AreEqual("THEAD", tagList.GetTag(0).TagName);
			Assert.AreEqual("TBODY", tagList.GetTag(1).TagName);
		}

		[TestMethod]
		public void AddingTagsInBulkAddsToList()
		{
			//Arrange
			var tagList = new TagElementCollection();

			//Act
			tagList.AppendTags(
				new TagElement("THEAD"),
				new TagElement("TBODY")
			);

			//Assert
			Assert.AreEqual(2, tagList.TagCount);
			Assert.AreEqual("THEAD", tagList.GetTag(0).TagName);
			Assert.AreEqual("TBODY", tagList.GetTag(1).TagName);
		}

		[TestMethod]
		public void CloningTagsWithAddedChildrenClonesElementsCorrectly()
		{
			//Arrange
			var element = new TagElement("DIV");
			element.Children.AppendTag(new TagElement("SPAN"));
			element.Children.AppendTag(new TagElement("SPAN"));

			var tagList = new TagElementCollection();
			tagList.AppendTags(element);

			//Act
			var clonedList = tagList.CloneTags(true);

			//Assert
			Assert.AreEqual(1, clonedList.TagCount);
			Assert.AreEqual(2, clonedList[0].Children.TagCount);
		}

		[TestMethod]
		public void CloningTagsWithoutAddedChildrenClonesElementsCorrectly()
		{
			//Arrange
			var tagList = new TagElementCollection();
			tagList.AppendTags(new TagElement("DIV"), new TagElement("DIV"));

			//Act
			var clonedList = tagList.CloneTags();

			//Assert
			Assert.IsTrue(clonedList.IsAll(i => i.TagName == "DIV", ValidationIsAllCheck.True), "Cloned items aren't DIV's");
		}

		[TestMethod]
		public void GettingTagByIndexReturnsCorrectObjects()
		{
			//Arrange			
			var tagList = Isolate.Fake.Instance<TagElementCollection>();
			Isolate.WhenCalled(() => tagList.GetTag(0)).WithExactArguments()
				.WillReturn(new TagElement("SPAN"));
			Isolate.WhenCalled(() => tagList.GetTag(4)).WithExactArguments()
				.WillReturn(new TagElement("A"));
			
			//Act
			var tag1 = tagList.GetTag(0);
			var tag2 = tagList.GetTag(4);

			//Assert
			Assert.IsNotNull(tag1);
			Assert.IsNotNull(tag2);
		}

		[TestMethod]
		public void GettingTagsByLambdaReturnsCollection()
		{
			//Arrange
			var tagList = new TagElementCollection();
			tagList.AppendTags
			(
				new TagElement("SPAN"),
				new TagElement("SPAN"),
				new TagElement("DIV"),
				new TagElement("SPAN"),
				new TagElement("DIV")
			);

			//Act
			var results = tagList.GetTags(i => i.TagName == "SPAN");

			//Assert
			Assert.AreEqual(3, results.Count());
			Assert.IsTrue(results.IsAll(i => i.TagName == "SPAN", ValidationIsAllCheck.True), "The tag name isn't SPAN");
		}

		[TestMethod]
		public void GettingTagsByNameReturnsCorrectFirstElement()
		{
			//Arrange
			var tagList = new TagElementCollection();
			tagList.AppendTags
			(
				new TagElement("SPAN", "My Content"),
				new TagElement("SPAN"),
				new TagElement("DIV"),
				new TagElement("SPAN"),
				new TagElement("DIV")
			);

			//Act
			var results = tagList.GetTag("SPAN");
			
			//Assert
			Assert.AreEqual("SPAN", results.TagName);
			Assert.AreEqual("My Content", results.Content);
		}

		[TestMethod]
		public void GettingTagsByNameWithNonMatchingValueReturnsNull()
		{
			//Arrange
			var tagList = new TagElementCollection();
			tagList.AppendTags
			(
				new TagElement("SPAN", "My Content"),
				new TagElement("SPAN"),
				new TagElement("DIV"),
				new TagElement("SPAN"),
				new TagElement("DIV")
			);

			//Act
			var results = tagList.GetTag("A");

			//Assert
			Assert.AreEqual(null, results);
		}

		[TestMethod]
		public void GettingTagsByNamesReturnsCorrectFirstElement()
		{
			//Arrange
			var tagList = new TagElementCollection();
			tagList.AppendTags
			(
				new TagElement("SPAN", "My Content"),
				new TagElement("SPAN"),
				new TagElement("DIV"),
				new TagElement("SPAN"),
				new TagElement("DIV")
			);

			//Act
			var results = tagList.GetTags("SPAN");

			//Assert
			Assert.AreEqual(3, results.Count);
			Assert.IsTrue(results.IsAll(i => i.TagName == "SPAN", ValidationIsAllCheck.True), "Elements aren't span");
		}

		[TestMethod]
		public void GettingTagsByNamesWithNonMatchingValueReturnsNull()
		{
			//Arrange
			var tagList = new TagElementCollection();
			tagList.AppendTags
			(
				new TagElement("SPAN", "My Content"),
				new TagElement("SPAN"),
				new TagElement("DIV"),
				new TagElement("SPAN"),
				new TagElement("DIV")
			);

			//Act
			var results = tagList.GetTags("A");

			//Assert
			Assert.IsNotNull(results);
			Assert.AreEqual(0, results.Count);
		}

		#endregion
	}
}
