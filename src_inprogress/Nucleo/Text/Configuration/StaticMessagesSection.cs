using System;
using System.Configuration;


namespace Nucleo.Text.Configuration
{
	public class StaticMessagesSection : ConfigurationSection
	{
		#region " Properties "

		public static StaticMessagesSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/staticMessages") as StaticMessagesSection; }
		}

		[
		ConfigurationProperty("messages", IsDefaultCollection=true),
		ConfigurationCollection(typeof(NameValueConfigurationCollection))
		]
		public NameValueConfigurationCollection Messages
		{
			get { return (NameValueConfigurationCollection)this["messages"]; }
		}

		#endregion
	}
}
