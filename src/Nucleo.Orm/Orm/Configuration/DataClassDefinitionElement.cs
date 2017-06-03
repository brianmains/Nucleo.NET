using System;
using System.Configuration;

using Nucleo.Configuration;


namespace Nucleo.Orm.Configuration
{
	public class DataClassDefinitionElement : ConfigurationElementBase
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the data class.
		/// </summary>
		[ConfigurationProperty("dataClassName", IsRequired = true)]
		public string DataClassName
		{
			get { return (string)this["dataClassName"]; }
			set { this["dataClassName"] = value; }
		}

		/// <summary>
		/// Gets the collection of insert triggers that will execute for the data class.
		/// </summary>
		[
		ConfigurationProperty("triggers", IsDefaultCollection = false),
		ConfigurationCollection(typeof(NameTypeElementCollection))
		]
		public NameTypeElementCollection Triggers
		{
			get { return (NameTypeElementCollection)this["triggers"]; }
		}

		protected override string UniqueKey
		{
			get { return this.DataClassName; }
		}

		#endregion
	}
}
