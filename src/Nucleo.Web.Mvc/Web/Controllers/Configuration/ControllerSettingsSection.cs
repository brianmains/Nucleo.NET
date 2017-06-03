using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Controllers.Configuration
{
	public class ControllerSettingsSection : ConfigurationSection
	{
		#region " Properties "

		[ConfigurationProperty("defaultActionInvokerType")]
		public string DefaultActionInvokerType
		{
			get { return (string)this["defaultActionInvokerType"]; }
			set { this["defaultActionInvokerType"] = value; }
		}

		[ConfigurationProperty("defaultServerType")]
		public string DefaultServerType
		{
			get { return (string)this["defaultServerType"]; }
			set { this["defaultServerType"] = value; }
		}

		public static ControllerSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo.web.mvc/controllerSettings") as ControllerSettingsSection; }
		}

		#endregion
	}
}
