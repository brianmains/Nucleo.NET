using System;
using Nucleo.Logs;


namespace Nucleo.Context.Services
{
	/// <summary>
	/// Represents the core logging service.
	/// </summary>
	public class LoggerService : ILoggerService
	{
		private Logger _logger = null;



		#region " Properties "

		/// <summary>
		/// Gets the implementation of the logger.
		/// </summary>
		private Logger Logger
		{
			get
			{
				if (_logger == null)
					_logger = Logger.Create();

				return _logger;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the message types registered with the logger.
		/// </summary>
		/// <returns>The collection of message types.</returns>
		public LogMessageTypeCollection GetMessageTypes()
		{
			return this.Logger.GetMessageTypes();
		}

		/// <summary>
		/// Gets the verbosity types registered with the logger.
		/// </summary>
		/// <returns>The collection of verbosity types.</returns>
		public LogVerbosityTypeCollection GetVerbosityTypes()
		{
			return this.Logger.GetVerbosityTypes();
		}

		/// <summary>
		/// Logs an error using the logger.
		/// </summary>
		/// <param name="ex">The exception to log.</param>
		/// <param name="source">The source to log.</param>
		/// <param name="messageType">The type of message.</param>
		/// <param name="verbosity">The verbosity of the message.</param>
		public void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			this.Logger.LogError(ex, source, messageType, verbosity);
		}

		/// <summary>
		/// Logs a message using the logger.
		/// </summary>
		/// <param name="message">The message to log.</param>
		/// <param name="source">The source to log.</param>
		/// <param name="messageType">The type of message.</param>
		/// <param name="verbosity">The verbosity of the message.</param>
		public void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			this.Logger.LogMessage(message, source, messageType, verbosity);
		}

		#endregion
	}
}
