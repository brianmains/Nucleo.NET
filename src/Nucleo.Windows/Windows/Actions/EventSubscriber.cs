using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.Actions
{
	public class EventSubscriber
	{
		private EventAction _action = null;
		private IEventSubscribingObject _subscribingObject = null;



		#region " Properties "

		/// <summary>
		/// Gets the action being listened to.
		/// </summary>
		public EventAction Action
		{
			get { return _action; }
		}

		/// <summary>
		/// Gets the object subscribing to the notification.
		/// </summary>
		public IEventSubscribingObject SubscribingObject
		{
			get { return _subscribingObject; }
		}

		#endregion



		#region " Constructors "

		private EventSubscriber() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates a new instance of the event subscription.
		/// </summary>
		/// <param name="action">The action to subscribe to.</param>
		/// <param name="subscribingObject">The object that's subscribing for a notification.</param>
		/// <returns>An instance of the subscription.</returns>
		public static EventSubscriber CreateSubscription(EventAction action, IEventSubscribingObject subscribingObject)
		{
			if (action == null)
				throw new ArgumentNullException("action");
			if (subscribingObject == null)
				throw new ArgumentNullException("subscribingObject");

			EventSubscriber subscriber = new EventSubscriber();
			subscriber._action = action;
			subscriber._subscribingObject = subscribingObject;

			return subscriber;
		}

		#endregion
	}
}
