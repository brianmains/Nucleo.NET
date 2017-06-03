using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Assertions
{
	[TestClass]
	public class EnumerableNullStatusConstraintTest
	{
		#region " Tests "

		[Test]
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

			var constraint = new EnumerableNullStatusConstraint<string>(list, false);

			//Act
			bool matches = constraint.Matches(default(object));

			//Assert
			Assert.IsFalse(matches, "One null item in list didn't match");
		}

		[Test]
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

			var constraint = new EnumerableNullStatusConstraint<string>(list, false);

			//Act
			bool matches = constraint.Matches(default(object));

			//Assert
			Assert.IsTrue(matches, "Null list didn't match");
		}

		[Test]
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

			var constraint = new EnumerableNullStatusConstraint<string>(list, true);

			//Act
			bool matches = constraint.Matches(default(object));

			//Assert
			Assert.IsFalse(matches, "One non-null item in list didn't match");
		}

		[Test]
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

			var constraint = new EnumerableNullStatusConstraint<string>(list, true);

			//Act
			bool matches = constraint.Matches(default(object));

			//Assert
			Assert.IsTrue(matches, "Null list didn't match");
		}

		#endregion
	}
}
