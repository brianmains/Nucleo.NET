using System;
using System.Collections.Generic;
using System.Linq;
using Nucleo.Views;


namespace Nucleo.Presentation.Discovery
{
	public class DefaultPresentationDiscoveryStrategy : IPresentationDiscoveryStrategy
	{

		#region IPresentationDiscoveryStrategy Members

		public Type FindPresenterType(DiscoveryOptions options)
		{
			Type presenterType = (new AttributePresentationDiscoveryStrategy()).FindPresenterType(options);
			if (presenterType != null)
				return presenterType;

#if SILVERLIGHT
#else
			presenterType = (new ConfigurationPresentationDiscoveryStrategy()).FindPresenterType(options);
			if (presenterType != null)
				return presenterType;
#endif

			return null;
		}

		#endregion
	}
}
