using System;
using System.Web.Management;


namespace Nucleo.Web.EventsManagement
{
	public abstract class WebMonitoringEventBase : WebBaseEvent
	{
		public WebMonitoringEventBase(string message, object eventSource, int eventCode) : base(message, eventCode, eventCode) { }
		public WebMonitoringEventBase(string message, object eventSource, int eventCode, int eventDetailedCode) : base(message, eventSource, eventCode, eventDetailedCode) { }
	}
}
