using System;
using System.Configuration;

using Nucleo.Configuration;
using Nucleo.State;


namespace Nucleo.State.Configuration
{
	public class StatePropertyElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("defaultValue")]
		public object DefaultValue
		{
			get { return this["defaultValue"]; }
			set { this["defaultValue"] = value; }
		}

		[ConfigurationProperty("isolation", DefaultValue = StatePropertyIsolation.Shared)]
		public StatePropertyIsolation Isolation
		{
			get { return (StatePropertyIsolation)this["isolation"]; }
			set { this["isolation"] = value; }
		}

		[ConfigurationProperty("name")]
		public string Name
		{
			get { return (string) this["name"]; }
			set { this["name"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion
	}
}
