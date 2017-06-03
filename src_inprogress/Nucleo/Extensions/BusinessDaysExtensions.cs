using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Extensions
{
	/// <summary>
	/// Represents the extensions for business days.
	/// </summary>
	public static class BusinessDaysExtensions
	{
		#region " Methods "

		/// <summary>
		/// Adds the specified number of business days to the date.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="days">The days.</param>
		/// <returns>The new date/time.</returns>
		public static DateTime AddBusinessDays(this DateTime date, int days)
		{
			return new BusinessDays(days).AddTo(date);
		}

		/// <summary>
		/// Adds the specified number of business days to the date.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="days">The days.</param>
		/// <param name="closeOfBusiness">Whether to make the date from the point of closing of business (end of day).</param>
		/// <returns>The new date/time.</returns>
		public static DateTime AddBusinessDays(this DateTime date, int days, bool closeOfBusiness)
		{
			return new BusinessDays(days, closeOfBusiness).AddTo(date);
		}

		/// <summary>
		/// Subtracts the specified number of business days to the date.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="days">The days.</param>
		/// <returns>The new date/time.</returns>
		public static DateTime SubtractBusinessDays(this DateTime date, int days)
		{
			return new BusinessDays(days).SubtractFrom(date);
		}

		/// <summary>
		/// Subtracts the specified number of business days to the date.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="days">The days.</param>
		/// <param name="closeOfBusiness">Whether to make the date from the point of closing of business (end of day).</param>
		/// <returns>The new date/time.</returns>
		public static DateTime SubtractBusinessDays(this DateTime date, int days, bool closeOfBusiness)
		{
			return new BusinessDays(days).SubtractFrom(date);
		}

		#endregion
	}
}
