using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class SimpleCollectionTest : SimpleCollection<string>
	{
		#region " Tests "

		[TestMethod]
		public void AddingItemsWorksOK()
		{
			//Arrange
			var list = new SimpleCollectionTest();

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
			var list = new SimpleCollectionTest();
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
			var list = new SimpleCollectionTest();
			list.Add("A");
			list.Add("B");
			list.Add("C");

			//Act
			int count = list.Count;

			//Assert
			Assert.AreEqual(3, count);
		}

		

		#endregion
	}
}
