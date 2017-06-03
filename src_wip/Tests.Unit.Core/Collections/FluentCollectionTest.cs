using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Collections
{
	[TestClass]
	public class FluentCollectionTest
	{
		protected class TestClass
		{
			public string Name { get; set; }
		}

		protected class TestCollection : FluentCollection<TestClass, TestCollection>
		{
			public TestCollection() { }

			public TestCollection(IEnumerable<TestClass> items)
				: base(items) { }
		}


		[TestMethod]
		public void AddingAnItemToCollection()
		{
			var coll = new TestCollection();
			coll.Add(new TestClass { Name = "A" });

			Assert.AreEqual(1, coll.Count);
			Assert.AreEqual("A", coll.Get(0).Name);
		}

		[TestMethod]
		public void AddingItemThroughActionWorksOK()
		{
			var coll = new TestCollection();
			coll.Add(new Action<TestClass>((t) => { t.Name = "A"; }));

			Assert.AreEqual(1, coll.Count);
			Assert.AreEqual("A", coll.Get(0).Name);
		}

		[TestMethod]
		public void AddingItemThroughFuncWorksOK()
		{
			var coll = new TestCollection();
			coll.Add(new Func<TestClass>(() => new TestClass { Name = "A" }));

			Assert.AreEqual(1, coll.Count);
			Assert.AreEqual("A", coll.Get(0).Name);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullItemThrowsException()
		{
			new TestCollection().Add(default(TestClass));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullItemThroughActionThrowsException()
		{
			new TestCollection().Add(default(Action<TestClass>));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullItemThroughLambdaThrowsException()
		{
			new TestCollection().Add(default(Func<TestClass>));
		}

		[TestMethod]
		public void GettingAllItemsReturnsAll()
		{
			var coll = new TestCollection(new[] 
			{ 
				new TestClass { Name = "A" },
				new TestClass { Name = "B" }
			});

			var output = coll.GetAll().ToList();

			Assert.AreEqual(2, output.Count);
			Assert.AreEqual("A", output[0].Name);
			Assert.AreEqual("B", output[1].Name);
		}

		[TestMethod]
		public void GettingAllItemsThroughEnumerationWorksOK()
		{
			var coll = new TestCollection(new[] 
			{ 
				new TestClass { Name = "A" },
				new TestClass { Name = "B" }
			});

			var output = coll.GetEnumerator();

			Assert.IsNotNull(output);
		}

		[TestMethod]
		public void GettingDefaultCountReturnsZero()
		{
			var coll = new TestCollection();

			Assert.AreEqual(0, coll.Count);
		}

		[TestMethod]
		public void GettingItemByIndexReturnsValue()
		{
			var coll = new TestCollection(new[] { new TestClass { Name = "A" } });

			Assert.AreEqual("A", coll.Get(0).Name);
		}

		[TestMethod]
		public void RemovingItemByLambdaWorksOK()
		{
			var item = new TestClass { Name = "A" };

			var coll = new TestCollection(new[] 
			{ 
				item,
				new TestClass { Name = "B" }
			});

			coll.Remove(() => item);

			Assert.AreEqual(1, coll.Count);
			Assert.IsFalse(coll.Contains(item));
		}

		[TestMethod]
		public void RemovingItemWorksOK()
		{
			var item = new TestClass { Name = "A" };

			var coll = new TestCollection(new[] 
			{ 
				item,
				new TestClass { Name = "B" }
			});

			coll.Remove(item);

			Assert.AreEqual(1, coll.Count);
			Assert.IsFalse(coll.Contains(item));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void RemovingNullItemThrowsException()
		{
			var coll = new TestCollection();

			coll.Remove(default(TestClass));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void RemovingNullItemWithLambdaThrowsException()
		{
			var coll = new TestCollection();

			coll.Remove(default(Func<TestClass>));
		}
	}
}
