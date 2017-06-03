using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a collection of CSS request details.
	/// </summary>
	public class CssReferenceRequestDetailsCollection : SimpleCollection<CssReferenceRequestDetails>
	{
		#region " Constructors "

		/// <summary>
		/// Creates the CSS request details collection.
		/// </summary>
		public CssReferenceRequestDetailsCollection() { }

		/// <summary>
		/// Creates the CSS request details collection with a single CSS request.
		/// </summary>
		public CssReferenceRequestDetailsCollection(CssReferenceRequestDetails request)
		{
			this.Add(request);
		}

		/// <summary>
		/// Creates the CSS request details collection with a collection of CSS requests.
		/// </summary>
		public CssReferenceRequestDetailsCollection(IEnumerable<CssReferenceRequestDetails> requests)
		{
			this.AddRange(requests);
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a enumerable collection of CSS references.
		/// </summary>
		/// <param name="details"></param>
		public void AddRange(IEnumerable<CssReferenceRequestDetails> details)
		{
			foreach (CssReferenceRequestDetails detail in details)
				this.Add(detail);
		}

		#endregion
	}
}
