using System;
using System.Configuration;


namespace Nucleo.Configuration
{
	public class FakeConfigurationElementBase : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.Name; }
		}

		[ConfigurationProperty("value")]
		public object Value
		{
			get { return this["value"]; }
			set { this["value"] = value; }
		}

		#endregion



		#region " Constructors "

		public FakeConfigurationElementBase() { }

		public FakeConfigurationElementBase(string name, object value)
		{
			this.Name = name;
			this.Value = value;
		}

		#endregion
	}
}
