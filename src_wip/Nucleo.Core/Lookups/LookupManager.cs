using System;
using System.Linq;
using System.Collections.Generic;

using Nucleo.Lookups.Identification;
using Nucleo.Lookups.Providers;
using Nucleo.Lookups.Repositories;


namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents the lookup manager that's used to wrap the lookup repository.
	/// </summary>
	public class LookupManager
	{
		private LookupProviderCollection _providers = null;



		#region " Properties "

		/// <summary>
		/// Gets the number of providers.
		/// </summary>
		public int ProviderCount
		{
			get { return (_providers != null) ? _providers.Count : 0; }
		}

		private LookupProviderCollection Providers
		{
			get
			{
				if (_providers == null)
					_providers = new LookupProviderCollection();
				return _providers;
			}
		}

		#endregion



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
			return new LookupManager();
		}

		/// <summary>
		/// Gets a lookup, by cross referencing the lookup name against the definition in the configuration file.
		/// </summary>
		/// <param name="lookup">The lookup to find.</param>
		/// <returns>The repository that matches the lookup name.</returns>
		public ILookupRepository GetLookupRepository(ILookupIdentifier id)
		{
			if (id == null)
				throw new ArgumentNullException("id");

			var providers = this.Providers.Where(i => i.SupportsIdentifier(id));
			foreach (var provider in providers)
			{
				var repository = provider.GetRepository(id);
				if (repository != null)
					return repository;
			}

			return null;
		}

		/// <summary>
		/// Registers a provider.
		/// </summary>
		/// <param name="provider">A provider to register.</param>
		/// <exception cref="ArgumentNullException">Thrown when the provider is null.</exception>
		public void Register(ILookupProvider provider)
		{
			if (provider == null)
				throw new ArgumentNullException("provider");

			this.Providers.Add(provider);
		}

		#endregion
	}
}
