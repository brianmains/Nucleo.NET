using System;

using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the subscriber of an event message submitted through the <see cref="EventRegistry"/> component.
	/// </summary>
	public interface IEventSubscriber
	{
		/// <summary>
		/// Receives the event details that was recently published.
		/// </summary>
		/// <param name="eventDetails">The published event details.</param>
		void Receive(PublishedEventDetails eventDetails);
	}
}
