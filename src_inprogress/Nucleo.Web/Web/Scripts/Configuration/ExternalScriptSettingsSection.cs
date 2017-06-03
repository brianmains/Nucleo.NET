using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Scripts.Configuration
{
	public class ExternalScriptSettingsSection : ConfigurationSection
	{
		#region " Properties "

		[ConfigurationProperty("externalScripts", IsRequired = true)]
		public ExternalScriptElementCollection ExternalScripts
		{
			get { return (ExternalScriptElementCollection)this["externalScripts"]; }
		}

		public static ExternalScriptSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo.web/externalScriptSettings") as ExternalScriptSettingsSection; }
		}

		#endregion
	}
}
