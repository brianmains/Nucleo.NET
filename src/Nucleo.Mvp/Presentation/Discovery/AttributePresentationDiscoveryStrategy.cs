using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Nucleo.Views;


namespace Nucleo.Presentation.Discovery
{
	public class AttributePresentationDiscoveryStrategy : IPresentationDiscoveryStrategy
	{
		#region " Methods "

		public Type FindPresenterType(DiscoveryOptions options)
		{
			PresenterBindingAttribute presenterBinding = options.View.GetType().GetCustomAttribute<PresenterBindingAttribute>(true);
			if (presenterBinding == null)
				return null;

			return presenterBinding.GetPresenterType();
		}

		#endregion
	}
}
