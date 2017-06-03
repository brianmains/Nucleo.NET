using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Logs.Configuration
{
	public class LoggerSettingsSection : ConfigurationSection
	{
		#region " Properties "

		[ConfigurationProperty("currentVerbosityName")]
		public string CurrentVerbosityName
		{
			get { return (string)this["currentVerbosityName"]; }
			set { this["currentVerbosityName"] = value; }
		}

		public static LoggerSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/loggerSettings") as LoggerSettingsSection; }
		}

		[
		ConfigurationProperty("logManagers", IsDefaultCollection=false),
		ConfigurationCollection(typeof(NameTypeElementCollection))
		]
		public NameTypeElementCollection LogManagers
		{
			get { return (NameTypeElementCollection)this["logManagers"]; }
		}

		[
		ConfigurationProperty("messageTypes", IsDefaultCollection=false),
		ConfigurationCollection(typeof(LogMessageTypeElementCollection))
		]
		public LogMessageTypeElementCollection MessageTypes
		{
			get { return (LogMessageTypeElementCollection)this["messageTypes"]; }
		}

		[
		ConfigurationProperty("verbosityTypes", IsDefaultCollection = false),
		ConfigurationCollection(typeof(LogVerbosityTypeElementCollection))
		]
		public LogVerbosityTypeElementCollection VerbosityTypes
		{
			get { return (LogVerbosityTypeElementCollection)this["verbosityTypes"]; }
		}

		#endregion
	}
}
