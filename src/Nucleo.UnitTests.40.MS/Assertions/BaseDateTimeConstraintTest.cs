using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;


namespace Nucleo.Assertions
{
	[TestClass]
	public class BaseDateTimeConstraintTest : BaseDateTimeConstraint
	{
		#region " Methods "

		public override bool Matches(object actual)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public override void WriteDescriptionTo(MessageWriter writer)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion



		#region " Tests "

		[Test]
		public void EqualityChecksReturnFalse()
		{
			//Arrange
			DateTime beginDate = new DateTime(2007, 1, 1, 18, 0, 0);
			DateTime endDate = new DateTime(2007, 1, 1, 13, 0, 0);

			//Act
			bool match = base.AreEqual(beginDate, endDate, true);

			//Assert
			Assert.IsFalse(match);
		}

		[Test]
		public void EqualityChecksReturnTrue()
		{
			//Arrange
			DateTime beginDate = new DateTime(2007, 1, 1, 18, 0, 0);
			DateTime endDate = new DateTime(2007, 1, 1, 13, 0, 0);

			//Act
			bool match = base.AreEqual(beginDate, endDate, false);

			//Assert
			Assert.IsTrue(match);
		}

		[Test]
		public void MatchingBetweenDatesReturnsTrue()
		{
			//Arrange
			DateTime beginDate = new DateTime(2007, 5, 1, 14, 0, 0);
			DateTime endDate = new DateTime(2007, 5, 31, 20, 0, 0);

			//Act
			bool match1 = base.IsInRange(beginDate, endDate, new DateTime(2007, 5, 1, 14, 0, 0));
			bool match2 = base.IsInRange(beginDate, endDate, new DateTime(2007, 5, 20));
			bool match3 = base.IsInRange(beginDate, endDate, new DateTime(2007, 5, 31, 20, 0, 0));

			//Assert
			Assert.IsTrue(match1);
			Assert.IsTrue(match2);
			Assert.IsTrue(match3);
		}

		[Test]
		public void MatchingOutsideDatesReturnsFalse()
		{
			//Arrange
			DateTime beginDate = new DateTime(2007, 5, 1, 14, 0, 0);
			DateTime endDate = new DateTime(2007, 5, 31, 20, 0, 0);

			//Act
			bool match1 = base.IsInRange(beginDate, endDate, new DateTime(2007, 5, 1));
			bool match2 = base.IsInRange(beginDate, endDate, new DateTime(2007, 5, 31, 23, 59, 59));

			//Assert
			Assert.IsFalse(match1);
			Assert.IsFalse(match2);
		}

		#endregion
	}
}
