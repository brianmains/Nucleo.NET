using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;


namespace Nucleo.Assertions
{
	[TestClass]
	public class DateTimeEqualityConstraintTest
	{
		private DateTimeEqualityConstraint _constraint = null;



		#region " Tests "

		[Test]
		public void EqualityMatching()
		{
			_constraint = new DateTimeEqualityConstraint(new DateTime(2007, 5, 1), true, true);
			Assert.IsTrue(_constraint.Matches(new DateTime(2007, 5, 1)));
			Assert.IsFalse(_constraint.Matches(new DateTime(2007, 5, 1, 13, 0, 0)));

			_constraint = new DateTimeEqualityConstraint(new DateTime(2007, 5, 1), false, true);
			Assert.IsTrue(_constraint.Matches(new DateTime(2007, 5, 1)));
			Assert.IsTrue(_constraint.Matches(new DateTime(2007, 5, 1, 13, 0, 0)));
		}

		[Test]
		public void NotEqualityMatching()
		{
			_constraint = new DateTimeEqualityConstraint(new DateTime(2007, 5, 1), true, false);
			Assert.IsFalse(_constraint.Matches(new DateTime(2007, 5, 1)));
			Assert.IsTrue(_constraint.Matches(new DateTime(2007, 5, 1, 13, 0, 0)));

			_constraint = new DateTimeEqualityConstraint(new DateTime(2007, 5, 1), false, false);
			Assert.IsFalse(_constraint.Matches(new DateTime(2007, 5, 1)));
			Assert.IsFalse(_constraint.Matches(new DateTime(2007, 5, 1, 13, 0, 0)));

			_constraint = new DateTimeEqualityConstraint(new DateTime(2007, 5, 2), false, false);
			Assert.IsTrue(_constraint.Matches(new DateTime(2007, 5, 1)));
			Assert.IsTrue(_constraint.Matches(new DateTime(2007, 5, 1, 13, 0, 0)));
		}

		#endregion
	}
}
