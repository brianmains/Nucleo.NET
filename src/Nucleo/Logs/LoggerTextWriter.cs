using System;
using System.IO;
using System.Text;


namespace Nucleo.Logs
{
	/// <summary>
	/// 
	/// 
	/// </summary>
	/// <example>
	/// var writer = new LoggerTextWriter("Source", new LoggerMessageType("Error", 255));
	/// writer.Write("This is my content.");
	/// writer.Write("  Some Additional Content.");
	/// writer.Flush();
	/// </example>
	public class LoggerTextWriter : TextWriter
	{
		private string _content = string.Empty;
		private LogMessageType _messageType = null;
		private string _source = null;
		private LogVerbosityType _verbosityType = null;



		#region " Properties "

		public override Encoding Encoding
		{
			get { return Encoding.Unicode; }
		}

		public LogMessageType MessageType
		{
			get { return _messageType; }
			set { _messageType = value; }
		}

		public string Source
		{
			get { return _source; }
			set { _source = value; }
		}

		public LogVerbosityType VerbosityType
		{
			get { return _verbosityType; }
			set { _verbosityType = value; }
		}

		#endregion



		#region " Constructors "

		public LoggerTextWriter(string source, LogMessageType messageType)
		{
			_source = source;
			_messageType = messageType;
		}

		public LoggerTextWriter(string source, LogMessageType messageType, LogVerbosityType verbosityType)
			: this(source, messageType)
		{
			_verbosityType = verbosityType;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Flushes the content to the logger.
		/// </summary>
		public override void Flush()
		{
			this.FlushContent();
		}

		/// <summary>
		/// Flushes the content to the logger.  Returns the text that was flushed.
		/// </summary>
		/// <returns>The flushed content.</returns>
		public string FlushContent()
		{
			string text = _content;
			_content = string.Empty;

			this.WriteContent(text);
			return text;
		}

		/// <summary>
		/// Writes the character value to the content stream.  Doesn't get written to the log until flushing occurs.
		/// </summary>
		/// <param name="value">The value to store.</param>
		public override void Write(char value)
		{
			_content += value;
		}
		
		/// <summary>
		/// Writes the string value to the content stream.  Doesn't get written to the log until flushing occurs.
		/// </summary>
		/// <param name="value">The value to store.</param>
		public override void Write(string value)
		{
			_content += value;
		}

		/// <summary>
		/// Writes the content internally to the logger.
		/// </summary>
		/// <param name="content">The content to write.</param>
		private void WriteContent(string content)
		{
			Logger logger = Logger.Create();
			if (logger != null)
				logger.LogMessage(_content, this.Source, this.MessageType,
					this.VerbosityType ?? logger.CurrentVerbosity);
		}

		#endregion
	}
}
