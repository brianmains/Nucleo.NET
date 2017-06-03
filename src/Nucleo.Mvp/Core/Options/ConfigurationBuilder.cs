using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Core.Configuration;
using Nucleo.Exceptions;
using Nucleo.Presentation.Caching;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;


namespace Nucleo.Core.Options
{
	public static class ConfigurationBuilder
	{
		#region " Methods "

		public static FrameworkConfiguration Create()
		{
			FrameworkSettingsSection section = FrameworkSettingsSection.Instance;
			IPresenterContextCache cache = null;
			IPresenterCreator creator = null;
			IPresentationDiscoveryStrategy strategy = null;

			if (section == null)
				return null;

			if (!string.IsNullOrEmpty(section.PresenterCreatorTypeName))
			{
				Type creatorType = Type.GetType(section.PresenterCreatorTypeName);
				if (creatorType == null)
					throw new NotFoundException("The type for the creator could not be found: " + section.PresenterCreatorTypeName);

				creator = (IPresenterCreator)Activator.CreateInstance(creatorType);
			}

			if (!string.IsNullOrEmpty(section.DiscoveryStrategyTypeName))
			{
				Type discoveryType = Type.GetType(section.DiscoveryStrategyTypeName);
				if (discoveryType == null)
					throw new NotFoundException("The type for the discovery strategy could not be found: " + section.DiscoveryStrategyTypeName);

				strategy = (IPresentationDiscoveryStrategy)Activator.CreateInstance(discoveryType);
			}

			if (!string.IsNullOrEmpty(section.PresenterCacheTypeName))
			{
				Type cacheType = Type.GetType(section.PresenterCacheTypeName);
				if (cacheType == null)
					throw new NotFoundException("The type for the cache could not be found: " + section.PresenterCacheTypeName);

				cache = (IPresenterContextCache)Activator.CreateInstance(cacheType);
			}

			return new FrameworkConfiguration
			{
				Cache = cache,
				Creator = creator,
				DiscoveryStrategy = strategy
			};
		}

		#endregion
	}
}
