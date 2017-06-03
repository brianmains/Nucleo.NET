using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Controls.Configuration
{
	public class ControlDefaultSettingsElement : ConfigurationElementBase
	{
		#region " Properties "

		[
		ConfigurationProperty("", IsDefaultCollection = true),
		ConfigurationCollection(typeof(NameValueElementCollection))
		]
		public NameValueElementCollection Entries
		{
			get { return (NameValueElementCollection)this[""]; }
		}

		[ConfigurationProperty("typeName", IsRequired=true)]
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
