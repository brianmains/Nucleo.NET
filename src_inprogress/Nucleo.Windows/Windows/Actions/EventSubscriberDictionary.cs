using System;
using System.Collections.Generic;

using Nucleo.Collections;


namespace Nucleo.Windows.Actions
{
	public class EventSubscriberDictionary
	{
		private SimpleCollection<EventSubscriber> _subscribers = null;



		#region " Properties "

		private SimpleCollection<EventSubscriber> Subscribers
		{
			get
			{
				if (_subscribers == null)
					_subscribers = new SimpleCollection<EventSubscriber>();
				return _subscribers;
			}
		}

		public int SubscriberCount
		{
			get { return this.Subscribers.Count; }
		}

		#endregion



		#region " Constructors "

		public EventSubscriberDictionary() { }

		#endregion



		#region " Methods "

		public void AddSubscriber(EventSubscriber subscriber)
		{
			if (subscriber == null)
				throw new ArgumentNullException("subscriber");

			this.Subscribers.Add(subscriber);
		}

		#endregion
	}
}
