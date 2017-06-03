using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Nucleo.Logs
{
	public class EventLogManager : LogManager
	{
		#region " Methods "

		public override void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			this.WriteToEventLog("The following error has occurred: " + ex.ToString(), source, messageType, verbosity);
		}

		public override void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			this.WriteToEventLog(message, source, messageType, verbosity);
		}

		private void WriteToEventLog(string message, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			EventLog.WriteEntry("Application", message + "Source: " + source, EventLogEntryType.Information);
		}

		#endregion
	}
}
