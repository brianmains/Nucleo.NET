using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Lookups
{
	public interface ILookupCache
	{
		/// <summary>
		/// Looks within the cache; attempts to load.
		/// </summary>
		/// <param name="lookupName">The name of the lookup.</param>
		/// <param name="criteria">The criteria used to load with.</param>
		/// <returns></returns>
		LookupCollection LoadFromCache(string lookupName, LookupCriteria criteria);

		/// <summary>
		/// Saves the lookup entries within the cache.
		/// </summary>
		/// <param name="lookupName">The name of the lookup.</param>
		/// <param name="criteria">The criteria used to save with.</param>
		/// <param name="values">The values to save.</param>
		void SaveLookups(string lookupName, LookupCriteria criteria, LookupCollection values);
	}
}
