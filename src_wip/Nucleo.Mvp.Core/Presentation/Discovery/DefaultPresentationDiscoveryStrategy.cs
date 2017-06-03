using System;
using System.Collections.Generic;
using System.Linq;
using Nucleo.Views;


namespace Nucleo.Presentation.Discovery
{
	public class DefaultPresentationDiscoveryStrategy : IPresentationDiscoveryStrategy
	{

		#region IPresentationDiscoveryStrategy Members

		public Type FindPresenterType(PresenterDiscoveryOptions options)
		{
			Type presenterType = (new AttributePresentationDiscoveryStrategy()).FindPresenterType(options);
			if (presenterType != null)
				return presenterType;

			return null;
		}

		#endregion
	}
}
