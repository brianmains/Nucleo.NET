using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo
{
	public static class DateTimeUtility
	{
		#region " Methods "

		/// <summary>
		/// Converts the date to start from midnight.
		/// </summary>
		/// <param name="beginDate">The date to convert.</param>
		/// <returns>A converted date.</returns>
		public static DateTime ConvertToBeginDate(DateTime beginDate)
		{
			return new DateTime(beginDate.Year, beginDate.Month, beginDate.Day, 0, 0, 0);
		}

		/// <summary>
		/// Converts the date to end at midnight.
		/// </summary>
		/// <param name="beginDate">The date to convert.</param>
		/// <returns>A converted date.</returns>
		public static DateTime ConvertToEndDate(DateTime endDate)
		{
			return new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
		}

		/// <summary>
		/// Whether the date is SQL Server appropriate.
		/// </summary>
		/// <param name="dateToCheck">The date to check to ensure it is within the valid range.</param>
		/// <returns>Whether the date is OK.</returns>
		public static bool IsSqlServerAppropriate(DateTime dateToCheck)
		{
			return (dateToCheck >= SqlServerLongDateMinimum());
		}

		/// <summary>
		/// The longdatetime minimum date.
		/// </summary>
		public static DateTime SqlServerLongDateMinimum()
		{
			return new DateTime(1753, 1, 1, 0, 0, 0);
		}

		/// <summary>
		/// The shortdatetime minimum date.
		/// </summary>
		public static DateTime SqlServerShortDateMinimum()
		{
			return new DateTime(1900, 1, 1, 0, 0, 0);
		}

		#endregion
	}
}
