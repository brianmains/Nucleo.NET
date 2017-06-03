using System;


namespace Nucleo.Logs
{
	public class ConsoleLogManager : LogManager
	{
		public override void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			Console.WriteLine(string.Format("{0}: {1}", source, ex.ToString()));
		}

		public override void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			Console.WriteLine(string.Format("{0}: {1}", source, message));
		}
	}
}
