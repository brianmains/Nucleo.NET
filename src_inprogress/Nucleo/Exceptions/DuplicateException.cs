using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	/// <summary>
	/// Represents an exception that fires when a duplication occurs.
	/// </summary>
	public class DuplicateException : BaseException
	{
		#region " Constructors "

		/// <summary>
		/// Creates the exception with a default message.
		/// </summary>
		public DuplicateException()
			: base("A duplicate has been detected.") { }

		/// <summary>
		/// Creates the exception with a message.
		/// </summary>
		/// <param name="message">The message.</param>
		public DuplicateException(string message) 
			: base(message) { }

		/// <summary>
		/// Creates the exception with a message and inner exception.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">THe inner exception.</param>
		public DuplicateException(string message, Exception inner)
			: base(message, inner) { }

		/// <summary>
		/// Creates the exception with serialization details.
		/// </summary>
		/// <param name="info">The information about the serialization.</param>
		/// <param name="context">The streaming context.</param>
		public DuplicateException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }

		#endregion
	}
}
