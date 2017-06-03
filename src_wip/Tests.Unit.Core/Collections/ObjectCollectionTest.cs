using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class ObjectCollectionTest
	{
		#region " Test Classes "

		protected class TestClass
		{
			public int Key { get; set; }
			public string Name { get; set; }
		}

		protected class TestClass2
		{
			public int Key { get; set; }
			public string Name { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingItemsToArrayListAddsToList()
		{
			//Arrange
			var coll = new ObjectCollection();
			ArrayList list = new ArrayList();

			//Act
			list.Add(new TestClass { Key = 1, Name = "1" });
			list.Add(new TestClass2 { Key = 2, Name = "2" });
			list.Add(new TestClass { Key = 3, Name = "3" });
			list.Add(new TestClass2 { Key = 4, Name = "4" });
			coll.AddRange(list);

			//Assert
			Assert.IsInstanceOfType(coll[0], typeof(TestClass));
			Assert.IsInstanceOfType(coll[2], typeof(TestClass));
			Assert.IsInstanceOfType(coll[1], typeof(TestClass2));
			Assert.IsInstanceOfType(coll[3], typeof(TestClass2));
		}

		[TestMethod]
		public void AddingItemsToRangeAddsToList()
		{
			//Arrange
			var coll = new ObjectCollection();

			//Act
			coll.AddRange((IEnumerable)(new object[]
			{
				new TestClass { Key = 1, Name = "1" },
				new TestClass2 { Key = 2, Name = "2" },
				new TestClass { Key = 3, Name = "3" },
				new TestClass2 { Key = 4, Name = "4" }
			}));

			//Assert
			Assert.IsInstanceOfType(coll[0], typeof(TestClass));
			Assert.IsInstanceOfType(coll[2], typeof(TestClass));
			Assert.IsInstanceOfType(coll[1], typeof(TestClass2));
			Assert.IsInstanceOfType(coll[3], typeof(TestClass2));
		}

		[TestMethod]
		public void AddingItemsToRangeGenericallyAddsToList()
		{
			//Arrange
			var coll = new ObjectCollection();

			//Act
			coll.AddRange<TestClass>(new[]
			{
				new TestClass { Key = 1, Name = "1" },
				new TestClass { Key = 2, Name = "2" },
				new TestClass { Key = 3, Name = "3" }
			});

			//Assert
			Assert.IsInstanceOfType(coll[0], typeof(TestClass));
			Assert.IsInstanceOfType(coll[2], typeof(TestClass));
			Assert.IsInstanceOfType(coll[1], typeof(TestClass));
		}

		[TestMethod]
		public void CreatingWithInitialListAssignsOK()
		{
			var list = new ObjectCollection(new[]
			{
				new TestClass { Key = 1, Name = "1" },
				new TestClass { Key = 2, Name = "2" },
				new TestClass { Key = 3, Name = "3" }
			});

			Assert.AreEqual(3, list.Count);
		}

		[TestMethod]
		public void CreatingWorksOK()
		{
			new ObjectCollection();
		}

		#endregion
	}
}

