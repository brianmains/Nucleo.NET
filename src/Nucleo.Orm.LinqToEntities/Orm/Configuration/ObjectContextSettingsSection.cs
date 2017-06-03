using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Orm.Configuration
{
	public class ObjectContextSettingsSection : ConfigurationSectionBase
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the connection string to pull from the &lt;connectionStrings> collection.
		/// </summary>
		[ConfigurationProperty("connectionStringName")]
		public string ConnectionStringName
		{
			get { return (string)this["connectionStringName"]; }
			set { this["connectionStringName"] = value; }
		}

		/// <summary>
		/// Gets the instance of the configuration section.
		/// </summary>
		public static ObjectContextSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo.orm/objectContextSettings") as ObjectContextSettingsSection; }
		}

		[ConfigurationProperty("shouldFireTriggers")]
		public bool ShouldFireTriggers
		{
			get { return (bool)this["shouldFireTriggers"]; }
			set { this["shouldFireTriggers"] = value; }
		}

		#endregion
	}
}
