using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Collections
{
	[TestClass]
	public class ChainableCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingItemsViaChainingAddsExistingItemsToCollection()
		{
			//Arrange
			var list = ChainableCollection<string>.Create();

			//Act
			list.Add("This").Add("Is").Add("My").Add("Test");

			//Assert
			Assert.AreEqual(4, list.Count);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullItemsThrowsExceptions()
		{
			ChainableCollection<string>.Create().Add(null);
		}

		[TestMethod]
		public void ChecksForWhetherItemsExistWorksOK()
		{
			//Arrange
			var list = ChainableCollection<string>.Create(new string[] { "1", "2", "3", "4", "5" });

			//Act
			bool c0 = list.Contains("0");
			bool c1 = list.Contains("1");
			bool c3 = list.Contains("3");
			bool c5 = list.Contains("5");
			bool c6 = list.Contains("6");

			//Assert
			Assert.AreEqual(false, c0);
			Assert.AreEqual(true, c1);
			Assert.AreEqual(true, c3);
			Assert.AreEqual(true, c5);
			Assert.AreEqual(false, c6);
		}

		[TestMethod]
		public void ClearingItemsFromListWorksOK()
		{
			//Arrange
			var list = ChainableCollection<string>.Create(new string[] { "1", "2", "3", "4", "5" });

			//Act
			int firstCount = list.Count;

			list.Clear();

			int lastCount = list.Count;

			//Assert
			Assert.AreEqual(5, firstCount, "Before isn't 5 count");
			Assert.AreEqual(0, lastCount, "After isn't 0 count");
		}

		[TestMethod]
		public void ContainsItemUsingChainingReturnsTrue()
		{
			//Arrange
			var list = ChainableCollection<int>.Create(new int[] { 1, 2, 3 });
			var contains1 = false;
			var contains2 = false;

			//Act
			list.Contains(3, out contains1);
			list.Contains(4, out contains2);

			//Assert
			Assert.IsTrue(contains1);
			Assert.IsFalse(contains2);
		}

		[TestMethod]
		public void CopyingArraysLocallyAssignsOK()
		{
			//Arrange
			var list = ChainableCollection<string>.Create(new string[] { "1", "2", "3", "4", "5" });

			//Act
			string[] outputArray = new string[5];
			list.CopyTo(outputArray);

			//Assert
			Assert.AreEqual(5, outputArray.Length);
			Assert.AreEqual("1", outputArray[0]);
			Assert.AreEqual("3", outputArray[2]);
			Assert.AreEqual("5", outputArray[4]);
		}

		[TestMethod]
		public void CopyingArraysLocallyWithIndexAssignsOK()
		{
			//Arrange
			var list = ChainableCollection<string>.Create(new string[] { "1", "2", "3", "4", "5" });

			//Act
			string[] outputArray = new string[5];
			list.CopyTo(outputArray, 0);

			//Assert
			Assert.AreEqual(5, outputArray.Length);
			Assert.AreEqual("1", outputArray[0]);
			Assert.AreEqual("3", outputArray[2]);
			Assert.AreEqual("5", outputArray[4]);
		}

		[TestMethod]
		public void CreatingCollectionsWithNoItemsWorksOK()
		{
			//Arrange
			var list = default(ChainableCollection<string>);

			//Act
			list = ChainableCollection<string>.Create();

			//Assert
			Assert.AreEqual(0, list.Count);
		}

		[TestMethod]
		public void CreatingCollectionsWithOneItemWorksOK()
		{
			//Arrange
			var list = default(ChainableCollection<string>);

			//Act
			list = ChainableCollection<string>.Create("Test");

			//Assert
			Assert.AreEqual(1, list.Count);
			Assert.AreEqual("Test", list.First());
		}

		[TestMethod]
		public void CreatingCollectionsWithThreeItemWorksOK()
		{
			//Arrange
			var list = default(ChainableCollection<string>);

			//Act
			list = ChainableCollection<string>.Create(new string[] { "1", "2", "3", "4", "5" });

			//Assert
			Assert.AreEqual(5, list.Count);
			
		}

		[TestMethod]
		public void GettingItemsByIndexReturnsCorrectValue()
		{
			//Arrange
			var list = ChainableCollection<int>.Create(new int[] { 1, 2, 3 });

			//Act
			var item = list[0];
			var item2 = list[2];

			//Assert
			Assert.AreEqual(1, item);
			Assert.AreEqual(3, item2);
		}

		[TestMethod]
		public void GettingItemsByInvalidIndexReturnsDefault()
		{
			//Arrange
			var list = ChainableCollection<int>.Create(new int[] { 1, 2, 3 });

			//Act
			var item = list[-1];
			var item2 = list[3];

			//Assert
			Assert.AreEqual(0, item);
			Assert.AreEqual(0, item2);
		}

		[TestMethod]
		public void GettingItemsByInvalidIndexReturnsNull()
		{
			//Arrange
			var list = ChainableCollection<string>.Create(new string[] { "1", "2", "3" });

			//Act
			var item = list[-1];
			var item2 = list[3];

			//Assert
			Assert.IsNull(item);
			Assert.IsNull(item2);
		}

		[TestMethod]
		public void RemovingItemsViaChainingRemovesItemsFromCollection()
		{
			//Arrange
			List<string> items = new List<string>();
			items.Add("This");
			items.Add("Is");
			items.Add("My");
			items.Add("Test");

			//Act
			var list = ChainableCollection<string>.Create(items);
			list.Remove("This").Remove("Test");

			//Assert
			Assert.AreEqual(2, list.Count);
		}

		[TestMethod]
		public void RemovingItemsWithOutputParameterViaChainingRemovesItemsFromCollection()
		{
			//Arrange
			List<string> items = new List<string>();
			items.Add("This");
			items.Add("Is");
			items.Add("My");
			items.Add("Test");

			bool return1 = false;
			bool return2 = false;

			//Act
			var list = ChainableCollection<string>.Create(items);
			list.Remove("This", out return1).Remove("Test", out return2);

			//Assert
			Assert.AreEqual(2, list.Count);
			Assert.IsTrue(return1);
			Assert.IsTrue(return2);
		}


		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void RemovingNullItemThrowsException()
		{
			//Arrange
			var list = ChainableCollection<string>.Create();

			//Act
			list.Remove(null);

			//Assert

		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void RemovingNullItemWithBooleanThrowsException()
		{
			//Arrange
			var list = ChainableCollection<string>.Create();
			var removed = false;

			//Act
			list.Remove(null, out removed);

			//Assert

		}

		#endregion
	}
}
