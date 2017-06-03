using System;
using Nucleo.Collections;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents a list of events.
	/// </summary>
	public class EventInformationCollection : CollectionBase<EventInformation>
	{
		/// <summary>
		/// Gets an event in the collection based on the name.
		/// </summary>
		/// <param name="name">The name of the event.</param>
		/// <returns>The event that was found with the specific name, or null if not found.</returns>
		public EventInformation GetEventByName(string name)
		{
			foreach (EventInformation information in this)
			{
				if (string.Compare(name, information.Name, StringComparison.CurrentCultureIgnoreCase) == 0)
					return information;
			}

			return null;
		}
	}
}
