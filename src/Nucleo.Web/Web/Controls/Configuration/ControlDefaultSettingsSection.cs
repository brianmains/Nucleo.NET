using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Controls.Configuration
{
	public class ControlDefaultSettingsSection : ConfigurationSection
	{
		#region " Properties "

		public static ControlDefaultSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/controlDefaultSettings") as ControlDefaultSettingsSection; }
		}

		[
		ConfigurationProperty("settings", IsDefaultCollection=false),
		ConfigurationCollection(typeof(ControlDefaultSettingsElementCollection))
		]
		public ControlDefaultSettingsElementCollection Settings
		{
			get { return (ControlDefaultSettingsElementCollection)this["settings"]; }
		}

		#endregion
	}
}
