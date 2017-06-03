using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Logs
{
	public interface ILogManager
	{
		#region " Methods "

		void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity);

		void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity);

		#endregion
	}
}
