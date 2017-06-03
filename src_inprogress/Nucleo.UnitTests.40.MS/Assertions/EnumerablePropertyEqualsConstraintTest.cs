using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Assertions
{
	[TestClass]
	public class EnumerablePropertyEqualsConstraintTest
	{
		#region " Test Classes "

		protected class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void ActualAndExpectedPropertyMatches()
		{
			//Arrange
			var list = new[]
			{
				new Person { FirstName = "Ted", LastName = "Test" },
				new Person { FirstName = "Ted", LastName = "List" },
				new Person { FirstName = "Ted", LastName = "Ryan" }
			};

			//Act
			var constraint = new EnumerablePropertyEqualsConstraint<Person, string>(list, 
				"Ted");
			bool matches = constraint.Matches(new Func<Person, string>(i => i.FirstName));

			//Assert
			Assert.AreEqual(true, matches);
		}

		#endregion
	}
}
