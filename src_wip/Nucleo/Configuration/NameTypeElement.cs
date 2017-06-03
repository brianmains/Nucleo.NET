using System;
using System.Configuration;


namespace Nucleo.Configuration
{
	/// <summary>
	/// Represents a collection of name and type elements.  This is useful for storing reference information that can be instantiated dynamically.
	/// </summary>
	public class NameTypeElement : ConfigurationElementBase
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the name/type pair.  The name represents a unique key to identify a type.
		/// </summary>
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		/// <summary>
		/// Gets or sets the type of the name/type pair.  This represents a class of some sort that will be instantiated.
		/// </summary>
		[ConfigurationProperty("type", IsRequired = true)]
		public string Type
		{
			get { return (string)this["type"]; }
			set { this["type"] = value; }
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
		/// Creates the name/type pairing.
		/// </summary>
		public NameTypeElement() { }

		/// <summary>
		/// Creates the name/type pairing.
		/// </summary>
		/// <param name="name">The name of the pair.</param>
		/// <param name="type">The type of the pair.</param>
		public NameTypeElement(string name, string type)
		{
			this.Name = name;
			this.Type = type;
		}

		#endregion
	}
}
