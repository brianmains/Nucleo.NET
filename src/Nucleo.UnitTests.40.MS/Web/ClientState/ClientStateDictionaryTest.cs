using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.ClientState
{
	[TestClass]
	public class ClientStateDictionaryTest
	{
		#region " Methods "

		[TestMethod]
		public void AddingItemsToDictionaryAddsCorrectly()
		{
			//Arrange
			var dict = Isolate.Fake.Instance<ClientStateDictionary>(Members.CallOriginal);

			//Act
			dict.Add("Test", 123);

			//Assert
			Assert.AreEqual(123, dict.Get("Test"));
		}

		[TestMethod]
		public void ContainsKeyReturnsFalse()
		{
			//Arrange
			Dictionary<string, object> list = new Dictionary<string, object>();
			list.Add("Text", "Test Text");

			var dictionary = new ClientStateDictionary(list);

			//Act
			var contains = dictionary.ContainsKey("Text2");

			//Assert
			Assert.IsFalse(contains);
		}

		[TestMethod]
		public void ContainsKeyReturnsTrue()
		{
			//Arrange
			Dictionary<string, object> list = new Dictionary<string, object>();
			list.Add("Text", "Test Text");

			var dictionary = new ClientStateDictionary(list);

			//Act
			var contains = dictionary.ContainsKey("Text");

			//Assert
			Assert.IsTrue(contains);
		}

		[TestMethod]
		public void CreatingStateDictionaryCreatesCorrectObject()
		{
			//Arrange
			Dictionary<string, object> list = new Dictionary<string,object>();
			list.Add("Text", "Test Text");
			
			//Act
			var dictionary1 = new ClientStateDictionary();
			var dictionary2 = new ClientStateDictionary(list);

			//Arrange
			Assert.AreEqual(0, dictionary1.Count);
			Assert.AreEqual(1, dictionary2.Count);
		}

		[TestMethod]
		public void GettingValueByGenericReferenceReturnsObject()
		{
			//Arrange
			Dictionary<string, object> list = new Dictionary<string, object>();
			list.Add("Text", "Test Text");

			var dictionary = new ClientStateDictionary(list);

			//Act
			var value = dictionary.Get<string>("Text");

			//Assert
			Assert.AreEqual("Test Text", value);
		}

		[TestMethod]
		public void GettingValueByKeyReturnsObject()
		{
			//Arrange
			Dictionary<string, object> list = new Dictionary<string, object>();
			list.Add("Text", "Test Text");

			var dictionary = new ClientStateDictionary(list);

			//Act
			var value = dictionary.Get("Text");

			//Assert
			Assert.AreEqual("Test Text", value);
		}

		[TestMethod]
		public void RemovingItemsToDictionaryRemovesCorrectly()
		{
			//Arrange
			var dict = Isolate.Fake.Instance<ClientStateDictionary>(Members.CallOriginal);
			dict.Add("Test", 123);

			//Act
			dict.Remove("Test");

			//Assert
			Assert.IsNull(dict["Test"]);
		}

		[TestMethod]
		public void SettingValueByKeyReturnsObject()
		{
			//Arrange
			Dictionary<string, object> list = new Dictionary<string, object>();
			list.Add("Text", "Test Text");

			var dictionary = new ClientStateDictionary(list);

			//Act
			dictionary["Text"] = "New Value";
			dictionary["NewVal"] = 1;

			//Assert
			Assert.AreEqual("New Value", dictionary["Text"]);
			Assert.AreEqual(1, dictionary["NewVal"]);
		}

		#endregion
	}
}
