using System;
using System.Collections.Generic;


namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents a repository of lookup values.
	/// </summary>
	public interface ILookupRepository
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the repository.
		/// </summary>
		string Name
		{
			get;
			set;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets all of the values within the supplied criteria.
		/// </summary>
		/// <param name="criteria">The criteria.</param>
		/// <returns>The collection of lookups.</returns>
		LookupCollection GetAllValues(LookupCriteria criteria);

		#endregion
	}
}
