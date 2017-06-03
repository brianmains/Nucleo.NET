using System;
using System.Configuration.Provider;

using Nucleo.Providers;
using Nucleo.Providers.Configuration;
using Nucleo.EventsManagement.Configuration;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the core object for getting of modifying event schedules.  Provides a simple API for managing an event-based schedule.  Can be used to wrap existing scheduling components.
	/// </summary>
	public class EventsSchedule
	{
		private EventScheduleProvider _defaultProvider = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the application, following the standards of the MS provider pattern.
		/// </summary>
		public string ApplicationName
		{
			get { return DefaultProvider.ApplicationName; }
		}

		/// <summary>
		/// Gets the default provider to serve requests.
		/// </summary>
		private EventScheduleProvider DefaultProvider
		{
			get { return _defaultProvider; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// This method creates a reoccurring event from the property information.
		/// </summary>
		/// <returns>An instance of an event object.</returns>
		public EventInformation AddEvent(EventInformation info)
		{
			if (info == null)
				throw new ArgumentNullException("eventInfo");
			if (info.BeginDate > info.EndDate)
				throw new ArgumentException("The begin date for the event cannot be less than the end date", "eventInfo");

			DefaultProvider.AddEvent(info);
			return info;
		}

		/// <summary>
		/// Creates a new instance of the schedule.  Uses the configuration file to create the underlying <see cref="EventScheduleProvider">EventScheduleProvider class</see>.
		/// </summary>
		/// <returns>The created schedule.</returns>
		public static EventsSchedule Create()
		{
			EventsScheduleSection section = EventsScheduleSection.Instance;
			if (section == null)
				throw new NullReferenceException("Cannot use the events schedule without configuration for the empty Create() method");

			EventsSchedule schedule = new EventsSchedule();
			Type providerType = Type.GetType(section.DefaultProvider);
			if (providerType == null)
				throw new InvalidOperationException("The type could not be found: " + section.DefaultProvider);
			
			schedule._defaultProvider = Activator.CreateInstance(providerType) as EventScheduleProvider;
			if (schedule._defaultProvider == null)
				throw new InvalidOperationException("The default provider could not be instantiated");

			return schedule;
		}

		/// <summary>
		/// Creates a new instance of the schedule, using the provided provider to serve all scheduling requests.
		/// </summary>
		/// <param name="provider">The provider to use.</param>
		/// <returns>The instance of the schedule.</returns>
		public static EventsSchedule Create(EventScheduleProvider provider)
		{
			if (provider == null)
				throw new ArgumentNullException("provider");

			EventsSchedule schedule = new EventsSchedule();
			schedule._defaultProvider = provider;

			return schedule;
		}

		/// <summary>
		/// Deletes an event from the repository.
		/// </summary>
		/// <param name="info">The event to delete.</param>
		public void DeleteEvent(EventInformation info)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			DefaultProvider.DeleteEvent(info);
		}

		/// <summary>
		/// Retrieves events for a specific day.
		/// </summary>
		/// <param name="day">The date/time to get events for.</param>
		/// <returns>A collection of events for the specific day.</returns>
		public EventInformationCollection GetEventsForDay(DateTime day)
		{
			return GetEventsForRange(new DateTime(day.Year, day.Month, day.Day, 0, 0, 0), new DateTime(day.Year, day.Month, day.Day, 23, 59, 59));
		}

		/// <summary>
		/// Retrieves events for a specific day.
		/// </summary>
		/// <param name="year">The year to get events for.</param>
		/// <param name="month">The month to get events for.</param>
		/// <param name="day">The day to get events for.</param>
		/// <returns>A collection of events for the specific day.</returns>
		public EventInformationCollection GetEventsForDay(int year, int month, int day)
		{
			return GetEventsForRange(new DateTime(year, month, day, 0, 0, 0), new DateTime(year, month, day, 23, 59, 59));
		}

		/// <summary>
		/// Retrieves events for a specific month.
		/// </summary>
		/// <param name="year">The year to get events for.</param>
		/// <param name="month">The month to get events for.</param>
		/// <returns>A collection of events for the specific day.</returns>
		public EventInformationCollection GetEventsForMonth(int year, int month)
		{
			return GetEventsForRange(new DateTime(year, month, 1, 0, 0, 0), new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59));
		}

		/// <summary>
		/// Retrieves events for a specific range.
		/// </summary>
		/// <param name="beginDate">The begin date of the range to get events for.</param>
		/// <param name="endDate">The end date of the range to get events for.</param>
		/// <returns>A collection of events for the specific day.</returns>
		public EventInformationCollection GetEventsForRange(DateTime beginDate, DateTime endDate)
		{
			return DefaultProvider.GetEventsForRange(beginDate, endDate);
		}

		/// <summary>
		/// Updates an event from the object specified.
		/// </summary>
		/// <param name="info">The event to update its information with.</param>
		public void UpdateEvent(EventInformation info)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			DefaultProvider.UpdateEvent(info);
		}

		#endregion
	}
}
