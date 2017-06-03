using System;
using System.Configuration;
using Nucleo.Configuration;
using Nucleo.Providers.Configuration;


namespace Nucleo.EventsManagement.Configuration
{
	/// <summary>
	/// Gets the configuration information for the events schedule.
	/// </summary>
	public class EventsScheduleSection : ConfigurationSectionBase
	{
		/// <summary>
		/// Gets the type of object that serves the event schedule data for the <see cref="EventsSchedule">EventsSchedule</see> component.
		/// </summary>
		[ConfigurationProperty("defaultProvider", IsRequired = true)]
		public string DefaultProvider
		{
			get { return (string)this["defaultProvider"]; }
			set { this["defaultProvider"] = value; }
		}

		public static EventsScheduleSection Instance
		{
			get
			{
				try { return (EventsScheduleSection)ConfigurationManager.GetSection("nucleo/eventsSchedule"); }
				catch { return null; }
			}
		}
	}
}