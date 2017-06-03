using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Estimation
{
	[TestClass]
	public class MonthsEstimatorTest
	{
		private MonthsEstimator _estimator = new MonthsEstimator();



		#region " Tests "

		[TestMethod]
		public void TestEstimatingCloseDates()
		{
			DateTime beginDate = new DateTime(2007, 6, 6);
			DateTime calcDate = _estimator.CalculateNextValue(beginDate, 2);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 8, 6), calcDate), "The date was incorrectly {0}", calcDate);
		}

		[TestMethod]
		public void TestEstimatingCloseDatesSeries()
		{
			DateTime beginDate = new DateTime(2007, 6, 6);
			DateTime[] calcDates = _estimator.CalculateNextValueSeries(beginDate, 2, 3);

			Assert.AreEqual(3, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 8, 6), calcDates[0]), "The date was incorrectly {0}", calcDates[0]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 10, 6), calcDates[1]), "The date was incorrectly {0}", calcDates[1]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 12, 6), calcDates[2]), "The date was incorrectly {0}", calcDates[2]);

			DateTime endDate = new DateTime(2007, 12, 25);
			calcDates = _estimator.CalculateNextValueSeries(beginDate, 2, endDate);
			Assert.AreEqual(3, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 8, 6), calcDates[0]), "The date was incorrectly {0}", calcDates[0]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 10, 6), calcDates[1]), "The date was incorrectly {0}", calcDates[1]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 12, 6), calcDates[2]), "The date was incorrectly {0}", calcDates[2]);
		}

		[TestMethod]
		public void TestEstimatingLongDates()
		{
			DateTime beginDate = new DateTime(2007, 1, 1);
			DateTime calcDate = _estimator.CalculateNextValue(beginDate, 20);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2008, 9, 1), calcDate), "The date was incorrectly {0}", calcDate);
		}

		[TestMethod]
		public void TestEstimatingLongDatesSeries()
		{
			DateTime beginDate = new DateTime(2007, 1, 1);
			DateTime[] calcDates = _estimator.CalculateNextValueSeries(beginDate, 12, 3);

			Assert.AreEqual(3, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2008, 1, 1), calcDates[0]), "The date was incorrectly {0}", calcDates[0]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2009, 1, 1), calcDates[1]), "The date was incorrectly {0}", calcDates[1]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2010, 1, 1), calcDates[2]), "The date was incorrectly {0}", calcDates[2]);
		}

		#endregion
	}
}