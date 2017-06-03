using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Estimation
{
	[TestClass]
	public class DateEstimationTest
	{
		[TestMethod]
		public void TestCalculatingByDay()
		{
			Assert.IsInstanceOfType(DateEstimation.GetEstimator(CalendarPeriod.Day), typeof(DaysEstimator));
			
		}

		[TestMethod]
		public void TestCalculatingByWeek()
		{
			Assert.IsInstanceOfType(DateEstimation.GetEstimator(CalendarPeriod.Week), typeof(WeeksEstimator));
		}

		[TestMethod]
		public void TestCalculatingByMonth()
		{
			Assert.IsInstanceOfType(DateEstimation.GetEstimator(CalendarPeriod.Month), typeof(MonthsEstimator));
		}

		[TestMethod]
		public void TestCalculatingByYear()
		{
			Assert.IsInstanceOfType(DateEstimation.GetEstimator(CalendarPeriod.Year), typeof(YearsEstimator));
		}

		[
		TestMethod, 
		ExpectedException(typeof(ArgumentException))
		]
		public void TestFailedGet()
		{
			DateEstimation.GetEstimator(CalendarPeriod.None);
		}
	}
}
