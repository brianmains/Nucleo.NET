using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Logs.Configuration
{
	public class LogVerbosityTypeElement : ConfigurationElementBase
	{
		#region " Properties "

		/// <summary>
		/// Gets the value of the message.
		/// </summary>
		[ConfigurationProperty("level", IsRequired=true)]
		public byte Level
		{
			get { return (byte)this["level"]; }
			set { this["level"] = value; }
		}

		/// <summary>
		/// Gets the name of the message type.
		/// </summary>
		[ConfigurationProperty("name", IsRequired=true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion



		#region " Constructors "

		public LogVerbosityTypeElement() { }

		public LogVerbosityTypeElement(string name, byte level)
		{
			this.Name = name;
			this.Level = level;
		}

		#endregion
	}
}
