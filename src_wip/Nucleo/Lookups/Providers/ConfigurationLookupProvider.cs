using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Lookups.Repositories;
using Nucleo.Lookups.Configuration;
using Nucleo.Lookups.Identification;


namespace Nucleo.Lookups.Providers
{
	public class ConfigurationLookupProvider : ILookupProvider
	{
		public ILookupRepository GetRepository(ILookupIdentifier id)
		{
			var section = LookupRepositoriesSection.Instance;
			var mapping = section.Mappings[((NameLookupIdentifier)id).Name];

			if (mapping == null)
				return null;

			var type = Type.GetType(mapping.Type);
			if (type == null)
				return null;

			var repos = (ILookupRepository)Activator.CreateInstance(type);

			return repos;
		}

		public bool SupportsIdentifier(ILookupIdentifier id)
		{
			return (id is NameLookupIdentifier);
		}
	}
}
