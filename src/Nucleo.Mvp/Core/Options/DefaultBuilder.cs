using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Presentation.Caching;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;


namespace Nucleo.Core.Options
{
	public static class DefaultBuilder
	{
		#region " Methods "

		public static FrameworkConfiguration Create()
		{
			return new FrameworkConfiguration
			{
				Creator = new DefaultPresenterCreator(),
				DiscoveryStrategy = new DefaultPresentationDiscoveryStrategy(),
				Cache = null
			};
		}

		#endregion
	}
}
