using System;
using System.Collections.Generic;

using Nucleo.Logs;



namespace Nucleo.Context.Services
{
	public class FakeLoggerService : ILoggerService
	{
		private List<FakeLogEntry> _entries = new List<FakeLogEntry>();
		private LogMessageTypeCollection _messageTypes = new LogMessageTypeCollection
		{
			new LogMessageType("Information", 0),
			new LogMessageType("Warning", 128),
			new LogMessageType("Error", 255)
		};
		private LogVerbosityTypeCollection _verbosityTypes = new LogVerbosityTypeCollection
		{
			new LogVerbosityType("Minimal", 0),
			new LogVerbosityType("Normal", 128),
			new LogVerbosityType("Verbose", 255)
		};



		#region " Properties "

		public List<FakeLogEntry> Entries
		{
			get
			{
				if (_entries == null)
					_entries = new List<FakeLogEntry>();

				return _entries;
			}
		}

		#endregion



		#region " Methods "

		public LogMessageTypeCollection GetMessageTypes()
		{
			return _messageTypes;
		}

		public LogVerbosityTypeCollection GetVerbosityTypes()
		{
			return _verbosityTypes;
		}

		public void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			this.Entries.Add(new FakeLogEntry(source, ex, messageType));
		}

		public void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			this.Entries.Add(new FakeLogEntry(source, message, messageType));
		}

		#endregion
	}
}
