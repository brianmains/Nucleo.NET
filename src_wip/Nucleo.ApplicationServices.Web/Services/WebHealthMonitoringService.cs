using System;
using System.Web;
using System.Web.Management;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents a service that works against the health monitoring API.
	/// </summary>
	public class WebHealthMonitoringService : IHealthMonitoringService
	{
		#region " Methods "

		/// <summary>
		/// Raises a health monitoring event against the web API.
		/// </summary>
		/// <param name="eventInfo">The event information.</param>
		public void RaiseEvent(WebBaseEvent eventInfo)
		{
			if (eventInfo == null)
				throw new ArgumentNullException("eventInfo");

			eventInfo.Raise();
		}

		#endregion
	}
}
