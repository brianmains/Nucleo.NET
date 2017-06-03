using System;
using System.Configuration;
using Nucleo.Providers.Configuration;


namespace Nucleo.Text.Configuration
{
	public class MessagesSection : ConfigurationSection
	{
		#region " Properties "

		[ConfigurationProperty("defaultProvider", IsRequired=true)]
		public string DefaultProvider
		{
			get { return (string)this["defaultProvider"]; }
			set { this["defaultProvider"] = value; }
		}

		public static MessagesSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/messages") as MessagesSection; }
		}

		/// <summary>
		/// Gets or sets whether to keep old messages in the system.  Old messages are not directly deleted.
		/// </summary>
		[ConfigurationProperty("keepOldMessages", DefaultValue = true)]
		public bool KeepOldMessages
		{
			get { return (bool)this["keepOldMessages"]; }
			set { this["keepOldMessages"] = value; }
		}

		#endregion
	}
}
