using System;
using System.Web;
using System.Web.Management;

using Nucleo.Logs;


namespace Nucleo.Web.Logs
{
	public class HealthMonitoringLogManager : LogManager
	{
		public override void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			LoggerErrorEvent.Raise(source, ex);
		}

		public override void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			LoggerMessageEvent.Raise(source, message);
		}
	}
}
