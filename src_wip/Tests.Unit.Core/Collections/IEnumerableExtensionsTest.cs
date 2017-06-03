using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class IEnumerableExtensionsTest
	{
		#region " Test Class "

		public class TestClass
		{
			public int Key { get; set; }
			public string Name { get; set; }
		}

		#endregion



		#region " Methods "
		
		[TestMethod]
		public void AddingRangeOfItemsAddsToList()
		{
			//Arrange
			var list = (IList<TestClass>)new List<TestClass>();

			//Act
			list.AddRange(new[]
			{
				new TestClass { Key = 1, Name = "1" },
				new TestClass { Key = 2, Name = "2" },
				new TestClass { Key = 3, Name = "3" },
				new TestClass { Key = 4, Name = "4" }
			});

			//Assert
			Assert.AreEqual(4, list.Count);
			Assert.AreEqual(1, list[0].Key);
			Assert.AreEqual(4, list[3].Key);
		}

		[TestMethod]
		public void CheckForNotNullFailsWhenAFieldIsNull()
		{
			var list = new KeyValuePair<string, int?>[]
			{
				new KeyValuePair<string, int?>("First", null),
				new KeyValuePair<string, int?>("Second", null),
				new KeyValuePair<string, int?>("Third", null)
			};

			Assert.IsFalse(list.HasNotNullEntry<KeyValuePair<string, int?>>(i => i.Value), "All fields are not null");
		}

		[TestMethod]
		public void CheckForNotNullStatusSucceedsWhenAllFieldsAreNotNull()
		{
			var list = new KeyValuePair<string, int>[]
			{
				new KeyValuePair<string, int>("First", 1),
				new KeyValuePair<string, int>("Second", 2),
				new KeyValuePair<string, int>("Third", 3)
			};

			Assert.IsTrue(list.HasNotNullEntry<KeyValuePair<string, int>>(i => i.Key), "A field is null");
			Assert.IsTrue(list.HasNotNullEntry<KeyValuePair<string, int>>(i => i.Value), "A field is null");
		}

		[TestMethod]
		public void CheckForNullFailsWhenAFieldIsNotNull()
		{
			var list = new KeyValuePair<string, int?>[]
			{
				new KeyValuePair<string, int?>("First", 1),
				new KeyValuePair<string, int?>("Second", 2),
				new KeyValuePair<string, int?>("Third", 3)
			};

			Assert.IsFalse(list.HasNullEntry<KeyValuePair<string, int?>>(i => i.Value), "All fields are not null");
		}

		[TestMethod]
		public void CheckForNullStatusSucceedsWhenAllFieldsAreNull()
		{
			var list = new KeyValuePair<string, int?>[]
			{
				new KeyValuePair<string, int?>("First", null),
				new KeyValuePair<string, int?>("Second", null),
				new KeyValuePair<string, int?>("Third", null)
			};

			Assert.IsTrue(list.HasNullEntry<KeyValuePair<string, int?>>(i => i.Value), "A field is not null");
		}

		[TestMethod]
		public void ConvertingToCollectionBaseWorksOK()
		{
			List<string> list = new List<string>();
			list.Add("A");
			list.Add("AN");
			list.Add("ANO");
			list.Add("ANOTHER");

			CollectionBase<string> collection = list.ToCollectionBase();
			Assert.AreEqual(4, collection.Count);
			Assert.AreEqual("A", collection[0]);
			Assert.AreEqual("AN", collection[1]);
			Assert.AreEqual("ANO", collection[2]);
			Assert.AreEqual("ANOTHER", collection[3]);
		}

		[TestMethod]
		public void EachItemActionProcessesAccordingly()
		{
			//Arrange
			var list = new[]
			{
				new TestClass { Key = 1, Name = "Test" },
				new TestClass { Key = 2, Name = "This" },
				new TestClass { Key = 3, Name = "Works" }
			};

			//Act
			list.Each((a) =>
				{
					a.Name = "Updated";
				});

			//Assert
			Assert.IsTrue(list.IsAllTrue(i => i.Name == "Updated"), "A name in the list wasn't 'Updated'");
		}

		[TestMethod]
		public void EachItemLambdaProcessesAccordingly()
		{
			//Arrange
			var list = new[]
			{
				new TestClass { Key = 1, Name = "Test" },
				new TestClass { Key = 2, Name = "This" },
				new TestClass { Key = 3, Name = "Works" }
			};

			//Act
			var output = list.Each<TestClass, string>((a) => "Updated");

			//Assert
			Assert.IsTrue(output.IsAllTrue(i => i == "Updated"));
		}

		[TestMethod]
		public void GettingEvenAlternatingItemsReturnsCorrectItems()
		{
			//Arrange
			List<string> items = new List<string>();
			items.Add("ODD");
			items.Add("EVEN");
			items.Add("ODD");
			items.Add("EVEN");
			items.Add("ODD");
			items.Add("EVEN");
			items.Add("ODD");
			items.Add("EVEN");

			//Act
			var checkList = items.GetAlternatingItems(true);

			//Assert
			Assert.IsTrue(checkList.IsAllTrue(i => i == "EVEN"), "A value isn't even");
		}

		[TestMethod]
		public void GettingOddAlternatingItemsReturnsCorrectItems()
		{
			//Arrange
			List<string> items = new List<string>();
			items.Add("ODD");
			items.Add("EVEN");
			items.Add("ODD");
			items.Add("EVEN");
			items.Add("ODD");
			items.Add("EVEN");
			items.Add("ODD");
			items.Add("EVEN");

			//Act
			var checkList = items.GetAlternatingItems(false);

			//Assert
			Assert.IsTrue(checkList.IsAllTrue(i => i == "ODD"), "A value isn't odd");
		}

		[TestMethod]
		public void SubsetsOfItemsReturnsCorrectResult()
		{
			var list = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };

			var output = list.Subset(1, 3).ToList();

			Assert.AreEqual("B", output[0]);
			Assert.AreEqual("C", output[1]);
			Assert.AreEqual("D", output[2]);
		}

		#endregion
	}
}
