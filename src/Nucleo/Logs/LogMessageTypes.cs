using System;
using System.Collections.Generic;


namespace Nucleo.Logs
{
	/// <summary>
	/// Represents the message types for the logger.
	/// </summary>
	public static class LogMessageTypes
	{
		#region " Methods "

		/// <summary>
		/// Gets the default options for the message types.
		/// </summary>
		public static LogMessageTypeCollection Default
		{
			get
			{
				LogMessageTypeCollection messages = new LogMessageTypeCollection();
				messages.Add(new LogMessageType("Information", 0));
				messages.Add(new LogMessageType("Warning", 127));
				messages.Add(new LogMessageType("Error", 255));

				return messages;
			}
		}

		#endregion
	}
}
