using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	/// <summary>
	/// Represents the exception that's thrown for the guard helper.
	/// </summary>
	public class GuardException : BaseException
	{
		#region " Constructors "

		/// <summary>
		/// Creates the exception with a message.
		/// </summary>
		/// <param name="message">The message.</param>
		public GuardException(string message) 
			: base("A guard condition failed for the following reason: " + message) { }

		/// <summary>
		/// Creates the exception with a message and inner exception.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">THe inner exception.</param>
		public GuardException(string message, Exception inner)
			: base("A guard condition failed for the following reason: " + message, inner) { }

		#endregion
	}
}
