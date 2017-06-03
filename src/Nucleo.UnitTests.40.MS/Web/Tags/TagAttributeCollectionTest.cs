using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class TagAttributeCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingBulkItemsUsingArrayAddsCorrectlyToList()
		{
			//Arrange
			var values = new List<TagAttribute>();
			values.Add(new TagAttribute("class", "Test"));
			values.Add(new TagAttribute("width", "500px"));

			var list = new TagAttributeCollection();

			//Act
			list.AppendAttributes(new TagAttribute[] 
			{ 
				new TagAttribute("class", "Test"), 
				new TagAttribute("width", "500px") 
			});

			//Assert
			Assert.AreEqual("Test", list.GetAttributeValue("class"));
			Assert.AreEqual("500px", list.GetAttributeValue("width"));
		}

		[TestMethod]
		public void AddingBulkItemsUsingDictionaryAddsCorrectlyToList()
		{
			//Arrange
			var dict = new Dictionary<string, object>();
			dict.Add("class", "Test");
			dict.Add("width", "500px");

			var list = new TagAttributeCollection();

			//Act
			list.AppendAttributes(dict);

			//Assert
			Assert.AreEqual("Test", list.GetAttributeValue("class"));
			Assert.AreEqual("500px", list.GetAttributeValue("width"));
		}

		[TestMethod]
		public void AddingBulkItemsUsingNullArrayThrowsException()
		{
			//Arrange
			var list = new TagAttributeCollection();

			//Act


			//Assert
			ExceptionTester.CheckException(true, (src) => { list.AppendAttributes(default(TagAttribute[])); });
		}

		[TestMethod]
		public void AddingBulkItemsUsingNullDictonaryThrowsException()
		{
			//Arrange
			var list = new TagAttributeCollection();

			//Act


			//Assert
			ExceptionTester.CheckException(true, (src) => { list.AppendAttributes(default(IDictionary<string, object>)); });
		}

		[TestMethod]
		public void AddingChainedItemsAddsCorrectItemsToList()
		{
			//Arrange
			var list = new TagAttributeCollection();

			//Act
			list.AppendAttribute("width", "100px").AppendAttribute("height", "100px");

			//Assert
			Assert.AreEqual(2, list.AttributeCount);
		}

		[TestMethod]
		public void AddingTagAttributeReferenceAddsToList()
		{
			//Arrange
			var list = new TagAttributeCollection();

			//Act
			list.AppendAttribute(new TagAttribute("width", "100px"));

			//Assert
			Assert.AreEqual(1, list.AttributeCount);
		}

		[TestMethod]
		public void ChangingItemValueChangesValueCOrrectly()
		{
			//Arrange
			var list = new TagAttributeCollection();

			//Act
			list.AppendAttribute("width", "100px").AppendAttribute("height", "100px")
				.ChangeAttributeValue("width", "200px");

			//Assert
			Assert.AreEqual(2, list.AttributeCount);
			Assert.AreEqual("200px", list.GetAttribute("width").Value);
		}

		[TestMethod]
		public void CopyingDataFromDictionaryAddsItemsInBulk()
		{
			//Arrange
			var dictionary = new Dictionary<string, object>();
			dictionary.Add("width", "100px");
			dictionary.Add("height", "10px");

			var list = new TagAttributeCollection();

			//Act
			list.CopyFrom(dictionary).AppendAttribute("overflow", "none");

			//Assert
			Assert.AreEqual(3, list.AttributeCount);
			Assert.AreEqual("100px", list.GetAttribute("width").Value);
			Assert.AreEqual("10px", list.GetAttribute("height").Value);
			Assert.AreEqual("none", list.GetAttribute("overflow").Value);
		}

		[TestMethod]
		public void GettingAsDictionaryReturnsDictionaryCollection()
		{
			//Arrange
			var list = new TagAttributeCollection();
			list.AppendAttribute("width", "100px").AppendAttribute("height", "100px");

			//Act
			var dictionary = list.ToDictionary();

			//Assert
			Assert.AreEqual(2, dictionary.Count);
			Assert.IsTrue(dictionary.ContainsKey("width"));
			Assert.IsTrue(dictionary.ContainsKey("height"));
		}

		[TestMethod]
		public void GettingCollectionReturnsTagAttributes()
		{
			//Arrange
			var list = new TagAttributeCollection();
			list.AppendAttribute("width", "100px").AppendAttribute("height", "100px");

			//Act
			var attributes = list.GetAttributes();

			//Assert
			Assert.AreEqual(2, attributes.Count());
			Assert.AreEqual("width", attributes.ElementAt(0).Name);
			Assert.AreEqual("height", attributes.ElementAt(1).Name);
		}

		[TestMethod]
		public void RemovingChainedItemsRemovesItemFromList()
		{
			//Arrange
			var list = new TagAttributeCollection();

			//Act
			list.AppendAttribute("width", "100px").AppendAttribute("height", "100px")
				.RemoveAttribute("height");

			//Assert
			Assert.AreEqual(1, list.AttributeCount);
		}

		#endregion
	}
}
