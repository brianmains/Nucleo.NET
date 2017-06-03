using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the receiver of the event.
	/// </summary>
	public interface IEventReceiver
	{
		#region " Methods "

		/// <summary>
		/// Receives an event notification from the event registry.
		/// </summary>
		/// <param name="subscription">The subscription information.</param>
		/// <param name="source">The source of the event.</param>
		void ReceiveEventNotification(IEventSubscription subscription, object source);

		#endregion
	}
}
