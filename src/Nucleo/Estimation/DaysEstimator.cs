using System;
using System.Collections.Generic;


namespace Nucleo.Estimation
{
	/// <summary>
	/// Represents an estimator for calculating days to target dates.
	/// </summary>
	public class DaysEstimator : BaseDateTimeEstimator
	{
		#region " Methods "

		/// <summary>
		/// Adds to the date the specified number of days.
		/// </summary>
		/// <param name="beginDate">The beginning date.</param>
		/// <param name="unitsFrom">The number of days.</param>
		/// <returns>The date with the specified number of days added.</returns>
		public override DateTime CalculateNextValue(DateTime beginDate, int unitsFrom)
		{
			return beginDate.AddDays(unitsFrom);
		}

		#endregion
	}
}