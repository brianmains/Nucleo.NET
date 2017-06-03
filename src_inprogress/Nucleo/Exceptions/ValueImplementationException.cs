using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	public class ValueImplementationException : BaseException
	{
		#region " Constructors "

		/// <summary>
		/// Creates the exception with a message.
		/// </summary>
		/// <param name="reference">The reference to whatever isn't implemented.</param>
		public ValueImplementationException(string method, object value)
			: base("The condition for method " + method + " has not been implemented for this value: " +
				((value != null) ? value.ToString() : "NULL")) { }

		/// <summary>
		/// Creates the exception with a message and inner exception.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">THe inner exception.</param>
		/// <param name="reference">The reference to whatever isn't implemented.</param>
		public ValueImplementationException(string method, object value, Exception innerEx)
			: base("The condition for method " + method + " has not been implemented for this value: " +
				((value != null) ? value.ToString() : "NULL"), innerEx) { }

		/// <summary>
		/// Creates the exception with serialization details.
		/// </summary>
		/// <param name="info">The information about the serialization.</param>
		/// <param name="context">The streaming context.</param>
		protected ValueImplementationException(SerializationInfo info, StreamingContext context) 
			: base(info, context) { }

		#endregion
	}
}
