using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nucleo;


namespace Nucleo.Estimation
{
	[TestClass]
	public class WeeksEstimatorTest
	{
		WeeksEstimator _estimator = new WeeksEstimator();



		#region " Tests "

		[TestMethod]
		public void TestEstimatingCloseDates()
		{
			DateTime beginDate = new DateTime(2007, 6, 6);
			DateTime calcDate = _estimator.CalculateNextValue(beginDate, 3);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 27), calcDate));
		}

		[TestMethod]
		public void TestEstimatingCloseDatesRange()
		{
			DateTime beginDate = new DateTime(2007, 6, 6);
			DateTime[] calcDates = _estimator.CalculateNextValueSeries(beginDate, 3, 3);

			Assert.AreEqual(3, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 27), calcDates[0]), "The date was incorrectly {0}", calcDates[0]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 7, 18), calcDates[1]), "The date was incorrectly {0}", calcDates[1]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 8, 8), calcDates[2]), "The date was incorrectly {0}", calcDates[2]);

			DateTime endDate = new DateTime(2007, 8, 31);
			calcDates = _estimator.CalculateNextValueSeries(beginDate, 3, endDate);
			Assert.AreEqual(4, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 27), calcDates[0]), "The date was incorrectly {0}", calcDates[0]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 7, 18), calcDates[1]), "The date was incorrectly {0}", calcDates[1]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 8, 8), calcDates[2]), "The date was incorrectly {0}", calcDates[2]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 8, 29), calcDates[3]), "The date was incorrectly {0}", calcDates[3]);
		}

		[TestMethod]
		public void TestEstimatingLongDates()
		{
			DateTime beginDate = new DateTime(2007, 6, 6);
			DateTime calcDate = _estimator.CalculateNextValue(beginDate, 7);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 7, 25), calcDate), "The date was incorrectly {0}", calcDate);
		}

		[TestMethod]
		public void TestEstimatingLongDatesRange()
		{
			DateTime beginDate = new DateTime(2007, 6, 6);
			DateTime[] calcDates = _estimator.CalculateNextValueSeries(beginDate, 7, 2);

			Assert.AreEqual(2, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 7, 25), calcDates[0]), "The date was incorrectly {0}", calcDates[0]);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 9, 12), calcDates[1]), "The date was incorrectly {0}", calcDates[1]);
		}

		#endregion
	}
}