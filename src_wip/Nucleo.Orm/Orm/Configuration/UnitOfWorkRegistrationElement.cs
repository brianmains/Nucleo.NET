using System;
using System.Configuration;

using Nucleo.Configuration;


namespace Nucleo.Orm.Configuration
{
	/// <summary>
	/// Represents the registration element for the unit of work.
	/// </summary>
	public class UnitOfWorkRegistrationElement : ConfigurationElementBase
	{
		#region " Properties "
		
		/// <summary>
		/// Gets the collection of attributes that are used for the unit of work, to provide the unit of work with additional information.
		/// </summary>
		[
		ConfigurationProperty("attributes", IsDefaultCollection = false),
		ConfigurationCollection(typeof(NameValueConfigurationCollection))
		]
		public NameValueConfigurationCollection Attributes
		{
			get { return (NameValueConfigurationCollection)this["attributes"]; }
		}

		/// <summary>
		/// Gets or sets the name of the unit of work object.
		/// </summary>
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the type for the unit of work.
		/// </summary>
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
