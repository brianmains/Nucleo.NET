using System;
using System.Collections.Generic;
using System.Reflection;
using Nucleo.Collections;


namespace Nucleo.ObjectModel
{
	/// <summary>
	/// Represents a reader to inflect, using reflection, upon an object.  Useful for ASP.NET-MVC-style development, which supports passing an object and reflecting its values.
	/// </summary>
	public class ObjectReader
	{
		private ObjectKeyedDictionary _attributes = null;
		


		#region " Properties "

		/// <summary>
		/// Gets the attributes that were read.
		/// </summary>
		public ObjectKeyedDictionary Attributes
		{
			get
			{
				if (_attributes == null)
					_attributes = new ObjectKeyedDictionary();

				return _attributes;
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the reader.
		/// </summary>
		public ObjectReader() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Reads the attributes of the object.
		/// </summary>
		/// <param name="attributes">The object to get the attributes from.</param>
		public void ReadAttributes(object attributes)
		{
			PropertyInfo[] properties = attributes.GetType().GetProperties();

			foreach (PropertyInfo property in properties)
			{
				if (!property.CanRead)
					continue;

				this.Attributes.Add(property.Name, property.GetValue(attributes, null));
			}
		}

		#endregion
	}
}
