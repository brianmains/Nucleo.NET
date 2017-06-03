using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	/// <summary>
	/// Represents an exception for a property.
	/// </summary>
	public class PropertyException : BaseException
	{
		/// <summary>
		/// Creates the exception with a property object/property.
		/// </summary>
		/// <param name="objectType">The type of object.</param>
		/// <param name="propertyName">The name of the property.</param>
		public PropertyException(Type objectType, string propertyName)
			: base(string.Format("The object of type '{0}' cannot write to property '{1}'.", objectType.Name, propertyName)) { }

		/// <summary>
		/// Creates the exception with a message and inner exception.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerEx">THe inner exception.</param>
		public PropertyException(string message, Exception innerEx)
			: base(message, innerEx) { }
	}
}
