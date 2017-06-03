using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	/// <summary>
	/// Represents validation exceptions that may occur.
	/// </summary>
	public class ValidateException : BaseException
	{
		#region " Constructors "

		/// <summary>
		/// Creates the exception with the message.
		/// </summary>
		/// <param name="message">The message.</param>
		public ValidateException(string message)
			: base(message) { }

		/// <summary>
		/// Creates the exception with a message and inner exception.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerEx">The inner exception.</param>
		public ValidateException(string message, Exception innerEx)
			: base(message, innerEx) { }

		/// <summary>
		/// Creates the exception with serialization details.
		/// </summary>
		/// <param name="info">The information about the serialization.</param>
		/// <param name="context">The streaming context.</param>
		protected ValidateException(SerializationInfo info, StreamingContext context) 
			: base(info, context) { }

		#endregion
	}
}
