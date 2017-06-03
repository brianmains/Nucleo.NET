using System;

using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	public interface IEventSubscriber
	{
		void Receive(PublishedEventDetails eventDetails);
	}
}
