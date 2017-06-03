using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Logs
{
	public class FakeLogEntry
	{
		private Exception _exception = null;
		private string _message = null;
		private LogMessageType _messageType = null;
		private string _source = null;



		#region " Properties "

		public Exception Exception
		{
			get { return _exception; }
		}

		public string Message
		{
			get { return _message; }
		}

		public LogMessageType MessageType
		{
			get { return _messageType; }
		}

		public string Source
		{
			get { return _source; }
		}

		#endregion



		#region " Constructors "

		public FakeLogEntry(string source, string message, LogMessageType messageType)
		{
			_source = source;
			_message = message;
			_messageType = messageType;
		}

		public FakeLogEntry(string source, Exception exception, LogMessageType messageType)
		{
			_source = source;
			_exception = exception;
			_messageType = messageType;
		}

		#endregion
	}
}
