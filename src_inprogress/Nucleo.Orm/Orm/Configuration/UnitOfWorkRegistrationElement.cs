using System;
using System.Configuration;

using Nucleo.Configuration;


namespace Nucleo.Orm.Configuration
{
	public class UnitOfWorkRegistrationElement : ConfigurationElementBase
	{
		#region " Properties "
		
		[
		ConfigurationProperty("attributes", IsDefaultCollection = false),
		ConfigurationCollection(typeof(NameValueConfigurationCollection))
		]
		public NameValueConfigurationCollection Attributes
		{
			get { return (NameValueConfigurationCollection)this["attributes"]; }
		}

		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("typeName")]
		public string TypeName
		{
			get { return (string)this["typeName"]; }
			set { this["typeName"] = value; }
		}

		protected override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion
	}
}
