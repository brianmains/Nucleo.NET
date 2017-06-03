using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Presentation;
using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Extensions for the <see cref="EventsRegistry"/> component.
	/// </summary>
	public static class EventsRegistryExtensions
	{
		/// <summary>
		/// Sends an event through the registry using the given presenter.
		/// </summary>
		/// <param name="registry">The registry.</param>
		/// <param name="sourcePresenter">The presenter that's the source of the event.</param>
		/// <param name="details">The details of the event.</param>
		/// <param name="direction">The direction of the event.</param>
		public static void SendEvent(this EventsRegistry registry, IPresenter sourcePresenter, PublishedEventDetails details, EventDirection direction)
		{
			if (direction == EventDirection.Bubble)
				SendEventBubble(sourcePresenter, details);
			else if (direction == EventDirection.Tunnel)
				SendEventTunnel(sourcePresenter, details);
		}

		private static void SendEventBubble(IPresenter sourcePresenter, PublishedEventDetails details)
		{
			var currentPresenter = sourcePresenter.Parent;

			while (currentPresenter != null)
			{
				if (currentPresenter is IEventSubscriber)
					((IEventSubscriber)currentPresenter).Receive(details);

				currentPresenter = currentPresenter.Parent;
			}
		}

		private static void SendEventTunnel(IPresenter sourcePresenter, PublishedEventDetails details)
		{
			foreach (var childPresenter in sourcePresenter.Subpresenters)
			{
				if (childPresenter is IEventSubscriber)
					((IEventSubscriber)childPresenter).Receive(details);

				SendEventTunnel(childPresenter, details);
			}
		}
	}
}
