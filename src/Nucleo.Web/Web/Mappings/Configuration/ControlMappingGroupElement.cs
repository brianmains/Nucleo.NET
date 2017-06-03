using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Mappings.Configuration
{
	public class ControlMappingGroupElement : ConfigurationElementBase
	{
		#region " Properties "

		[
			ConfigurationProperty("", IsDefaultCollection=true),
			ConfigurationCollection(typeof(ControlMappingElementCollection))
		]
		public ControlMappingElementCollection Mappings
		{
			get { return (ControlMappingElementCollection) this[""]; }
		}

		[ConfigurationProperty("name", IsRequired=true)]
		public string Name
		{
			get { return (string) this["name"]; }
			set { this["name"] = value; }
		}

		protected override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion
	}
}
