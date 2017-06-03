using System;
using System.Linq;
using System.Reflection;

using Nucleo.Views;


namespace Nucleo.Presentation.Discovery
{
	/// <summary>
	/// Represents the presentation discovery strategy that uses the static view registrations.
	/// </summary>
	public class ViewRegistrationPresentationDiscoveryStrategy : IPresentationDiscoveryStrategy
	{
		public Type FindPresenterType(PresenterDiscoveryOptions options)
		{
			var contract = options.View.GetType().GetInterfaces().FirstOrDefault(i => !i.Name.Contains("IView") && typeof(IView).IsAssignableFrom(i));
			return ViewRegistration.Get(contract).PresenterType;
		}
	}
}
