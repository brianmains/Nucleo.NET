using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Estimation
{
	[TestClass]
	public class BaseDateTimeEstimatorTest : BaseDateTimeEstimator
	{
		#region " Methods "

		public override DateTime CalculateNextValue(DateTime beginValue, int unitsFrom)
		{
			if (unitsFrom <= 0)
				throw new ArgumentNullException("unitsFrom");

			return beginValue.AddDays(unitsFrom);
		}

		#endregion


		#region " Tests "

		[TestMethod]
		public void TestCalculateNextSeriesValue()
		{
			DateTime nextDate = this.CalculateNextValue(DateTime.Today, 1);
			Assert.AreEqual(DateTime.Today.AddDays(1), nextDate);

			nextDate = this.CalculateNextValue(nextDate, 1);
			Assert.AreEqual(DateTime.Today.AddDays(2), nextDate);
		}

		[TestMethod]
		public void TestCalculateNextValue()
		{
			DateTime nextDate = this.CalculateNextValue(DateTime.Today, 3);
			Assert.AreEqual(DateTime.Today.AddDays(3), nextDate);

			nextDate = this.CalculateNextValue(nextDate, 4);
			Assert.AreEqual(DateTime.Today.AddDays(7), nextDate);
		}

		[
		TestMethod, 
		ExpectedException(typeof(ArgumentNullException))
		]
		public void TestCalculateNextValueFailures()
		{
			this.CalculateNextValue(DateTime.Today, 0);
		}

		#endregion
	}
}
