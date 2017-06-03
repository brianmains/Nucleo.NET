using System;
using System.Collections.Generic;

using Nucleo.Lookups.Configuration;
using Nucleo.Lookups.Identification;


namespace Nucleo.Lookups.Repositories
{
	/// <summary>
	/// Represents the configuration lookup repository that pulls lookup values from the <see cref="Nucleo.Web.Lookups.Configuration.LookupRepositoriesSection">LookupRepositoriesSection configuration section</see>.
	/// </summary>
	public class ConfigurationLookupRepository : ILookupRepository
	{
		#region " Methods "

		/// <summary>
		/// Gets all of the values for the lookup.
		/// </summary>
		/// <param name="criteria">The criteria.</param>
		/// <returns>The collection of lookups from configuration.</returns>
		public LookupCollection GetAllValues(LookupCriteria criteria)
		{
			

			LookupRepositoriesSection section = LookupRepositoriesSection.Instance;
			if (section == null)
				return null;
			if (!(criteria.Identifier is NameLookupIdentifier))
				throw new InvalidOperationException();

			string name = ((NameLookupIdentifier)criteria.Identifier).Name;
			LookupCollection lookups = new LookupCollection();
			LookupGroupElement group = section.Groups[name];
			DateTime? relativeDate = (criteria != null) ? criteria.TimeframeDate : default(DateTime?);

			//Load the group values that match.
			foreach (LookupElement lookupElement in group.Values)
			{
				//Ensure within the range
				if (relativeDate == null || (relativeDate.Value >= lookupElement.EffectiveDate && relativeDate.Value <= lookupElement.EndDate))
					lookups.Add(new Lookup(lookupElement.Name, lookupElement.Value, lookupElement.RepresentationCode));
			}

			return lookups;
		}

		#endregion
	}
}
