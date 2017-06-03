using System;


namespace Nucleo.EventsManagement.Listeners
{
	public class EventListenerCriteria : IListenerCriteria
	{
		private IEvent _eventInfo = null;
		private object _source = null;



		#region " Properties "

		/// <summary>
		/// Gets the instance of the event.
		/// </summary>
		public IEvent Event
		{
			get { return _eventInfo; }
		}

		/// <summary>
		/// Gets an instance of the source.
		/// </summary>
		public object Source
		{
			get { return _source; }
		}

		#endregion



		#region " Constructors "

		public EventListenerCriteria(IEvent eventInfo)
		{
			if (eventInfo == null)
				throw new ArgumentNullException("eventInfo");

			_eventInfo = eventInfo;
		}

		public EventListenerCriteria(IEvent eventInfo, object source)
			: this(eventInfo)
		{
			if (source == null)
				throw new ArgumentNullException("source");

			_source = source;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets whether the current listener is a match with another criteria listener.
		/// </summary>
		/// <param name="criteria">The criteria to evaluate.</param>
		/// <returns>Whether a match occurs.</returns>
		public virtual bool IsMatch(IListenerCriteria criteria)
		{
			if (criteria is EventListenerCriteria)
			{
				if (((EventListenerCriteria)criteria).Event.Name == this.Event.Name)
				{
					if (this.Source == null || Object.Equals(this.Source, ((EventListenerCriteria)criteria).Source))
					return true;
				}
			}
			else if (criteria is NameIdentifierListenerCriteria)
			{
				return (((NameIdentifierListenerCriteria)criteria).Identifier == this.Event.Name);
			}
			else if (criteria is EntityTypeListenerCriteria)
			{
				return this.Event.GetType().IsAssignableFrom(((EntityTypeListenerCriteria)criteria).EntityType);
			}

			return false;
		}

		public override string ToString()
		{
			return "Event " + ((_eventInfo != null) ? _eventInfo.Name : "Unknown");
		}

		#endregion
	}
}
