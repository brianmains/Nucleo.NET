using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	/// <summary>
	/// Represents the base class for exceptions.
	/// </summary>
	public class BaseException : Exception
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
	}
}
