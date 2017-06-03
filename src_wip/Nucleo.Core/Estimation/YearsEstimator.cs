using System;
using System.Collections.Generic;

namespace Nucleo.Estimation
{
	/// <summary>
	/// Represents an estimator for calculating years to target dates.
	/// </summary>
	public class YearsEstimator : BaseDateTimeEstimator
	{
		#region " Methods "

		/// <summary>
		/// Adds to the date the specified number of years.
		/// </summary>
		/// <param name="beginDate">The beginning date.</param>
		/// <param name="unitsFrom">The number of years.</param>
		/// <returns>The date with the specified number of years added.</returns>
		public override DateTime CalculateNextValue(DateTime beginValue, int unitsFrom)
		{
			if (unitsFrom < 1)
				throw new ArgumentOutOfRangeException("unitsFrom");

			return beginValue.AddYears(unitsFrom);
		}

		#endregion
	}
}