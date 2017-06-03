using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock;


namespace Nucleo.Configuration
{
	[TestClass]
	public class ConfigurationCollectionBaseTest
	{
		[TestMethod]
		public void AddingItemsAddsToList()
		{
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();
			collection.Add(new FakeConfigurationElementBase("Working", "Value"));
			Assert.AreEqual(1, collection.Count);

			collection.Add(new FakeConfigurationElementBase("Another", "Value"));
			Assert.AreEqual(2, collection.Count);
		}

		[TestMethod]
		public void AddingNullItemsThrowsException()
		{
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();

			try
			{
				collection.Add(null);
				Assert.Fail();
			}
			catch (ArgumentNullException ex) { Assert.IsNotNull(ex); }
		}

		[TestMethod]
		public void AddingNullItemsRangeThrowsException()
		{
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();

			try
			{
				collection.AddRange(null);
				Assert.Fail();
			}
			catch (ArgumentNullException ex) { Assert.IsNotNull(ex); }
		}

		[TestMethod]
		public void AddingRangeItemsAddsToList()
		{
			//Arrange
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();

			//Act
			collection.AddRange(new FakeConfigurationElementBase[]
				{
					new FakeConfigurationElementBase("Test1", "Test"),
					new FakeConfigurationElementBase("Value", "Value"),
					new FakeConfigurationElementBase("Run", "Test")
				}
			);

			//Assert
			Assert.AreEqual(3, collection.Count);
		}

		[TestMethod]
		public void CheckingForItemExistenceWorksOK()
		{
			//Arrange
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();
			collection.AddRange(new FakeConfigurationElementBase[]
				{
					new FakeConfigurationElementBase("Test1", "Test"),
					new FakeConfigurationElementBase("Value", "Value"),
					new FakeConfigurationElementBase("Run", "Test")
				}
			);

			//Act
			bool contains = collection.Contains("Value");

			//Assert
			Assert.IsTrue(contains);
		}

		[TestMethod]
		public void ClearingItemsWorksOK()
		{
			//Arrange
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();
			collection.AddRange(new FakeConfigurationElementBase[]
				{
					new FakeConfigurationElementBase("Test1", "Test"),
					new FakeConfigurationElementBase("Value", "Value"),
					new FakeConfigurationElementBase("Run", "Test")
				}
			);

			//Act
			collection.Clear();

			//Assert
			Assert.AreEqual(0, collection.Count);
		}

		[TestMethod]
		public void GettingEnumeratedListWorksWithoutError()
		{
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();
			collection.Add(new FakeConfigurationElementBase("Test", "Value"));
			collection.Add(new FakeConfigurationElementBase("Other", "Item"));

			var enumeratedList = collection.GetEnumerator();
			Assert.IsNotNull(enumeratedList);
		}

		[TestMethod]
		public void RemovingItemsByIndexWorksOK()
		{
			//Arrange
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();
			collection.AddRange(new FakeConfigurationElementBase[]
				{
					new FakeConfigurationElementBase("Test1", "Test"),
					new FakeConfigurationElementBase("Value", "Value"),
					new FakeConfigurationElementBase("Run", "Test")
				}
			);

			//Act
			collection.RemoveAt(1);

			//Assert
			Assert.AreEqual(2, collection.Count);
			Assert.AreEqual("Run", collection[1].Name);
		}

		[TestMethod]
		public void RemovingItemsByKeyWorksOK()
		{
			//Arrange
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();
			collection.AddRange(new FakeConfigurationElementBase[]
				{
					new FakeConfigurationElementBase("Test1", "Test"),
					new FakeConfigurationElementBase("Value", "Value"),
					new FakeConfigurationElementBase("Run", "Test")
				}
			);

			//Act
			collection.Remove("Value");

			//Assert
			Assert.AreEqual(2, collection.Count);
			Assert.AreEqual("Run", collection[1].Name);
		}

		[TestMethod]
		public void RemovingItemsByReferenceWorksOK()
		{
			//Arrange
			FakeConfigurationCollectionBase collection = new FakeConfigurationCollectionBase();
			collection.AddRange(new FakeConfigurationElementBase[]
				{
					new FakeConfigurationElementBase("Test1", "Test"),
					new FakeConfigurationElementBase("Value", "Value"),
					new FakeConfigurationElementBase("Run", "Test")
				}
			);

			//Act
			collection.Remove(collection.ElementAt(1));

			//Assert
			Assert.AreEqual(2, collection.Count);
			Assert.AreEqual("Run", collection[1].Name);
		}
	}
}
