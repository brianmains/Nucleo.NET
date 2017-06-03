using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Mappings.Configuration
{
	public class ControlMappingElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("controlID", IsRequired=true)]
		public string ControlID
		{
			get { return (string) this["controlID"]; }
			set { this["controlID"] = value; }
		}

		[ConfigurationProperty("objectPropertyName", IsRequired=true)]
		public string ObjectPropertyName
		{
			get { return (string) this["objectPropertyName"]; }
			set { this["objectPropertyName"] = value; }
		}

		protected override string UniqueKey
		{
			get { return this.ObjectPropertyName; }
		}

		#endregion
	}
}
