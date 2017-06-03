using System;
using System.Configuration;


namespace Nucleo.Web.Handlers.Configuration
{
	public class FileMonitoringSettingsSection : ConfigurationSection
	{
		#region " Properties "

		public static FileMonitoringSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/fileMonitoringSettings") as FileMonitoringSettingsSection; }
		}

		[ConfigurationProperty("paths", IsDefaultCollection=false)]
		public NameValueConfigurationCollection Paths
		{
			get { return (NameValueConfigurationCollection)this["paths"]; }
		}

		#endregion
	}
}
