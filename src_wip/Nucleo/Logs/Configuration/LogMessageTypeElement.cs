using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Logs.Configuration
{
	public class LogMessageTypeElement : ConfigurationElementBase
	{
		#region " Properties "

		/// <summary>
		/// Gets the name of the message type.
		/// </summary>
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.Name; }
		}

		/// <summary>
		/// Gets the value of the message.
		/// </summary>
		[ConfigurationProperty("value", IsRequired = true)]
		public byte Value
		{
			get { return (byte)this["value"]; }
			set { this["value"] = value; }
		}

		#endregion



		#region " Constructors "

		public LogMessageTypeElement() { }

		public LogMessageTypeElement(string name, byte value)
		{
			this.Name = name;
			this.Value = value;
		}

		#endregion
	}
}
