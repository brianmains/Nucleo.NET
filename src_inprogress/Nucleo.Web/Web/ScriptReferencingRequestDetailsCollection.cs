using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web
{
	public class ScriptReferencingRequestDetailsCollection : SimpleCollection<ScriptReferencingRequestDetails>
	{
		#region " Constructors "

		public ScriptReferencingRequestDetailsCollection() { }

		public ScriptReferencingRequestDetailsCollection(ScriptReferencingRequestDetails request)
		{
			this.Add(request);
		}

		public ScriptReferencingRequestDetailsCollection(IEnumerable<ScriptReferencingRequestDetails> requests)
		{
			this.AddRange(requests);
		}

		#endregion



		#region " Methods "

		public void AddRange(IEnumerable<ScriptReferencingRequestDetails> details)
		{
			foreach (ScriptReferencingRequestDetails detail in details)
				this.Add(detail);
		}

		#endregion
	}
}
