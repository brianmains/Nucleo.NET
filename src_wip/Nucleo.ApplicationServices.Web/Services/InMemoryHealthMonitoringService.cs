using System;
using System.Collections.Generic;
using System.Web.Management;

using Nucleo.Collections;



namespace Nucleo.Services
{
	/// <summary>
	/// Represents an inline version of the health monitoring service, for testing purposes.
	/// </summary>
	public class InMemoryHealthMonitoringService : IHealthMonitoringService
	{
		private WebEventCollection _events = null;



		#region " Properties "

		/// <summary>
		/// Gets the collection of events raised.
		/// </summary>
		public WebEventCollection Events
		{
			get
			{
				if (_events == null)
					_events = new WebEventCollection();

				return _events;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Raises an event.
		/// </summary>
		/// <param name="eventInfo">The event to raise.</param>
		public void RaiseEvent(WebBaseEvent eventInfo)
		{
			if (eventInfo == null)
				throw new ArgumentNullException("eventInfo");

			this.Events.Add(eventInfo);
		}

		#endregion
	}
}
