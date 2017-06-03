using System;
using System.Collections;
using System.Linq;


namespace Nucleo.Orm.Discovery
{
	/// <summary>
	/// Represents the discovery strategy to find a unit of work.
	/// </summary>
	public interface IUnitOfWorkDiscoveryStrategy
	{
		/// <summary>
		/// Locates a unit of work using the associated discovery options.
		/// </summary>
		/// <param name="options">The options to use when locating a unit of work.</param>
		/// <returns>The found unit of work.</returns>
		IUnitOfWork LocateUnitOfWork(UnitOfWorkDiscoveryOptions options);
	}
}
