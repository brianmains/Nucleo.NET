using System;
using System.Collections.Generic;

using Nucleo.Collections;


namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents the collection of lookups.
	/// </summary>
	public class LookupCollection : SimpleCollection<ILookup>
	{
		public LookupCollection() { }

		public LookupCollection(IEnumerable<ILookup> lookups)
		{
			foreach (var lookup in lookups)
				this.Add(lookup);
		}
	}
}
