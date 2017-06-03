using System;
using System.Configuration;


namespace Nucleo.Configuration
{
	/// <summary>
	/// Represents a name/value pair.
	/// </summary>
	public class NameValueElement : ConfigurationElementBase
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the name/value pair.
		/// </summary>
		[ConfigurationProperty("name", IsRequired=true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		/// <summary>
		/// Gets or sets the value of the name/value pair.
		/// </summary>
		[ConfigurationProperty("value", IsRequired = true)]
		public object Value
		{
			get { return this["value"]; }
			set { this["value"] = value; }
		}

		/// <summary>
		/// Gets the unique key.
		/// </summary>
		protected internal override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the name/value pair.
		/// </summary>
		public NameValueElement() { }

		/// <summary>
		/// Gets the name/value pair.
		/// </summary>
		/// <param name="name">The name of the pair.</param>
		/// <param name="value">The value of the pair.</param>
		public NameValueElement(string name, object value)
		{
			this.Name = name;
			this.Value = value;
		}

		#endregion
	}
}
