using System;
using System.Collections.Generic;


namespace Nucleo.Estimation
{
	/// <summary>
	/// Represents a calculator used to calculate based upon a day of week.
	/// </summary>
	public class DayOfWeekEstimator : BaseEstimator<DateTime, DayOfWeekReoccurrence>
	{
		#region " Methods "

		/// <summary>
		/// Calculates the nexct value from the date, figuring out which days of week are desired to iterate by.
		/// </summary>
		/// <param name="beginValue">The starting date.</param>
		/// <param name="unitsFrom">The days of the week to include in the calculation.</param>
		/// <returns>The new date.</returns>
		/// <remarks>Depending on the day of week, this could be the next day, or a day in the next week.</remarks>
		public override DateTime CalculateNextValue(DateTime beginValue, DayOfWeekReoccurrence unitsFrom)
		{
			DateTime nextValue = beginValue;

			for (int i = 0; i < 31; i++)
			{
				nextValue = nextValue.AddDays(1);
				WeekNumber weekNumber = this.GetWeekNumber(nextValue);
				if (weekNumber == WeekNumber.Any)
					throw new Exception();

				if (nextValue.DayOfWeek == unitsFrom.Days)
				{
					if (unitsFrom.WeekNumbers == WeekNumber.Any ||
					 (unitsFrom.WeekNumbers & weekNumber) > 0)
						return nextValue;
				}
			}

			return DateTime.MinValue;
		}

		/// <summary>
		/// Calculates the number of items that should appear within the series.
		/// </summary>
		/// <param name="beginValue">The starting date.</param>
		/// <param name="unitsFrom">The days of the week to include.</param>
		/// <param name="endValue">The ending date.</param>
		/// <returns>The number of series to include.</returns>
		protected override int CalculateSeriesCount(DateTime beginValue, DayOfWeekReoccurrence unitsFrom, DateTime endValue)
		{
			int count = 0;

			DateTime currentValue = beginValue;
			while (currentValue <= endValue)
			{
				currentValue = this.CalculateNextValue(currentValue, unitsFrom);
				if (currentValue == DateTime.MinValue)
					return count;
				if (currentValue <= endValue)
					count++;
			}

			return count;
		}

		/// <summary>
		/// This method calculates the week number based on the current date.
		/// </summary>
		/// <param name="date">The date of the current date to get the week number for.</param>
		/// <returns>An enumeration for the week number.</returns>
		private WeekNumber GetWeekNumber(DateTime date)
		{
			int weekNumber = 1;
			int dayCount = date.Day;

			while (dayCount > 7)
			{
				weekNumber++;
				dayCount -= 7;
			}

			if (weekNumber == 1)
				return WeekNumber.First;
			else if (weekNumber == 2)
				return WeekNumber.Second;
			else if (weekNumber == 3)
				return WeekNumber.Third;
			else if (weekNumber == 4)
				return WeekNumber.Fourth;
			else if (weekNumber == 5)
				return WeekNumber.Fifth;
			else
				return WeekNumber.Any;
		}

		/// <summary>
		/// This method determines whether the current value matches the reoccurrence pattern.
		/// </summary>
		/// <param name="value">The value to check to see if it matches the reoccurrence pattern.</param>
		/// <param name="unitsFrom">The reoccurrence information to match.</param>
		/// <returns>A flag determining whether the date matches the reoccurrence pattern.</returns>
		public bool IsMatch(DateTime value, DayOfWeekReoccurrence unitsFrom)
		{
			WeekNumber number = this.GetWeekNumber(value);
			return (unitsFrom.Days == value.DayOfWeek && (unitsFrom.WeekNumbers == WeekNumber.Any || unitsFrom.WeekNumbers == number));
		}

		#endregion
	}
}