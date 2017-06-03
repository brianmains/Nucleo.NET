using System;
using System.Collections.Generic;
using System.Web.Management;


namespace Nucleo.Web.Logs
{
	public class LoggerMessageEvent : WebBaseEvent
	{
		#region " Constructors "

		public LoggerMessageEvent(string source, string message)
			: base(message, source, 100000) { }

		#endregion



		#region " Methods "

		public static LoggerMessageEvent Raise(string source, string message)
		{
			LoggerMessageEvent eventInfo = new LoggerMessageEvent(source, message);
			eventInfo.Raise();

			return eventInfo;
		}

		#endregion
	}
}
