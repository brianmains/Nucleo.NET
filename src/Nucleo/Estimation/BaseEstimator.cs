using System;
using System.Collections.Generic;


namespace Nucleo.Estimation
{
	/// <summary>
	/// Represents the base class for components that estimate values.  For instance, calculating X number of months from the starting date.
	/// </summary>
	/// <typeparam name="T">The type of the core object to use for calculations.</typeparam>
	/// <typeparam name="U">The type of the units value.</typeparam>
	public abstract class BaseEstimator<T, U>
	{
		/// <summary>
		/// Calculates the next value, using the core value, by adding the units value to it.
		/// </summary>
		/// <param name="beginValue">The begin value to calculate by.</param>
		/// <param name="unitsFrom">The number of units to use for the calculation.</param>
		/// <returns>The calculated value.</returns>
		public abstract T CalculateNextValue(T beginValue, U unitsFrom);

		/// <summary>
		/// Calculates a series of values, using the beginning value, units, and the end cutoff value.
		/// </summary>
		/// <param name="beginValue">The being value to use for calculations.</param>
		/// <param name="unitsFrom">The number of units to use for calculations between the begin and end.</param>
		/// <param name="endValue">The ending value to limit the results by.</param>
		/// <returns>The array of calculated values.</returns>
		public T[] CalculateNextValueSeries(T beginValue, U unitsFrom, T endValue)
		{
			if (unitsFrom == null)
				throw new ArgumentNullException("unitsFrom");

			return CalculateNextValueSeries(beginValue, unitsFrom, this.CalculateSeriesCount(beginValue, unitsFrom, endValue));
		}

		/// <summary>
		/// Calculates a series of values, using the beginning value, units, and the end number of instances.
		/// </summary>
		/// <param name="beginValue">The being value to use for calculations.</param>
		/// <param name="unitsFrom">The number of units to use for calculations between the begin and end.</param>
		/// <param name="seriesCount">The total number of entries to calculate for.</param>
		/// <returns>The array of calculated values.</returns>
		public T[] CalculateNextValueSeries(T beginValue, U unitsFrom, int seriesCount)
		{
			if (unitsFrom == null)
				throw new ArgumentNullException("unitsFrom");

			List<T> seriesList = new List<T>();
			T seriesValue = beginValue;

			for (int i = 0; i < seriesCount; i++)
			{
				seriesValue = this.CalculateNextValue(seriesValue, unitsFrom);
				seriesList.Add(seriesValue);
			}

			return seriesList.ToArray();
		}

		/// <summary>
		/// This method calculates the total number of units between the beginning and ending value.
		/// </summary>
		/// <param name="beginValue">The beginning value to range.</param>
		/// <param name="unitsFrom">How many units are used between the beginning/ending values (for instance, if estimating the amount of days, and units from 30, this would mean groups of 30 day periods).</param>
		/// <param name="endValue">The ending value of the range.</param>
		/// <returns></returns>
		protected abstract int CalculateSeriesCount(T beginValue, U unitsFrom, T endValue);
	}
}