using System;


namespace Nucleo.Estimation
{
	/// <summary>
	/// This class is a facade, exposing access to the core calendar period estimators.
	/// </summary>
	public static class DateEstimation
	{
		/// <summary>
		/// This method returns the appropriate estimator that works with the specific calendar period.
		/// </summary>
		/// <param name="period">The period to get the estimator for.</param>
		/// <returns>A <seealso cref="BaseDateTimeEstimator">BaseDateTimeEstimator object</seealso> that represents the specific validator.</returns>
		public static BaseDateTimeEstimator GetEstimator(CalendarPeriod period)
		{
			if (period == CalendarPeriod.None)
				throw new ArgumentException("The calendar period cannot be a value of 'None'");

			if (period == CalendarPeriod.Day)
				return new DaysEstimator();
			else if (period == CalendarPeriod.Month)
				return new MonthsEstimator();
			else if (period == CalendarPeriod.Week)
				return new WeeksEstimator();
			else if (period == CalendarPeriod.Year)
				return new YearsEstimator();
			else
				return null;
		}
	}
}
