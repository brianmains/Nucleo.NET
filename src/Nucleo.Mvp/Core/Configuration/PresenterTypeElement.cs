using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Core.Configuration
{
	public class PresenterTypeElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("typeName")]
		public string TypeName
		{
			get { return (string)this["typeName"]; }
			set { this["typeName"] = value; }
		}

		protected override string UniqueKey
		{
			get { return this.TypeName; }
		}

		#endregion
	}
}
