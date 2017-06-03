using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Exceptions
{
	public class AssertionFailedException : Exception
	{
		#region " Constructors "

		public AssertionFailedException(string message)
			: base(message) { }

		public AssertionFailedException(string message, Exception inner)
			: base(message, inner) { }

		#endregion
	}
}
