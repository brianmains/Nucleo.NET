using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo
{
	/// <summary>
	/// Represents a number of business days.
	/// </summary>
	public class BusinessDays
	{
		private bool _closeOfBusiness = false;
		private int _days = 0;



		#region " Properties "

		/// <summary>
		/// Gets whether to evaluate the date from close of business, or the end of the day.
		/// </summary>
		public bool CloseOfBusiness
		{
			get { return _closeOfBusiness; }
		}

		/// <summary>
		/// Gets the number of dates to append.
		/// </summary>
		public int Days
		{
			get { return _days; }
		}

		#endregion



		#region " Constructors "

		public BusinessDays(int days)
			: this(days, false) { }

		public BusinessDays(int days, bool closeOfBusiness)
		{
			if (days < 0)
				throw new ArgumentOutOfRangeException("days");

			_days = days;
			_closeOfBusiness = closeOfBusiness;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds to the starting date the specified number of days.
		/// </summary>
		/// <param name="startingDate">The starting date.</param>
		/// <returns>The new date/time.</returns>
		public DateTime AddTo(DateTime startingDate)
		{
			int counter = _days;
			DateTime date = AdjustAddingDate(startingDate);

			while (counter >= 5)
			{
				date = date.AddDays(7);
				counter -= 5;
			}

			for (var i = counter - 1; i >= 0; i--)
			{
				date = AdjustAddingDate(date).AddDays(1);
			}

			return date;
		}

		private DateTime AdjustAddingDate(DateTime date)
		{
			if (date.DayOfWeek == DayOfWeek.Friday)
				date = date.Add(new TimeSpan(2, 0, 0, 0));
			else if (date.DayOfWeek == DayOfWeek.Saturday)
				date = date.Add(new TimeSpan(1, 0, 0, 0));
			return date;
		}

		private DateTime AdjustSubtractingDate(DateTime date)
		{
			if (date.DayOfWeek == DayOfWeek.Monday)
				date = date.Subtract(new TimeSpan(2, 0, 0, 0));
			else if (date.DayOfWeek == DayOfWeek.Sunday)
				date = date.Subtract(new TimeSpan(1, 0, 0, 0));
			return date;
		}

		/// <summary>
		/// Subtracts from the starting date the specified number of days.
		/// </summary>
		/// <param name="startingDate">The starting date.</param>
		/// <returns>The new date/time.</returns>
		public DateTime SubtractFrom(DateTime startingDate)
		{
			int counter = _days;
			DateTime date = startingDate;
			date = AdjustSubtractingDate(date);

			while (counter >= 5)
			{
				date = date.Subtract(new TimeSpan(7, 0, 0, 0));
				counter -= 5;
			}

			for (var i = counter - 1; i >= 0; i--)
				date = AdjustSubtractingDate(date).Subtract(new TimeSpan(1, 0, 0, 0));

			return date;
		}

		#endregion
	}
}
