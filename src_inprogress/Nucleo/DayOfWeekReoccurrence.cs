using System;


namespace Nucleo
{
	/// <summary>
	/// Represents a reoccurrence of days and weeks that items are tasked by.
	/// </summary>
	public class DayOfWeekReoccurrence
	{
		private DayOfWeek _days;
		private WeekNumber _weekNumbers;



		#region " Properties "

		/// <summary>
		/// Get or sets the days of the week that are in reoccurrence.
		/// </summary>
		public DayOfWeek Days
		{
			get { return _days; }
			set { _days = value; }
		}

		/// <summary>
		/// Gets or sets the numbers of the week to determine if they are in reoccurrence (first, second, third, etc.).
		/// </summary>
		public WeekNumber WeekNumbers
		{
			get { return _weekNumbers; }
			set { _weekNumbers = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates a new instance of the reoccurrence.
		/// </summary>
		public DayOfWeekReoccurrence() { }

		/// <summary>
		/// Creates a new instance of the reoccurrence.
		/// </summary>
		/// <param name="day">The days to reoccur on.</param>
		/// <param name="weekNumber">The week numbers to reoccur on (first, second, etc.).</param>
		public DayOfWeekReoccurrence(DayOfWeek day, WeekNumber weekNumber)
		{
			_days = day;
			_weekNumbers = weekNumber;
		}

		#endregion
	}
}