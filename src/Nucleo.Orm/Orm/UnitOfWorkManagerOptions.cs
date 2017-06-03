using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Orm.Caching;
using Nucleo.Orm.Configuration;
using Nucleo.Orm.Creation;
using Nucleo.Orm.Discovery;


namespace Nucleo.Orm
{
	/// <summary>
	/// Represents the options for the manager of the unit of work.
	/// </summary>
	public class UnitOfWorkManagerOptions
	{
		/// <summary>
		/// Gets or sets the cache.
		/// </summary>
		public IUnitOfWorkCaching Caching
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the creator.
		/// </summary>
		public IUnitOfWorkCreator Creator
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the discovery strategy.
		/// </summary>
		public IUnitOfWorkDiscoveryStrategy DiscoveryStrategy
		{
			get;
			set;
		}
	}
}
