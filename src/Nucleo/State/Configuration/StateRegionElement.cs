using System;
using System.Configuration;

using Nucleo.Configuration;


namespace Nucleo.State.Configuration
{
	public class StateRegionElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		[
		ConfigurationProperty("properties", IsDefaultCollection = false),
		ConfigurationCollection(typeof(StatePropertyElementCollection))
		]
		public StatePropertyElementCollection Properties
		{
			get { return (StatePropertyElementCollection)this["properties"]; }
		}

		protected internal override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion
	}
}
