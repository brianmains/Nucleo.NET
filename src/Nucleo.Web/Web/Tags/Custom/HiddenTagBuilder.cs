using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.Tags.Custom
{
	/// <summary>
	/// Represents a builder to create a hidden tag.
	/// </summary>
	/// <example>
	/// var builder = HiddenTagBuilder.Create("keyfield", 2);
	/// var element = builder.ToElement(); //Returns hidden field as element
	/// </example>
	public class HiddenTagBuilder : ICustomTagBuilder
	{
		private string _name = null;
		private object _value = null;



		#region " Constructors "

		/// <summary>
		/// Creates the builder internally.
		/// </summary>
		/// <param name="name">The name to create with.</param>
		/// <param name="value">The value to store.</param>
		private HiddenTagBuilder(string name, object value)
		{
			_name = name;
			_value = value;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates the builder using the name and value for the hidden tag.
		/// </summary>
		/// <param name="name">The name of the hidden field.</param>
		/// <param name="value">The value to store in the hidden field.</param>
		/// <returns>The builder.</returns>
		/// <example>
		/// var builder = HiddenTagBuilder.Create("key", 1);
		/// </example>
		public static HiddenTagBuilder Create(string name, object value)
		{
			if (name == null)
				throw new ArgumentNullException("name");

			return new HiddenTagBuilder(name, value);
		}

		/// <summary>
		/// Gets the element from the builder.
		/// </summary>
		/// <returns>The element to get.</returns>
		public TagElement ToElement()
		{
			TagElement element = new TagElement("INPUT");
			element.Attributes.AppendAttribute("type", "hidden")
				.AppendAttribute("id", _name)
				.AppendAttribute("name", _name)
				.AppendAttribute("value", _value);

			return element;
		}

		#endregion
	}
}
