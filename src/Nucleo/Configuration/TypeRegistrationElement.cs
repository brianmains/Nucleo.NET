using System;
using System.Configuration;


namespace Nucleo.Configuration
{
	public class TypeRegistrationElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("contractTypeName", IsRequired = true)]
		public string ContractTypeName
		{
			get { return (string)this["contractTypeName"]; }
			set { this["contractTypeName"] = value; }
		}

		[ConfigurationProperty("mappedTypeName", IsRequired = true)]
		public string MappedTypeName
		{
			get { return (string)this["mappedTypeName"]; }
			set { this["mappedTypeName"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.ContractTypeName; }
		}

		#endregion
	}
}
