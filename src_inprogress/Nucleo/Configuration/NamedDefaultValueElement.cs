using System;
using System.Configuration;


namespace Nucleo.Configuration
{
	/// <summary>
	/// Represents a configuration element that stores a name, value, and default value properties.  Useful for storing name/value pairs, with a default value if the value is missing.
	/// </summary>
	public class NamedDefaultValueElement : NameValueElement
	{
		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		[ConfigurationProperty("defaultValue")]
		public object DefaultValue
		{
			get { return this["defaultValue"]; }
			set { this["defaultValue"] = value; }
		}
	}
}
