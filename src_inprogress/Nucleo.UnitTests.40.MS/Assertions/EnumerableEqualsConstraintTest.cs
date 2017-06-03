using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Assertions
{
	[TestClass]
	public class EnumerableEqualsConstraintTest
	{
		#region " Tests "

		[Test]
		public void ActualAndEstimatedListsDontMatch()
		{
			//Arrange
			var constraint = new EnumerableEqualsConstraint<string>(new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			});

			var actual = new string[]
			{
				"Test",
				"That",
				"Doesn't",
				"Works"
			};

			//Act
			var matches = constraint.Matches(actual);

			//Assert
			Assert.AreEqual(false, matches);
		}

		[Test]
		public void ActualAndEstimatedListsMatch()
		{
			//Arrange
			var constraint = new EnumerableEqualsConstraint<string>(new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			});

			var actual = new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			};

			//Act
			var matches = constraint.Matches(actual);

			//Assert
			Assert.AreEqual(true, matches);
		}

		[Test]
		public void ActualAndEstimatedListsVaryByCountDontMatch()
		{
			//Arrange
			var constraint = new EnumerableEqualsConstraint<string>(new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			});

			var actual = new string[]
			{
				"Test",
				"That",
				"This",
				"Works",
				", Not"
			};

			//Act
			var matches = constraint.Matches(actual);

			//Assert
			Assert.AreEqual(false, matches);
		}

		[Test]
		public void ActualAndEstimatedListsVaryByTypeDontMatch()
		{
			//Arrange
			var constraint = new EnumerableEqualsConstraint<string>(new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			});

			var actual = new int[] { 1, 2, 3, 4 };

			//Act
			var matches = constraint.Matches(actual);

			//Assert
			Assert.AreEqual(false, matches);
		}

		[Test]
		public void ActualPassesInNullDoesntMatch()
		{
			//Arrange
			var constraint = new EnumerableEqualsConstraint<string>(new string[]
			{
				"Test",
				"That",
				"This",
				"Works"
			});

			//Act
			var matches = constraint.Matches((object)null);

			//Assert
			Assert.AreEqual(false, matches);
		}

		#endregion
	}
}
