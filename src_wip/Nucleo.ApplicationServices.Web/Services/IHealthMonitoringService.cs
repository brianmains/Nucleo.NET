using System;
using System.Web.Management;

using Nucleo;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents the health monitoring service.
	/// </summary>
	public interface IHealthMonitoringService : IService
	{
		#region " Methods "

		/// <summary>
		/// Raises an event specific to health monitoring.
		/// </summary>
		/// <param name="eventInfo">The event information.</param>
		void RaiseEvent(WebBaseEvent eventInfo);

		#endregion
	}
}
