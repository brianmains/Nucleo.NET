using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Orm.Configuration
{
	/// <summary>
	/// Represents the context settings.
	/// </summary>
	public class DataContextSettingsSection : ConfigurationSectionBase
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

		[
		ConfigurationProperty("dataClasses", IsDefaultCollection = false),
		ConfigurationCollection(typeof(DataClassDefinitionElementCollection))
		]
		public DataClassDefinitionElementCollection DataClasses
		{
			get { return (DataClassDefinitionElementCollection)this["dataClasses"]; }
		}

		/// <summary>
		/// Gets the instance of the configuration section.
		/// </summary>
		public static DataContextSettingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo.orm/dataContextSettings") as DataContextSettingsSection; }
		}

		[ConfigurationProperty("shouldFireTriggers")]
		public bool ShouldFireTriggers
		{
			get { return (bool)this["shouldFireTriggers"]; }
			set { this["shouldFireTriggers"] = value; }
		}

		#endregion



		#region " Methods "

		public DataClassDefinitionElement GetDefinitionByType<T>()
			where T : class
		{
			return this.DataClasses[typeof(T).Name];
		}

		#endregion
	}
}
