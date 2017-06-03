using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Estimation
{
	[TestClass]
	public class YearsEstimatorTest
	{
		private YearsEstimator _estimator = new YearsEstimator();



		#region " Tests "

		[TestMethod]
		public void TestEstimatingDates()
		{
			DateTime beginDate = new DateTime(2007, 6, 1);

			DateTime calcDate = _estimator.CalculateNextValue(beginDate, 1);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2008, 6, 1), calcDate));

			calcDate = _estimator.CalculateNextValue(beginDate, 2);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2009, 6, 1), calcDate));

			calcDate = _estimator.CalculateNextValue(beginDate, 10);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2017, 6, 1), calcDate));
		}

		[TestMethod]
		public void TestEstimatingDatesSeries()
		{
			DateTime beginDate = new DateTime(2007, 6, 1);

			DateTime[] calcDates = _estimator.CalculateNextValueSeries(beginDate, 1, 5);
			Assert.AreEqual(5, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2008, 6, 1), calcDates[0]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2009, 6, 1), calcDates[1]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2010, 6, 1), calcDates[2]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2011, 6, 1), calcDates[3]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2012, 6, 1), calcDates[4]));

			DateTime endDate = new DateTime(2010, 6, 1);
			calcDates = _estimator.CalculateNextValueSeries(beginDate, 1, endDate);
			Assert.AreEqual(3, calcDates.Length);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2008, 6, 1), calcDates[0]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2009, 6, 1), calcDates[1]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2010, 6, 1), calcDates[2]));
		}

		#endregion
	}
}