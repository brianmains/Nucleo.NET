using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Nucleo.Exceptions
{
	/// <summary>
	/// Represents an exception thrown when a presenter is not found.
	/// </summary>
	public class PresenterNotFoundException : BaseException
	{
		public PresenterNotFoundException()
			: base("The presenter could not be found.") { }

		public PresenterNotFoundException(string presenterName)
			: base(string.Format("The presenter '{0}' could not be found.", presenterName)) { }

		public PresenterNotFoundException(string presenterName, Exception innerEx)
			: base(string.Format("The presenter '{0}' could not be found.", presenterName), innerEx) { }

#if SILVERLIGHT
#else
		protected PresenterNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
#endif
	}
}
