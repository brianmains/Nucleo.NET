using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents a lookup repository that pulls the results from the repository from cache.
	/// </summary>
	public class CacheLookupRepository : ILookupRepository
	{
		private ILookupCache _cache = null;
		private ILookupRepository _baseRepository = null;
		private string _name = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the lookup.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		#endregion



		#region " Constructors "

		public CacheLookupRepository(ILookupCache cache, ILookupRepository baseRepository)
		{
			_cache = cache;
			_baseRepository = baseRepository;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets all of the values from the lookup collection.
		/// </summary>
		/// <param name="criteria">The criteria of the lookup.</param>
		/// <returns>THe collection of lookup values.</returns>
		public LookupCollection GetAllValues(LookupCriteria criteria)
		{
			LookupCollection values = _cache.LoadFromCache(this.Name, criteria);
			if (values != null)
				return values;

			return _baseRepository.GetAllValues(criteria);
		}

		#endregion
	}
}
