using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Providers
{
	/// <summary>
	/// Represents a collection of providers.
	/// </summary>
	public interface IProviderCollection
	{
		/// <summary>
		/// Adds a provider to the collection.
		/// </summary>
		/// <param name="provider">The provider to add.</param>
		void Add(IProvider provider);

		/// <summary>
		/// Removes a provider to the collection.
		/// </summary>
		/// <param name="provider">The provider to remove.</param>
		void Remove(IProvider provider);
	}
}
