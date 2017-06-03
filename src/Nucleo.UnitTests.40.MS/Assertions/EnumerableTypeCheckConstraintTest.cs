using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Assertions
{
	public class EnumerableTypeCheckConstraintTest
	{
		#region " Test Classes "

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
			var constraint = new EnumerableTypeCheckConstraint<Person, string>(list);

			//Act
			var match = constraint.Matches(new Func<Person, object>(i => i.FirstName));

			//Assert
			Assert.AreEqual(true, match);
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
			var constraint = new EnumerableTypeCheckConstraint<Person, string>(list);

			//Act
			var match = constraint.Matches(new Func<Person, object>(i => i.Identifier));

			//Assert
			Assert.AreEqual(false, match);
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
			var constraint = new EnumerableTypeCheckConstraint<Person, DateTime>(list);

			//Act
			var match = constraint.Matches(new Func<Person, object>(i => i.Identifier));

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
			var constraint = new EnumerableTypeCheckConstraint<Person, int>(list);

			//Act
			var match = constraint.Matches(new Func<Person, object>(i => i.Identifier));

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
			var constraint = new EnumerableTypeCheckConstraint<Person, string>(list);

			//Act
			var match = constraint.Matches(new Func<Person, object>(i => i.Identifier));

			//Assert
			Assert.AreEqual(true, match);
		}

		#endregion
	}
}
