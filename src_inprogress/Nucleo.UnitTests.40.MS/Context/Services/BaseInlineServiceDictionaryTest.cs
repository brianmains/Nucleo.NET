using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Context.Services
{
	[TestClass]
	public class BaseInlineServiceDictionaryTest
	{
		#region " Test Classes "

		public class TestDictionary : BaseInlineServiceDictionary
		{
			public TestDictionary() { }

			public Dictionary<string, object> GetItems()
			{
				return this.Items;
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingItemToDictionaryWorks()
		{
			//Arrange
			var dict = new TestDictionary();

			//Act
			dict.Add("A", 1);
			dict.Add("B", 2);

			var items = dict.GetItems();

			//Assert
			Assert.AreEqual(1, items["A"]);
			Assert.AreEqual(2, items["B"]);
		}

		[TestMethod]
		public void RemovingItemsFromDictionaryWorks()
		{
			//Arrange
			var dict = new TestDictionary();
			dict.Add("A", 1);
			dict.Add("B", 2);
			dict.Add("C", 3);

			//Act
			dict.Remove("A");

			var items = dict.GetItems();

			//Assert
			Assert.AreEqual(2, items["B"]);
			Assert.AreEqual(3, items["C"]);
			Assert.IsFalse(items.ContainsKey("A"));
		}

		#endregion
	}
}
