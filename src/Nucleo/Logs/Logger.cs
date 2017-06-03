using System;
using System.Reflection;
using System.Collections.Generic;

using Nucleo.Configuration;
using Nucleo.Logs.Configuration;


namespace Nucleo.Logs
{
	public class Logger
	{
		private LogVerbosityType _currentVerbosity = null;
		private LogManagerCollection _logs = null;
		private LogMessageTypeCollection _messageTypes = null;
		private LogVerbosityTypeCollection _verbosityTypes = null;



		#region " Properties "

		public LogVerbosityType CurrentVerbosity
		{
			get { return _currentVerbosity; }
			set { _currentVerbosity = value; }
		}

		private LogManagerCollection Logs
		{
			get
			{
				if (_logs == null)
					_logs = new LogManagerCollection();
				return _logs;
			}
		}

		private LogMessageTypeCollection MessageTypes
		{
			get
			{
				if (_messageTypes == null)
					_messageTypes = new LogMessageTypeCollection();
				return _messageTypes;
			}
		}

		private LogVerbosityTypeCollection VerbosityTypes
		{
			get
			{
				if (_verbosityTypes == null)
					_verbosityTypes = new LogVerbosityTypeCollection();
				return _verbosityTypes;
			}
		}

		#endregion



		#region " Constructors "

		private Logger() { }

		#endregion



		#region " Methods "

		public static Logger Create()
		{
			Logger logger = new Logger();
			LoggerSettingsSection settings = LoggerSettingsSection.Instance;

			if (settings == null)
				throw new InvalidOperationException("The configuration section must be defined for this version of Create.");

			LoggerOptions options = new LoggerOptions();

			for (int index = 0, len = settings.LogManagers.Count; index < len; index++)
			{
				options.LogManagers.Add(CreateLogManagerInstance(
					settings.LogManagers[index].Type));
			}

			for (int index = 0, len = settings.MessageTypes.Count; index < len; index++)
			{
				options.CustomMessageTypes.Add(new LogMessageType(
					settings.MessageTypes[index].Name,
					settings.MessageTypes[index].Value));
			}

			for (int index = 0, len = settings.VerbosityTypes.Count; index < len; index++)
			{
				options.CustomVerbosityTypes.Add(new LogVerbosityType(
					settings.VerbosityTypes[index].Name,
					settings.VerbosityTypes[index].Level));
			}

			if (!string.IsNullOrEmpty(settings.CurrentVerbosityName))
				options.CurrentVerbosityLevel = settings.CurrentVerbosityName;

			return Create(options);
		}

		public static Logger Create(LoggerOptions options)
		{
			Logger logger = new Logger();
			logger._messageTypes = LogMessageTypes.Default;
			logger._verbosityTypes = LogVerbosityTypes.Default;

			foreach (LogMessageType type in options.CustomMessageTypes)
				logger.MessageTypes.Add(type);
			foreach (LogVerbosityType type in options.CustomVerbosityTypes)
				logger.VerbosityTypes.Add(type);
			foreach (ILogManager manager in options.LogManagers)
				logger.Logs.Add(manager);

			//Default the verbosity
			if (string.IsNullOrEmpty(options.CurrentVerbosityLevel))
				options.CurrentVerbosityLevel = "Normal";
			logger.CurrentVerbosity = logger.VerbosityTypes[options.CurrentVerbosityLevel];
			if (logger.CurrentVerbosity == null)
				throw new ArgumentException("The current verbosity setting does not match an item in the list.", "CurrentVerbosityName");

			return logger;
		}

		private static ILogManager CreateLogManagerInstance(string type)
		{
			Type managerType = Type.GetType(type);
			if (managerType == null)
				throw new NullReferenceException(string.Format("The manager type '{0}' could not be found.", type));

			return (ILogManager)Activator.CreateInstance(managerType);
		}

		private static LogMessageTypeCollection GetDefaultMessageTypes()
		{
			return LogMessageTypes.Default;
		}

		private static LogVerbosityTypeCollection GetDefaultVerbosityTypes()
		{
			return LogVerbosityTypes.Default;
		}

		public LogManagerCollection GetLogManagers()
		{
			return this.Logs;
		}

		public LogMessageTypeCollection GetMessageTypes()
		{
			return this.MessageTypes;
		}

		public LogVerbosityTypeCollection GetVerbosityTypes()
		{
			return this.VerbosityTypes;
		}

		private bool IfVerbosityOK(LogVerbosityType messageVerbosity)
		{
			if (this.CurrentVerbosity == null)
				return true;

			return (this.CurrentVerbosity.Level >= messageVerbosity.Level);
		}

		public void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			if (!this.IfVerbosityOK(verbosity))
				return;

			foreach (ILogManager manager in this.Logs)
				manager.LogError(ex, source, messageType, verbosity);
		}

		public void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			if (!this.IfVerbosityOK(verbosity))
				return;

			foreach (ILogManager manager in this.Logs)
				manager.LogMessage(message, source, messageType, verbosity);
		}

		public void LogObjectDetails(object obj, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			if (!this.IfVerbosityOK(verbosity))
				return;

			string details = string.Concat(obj.GetType().FullName, ": ");
			PropertyInfo[] properties = obj.GetType().GetProperties();
			bool comma = false;

			foreach (PropertyInfo property in properties)
			{
				if (comma)
					details += ", ";
				else
					comma = true;

				if (property.CanRead)
					details += string.Concat(property.Name, "=", property.GetValue(obj, null));
			}

			foreach (ILogManager manager in this.Logs)
			{
				manager.LogMessage(details, source, messageType, verbosity);
			}
		}

		public void RegisterLogManager(ILogManager manager)
		{
			this.Logs.Add(manager);
		}

		#endregion
	}
}
