using System;
using System.Collections.Generic;

using Nucleo.Configuration;
using Nucleo.Lookups.Configuration;


namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents the lookup manager that's used to wrap the lookup repository.
	/// </summary>
	public class LookupManager
	{
		private ILookupCache _cache = null;



		#region " Constructors "

		private LookupManager() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates a new instance of the lookup manager.
		/// </summary>
		/// <returns>The lookup manager that was created.</returns>
		public static LookupManager Create()
		{
			LookupManager manager = new LookupManager();
			LookupRepositoriesSection section = LookupRepositoriesSection.Instance;

			if (section == null || string.IsNullOrEmpty(section.CacheTypeName))
				return manager;

			manager._cache = (ILookupCache)Activator.CreateInstance(Type.GetType(section.CacheTypeName));
			return manager;
		}

		/// <summary>
		/// Gets a lookup, by cross referencing the lookup name against the definition in the configuration file.
		/// </summary>
		/// <param name="lookup">The lookup to find.</param>
		/// <returns>The repository that matches the lookup name.</returns>
		public ILookupRepository GetLookupRepository(string lookup)
		{
			if (string.IsNullOrEmpty(lookup))
				throw new ArgumentNullException("lookup");

			LookupRepositoriesSection section = LookupRepositoriesSection.Instance;
			NameTypeElement config = section.Mappings[lookup];

			if (config == null)
				return null;

			ILookupRepository repository = ActivatorLoader.LoadType<ILookupRepository>(config);
			if (repository != null)
				repository.Name = lookup;

			return repository;
		}

		#endregion
	}
}
