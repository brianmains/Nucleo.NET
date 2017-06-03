using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class ObjectKeyedDictionaryTest
	{
		#region " Tests "

		[TestMethod]
		public void CopyingFromDictionaryCopiesOverObjects()
		{
			//Arrange
			var dict = new Dictionary<string, object>();
			dict.Add("1", 1);
			dict.Add("2", 2);
			dict.Add("3", 3);

			//Act
			var newDict = new ObjectKeyedDictionary();
			newDict.CopyFrom(dict);

			//Assert
			Assert.AreEqual(3, newDict.Count);
			Assert.AreEqual(1, newDict["1"]);
			Assert.AreEqual(2, newDict["2"]);
			Assert.AreEqual(3, newDict["3"]);
		}

		[TestMethod]
		public void CopyingFromObjectDictionaryCopiesOverObjects()
		{
			//Arrange
			var dict = new ObjectKeyedDictionary();
			dict.Add("1", 1);
			dict.Add("2", 2);
			dict.Add("3", 3);
			dict.Add("4", 4);
			dict.Add("5", 5);

			//Act
			var newDict = new ObjectKeyedDictionary();
			newDict.CopyFrom(dict);

			//Assert
			Assert.AreEqual(5, newDict.Count);
			Assert.AreEqual(1, newDict["1"]);
			Assert.AreEqual(2, newDict["2"]);
			Assert.AreEqual(3, newDict["3"]);
			Assert.AreEqual(4, newDict["4"]);
			Assert.AreEqual(5, newDict["5"]);
		}

		#endregion
	}
}
