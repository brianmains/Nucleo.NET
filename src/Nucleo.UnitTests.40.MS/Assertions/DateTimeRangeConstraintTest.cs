using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;


namespace Nucleo.Assertions
{
	[TestClass]
	public class DateTimeRangeConstraintTest
	{
		private DateTimeRangeConstraint _constraint = null;



		#region " Tests "

		[Test]
		public void TestMatching()
		{
			_constraint = new DateTimeRangeConstraint(new DateTime(2007, 5, 1), new DateTime(2007, 5, 31));
			Assert.IsTrue(_constraint.Matches(new DateTime(2007, 5, 1)));
			Assert.IsTrue(_constraint.Matches(new DateTime(2007, 5, 31)));
			Assert.IsTrue(_constraint.Matches(new DateTime(2007, 5, 15)));
			Assert.IsFalse(_constraint.Matches(new DateTime(2007, 6, 1)));
			Assert.IsFalse(_constraint.Matches(new DateTime(2007, 4, 30)));
		}

		#endregion
	}
}
