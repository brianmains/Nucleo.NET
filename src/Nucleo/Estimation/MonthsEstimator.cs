using System;
using System.Collections.Generic;

namespace Nucleo.Estimation
{
	/// <summary>
	/// Represents an estimator for calculating months to target dates.
	/// </summary>
	public class MonthsEstimator : BaseDateTimeEstimator
	{
		#region " Methods "

		/// <summary>
		/// Adds to the date the specified number of months.
		/// </summary>
		/// <param name="beginDate">The beginning date.</param>
		/// <param name="unitsFrom">The number of months.</param>
		/// <returns>The date with the specified number of months added.</returns>
		public override DateTime CalculateNextValue(DateTime beginValue, int unitsFrom)
		{
			if (unitsFrom < 1)
				throw new ArgumentOutOfRangeException("unitsFrom");

			return beginValue.AddMonths(unitsFrom);
		}

		#endregion
	}
}