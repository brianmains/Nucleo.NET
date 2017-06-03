using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo
{
	[TestClass]
	public class DateTimeEqualityTest
	{
		[TestMethod]
		public void CheckingThatDateIsInRangeIsAfter()
		{
			DateTime date = new DateTime(2007, 1, 2, 1, 0, 0);

			Assert.IsFalse(DateTimeEquality.IsInRange(date, new DateTime(2007, 1, 1, 11, 0, 0), new DateTime(2007, 1, 2)));
		}

		[TestMethod]
		public void CheckingThatDateIsInRangeIsBefore()
		{
			DateTime date = new DateTime(2007, 1, 1, 10, 12, 32);

			Assert.IsFalse(DateTimeEquality.IsInRange(date, new DateTime(2007, 1, 1, 11, 0, 0), new DateTime(2007, 1, 2)));
		}

		[TestMethod]
		public void CheckingThatDateIsInRangeIsOK()
		{
			DateTime date = new DateTime(2007, 1, 1, 10, 12, 32);

			Assert.IsTrue(DateTimeEquality.IsInRange(date, new DateTime(2007, 1, 1), new DateTime(2007, 1, 2)));
		}

		[TestMethod]
		public void TestGeneralEquals()
		{
			DateTime date1 = new DateTime(2007, 1, 1, 10, 12, 32);
			DateTime date2 = new DateTime(2007, 1, 1, 11, 34, 10);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(date1, date2));

			date1 = new DateTime(2007, 1, 2, 00, 00, 00);
			date2 = new DateTime(2007, 1, 1, 23, 59, 59);
			Assert.IsFalse(DateTimeEquality.GeneralEquals(date1, date2));
		}

		[TestMethod]
		public void TestSpecificEquals()
		{
			DateTime date1 = new DateTime(2007, 1, 1, 10, 20, 30);
			DateTime date2 = new DateTime(2007, 1, 1, 10, 20, 30);
			Assert.IsTrue(DateTimeEquality.SpecificEquals(date1, date2));

			date1 = new DateTime(2007, 1, 1, 10, 20, 30);
			date2 = new DateTime(2007, 1, 1, 10, 20, 31);
			Assert.IsFalse(DateTimeEquality.SpecificEquals(date1, date2));
		}
	}
}
