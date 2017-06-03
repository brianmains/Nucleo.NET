using System;

using Nucleo.Views;


namespace Nucleo.Presentation.Discovery
{
	public interface IPresentationDiscoveryStrategy
	{
		Type FindPresenterType(DiscoveryOptions options);
	}
}
