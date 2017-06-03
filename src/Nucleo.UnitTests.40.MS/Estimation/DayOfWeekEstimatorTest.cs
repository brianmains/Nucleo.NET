using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nucleo;


namespace Nucleo.Estimation
{
	[TestClass]
	public class DayOfWeekEstimatorTest
	{
		private DayOfWeekEstimator _estimator = new DayOfWeekEstimator();



		#region " Tests "

		[TestMethod]
		public void TestEstimatingDates()
		{
			DateTime beginDate = new DateTime(2007, 6, 1);

			DateTime calcDate = _estimator.CalculateNextValue(beginDate, new DayOfWeekReoccurrence(DayOfWeek.Wednesday, WeekNumber.Any));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 6), calcDate), "The value returned was incorrectly {0}", calcDate);

			calcDate = _estimator.CalculateNextValue(beginDate, new DayOfWeekReoccurrence(DayOfWeek.Friday, WeekNumber.Any));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 8), calcDate), "The value returned was incorrectly {0}", calcDate);

			calcDate = _estimator.CalculateNextValue(beginDate, new DayOfWeekReoccurrence(DayOfWeek.Thursday, WeekNumber.Fourth));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 28), calcDate), "The value returned was incorrectly {0}", calcDate);

			calcDate = _estimator.CalculateNextValue(beginDate, new DayOfWeekReoccurrence(DayOfWeek.Saturday, WeekNumber.Fifth));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 30), calcDate), "The value returned was incorrectly {0}", calcDate);
		}

		[TestMethod]
		public void TestEstimatingDatesSeries()
		{
			DateTime beginDate = new DateTime(2007, 6, 1);
			DateTime[] calcDates = _estimator.CalculateNextValueSeries(beginDate, new DayOfWeekReoccurrence(DayOfWeek.Friday, WeekNumber.Any), 6);

			Assert.AreEqual(6, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 8), calcDates[0]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 15), calcDates[1]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 22), calcDates[2]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 29), calcDates[3]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 7, 6), calcDates[4]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 7, 13), calcDates[5]));
		}

		[TestMethod]
		public void TestIsMatch()
		{
			DateTime beginDate = new DateTime(2007, 6, 1);
			Assert.IsTrue(_estimator.IsMatch(beginDate, new DayOfWeekReoccurrence(DayOfWeek.Friday, WeekNumber.Any)));

			beginDate = new DateTime(2007, 6, 2);
			Assert.IsFalse(_estimator.IsMatch(beginDate, new DayOfWeekReoccurrence(DayOfWeek.Friday, WeekNumber.Any)));
		}

		#endregion
	}
}