using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Lookups.Configuration
{
	/// <summary>
	/// Represents the lookup element.
	/// </summary>
	public class LookupElement : ConfigurationElementBase
	{
		#region " Methods "

		/// <summary>
		/// Gets the start date of the lookup value is effective.
		/// </summary>
		[ConfigurationProperty("effectiveDate")]
		public DateTime EffectiveDate
		{
			get { return (DateTime)this["effectiveDate"]; }
			set { this["effectiveDate"] = value; }
		}

		/// <summary>
		/// Gets the end date of the lookup value, when it is no longer effective.
		/// </summary>
		[ConfigurationProperty("endDate")]
		public DateTime? EndDate
		{
			get { return (DateTime?)this["endDate"]; }
			set { this["endDate"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the lookup.
		/// </summary>
		[ConfigurationProperty("name", IsRequired=true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		/// <summary>
		/// Gets or sets the representation code of the lookup.
		/// </summary>
		[ConfigurationProperty("representationCode", IsRequired = true)]
		public object RepresentationCode
		{
			get { return (string)this["representationCode"]; }
			set { this["representationCode"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.Name; }
		}

		/// <summary>
		/// Gets or sets the value of the lookup.
		/// </summary>
		[ConfigurationProperty("value", IsRequired = true)]
		public string Value
		{
			get { return (string)this["value"]; }
			set { this["value"] = value; }
		}

		#endregion
	}
}
