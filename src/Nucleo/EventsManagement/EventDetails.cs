using System;
using System.Collections.Generic;

using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	internal class EventDetails
	{
		private Action<PublishedEventDetails> _action = null;
		private IListenerCriteria _criteria = null;
		private IEventSubscriber _receiver = null;



		#region " Properties "

		public Action<PublishedEventDetails> Action
		{
			get { return _action; }
			set { _action = value; }
		}

		public IListenerCriteria Criteria
		{
			get { return _criteria; }
			set { _criteria = value; }
		}

		public IEventSubscriber Receiver
		{
			get { return _receiver; }
			set { _receiver = value; }
		}

		#endregion



		#region " Constructors "

		public EventDetails(IListenerCriteria criteria, Action<PublishedEventDetails> action)
		{
			_criteria = criteria;
			_action = action;
		}

		public EventDetails(IListenerCriteria criteria, IEventSubscriber receiver)
		{
			_criteria = criteria;
			_receiver = receiver;
		}

		#endregion
	}
}
