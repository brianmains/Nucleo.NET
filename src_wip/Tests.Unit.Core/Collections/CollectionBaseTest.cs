using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Collections
{
	[TestClass]
	public class CollectionBaseTest
	{
		#region " Test Classes "

		protected class Pair
		{
			public object First;
			public object Second;

			public Pair(object first, object second)
			{
				First = first;
				Second = second;
			}
		}

		protected class ObjectCollectionBase : CollectionBase<Pair> { }

		protected class StringCollectionBase : CollectionBase<string>
		{
			public StringCollectionBase()
				: base() { }

			public StringCollectionBase(IEnumerable<string> items)
				: base(items) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingBulkItemsAddsOK()
		{
			//Arrange
			StringCollectionBase strings = new StringCollectionBase();

			//Act
			strings.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });

			//Assert
			Assert.AreEqual("1", strings[0]);
			Assert.AreEqual("3", strings[2]);
			Assert.AreEqual("5", strings[4]);
			Assert.AreEqual("6", strings[5]);
		}

		[TestMethod]
		public void AddingItemsAddsOK()
		{
			//Arrange
			StringCollectionBase strings = new StringCollectionBase();

			//Act
			strings.Add("Test");
			strings.Add("This is a test");
			strings.Add("My name is Brian");
			strings.Add("This is a test 2");
			strings.Add("Test");
			strings.Add("Double Test");

			//Assert
			Assert.AreEqual(6, strings.Count, "Count isn't 6");
			Assert.AreEqual("Test", strings[0]);
			Assert.AreEqual("This is a test", strings[1]);
			Assert.AreEqual("My name is Brian", strings[2]);
			Assert.AreEqual("This is a test 2", strings[3]);
			Assert.AreEqual("Test", strings[4]);
			Assert.AreEqual("Double Test", strings[5]);
		}

		[TestMethod]
		public void AddingEnumerableListOfItemsAddsOK()
		{
			//Arrange
			List<string> items = new List<string>();
			items.Add("1");
			items.Add("2");
			items.Add("3");
			items.Add("4");
			items.Add("5");
			items.Add("6");
			items.Add("7");

			StringCollectionBase strings = new StringCollectionBase();

			//Act
			strings.AddRange((IEnumerable)items);
			
			//Assert
			Assert.AreEqual(7, strings.Count);
			Assert.AreEqual("1", strings[0]);
			Assert.AreEqual("3", strings[2]);
			Assert.AreEqual("5", strings[4]);
			Assert.AreEqual("7", strings[6]);
		}

		[TestMethod]
		public void AddingGenericEnumerableListOfItemsAddsOK()
		{
			//Arrange
			List<string> items = new List<string>();
			items.Add("1");
			items.Add("2");
			items.Add("3");
			items.Add("4");
			items.Add("5");
			items.Add("6");
			items.Add("7");

			StringCollectionBase strings = new StringCollectionBase();

			//Act
			strings.AddRange(items);

			//Assert
			Assert.AreEqual(7, strings.Count);
			Assert.AreEqual("1", strings[0]);
			Assert.AreEqual("3", strings[2]);
			Assert.AreEqual("5", strings[4]);
			Assert.AreEqual("7", strings[6]);
		}

		[TestMethod]
		public void CheckingForExistingItemsReturnsFalse()
		{
			//Arrange
			StringCollectionBase strings = new StringCollectionBase(new string[] { "1", "2", "3", "4", "5" });

			//Act
			bool c0 = strings.Contains("0");
			bool c1 = strings.Contains("1");
			bool c3 = strings.Contains("3");
			bool c5 = strings.Contains("5");
			bool c6 = strings.Contains("6");
			
			//Assert
			Assert.AreEqual(false, c0);
			Assert.AreEqual(true, c1);
			Assert.AreEqual(true, c3);
			Assert.AreEqual(true, c5);
			Assert.AreEqual(false, c6);
		}

		[TestMethod]
		public void ClearingItemsFromListRemovesAllItems()
		{
			//Arrange
			StringCollectionBase strings = new StringCollectionBase(new string[] { "1", "2", "3", "4", "5" });

			//Act
			int beforeCount = strings.Count;
			strings.Clear();
			int afterCount = strings.Count;

			//Assert
			Assert.AreEqual(5, beforeCount);
			Assert.AreEqual(0, afterCount);
		}

		[TestMethod]
		public void CopyingArraysToSecondList()
		{
			//Arrange
			StringCollectionBase strings = new StringCollectionBase(new string[] { "1", "2", "3", "4", "5" });
			string[] arr = new string[5];

			//Act
			strings.CopyTo(arr, 0);

			//Assert
			Assert.AreEqual(5, arr.Length);
		}

		[TestMethod]
		public void CreatingWithExistingItemWorksOK()
		{
			//Arrange
			

			//Act
			var coll = Isolate.Fake.Instance<CollectionBase<string>>(Members.CallOriginal, ConstructorWillBe.Called, new[] { "X" });

			//Assert
			Assert.AreEqual(1, coll.Count);
		}

		[TestMethod]
		public void GettingRangeOfStringsWorksCorrectly()
		{
			//Arrange
			StringCollectionBase scoll = new StringCollectionBase();
			scoll.Add("1");
			scoll.Add("2");
			scoll.Add("3");
			scoll.Add("4");
			scoll.Add("5");
			scoll.Add("6");
			scoll.Add("7");
			scoll.Add("8");
			scoll.Add("9");
			scoll.Add("10");

			//Act
			string[] innerColl = scoll.GetRange(1, 3);
			string[] innerColl2 = scoll.GetRange(9, 20);
			
			//Assert
			Assert.AreEqual(3, innerColl.Length);
			Assert.AreEqual("2", innerColl[0]);
			Assert.AreEqual("3", innerColl[1]);
			Assert.AreEqual("4", innerColl[2]);

			Assert.AreEqual(1, innerColl2.Length);
			Assert.AreEqual("10", innerColl2[0]);
		}

		[TestMethod]
		public void IndexOfItemsReturnsCorrectIndexes()
		{
			//Arrange
			StringCollectionBase strings = new StringCollectionBase(new string[] { "1", "2", "3", "4", "5" });

			//Act
			int index = strings.IndexOf("3");

			//Assert
			Assert.AreEqual(2, index, "Item 3 isn't at position 2");
		}

		[TestMethod]
		public void RemovingObjectItems()
		{
			ObjectCollectionBase ocoll = new ObjectCollectionBase();
			ocoll.Add(new Pair(1, 2));
			ocoll.Add(new Pair(3, 4));
			ocoll.Add(new Pair(5, 6));
			ocoll.Add(new Pair(7, 8));
			ocoll.Add(new Pair(9, 10));
			Assert.AreEqual(5, ocoll.Count);

			ocoll.Remove(ocoll[3]);
			Assert.AreEqual(4, ocoll.Count);
			Assert.AreEqual(9, ocoll[3].First);
			Assert.AreEqual(10, ocoll[3].Second);

			ocoll.RemoveAt(0);
			Assert.AreEqual(3, ocoll[0].First);
			Assert.AreEqual(4, ocoll[0].Second);

			try
			{
				ocoll.RemoveAt(6);
			}
			catch (ArgumentOutOfRangeException ex) { }
		}

		[TestMethod]
		public void RemovingStringItems()
		{
			//Arrange
			StringCollectionBase scoll = new StringCollectionBase();
			scoll.Add("1");
			scoll.Add("2");
			scoll.Add("3");
			scoll.Add("4");
			scoll.Add("5");
			Assert.AreEqual(5, scoll.Count);

			scoll.Remove(scoll[3]);
			Assert.AreEqual(4, scoll.Count);
			Assert.AreEqual("5", scoll[3]);

			scoll.RemoveAt(0);
			Assert.AreEqual(3, scoll.Count);
			Assert.AreEqual("2", scoll[0]);

			try
			{
				scoll.RemoveAt(6);
			}
			catch (ArgumentOutOfRangeException ex) { }
		}

		#endregion
	}
}
