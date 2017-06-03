using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Configuration
{
	/// <summary>
	/// Represents the base class for custom configuration elements.
	/// </summary>
	[CLSCompliant(true)]
	public abstract class ConfigurationElementBase : System.Configuration.ConfigurationElement 
	{
		/// <summary>
		/// Gets the unique key for the element.  In most cases, the common value returned would be the unique name identifier.
		/// </summary>
		/// <example>
		/// public class ConfigEl : ConfigurationElementBase
		/// {
		///		[ConfigurationProperty("name", IsRequired = true)]
		///		public string Name
		///		{
		///			get { return (string)this["name"]; }
		///			set { this["name"] = value; }
		///		}
		///		
		///		[ConfigurationProperty("value", IsRequired = true)]
		///		public string Value
		///		{
		///			get { return (string)this["value"]; }
		///			set { this["value"] = value; }
		///		}
		///		
		///		protected override string UniqueKey
		///		{
		///			get { return this.Name; }
		///		}
		/// }
		/// </example>
		protected internal abstract string UniqueKey { get; }
	}
}
