using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Estimation
{
	/// <summary>
	/// Represents the base estimator for date/time evaluations.
	/// </summary>
	public abstract class BaseDateTimeEstimator : BaseEstimator<DateTime, int>
	{
		/// <summary>
		/// Calculates the total number of series that should appear between dates.
		/// </summary>
		/// <param name="beginValue">The begin date.</param>
		/// <param name="unitsFrom">The number of units in the calculation.</param>
		/// <param name="endValue">The end date.</param>
		/// <returns></returns>
		protected override int CalculateSeriesCount(DateTime beginValue, int unitsFrom, DateTime endValue)
		{
			if (beginValue == DateTime.MinValue)
				throw new ArgumentOutOfRangeException("beginValue");
			if (endValue == DateTime.MaxValue)
				throw new ArgumentOutOfRangeException("endValue");
			if (unitsFrom <= 0)
				throw new ArgumentOutOfRangeException("unitsFrom");

			int seriesCount = 0;
			DateTime currentValue = beginValue;

			while (currentValue <= endValue)
			{
				currentValue = this.CalculateNextValue(currentValue, unitsFrom);
				if (currentValue <= endValue)
					seriesCount += 1;
			}

			return seriesCount;
		}
	}
}
