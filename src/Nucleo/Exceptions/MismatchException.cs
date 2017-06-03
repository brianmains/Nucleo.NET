using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	public class MismatchException : BaseException
	{
		#region " Constructors "

		/// <summary>
		/// Creates the exception with a message.
		/// </summary>
		/// <param name="message">The message.</param>
		public MismatchException(string message)
			: base(message) { }

		/// <summary>
		/// Creates the exception with a message and inner exception.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">THe inner exception.</param>
		public MismatchException(string message, Exception innerEx)
			: base(message, innerEx) { }

		/// <summary>
		/// Creates the exception with serialization details.
		/// </summary>
		/// <param name="info">The information about the serialization.</param>
		/// <param name="context">The streaming context.</param>
		protected MismatchException(SerializationInfo info, StreamingContext context) 
			: base(info, context) { }

		#endregion
	}
}
