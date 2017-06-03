using System;
using System.Configuration;

using Nucleo.Configuration;


namespace Nucleo.DataServices.Modules.Configuration
{
	public class ExecutingModuleElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("name")]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion
	}
}
