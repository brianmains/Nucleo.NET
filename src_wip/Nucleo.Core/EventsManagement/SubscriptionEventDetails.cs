using System;
using System.Collections.Generic;

using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the details of an event that is being subscribed to.  Supports using an action as the means for receiving an event, or also uses the <see cref="IEventSubscriber"/> interface too.
	/// </summary>
	/// <example>
	/// public class SomePresenter : IPresenter&lt;SomeView>
	/// {
	///		public SomePresenter(ISomeView view) 
	///		{
	///			this.CurrentContext.EventsRegistry.Publish(new SubscriptionEventDetails(
	///				ListenerCriterion.Identifier("EventName"),
	///				(p) => { this.LoadData((int)p.Attributes["Key"]); }));
	///		}
	/// }
	/// </example>
	public class SubscriptionEventDetails : BaseEventDetails
	{
		Action<PublishedEventDetails> _action = null;
		private IEventSubscriber _receiver = null;



		#region " Properties "

		/// <summary>
		/// Gets the action that is being used to listen to the event, which takes the published details.
		/// </summary>
		/// <example>
		/// public class SomePresenter : IPresenter&lt;SomeView>
		/// {
		///		public SomePresenter(ISomeView view) 
		///		{
		///			this.CurrentContext.EventsRegistry.Publish(new SubscriptionEventDetails(
		///				ListenerCriterion.Identifier("EventName"),
		///				(p) => { this.LoadData((int)p.Attributes["Key"]); }));
		///		}
		/// }
		/// </example>
		public Action<PublishedEventDetails> Action
		{
			get { return _action; }
		}

		/// <summary>
		/// Gets the event subscriber instance that is being used to listen to the event.
		/// </summary>
		/// <example>
		/// public class SomePresenter : IPresenter&lt;SomeView>
		/// {
		///		public SomePresenter(ISomeView view) 
		///		{
		///			this.CurrentContext.EventsRegistry.Publish(new SubscriptionEventDetails(
		///				ListenerCriterion.Identifier("EventName"), eventReceiverObject));
		///		}
		/// }
		/// </example>
		public IEventSubscriber Receiver
		{
			get { return _receiver; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the subscription details using the expected listener criteria, and the event subscriber instance.
		/// </summary>
		/// <param name="criteria">The criteria being subscribed to.</param>
		/// <param name="receiver">The event subscriber.</param>
		public SubscriptionEventDetails(IListenerCriteria criteria, IEventSubscriber receiver)
			: base(criteria) 
		{
			_receiver = receiver;
		}

		/// <summary>
		/// Creates the subscription details using the expected listener criteria, and the action used to receive a subscription.
		/// </summary>
		/// <param name="criteria">The criteria being subscribed to.</param>
		/// <param name="receiver">The action that handles the event.</param>
		public SubscriptionEventDetails(IListenerCriteria criteria, Action<PublishedEventDetails> action)
			: base(criteria)
		{
			_action = action;
		}
		
		#endregion
	}
}
