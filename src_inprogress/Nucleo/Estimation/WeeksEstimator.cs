using System;
using System.Collections.Generic;


namespace Nucleo.Estimation
{
	/// <summary>
	/// Represents an estimator for calculating weeks to target dates.
	/// </summary>
	public class WeeksEstimator : BaseDateTimeEstimator
	{
		#region " Methods "

		/// <summary>
		/// Adds to the date the specified number of weeks.
		/// </summary>
		/// <param name="beginDate">The beginning date.</param>
		/// <param name="unitsFrom">The number of weeks.</param>
		/// <returns>The date with the specified number of weeks added.</returns>
		public override DateTime CalculateNextValue(DateTime beginValue, int unitsFrom)
		{
			if (unitsFrom < 1)
				throw new ArgumentOutOfRangeException("unitsFrom");

			return beginValue.AddDays((unitsFrom * 7));
		}

		#endregion
	}
}