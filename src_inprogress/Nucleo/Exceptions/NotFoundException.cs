using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	public class NotFoundException : BaseException
	{
		#region " Constructors "

		/// <summary>
		/// Creates the exception with a message.
		/// </summary>
		/// <param name="message">The message.</param>
		public NotFoundException(string message)
			: base(message) { }

		/// <summary>
		/// Creates the exception with a message and inner exception.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerEx">THe inner exception.</param>
		public NotFoundException(string message, Exception innerEx)
			: base(message, innerEx) { }

#if SILVERLIGHT
#else
		/// <summary>
		/// Creates the exception with serialization details.
		/// </summary>
		/// <param name="info">The information about the serialization.</param>
		/// <param name="context">The streaming context.</param>
		protected NotFoundException(SerializationInfo info, StreamingContext context) 
			: base(info, context) { }
#endif

		#endregion
	}
}
