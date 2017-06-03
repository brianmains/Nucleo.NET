using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Assertions
{
	[TestClass]
	public class EnumerableAssertTest
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

		[Test]
		public void ActualAndExpectedIsInstanceOfMatches()
		{
			//Arrange
			var list = new[]
			{
				new Person { FirstName = "Ted", LastName = "Test", Identifier = 1 },
				new Person { FirstName = "Ted", LastName = "List", Identifier = 4 },
				new Person { FirstName = "Ted", LastName = "Ryan", Identifier = 900 }
			};

			//Act
			EnumerableAssert.IsInstanceOf<Person, int>(list, i => i.Identifier, "Identifier doesn't match");
		}

		[Test]
		public void ActualAndExpectedPropertyFuncMatches()
		{
			//Arrange
			var list = new[]
			{
				new Person { FirstName = "Ted", LastName = "Test" },
				new Person { FirstName = "Ted", LastName = "List" },
				new Person { FirstName = "Ted", LastName = "Ryan" }
			};

			//Act
			EnumerableAssert.AreEqual(list, "Ted", i => i.FirstName, "First name doesn't match");
		}

		#endregion
	}
}
