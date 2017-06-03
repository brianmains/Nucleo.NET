using System;
using System.Collections.Generic;

using Nucleo.Lookups.Identification;


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
		#region " Properties "

		/// <summary>
		/// Gets or sets the identifier of the repository.
		/// </summary>
		public ILookupIdentifier Identifier
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the general timeframe to restrict the input by.
		/// </summary>
		public DateTime? TimeframeDate
		{
			get;
			set;
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
		public LookupCriteria(ILookupIdentifier id, DateTime? timeframeDate)
		{
			this.Identifier = id;
			this.TimeframeDate = timeframeDate;
		}

		#endregion
	}
}
