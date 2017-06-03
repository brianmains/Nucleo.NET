using System;
using System.Collections.Generic;


namespace Nucleo.EventsManagement
{
	public class FakeEventScheduleProvider : EventScheduleProvider
	{
		private EventInformationCollection _events = null;



		#region " Properties "

		/// <summary>
		/// Gets the events for the schedule.
		/// </summary>
		public EventInformationCollection Events
		{
			get
			{
				if (_events == null)
					_events = new EventInformationCollection();
				return _events;
			}
		}

		#endregion



		#region " Methods "

		public override void AddEvent(EventInformation info)
		{
			this.Events.Add(info);
		}

		public override void DeleteEvent(EventInformation info)
		{
			this.Events.Remove(info);
		}

		public override EventInformationCollection GetEventsForRange(DateTime minDate, DateTime maxDate)
		{
			EventInformationCollection events = new EventInformationCollection();

			foreach (EventInformation eventInfo in this.Events)
			{
				if (eventInfo.BeginDate >= minDate && eventInfo.BeginDate < maxDate)
					events.Add(eventInfo);
				else if (eventInfo.EndDate >= minDate && eventInfo.EndDate < maxDate)
					events.Add(eventInfo);
			}

			return events;
		}

		public override void UpdateEvent(EventInformation info)
		{
			EventInformation currentEvent = null;

			foreach (EventInformation eventInfo in this.Events)
			{
				if (info.ID == eventInfo.ID)
				{
					currentEvent = eventInfo;
					break;
				}
			}

			if (currentEvent != null)
			{
				this.Events.Remove(currentEvent);
				this.Events.Add(info);
			}
		}

		#endregion
	}
}
