using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Estimation
{
	[TestClass]
	public class DaysEstimatorTest
	{
		private DaysEstimator _estimator = new DaysEstimator();



		#region " Tests "

		[TestMethod]
		public void TestEstimatingCloseDates()
		{
			DateTime beginDate = new DateTime(2007, 6, 6);
			DateTime calcDate = _estimator.CalculateNextValue(beginDate, 3);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 9), calcDate));
		}

		[TestMethod]
		public void TestEstimatingCloseDatesSeries()
		{
			DateTime beginDate = new DateTime(2007, 6, 6);
			DateTime[] calcDates = _estimator.CalculateNextValueSeries(beginDate, 3, 5);
			Assert.AreEqual(5, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 9), calcDates[0]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 12), calcDates[1]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 15), calcDates[2]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 18), calcDates[3]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 21), calcDates[4]));
		}

		[TestMethod]
		public void TestEstimatingLongDates()
		{
			DateTime beginDate = new DateTime(2007, 1, 1);
			DateTime calcDate = _estimator.CalculateNextValue(beginDate, 180);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 30), calcDate), "The date is not " + calcDate.ToString());
		}

		[TestMethod]
		public void TestEstimatingLongDatesSeries()
		{
			DateTime beginDate = new DateTime(2007, 1, 1);
			DateTime[] calcDates = _estimator.CalculateNextValueSeries(beginDate, 90, 2);
			Assert.AreEqual(2, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 4, 1), calcDates[0]), "The date is not " + calcDates[0].ToString());
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 30), calcDates[1]), "The date is not " + calcDates[1].ToString());

			DateTime endDate = new DateTime(2007, 8, 1);
			calcDates = _estimator.CalculateNextValueSeries(beginDate, 30, endDate);
			Assert.AreEqual(7, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 1, 31), calcDates[0]), "The date is not " + calcDates[0].ToString());
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 3, 2), calcDates[1]), "The date is not " + calcDates[1].ToString());
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 4, 1), calcDates[2]), "The date is not " + calcDates[2].ToString());
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 5, 1), calcDates[3]), "The date is not " + calcDates[3].ToString());
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 5, 31), calcDates[4]), "The date is not " + calcDates[4].ToString());
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 6, 30), calcDates[5]), "The date is not " + calcDates[5].ToString());
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 7, 30), calcDates[6]), "The date is not " + calcDates[6].ToString());
		}

		#endregion
	}
}