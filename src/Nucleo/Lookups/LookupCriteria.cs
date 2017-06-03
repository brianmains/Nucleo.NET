using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents criteria to filter the lookup by.
	/// </summary>
	/// <example>
	/// var criteria = new LookupCriteria(DateTime.Now);
	/// var values = lookupRepository.GetAllValues(criteria);
	/// </example>
	public class LookupCriteria
	{
		private DateTime? _timeframeDate = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the general timeframe to restrict the input by.
		/// </summary>
		public DateTime? TimeframeDate
		{
			get { return _timeframeDate; }
			set { _timeframeDate = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates empty lookup criteria.
		/// </summary>
		public LookupCriteria() { }

		/// <summary>
		/// Creates the lookup criteria.
		/// </summary>
		/// <param name="timeframeDate">The general timeframe.</param>
		public LookupCriteria(DateTime? timeframeDate)
		{
			_timeframeDate = timeframeDate;
		}

		#endregion
	}
}
