using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Lookups.Configuration
{
	/// <summary>
	/// Represents the lookup group.
	/// </summary>
	public class LookupGroupElement :ConfigurationElementBase
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the lookup.
		/// </summary>
		[ConfigurationProperty("lookupName", IsRequired = true)]
		public string LookupName
		{
			get { return (string)this["lookupName"]; }
			set { this["lookupName"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.LookupName; }
		}

		[
		ConfigurationProperty("values", IsDefaultCollection = false),
		ConfigurationCollection(typeof(LookupElementCollection))
		]
		public LookupElementCollection Values
		{
			get { return (LookupElementCollection)this["values"]; }
		}

		#endregion
	}
}
