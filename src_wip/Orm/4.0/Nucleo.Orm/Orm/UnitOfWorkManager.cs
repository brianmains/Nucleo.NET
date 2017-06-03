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
	/// Represents the manager that can serve up unit of work implementations.
	/// </summary>
	/// <remarks>Instantiate using one of the available Create() methods.</remarks>
	public class UnitOfWorkManager
	{
		private IUnitOfWorkCaching _caching = null;
		private IUnitOfWorkCreator _creator = null;
		private IUnitOfWorkDiscoveryStrategy _discoveryStrategy = null;



		#region " Constructors "

		private UnitOfWorkManager() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates a new instance of the unit of work manager, using the configuration section information from <see cref="UnitOfWorkSection"/>.
		/// </summary>
		/// <returns>The manager instance instantiated from the configuration file.</returns>
		/// <exception cref="System.Configuration.ConfigurationErrorsException" />
		public static UnitOfWorkManager Create()
		{
			UnitOfWorkSection section = UnitOfWorkSection.Instance;
			if (section == null)
				throw new System.Configuration.ConfigurationErrorsException("The unit of work configuration section has not yet been established.");

			UnitOfWorkManager mgr = new UnitOfWorkManager();
			mgr._caching = (IUnitOfWorkCaching)mgr.LoadType(() => section.CacheTypeName, "cache");
			mgr._creator = (IUnitOfWorkCreator)mgr.LoadType(() => section.CreatorTypeName, "creator");
			mgr._discoveryStrategy = (IUnitOfWorkDiscoveryStrategy)mgr.LoadType(() => section.DiscoveryStrategyTypeName, "discovery strategy");

			return mgr;
		}

		/// <summary>
		/// Creates a new instance of the unit of work manager using the specified discovery strategy, unit of work creator, and cacher.
		/// </summary>
		/// <param name="discoveryStrategy">The discovery strategy to use.</param>
		/// <param name="creator">The creator instance.</param>
		/// <param name="cacher">The cacher object.</param>
		/// <returns>The manager instance instantiated.</returns>
		public static UnitOfWorkManager Create(UnitOfWorkManagerOptions options)
		{
			if (options == null)
				throw new ArgumentNullException("options");

			return new UnitOfWorkManager
			{
				_discoveryStrategy = options.DiscoveryStrategy,
				_creator = options.Creator,
				_caching = options.Caching
			};
		}

		private object LoadType(Func< string> selector, string entity)
		{
			string value = selector();
			if (string.IsNullOrEmpty(value))
				return null;

			Type cacheType = Type.GetType(value);
			if (cacheType == null)
				throw new NullReferenceException("The " + entity + " type does not exist: " + value);

			return Activator.CreateInstance(cacheType);
		}

		/// <summary>
		/// Locates a unit of work.
		/// </summary>
		/// <param name="name">The name to use to find the unit of work.</param>
		/// <returns>The unit of work instance.</returns>
		/// <exception cref="ArgumentNullException">Thrown when name is null or empty.</exception>
		public IUnitOfWork LocateUnitOfWork(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			if (_caching != null)
			{
				IUnitOfWork cachedWork = _caching.GetUnitOfWork(name);
				if (cachedWork != null)
					return cachedWork;
			}

			var results = _discoveryStrategy.LocateUnitOfWork(new UnitOfWorkDiscoveryOptions
			{
				Name = name
			});

            if (results == null || results.UnitOfWorkType == null)
                return null;

            IUnitOfWork work = (_creator != null) 
                ? _creator.Create(results.UnitOfWorkType, results.Attributes)
                : (Activator.CreateInstance(results.UnitOfWorkType) as IUnitOfWork);

			if (_caching != null && work != null)
				_caching.SaveUnitOfWork(name, work);

			return work;
		}

		#endregion
	}
}
