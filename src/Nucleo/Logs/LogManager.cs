using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Logs
{
	public abstract class LogManager : ILogManager
	{
		#region " Methods "

		public abstract void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity);

		public abstract void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity);

		#endregion
	}
}
