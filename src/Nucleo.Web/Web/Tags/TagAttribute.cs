using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.Tags
{
	/// <summary>
	/// Represents an attribute of a tag.
	/// </summary>
	/// <example>
	/// var tag = new TagAttribute("class", "inputbox");
	/// tag.Value = "Newbox";
	/// </example>
	public class TagAttribute
	{
		private string _name = null;
		private object _value = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the tag attribute.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets or sets the value of the tag attribute.
		/// </summary>
		public object Value
		{
			get { return _value; }
			set { _value = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the attribute with the name of the attribute and it initial value.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="value">The initial value.</param>
		public TagAttribute(string name, object value)
		{
			_name = name;
			_value = value;
		}

		#endregion
	}
}
