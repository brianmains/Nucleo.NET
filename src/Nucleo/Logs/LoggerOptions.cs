using System;
using System.Collections.Generic;


namespace Nucleo.Logs
{
	/// <summary>
	/// Gets the options to use when logging.
	/// </summary>
	public class LoggerOptions
	{
		private string _currentVerbosityLevel = null;
		private LogMessageTypeCollection _customMessageTypes = null;
		private LogVerbosityTypeCollection _customVerbosityTypes = null;
		private LogManagerCollection _logManagers = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the current verbosity level.
		/// </summary>
		public string CurrentVerbosityLevel
		{
			get { return _currentVerbosityLevel; }
			set { _currentVerbosityLevel = value; }
		}

		/// <summary>
		/// Gets or sets the custom message types, outside of the default 3.
		/// </summary>
		public LogMessageTypeCollection CustomMessageTypes
		{
			get
			{
				if (_customMessageTypes == null)
					_customMessageTypes = new LogMessageTypeCollection();

				return _customMessageTypes;
			}
			set { _customMessageTypes = value; }
		}

		/// <summary>
		/// Gets or sets the custom verbosity types, outside of the default 3.
		/// </summary>
		public LogVerbosityTypeCollection CustomVerbosityTypes
		{
			get
			{
				if (_customVerbosityTypes == null)
					_customVerbosityTypes = new LogVerbosityTypeCollection();

				return _customVerbosityTypes;
			}
			set { _customVerbosityTypes = value; }
		}

		/// <summary>
		/// Gets or sets the collection of log managers to log to.
		/// </summary>
		public LogManagerCollection LogManagers
		{
			get
			{
				if (_logManagers == null)
					_logManagers = new LogManagerCollection();
				return _logManagers;
			}
			set { _logManagers = value; }
		}

		#endregion
	}
}
