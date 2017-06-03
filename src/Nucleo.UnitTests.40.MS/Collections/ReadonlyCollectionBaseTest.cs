using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class ReadonlyCollectionBaseTest : ReadonlyCollectionBase<string>
	{
		#region " Tests "

		[TestMethod]
		public void AddingItemsToListWorksOK()
		{
			//Arrange
			var test = new ReadonlyCollectionBaseTest();

			//Act
			test.Add("B");
			test.Add("C");

			//Assert
			Assert.AreEqual(2, test.Count);
		}

		[TestMethod]
		public void AddingItemsInRangeWorksOK()
		{
			//Arrange
			var test = new ReadonlyCollectionBaseTest();

			//Act
			test.AddRange(new string[] { "1", "2", "3", "4", "5" });

			//Assert
			Assert.AreEqual(5, test.Count);
			Assert.AreEqual("1", test[0]);
			Assert.AreEqual("3", test[2]);
			Assert.AreEqual("5", test[4]);
		}

		[TestMethod]
		public void ClearingItemsRemovesAll()
		{
			//Arrange
			var test = new ReadonlyCollectionBaseTest();
			test.AddRange(new string[] { "A", "B", "C", "D", "E" });

			//Act
			test.Clear();

			//Assert
			Assert.AreEqual(0, test.Count);
		}

		[TestMethod]
		public void CopyingItemsCopiesToNewArray()
		{
			//Arrange
			var test = new ReadonlyCollectionBaseTest();
			test.AddRange(new string[] { "A", "B", "C", "D", "E" });

			//Act
			string[] newArray = new string[5];
			test.CopyTo(newArray, 0);

			//Assert
			Assert.AreEqual(5, newArray.Length);
			Assert.IsTrue(test.AreEqual(newArray), "Array's don't match");
		}

		[TestMethod]
		public void GettingIndexOfItemReturnsCOrrectIndex()
		{
			//Arrange
			var test = new ReadonlyCollectionBaseTest();
			test.AddRange(new string[] { "A", "B", "C", "D", "E" });

			//Act
			var index1 = test.IndexOf("B");
			var index2 = test.IndexOf("E");
			
			//Assert
			Assert.AreEqual(1, index1);
			Assert.AreEqual(4, index2);
		}

		[TestMethod]
		public void InsertingItemWorksOK()
		{
			//Arrange
			var test = new ReadonlyCollectionBaseTest();

			//Act
			test.Insert(0, "B");
			test.Insert(0, "C");
			test.Insert(2, "A");

			//Assert
			Assert.AreEqual(3, test.Count);
			Assert.AreEqual("A", test[2]);
		}

		[TestMethod]
		public void RemovingItemsWorksOK()
		{
			//Arrange
			var test = new ReadonlyCollectionBaseTest();
			test.AddRange(new string[] { "A", "B", "C", "D", "E" });

			//Act
			test.Remove("C");

			//Assert
			Assert.AreEqual(4, test.Count);
			Assert.AreEqual("B", test[1]);
			Assert.AreEqual("D", test[2]);
		}

		#endregion
	}
}
