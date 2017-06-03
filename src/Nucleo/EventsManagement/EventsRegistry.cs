using System;
using System.Collections.Generic;

using Nucleo.EventArguments;
using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents a registry of event subscriptions.
	/// </summary>
	public class EventsRegistry : IDisposable
	{
		private List<SubscriptionEventDetails> _items = null;



		#region " Properties "

		private List<SubscriptionEventDetails> Items
		{
			get 
			{
				if (_items == null)
					_items = new List<SubscriptionEventDetails>();
				return _items;
			}
		}

		/// <summary>
		/// Gets the number of subscriptions in the event registry.
		/// </summary>
		public int SubscriptionCount
		{
			get { return this.Items.Count; }
		}

		#endregion



		#region " Methods "

		public void Dispose()
		{
			this.Dispose(true);
		}

		public bool Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Items.Clear();
				_items = null;

				return true;
			}

			return false;
		}

		/// <summary>
		/// Publishes a message using the specified criteria and attributes.
		/// </summary>
		/// <param name="criteria">The criteria used to perform the publish.</param>
		/// <param name="attributes">The collection of attributes to pass along.</param>
		public void Publish(object source, IListenerCriteria criteria, IDictionary<string, object> attributes)
		{
			PublishedEventDetails details = new PublishedEventDetails(source, criteria, attributes);
			this.Publish(details);
		}

		/// <summary>
		/// Publishes a message with the specified published details.
		/// </summary>
		/// <param name="publishedDetails">The published details for the subscription.</param>
		public void Publish(PublishedEventDetails publishedDetails)
		{
			if (publishedDetails == null)
				throw new ArgumentNullException("publishedDetails");

			for (int index = 0, len = this.Items.Count; index < len; index++)
			{
				SubscriptionEventDetails details = this.Items[index];
				if (details.Criteria.IsMatch(publishedDetails.Criteria))
					this.PublishDetails(details, publishedDetails);
			}
		}

		public void Publish(IEnumerable<PublishedEventDetails> publishedDetails)
		{
			if (publishedDetails == null)
				throw new ArgumentNullException("publishedDetails");

			for (int index = 0, len = this.Items.Count; index < len; index++)
			{
				SubscriptionEventDetails details = this.Items[index];

				foreach (PublishedEventDetails publishDetails in publishedDetails)
				{
					if (details.Criteria.IsMatch(publishDetails.Criteria))
						this.PublishDetails(details, publishDetails);
				}
			}
		}

		private void PublishDetails(SubscriptionEventDetails details, PublishedEventDetails publishedDetails)
		{
			if (details.Action != null)
				details.Action(publishedDetails);
			else
				details.Receiver.Receive(publishedDetails);
		}

		/// <summary>
		/// Subscribes to an event using the criteria and a receiver component implement <see cref="IEventSubscriber"/>.
		/// </summary>
		/// <param name="criteria">The criteria to subscribe to.</param>
		/// <param name="receiver">The receiver instance.</param>
		public void Subscribe(IListenerCriteria criteria, IEventSubscriber receiver)
		{
			if (criteria == null)
				throw new ArgumentNullException("criteria");
			if (receiver == null)
				throw new ArgumentNullException("receiver");

			this.Items.Add(new SubscriptionEventDetails(criteria, receiver));
		}

		public void Subscribe(IListenerCriteria criteria, Action<PublishedEventDetails> action)
		{
			if (criteria == null)
				throw new ArgumentNullException("criteria");
			if (action == null)
				throw new ArgumentNullException("action");

			this.Items.Add(new SubscriptionEventDetails(criteria, action));
		}

		public void Subscribe(SubscriptionEventDetails details)
		{
			if (details == null)
				throw new ArgumentNullException("details");

			this.Items.Add(details);
		}

		public void Subscribe(IEnumerable<SubscriptionEventDetails> details)
		{
			if (details == null)
				throw new ArgumentNullException("details");

			foreach (SubscriptionEventDetails detail in details)
				this.Items.Add(detail);
		}

		public void Subscribe(IEnumerable<IListenerCriteria> criterias, Action<PublishedEventDetails> action)
		{
			if (criterias == null)
				throw new ArgumentNullException("criterias");
			if (action == null)
				throw new ArgumentNullException("action");

			foreach (IListenerCriteria criteria in criterias)
				this.Items.Add(new SubscriptionEventDetails(criteria, action));
		}

		public void Subscribe(IEnumerable<IListenerCriteria> criterias, IEventSubscriber receiver)
		{
			if (criterias == null)
				throw new ArgumentNullException("criterias");
			if (receiver == null)
				throw new ArgumentNullException("receiver");

			foreach (IListenerCriteria criteria in criterias)
				this.Items.Add(new SubscriptionEventDetails(criteria, receiver));
		}

		///// <summary>
		///// Adds a listener to an event.  If the event doesn't exist, the event is added too.
		///// </summary>
		///// <param name="subscription">The subscription to add a receiver to, or even to add itself.</param>
		///// <param name="receiver">The receiver for the event.</param>
		//public void AddEventListener(IEventSubscription subscription, IEventReceiver receiver)
		//{
		//    if (subscription == null)
		//        throw new ArgumentNullException("subscription");
		//    if (receiver == null)
		//        throw new ArgumentNullException("receiver");

		//    if (!this.Receivers.ContainsKey(subscription))
		//        this.Receivers.Add(subscription, new List<IEventReceiver> { receiver });
		//    else
		//        this.Receivers[subscription].Add(receiver);				
		//}

		//public void AddEventListenerUsing(Type objectTypeWithAttribute, IEventReceiver receiver)
		//{
		//    this.AddEventListenerUsing(objectTypeWithAttribute, null, receiver);
		//}

		//public void AddEventListenerUsing(Type objectTypeWithAttribute, string eventName, IEventReceiver receiver)
		//{
		//    if (objectTypeWithAttribute == null)
		//        throw new ArgumentNullException("objectTypeWithAttribute");
		//    if (receiver == null)
		//        throw new ArgumentNullException("receiver");

		//    object[] attributes = objectTypeWithAttribute.GetCustomAttributes(typeof(EventSubscriptionAttribute), true);

		//    foreach (EventSubscriptionAttribute attribute in attributes)
		//    {
		//        if (eventName == null || string.Compare(attribute.Name, eventName, StringComparison.InvariantCultureIgnoreCase) == 0)
		//            this.AddEventListener(attribute, receiver);
		//    }
		//}

		///// <summary>
		///// Fires an event, finding all of the receivers and triggering their callback.
		///// </summary>
		///// <param name="subscription">The subscription to trigger a notification for.</param>
		///// <param name="source">The source of the event.</param>
		//public void FireEvent(IEventSubscription subscription, object source)
		//{
		//    if (subscription == null)
		//        throw new ArgumentNullException("subscription");
		//    if (source == null)
		//        throw new ArgumentNullException("source");

		//    if (this.Receivers.ContainsKey(subscription))
		//    {
		//        List<IEventReceiver> receivers = this.Receivers[subscription];

		//        for (int index = 0, len = receivers.Count; index < len; index++)
		//            receivers[index].ReceiveEventNotification(subscription, source);

		//        this.OnEventFired(new FiredEventEventArgs(subscription));
		//    }
		//}

		//public void FireEventUsing(object sourceWithAttribute, string eventName)
		//{
		//    if (sourceWithAttribute == null)
		//        throw new ArgumentNullException("sourceWithAttribute");
		//    if (string.IsNullOrEmpty(eventName))
		//        throw new ArgumentNullException("eventName");

		//    foreach (IEventSubscription subscription in this.Receivers.Keys)
		//    {
		//        if (!(subscription is EventSubscriptionAttribute))
		//            continue;
		//        if (string.Compare(subscription.Name, eventName, StringComparison.InvariantCultureIgnoreCase) != 0)
		//            continue;

		//        this.FireEvent(subscription, sourceWithAttribute);
		//        this.OnEventFired(new FiredEventEventArgs(subscription));
		//        return;
		//    }
		//}

		//protected virtual void OnEventFired(FiredEventEventArgs e)
		//{
		//    if (EventFired != null)
		//        EventFired(this, e);
		//}

		//public bool RemoveAllEventListeners(IEventSubscription subscription)
		//{
		//    return this.Receivers.Remove(subscription);
		//}

		//public bool RemoveAllEventListeners(IEventReceiver receiver)
		//{
		//    foreach (KeyValuePair<IEventSubscription, List<IEventReceiver>> pair in this.Receivers)
		//    {
		//        if (pair.Value != null && pair.Value.Contains(receiver))
		//            pair.Value.Remove(receiver);
		//    }

		//    return true;
		//}

		//public bool RemoveEventListener(IEventSubscription subscription, IEventReceiver receiver)
		//{
		//    if (!this.Receivers.ContainsKey(subscription))
		//        return false;

		//    List<IEventReceiver> receivers = this.Receivers[subscription] as List<IEventReceiver>;
		//    if (receivers == null)
		//        return false;

		//    receivers.Remove(receiver);
		//    this.Receivers[subscription] = receivers;
		//    return true;
		//}

		#endregion
	}
}
