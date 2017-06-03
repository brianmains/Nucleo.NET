using System;
using System.Collections.Generic;


namespace Nucleo.Logs
{
	public class FakeLogManager : LogManager
	{
		private List<FakeLogEntry> _entries = new List<FakeLogEntry>();



		#region " Methods "

		public List<FakeLogEntry> GetEntries()
		{
			return _entries;
		}

		public override void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			_entries.Add(new FakeLogEntry(source, ex, messageType));
		}

		public override void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			_entries.Add(new FakeLogEntry(source, message, messageType));
		}

		#endregion
	}
}
