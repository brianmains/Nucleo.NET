using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Lookups;


namespace Nucleo.Framework.Lookups
{
	public class CountriesLookupRepository : ILookupRepository
	{
		#region ILookupRepository Members

		public string Name
		{
			get;
			set;
		}

		public LookupCollection GetAllValues(LookupCriteria criteria)
		{
			return new LookupCollection
			{
				new Lookup("United States", "1", "US"),
				new Lookup("Mexico", "2", "MX"),
				new Lookup("United Kingdom", "3", "UK"),
				new Lookup("Canada", "4", "CA")
			};
		}

		#endregion
	}
}