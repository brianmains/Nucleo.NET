using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class EnumerableValidationTest
	{
		#region " Test Classes "

		protected class RefValue
		{
			public int ID { get; set; }
			public string Value { get; set; }
		}

		protected class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public object Identifier { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void ActualAndExpectedListIsInstanceOfType()
		{
			//Arrange
			var list = new[]
			{
				new Person { FirstName = "Ted", LastName = "Test" },
				new Person { FirstName = "Ted", LastName = "List" },
				new Person { FirstName = "Ted", LastName = "Ryan" }
			};

			//Act
			var match = list.IsInstanceOf<Person, string>(i => i.FirstName);
			var match2 = list.IsInstanceOf<Person, string>(i => i.LastName);

			//Assert
			Assert.AreEqual(true, match);
			Assert.AreEqual(true, match2);
		}

		[TestMethod]
		public void ActualAndExpectedListWithMismatchingTypesReturnsFalse()
		{
			//Arrange
			var list = new[]
			{
				new Person { FirstName = "Ted", LastName = "Test", Identifier = 1 },
				new Person { FirstName = "Ted", LastName = "List", Identifier = "ABCDEF" },
				new Person { FirstName = "Ted", LastName = "Ryan", Identifier = DateTime.Now }
			};

			//Act
			var match = list.IsInstanceOf<Person, string>(i => i.Identifier);
			var match2 = list.IsInstanceOf<Person, int>(i => i.Identifier);

			//Assert
			Assert.AreEqual(false, match);
			Assert.AreEqual(false, match2);
		}

		[TestMethod]
		public void ActualAndExpectedListWithObjectTypeOfDateTimeMatches()
		{
			//Arrange
			var list = new[]
			{
				new Person { FirstName = "Ted", LastName = "Test", Identifier = DateTime.MinValue },
				new Person { FirstName = "Ted", LastName = "List", Identifier = DateTime.Today },
				new Person { FirstName = "Ted", LastName = "Ryan", Identifier = DateTime.MaxValue }
			};

			//Act
			var match = list.IsInstanceOf<Person, DateTime>(i => i.Identifier);

			//Assert
			Assert.AreEqual(true, match);
		}

		[TestMethod]
		public void ActualAndExpectedListWithObjectTypeOfIntMatches()
		{
			//Arrange
			var list = new[]
			{
				new Person { FirstName = "Ted", LastName = "Test", Identifier = -1 },
				new Person { FirstName = "Ted", LastName = "List", Identifier = 1 },
				new Person { FirstName = "Ted", LastName = "Ryan", Identifier = 450 }
			};

			//Act
			var match = list.IsInstanceOf<Person, int>(i => i.Identifier);

			//Assert
			Assert.AreEqual(true, match);
		}

		[TestMethod]
		public void ActualAndExpectedListWithObjectTypeOfStringMatches()
		{
			//Arrange
			var list = new[]
			{
				new Person { FirstName = "Ted", LastName = "Test", Identifier = "A" },
				new Person { FirstName = "Ted", LastName = "List", Identifier = "ABCDEF" },
				new Person { FirstName = "Ted", LastName = "Ryan", Identifier = "" }
			};

			//Act
			var match = list.IsInstanceOf<Person, string>(i => i.Identifier);

			//Assert
			Assert.AreEqual(true, match);
		}

		[TestMethod]
		public void ActualAndEstimatedListsDontMatch()
		{
			//Arrange
			var expected = new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			};

			var actual = new string[]
			{
				"Test",
				"That",
				"Doesn't",
				"Works"
			};

			//Act
			var matches = expected.AreEqual(actual);

			//Assert
			Assert.AreEqual(false, matches);
		}

		[TestMethod]
		public void ActualAndEstimatedListsMatch()
		{
			//Arrange
			var expected = new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			};

			var actual = new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			};

			//Act
			var matches = expected.AreEqual(actual);

			//Assert
			Assert.AreEqual(true, matches);
		}

		[TestMethod]
		public void ActualAndEstimatedListsVaryByCountDontMatch()
		{
			//Arrange
			var expected = new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			};

			var actual = new string[]
			{
				"Test",
				"That",
				"This",
				"Works",
				", Not"
			};

			//Act
			var matches = expected.AreEqual(actual);

			//Assert
			Assert.AreEqual(false, matches);
		}

		[TestMethod]
		public void ActualAndEstimatedListsVaryByTypeDontMatch()
		{
			//Arrange
			var expected = new object[]
			{
				"Test",
				"That",
				"This",
				"Works"
			};

			var actual = new object[] { 1, 2, 3, 4 };

			//Act
			var matches = expected.AreEqual(actual);

			//Assert
			Assert.AreEqual(false, matches);
		}

		[TestMethod]
		public void ActualPassesInNullDoesntMatch()
		{
			//Arrange
			var expected = new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			};

			//Act
			var matches = expected.AreEqual(default(IEnumerable<string>));

			//Assert
			Assert.AreEqual(false, matches);
		}

		[TestMethod]
		public void CheckingNotNullListOfItemsFails()
		{
			//Arrange
			var list = new List<string>
			{
				"Test",
				"",
				null,
				null
			};

			//Act
			bool matches = list.IsNotNull();

			//Assert
			Assert.IsFalse(matches, "One null item in list didn't match");
		}

		[TestMethod]
		public void CheckingNotNullListOfItemsWorksOK()
		{
			//Arrange
			var list = new List<string>
			{
				"A",
				"B",
				"C",
				"D"
			};

			//Act
			bool matches = list.IsNotNull();

			//Assert
			Assert.IsTrue(matches, "Null list didn't match");
		}

		[TestMethod]
		public void CheckingNullListOfItemsFails()
		{
			//Arrange
			var list = new List<string>
			{
				null,
				"",
				null,
				null
			};

			//Act
			bool matches = list.IsNull();

			//Assert
			Assert.IsFalse(matches, "One non-null item in list didn't match");
		}

		[TestMethod]
		public void CheckingNullListOfItemsWorksOK()
		{
			//Arrange
			var list = new List<string>
			{
				null,
				null,
				null,
				null
			};

			//Act
			bool matches = list.IsNull();

			//Assert
			Assert.IsTrue(matches, "Null list didn't match");
		}

		[TestMethod]
		public void CheckingThatAllItemsAreFalseFails()
		{
			//Arrange
			var items = new[]
			{
				new RefValue { ID = 1, Value = null },
				new RefValue { ID = 2, Value = "B" },
				new RefValue { ID = 3, Value = null },
				new RefValue { ID = 3, Value = null }
			};

			//Act
			var value = items.IsAll(i => i.Value != null, ValidationIsAllCheck.False);

			//Assert
			Assert.IsFalse(value);
		}

		[TestMethod]
		public void CheckingThatAllItemsAreFalseSucceeds()
		{
			//Arrange
			var items = new[]
			{
				new RefValue { ID = 1, Value = "A" },
				new RefValue { ID = 2, Value = "B" },
				new RefValue { ID = 3, Value = "C" }
			};

			//Act
			var value = items.IsAll(i => i.Value == null, ValidationIsAllCheck.False);

			//Assert
			Assert.IsTrue(value);
		}

		[TestMethod]
		public void CheckingThatAllItemsAreTrueFails()
		{
			//Arrange
			var items = new[]
			{
				new RefValue { ID = 1, Value = "A" },
				new RefValue { ID = 2, Value = "B" },
				new RefValue { ID = 3, Value = null }
			};

			//Act
			var value = items.IsAll(i => i.Value != null, ValidationIsAllCheck.True);

			//Assert
			Assert.IsFalse(value);
		}

		[TestMethod]
		public void CheckingThatAllItemsAreTrueSucceeds()
		{
			//Arrange
			var items = new[]
			{
				new RefValue { ID = 1, Value = "A" },
				new RefValue { ID = 2, Value = "B" },
				new RefValue { ID = 3, Value = "C" }
			};

			//Act
			var value = items.IsAll(i => i.Value != null, ValidationIsAllCheck.True);

			//Assert
			Assert.IsTrue(value);
		}

		[TestMethod]
		public void CheckingThatAllItemsAreTrueWorksOK()
		{
			//Arrange
			var items = new[]
			{
				new RefValue { ID = 1, Value = "A" },
				new RefValue { ID = 2, Value = "B" },
				new RefValue { ID = 3, Value = "C" }
			};

			//Act
			var value = items.IsAllTrue(i => i.Value != null);

			//Assert
			Assert.IsTrue(value);
		}

		#endregion
	}
}
