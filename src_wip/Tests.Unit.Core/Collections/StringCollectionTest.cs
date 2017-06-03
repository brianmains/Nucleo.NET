using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class StringCollectionTest
	{
		[TestMethod]
		public void TestConvertingCollection()
		{
			StringCollection collection = new StringCollection();
			collection.Add("this");
			collection.Add("is");
			collection.Add("a");
			collection.Add("test");

			StringCollectionConverter converter = new StringCollectionConverter("|");
			Assert.IsTrue(converter.CanConvertFrom(typeof(StringCollection)));
			Assert.IsTrue(converter.CanConvertTo(typeof(string)));

			Assert.AreEqual("this|is|a|test", converter.ConvertTo(collection, typeof(string)));
			string line = (string)converter.ConvertTo(collection, typeof(string));
			Assert.IsInstanceOfType(converter.ConvertFrom(line), typeof(StringCollection));
			collection = (StringCollection)converter.ConvertFrom(line);
			Assert.AreEqual(4, collection.Count);
			Assert.AreEqual("this", collection[0]);
			Assert.AreEqual("is", collection[1]);
			Assert.AreEqual("a", collection[2]);
			Assert.AreEqual("test", collection[3]);
		}

		[TestMethod]
		public void TestUsingCollection()
		{
			StringCollection collection = new StringCollection();
			collection.Add("1");
			collection.Add("A");
			collection.Add("This is a test");

			Assert.AreEqual("1", collection[0]);
			Assert.AreEqual("A", collection[1]);
			Assert.AreEqual("This is a test", collection[2]);

			Assert.AreEqual("1,A,This is a test", collection.ToCommaSeparatedList());
			Assert.AreEqual("1|A|This is a test", collection.ToSeparatedList("|"));

			collection.Clear();
			collection.FromCommaSeparatedList("this,is,a,test");
			Assert.AreEqual(4, collection.Count);
			Assert.AreEqual("this", collection[0]);
			Assert.AreEqual("is", collection[1]);
			Assert.AreEqual("a", collection[2]);
			Assert.AreEqual("test", collection[3]);

			collection.Clear();
			collection.FromSeparatedList("this|is|a|test", "|");
			Assert.AreEqual(4, collection.Count);
			Assert.AreEqual("this", collection[0]);
			Assert.AreEqual("is", collection[1]);
			Assert.AreEqual("a", collection[2]);
			Assert.AreEqual("test", collection[3]);

			collection = StringCollection.FromList("this|is|a|test", "|");
			Assert.AreEqual(4, collection.Count);
			Assert.AreEqual("this", collection[0]);
			Assert.AreEqual("is", collection[1]);
			Assert.AreEqual("a", collection[2]);
			Assert.AreEqual("test", collection[3]);
		}

		[TestMethod]
		public void CreatingEmptyWorksOK()
		{
			var coll = new StringCollection();

			Assert.AreEqual(0, coll.Count);
		}

		[TestMethod]
		public void CreatingWithArrayOfItemsWorksOK()
		{
			var coll = new StringCollection(new string[] { "ABC", "DEF", "GHI" });

			Assert.AreEqual(3, coll.Count);
			Assert.AreEqual("ABC", coll[0]);
			Assert.AreEqual("GHI", coll[2]);
		}

		[TestMethod]
		public void CreatingWithEnumerableOfItemsWorksOK()
		{
			var coll = new StringCollection(new List<string> { "ABC", "DEF", "GHI" });

			Assert.AreEqual(3, coll.Count);
			Assert.AreEqual("ABC", coll[0]);
			Assert.AreEqual("GHI", coll[2]);
		}

		[TestMethod]
		public void CreatingWithSingleItemWorksOK()
		{
			var coll = new StringCollection("ABC");

			Assert.AreEqual(1, coll.Count);
			Assert.AreEqual("ABC", coll[0]);
		}
	}
}
