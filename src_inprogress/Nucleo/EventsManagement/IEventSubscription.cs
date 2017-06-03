using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents an event subscription.
	/// </summary>
	public interface IEventSubscription
	{
		/// <summary>
		/// Gets the name of the event.
		/// </summary>
		string Name { get; }
	}
}
