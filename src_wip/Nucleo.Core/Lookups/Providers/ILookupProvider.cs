using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Lookups.Identification;
using Nucleo.Lookups.Repositories;


namespace Nucleo.Lookups.Providers
{
	/// <summary>
	/// Represents a lookup provider, which is a provider that is responsible for instanting a repository to return lookup data.
	/// </summary>
	public interface ILookupProvider
	{
		/// <summary>
		/// Gets the repository using the matching identifier; this assumes <see cref="SupportsIdentifier"/> has been called first.
		/// </summary>
		/// <param name="id">The ID to check support for.</param>
		/// <returns>The lookup repository.</returns>
		ILookupRepository GetRepository(ILookupIdentifier id);

		/// <summary>
		/// Checks whether the matching ID is supported by the provider; if not, it can't corectly instantiate a repository.  Therefore, this must be called before calling <see cref="GetRepository"/>.
		/// </summary>
		/// <param name="id">The ID to check support for.</param>
		/// <returns>Whether the identifier is supported.</returns>
		bool SupportsIdentifier(ILookupIdentifier id);
	}
}
