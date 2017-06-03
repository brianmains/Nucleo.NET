using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;


namespace Nucleo.Collections
{
	[TestClass]
	public class DictionaryExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingNewValuesWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, string>();

			//Act
			dict.AddOrUpdate("1", "A");
			dict.AddOrUpdate("2", "B");
			dict.AddOrUpdate("3", "C");

			//Assert
			Assert.IsTrue(dict.ContainsKey("1"));
			Assert.IsTrue(dict.ContainsKey("2"));
			Assert.IsTrue(dict.ContainsKey("3"));
			Assert.AreEqual("A", dict["1"]);
			Assert.AreEqual("B", dict["2"]);
			Assert.AreEqual("C", dict["3"]);
		}

		[TestMethod]
		public void ConvertingDictionaryToCollectionBaseWorksOK()
		{
			Dictionary<string, int> items = new Dictionary<string, int>();
			items.Add("A", 1);
			items.Add("B", 2);
			items.Add("C", 4);

			CollectionBase<int> list = items.ToCollectionBase();
			Assert.AreEqual(3, list.Count);
			Assert.AreEqual(1, list[0]);
			Assert.AreEqual(2, list[1]);
			Assert.AreEqual(4, list[2]);
		}

		[TestMethod]
		public void ConvertingDictionaryToListWorksOK()
		{
			Dictionary<string, int> items = new Dictionary<string, int>();
			items.Add("A", 7);
			items.Add("B", 2);
			items.Add("C", 5);

			List<int> list = items.ToList();
			Assert.AreEqual(3, list.Count);
			Assert.AreEqual(7, list[0]);
			Assert.AreEqual(2, list[1]);
			Assert.AreEqual(5, list[2]);
		}

		[TestMethod]
		public void GetOrDefaultWithDefaultValueReturnsOK()
		{
			//Arrange
			var dict = new Dictionary<string, string>();
			dict.Add("1", "A");
			dict.Add("2", "B");

			var dict2 = new Dictionary<string, int>();
			dict2.Add("1", 1);
			dict2.Add("2", 2);

			//Act
			var value = dict.GetOrDefault("1", "CCC");
			var value2 = dict2.GetOrDefault("1", 123);
			var noValue = dict.GetOrDefault("3", "DDD");
			var noValue2 = dict2.GetOrDefault("3", 456);

			Assert.AreEqual("A", value);
			Assert.AreEqual(1, value2);
			Assert.AreEqual("DDD", noValue);
			Assert.AreEqual(456, noValue2);
		}

		[TestMethod]
		public void GetOrDefaultWithoutDefaultValueReturnsOK()
		{
			//Arrange
			var dict = new Dictionary<string, string>();
			dict.Add("1", "A");
			dict.Add("2", "B");

			var dict2 = new Dictionary<string, int>();
			dict2.Add("1", 1);
			dict2.Add("2", 2);

			//Act
			var value = dict.GetOrDefault("1");
			var value2 = dict2.GetOrDefault("1");
			var noValue = dict.GetOrDefault("3");
			var noValue2 = dict2.GetOrDefault("3");

			Assert.AreEqual("A", value);
			Assert.AreEqual(1, value2);
			Assert.IsNull(noValue);
			Assert.AreEqual(0, noValue2);
		}

		[TestMethod]
		public void UpdatingExistingValuesWorksOK()
		{
			//Arrange
			var dict = new Dictionary<string, string>();
			dict.Add("1", "A");
			dict.Add("2", "B");
			dict.Add("3", "C");

			//Act
			dict.AddOrUpdate("1", "D");
			dict.AddOrUpdate("2", "E");
			dict.AddOrUpdate("3", "F");

			//Assert
			Assert.IsTrue(dict.ContainsKey("1"));
			Assert.IsTrue(dict.ContainsKey("2"));
			Assert.IsTrue(dict.ContainsKey("3"));
			Assert.AreEqual("D", dict["1"]);
			Assert.AreEqual("E", dict["2"]);
			Assert.AreEqual("F", dict["3"]);
		}

		#endregion
	}
}
