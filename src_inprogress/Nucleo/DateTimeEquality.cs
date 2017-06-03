using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo
{
	/// <summary>
	/// Determines whether dates and times are equal; when comparing date/time values from the database, millisecond values are included, whereas most .NET framework dates do not explicitly capture milliseconds.
	/// </summary>
	public static class DateTimeEquality
	{
		/// <summary>
		/// Determines whether two dates match, by month, date, and year only.
		/// </summary>
		/// <param name="date1">The first date to compare.</param>
		/// <param name="date2">The second date to compare.</param>
		/// <returns>Whether the dates match.</returns>
		public static bool GeneralEquals(DateTime date1, DateTime date2)
		{
			return date1.ToShortDateString().Equals(date2.ToShortDateString());
		}

		/// <summary>
		/// Whether one date is within a specified range.
		/// </summary>
		/// <param name="dateToCheck">The date to check whether it is in range.</param>
		/// <param name="beginDate">The first date of the range, the lower date.</param>
		/// <param name="endDate">The second date of the range, the upper date.</param>
		/// <returns>Whether the date is in the range.</returns>
		public static bool IsInRange(DateTime dateToCheck, DateTime beginDate, DateTime endDate)
		{
			return (dateToCheck > beginDate && dateToCheck < endDate);
		}

		/// <summary>
		/// Determines whether two dates match, by date and time.
		/// </summary>
		/// <param name="date1">The first date to compare.</param>
		/// <param name="date2">The second date to compare.</param>
		/// <returns></returns>
		public static bool SpecificEquals(DateTime date1, DateTime date2)
		{
			return date1.ToString().Equals(date2.ToString());
		}
	}
}
