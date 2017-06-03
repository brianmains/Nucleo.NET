using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class FormCollectionTests
	{
		#region " Tests "

		[TestMethod]
		public void AddingNewValuesWorksOK()
		{
			//Arrange
			var dict = new FormCollection();

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
		public void AddingRangeOfItemsAssignsOK()
		{
			var coll = new Dictionary<string, string>();
			coll.Add("A", "1");
			coll.Add("B", "2");

			var list = new FormCollection();
			list.AddRange(coll);

			Assert.AreEqual(2, list.Count);
			Assert.AreEqual("1", list["A"]);
			Assert.AreEqual("2", list["B"]);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingRangeOfNullItemsThrowsException()
		{
			var list = new FormCollection();

			list.AddRange(null);
		}

		[TestMethod]
		public void CreatingWithDictionaryAssignsOK()
		{
			var coll = new Dictionary<string, string>();
			coll.Add("A", "1");
			coll.Add("B", "2");

			var list = new FormCollection(coll);

			Assert.AreEqual(2, list.Count);
			Assert.AreEqual("1", list["A"]);
			Assert.AreEqual("2", list["B"]);
		}

		[TestMethod]
		public void CreatingWithNameValueCollectionAssignsOK()
		{
			var coll = new System.Collections.Specialized.NameValueCollection();
			coll.Add("A", "1");
			coll.Add("B", "2");

			var list = new FormCollection(coll);

			Assert.AreEqual(2, list.Count);
			Assert.AreEqual("1", list["A"]);
			Assert.AreEqual("2", list["B"]);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullDictionaryThrowsException()
		{
			new FormCollection(default(IDictionary<string, string>));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullNameValueCollectionThrowsException()
		{
			new FormCollection(default(NameValueCollection));
		}

		[TestMethod]
		public void GetOrDefaultWithDefaultValueReturnsOK()
		{
			//Arrange
			var dict = new FormCollection();
			dict.Add("1", "A");
			dict.Add("2", "B");
			dict.Add("3", "C");
			dict.Add("4", "D");

			//Act
			var value = dict.GetOrDefault("1", "CCC");
			var value2 = dict.GetOrDefault("2", "DSDF");
			var noValue = dict.GetOrDefault("6", "DDD");
			var noValue2 = dict.GetOrDefault("7", "$%^");

			Assert.AreEqual("A", value);
			Assert.AreEqual("B", value2);
			Assert.AreEqual("DDD", noValue);
			Assert.AreEqual("$%^", noValue2);
		}

		[TestMethod]
		public void UpdatingExistingValuesWorksOK()
		{
			//Arrange
			var dict = new FormCollection();
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