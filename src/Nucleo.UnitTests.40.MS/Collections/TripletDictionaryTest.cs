using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class TripletDictionaryTest
	{
		#region " Methods "

		[TestMethod]
		public void AddingItemsWorksOK()
		{
			//Arrange
			var dict = new TripletDictionary<string, object, int>();

			//Act
			dict.Add("A", true, 1);

			//Assert
			Assert.AreEqual(true, dict["A"].Value1);
			Assert.AreEqual(1, dict["A"].Value2);
		}

		[TestMethod]
		public void CheckingForItemsWorksOK()
		{
			//Arrange
			var dict = new TripletDictionary<string, bool, int>();
			
			//Act
			dict.Add("A", true, 1);
			dict.Add("B", false, 2);

			//Assert
			Assert.IsTrue(dict.ContainsKey("A"));
			Assert.IsTrue(dict.ContainsKey("B"));
			Assert.IsFalse(dict.ContainsKey("b"));
			Assert.IsFalse(dict.ContainsKey("C"));
		}

		[TestMethod]
		public void CheckingListCountWorksOK()
		{
			//Arrange
			var dict = new TripletDictionary<string, bool, int>();

			//Act
			dict.Add("A", true, 1);
			dict.Add("B", true, 1);

			//Assert
			Assert.AreEqual(2, dict.Count);
		}

		[TestMethod]
		public void IteratingThroughItemsWorksOK()
		{
			//Arrange
			var dict = new TripletDictionary<string, bool, int>();
			dict.Add("A", true, 1);
			dict.Add("B", true, 2);
			dict.Add("C", false, 3);

			int count = 0;
			bool isNull = false;

			//Act
			foreach (var item in dict)
			{
				count++;
				if (item == null)
					isNull = true;
			}

			//Assert
			Assert.AreEqual(3, count);
			Assert.IsFalse(isNull);
		}

		[TestMethod]
		public void RemovingItemsByKeyWorksOK()
		{
			//Arrange
			var dict = new TripletDictionary<string, bool, int>();
			dict.Add("A", true, 1);
			dict.Add("B", true, 2);
			dict.Add("C", false, 3);

			//Act
			dict.Remove("B");

			//Assert
			Assert.IsNull(dict["B"]);
		}

		#endregion
	}
}
