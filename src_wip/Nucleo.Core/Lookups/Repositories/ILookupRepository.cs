using System;
using System.Collections.Generic;


namespace Nucleo.Lookups.Repositories
{
	/// <summary>
	/// Represents a repository of lookup values.
	/// </summary>
	public interface ILookupRepository
	{
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
