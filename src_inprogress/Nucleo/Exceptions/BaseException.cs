using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	/// <summary>
	/// Represents the base class for exceptions.
	/// </summary>
	public class BaseException : ApplicationException
	{
		/// <summary>
		/// Creates the exception with a message.
		/// </summary>
		/// <param name="message">The message for the exception.</param>
		public BaseException(string message) : base(message) { }

		/// <summary>
		/// Creates the exception with a message and inner exception.
		/// </summary>
		/// <param name="message">The message for the exception.</param>
		/// <param name="ex">The inner exception.</param>
		public BaseException(string message, Exception ex) : base(message, ex) { }

		/// <summary>
		/// Creates the exception with serialization details.
		/// </summary>
		/// <param name="info">The information about the serialization.</param>
		/// <param name="context">The streaming context.</param>
		protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
