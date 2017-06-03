using System;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	public class AssertionFailedException : ApplicationException
	{
		#region " Constructors "

		public AssertionFailedException(string message)
			: base(message) { }

		public AssertionFailedException(string message, Exception inner)
			: base(message, inner) { }

		protected AssertionFailedException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }

		#endregion
	}
}
