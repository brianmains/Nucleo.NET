using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class SimpleCollectionTest : SimpleCollection<string>
	{
		protected class StringTestCollection : SimpleCollection<string> 
		{
			public StringTestCollection() { }

			public StringTestCollection(IEnumerable<string> items)
				: base(items) { }
		}



		#region " Tests "

		[TestMethod]
		public void AddingItemsWorksOK()
		{
			//Arrange
			var list = new StringTestCollection();

			//Act
			list.Add("A");
			list.Add("B");
			list.Add("C");

			//Assert
			Assert.AreEqual(3, list.Count);
			Assert.AreEqual("A", list[0]);
			Assert.AreEqual("C", list[2]);
		}

		[TestMethod]
		public void CheckingForItemExistenceWorksOK()
		{
			//Arrange
			var list = new StringTestCollection();
			list.Add("A");
			list.Add("B");
			list.Add("C");

			//Act
			bool contains1 = list.Contains("A");
			bool contains2 = list.Contains("D");

			//Assert
			Assert.AreEqual(true, contains1);
			Assert.AreEqual(false, contains2);
		}

		[TestMethod]
		public void CheckingItemCountWorksOK()
		{
			//Arrange
			var list = new StringTestCollection();
			list.Add("A");
			list.Add("B");
			list.Add("C");

			//Act
			int count = list.Count;

			//Assert
			Assert.AreEqual(3, count);
		}

		[TestMethod]
		public void CreatingWithEnumerableWorksOK()
		{
			var output = new StringTestCollection(new string[] { "A", "B", "C" });

			Assert.AreEqual(3, output.Count);
		}

		[TestMethod]
		public void CreatingWorksOK()
		{
			new StringTestCollection();
		}

		[TestMethod]
		public void RemovingItemsByIndexWorksOK()
		{
			var output = new StringTestCollection(new string[] { "A", "B", "C" });

			output.RemoveAt(0);

			Assert.AreEqual("B", output[0]);
		}

		[TestMethod]
		public void ToArrayReturnsCollectionOfItems()
		{
			var items = new StringTestCollection(new string[] { "A", "B", "C" });

			var output = items.ToArray();

			Assert.AreEqual(3, output.Length);
			Assert.AreEqual("A", output[0]);
			Assert.AreEqual("C", output[2]);
		}

		#endregion
	}
}
