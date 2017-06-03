using System;
using Nucleo.Providers;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the provider for the event schedule.
	/// </summary>
	public abstract class EventScheduleProvider : ProviderBase
	{
		/// <summary>
		/// Adds an event to the underlying data source.
		/// </summary>
		/// <param name="info">The information of the event to save.</param>
		public abstract void AddEvent(EventInformation info);

		/// <summary>
		/// Deletes an event from the underlying data source.
		/// </summary>
		/// <param name="info">The event to delete.</param>
		public abstract void DeleteEvent(EventInformation info);

		/// <summary>
		/// Gets events that are within a specified range.
		/// </summary>
		/// <param name="minDate">The start of the events range.</param>
		/// <param name="maxDate">The end of the events range.</param>
		/// <returns>The collection of events.</returns>
		public abstract EventInformationCollection GetEventsForRange(DateTime minDate, DateTime maxDate);

		/// <summary>
		/// Updates an event from the underlying data source.
		/// </summary>
		/// <param name="info">The event to update.</param>
		public abstract void UpdateEvent(EventInformation info);
	}


	/// <summary>
	/// Represents the collection of event schedule providers.
	/// </summary>
	public class EventScheduleProviderCollection : ProviderCollection<EventScheduleProvider> { }
}
