using System;
using System.Web;


namespace Nucleo.Web.EventsManagement
{
	/// <summary>
	/// Represents an error event.
	/// </summary>
	public class WebErrorEvent : WebMonitoringEventBase
	{
		private const string EVENT_MESSAGE = "An error occurred within the ASPX page '{0}' with an exception of: {1}";
		private const int EVENT_CODE = 100100;


		public WebErrorEvent(string page, object source, Exception ex) : base(string.Format(EVENT_MESSAGE, page, ex.ToString()), source, EVENT_CODE) { }
	}
}
