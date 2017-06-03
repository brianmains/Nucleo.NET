using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web
{
	/// <summary>
	/// Gets a collection of CSS files.  This is not a class you need to use directly for any custom controls/extenders, but is a collection you can use for other purposes.
	/// </summary>
	public class CssReferenceCollection  : SimpleCollection<CssReference>
	{
		/// <summary>
		/// Gets CSS references using the request details object.  This object contains the CSS needs for a particular request.
		/// </summary>
		/// <param name="details">The request details to find CSS files for.</param>
		/// <returns>A matching CSS file or null.</returns>
		public CssReference GetByDetails(CssReferenceRequestDetails details)
		{
			if (details == null)
				throw new ArgumentNullException("details");

			for (int index = 0, len = this.Count; index < len; index++)
			{
				CssReference reference = this[index];

				if (string.Compare(details.Path, reference.Path, StringComparison.InvariantCultureIgnoreCase) == 0)
					return reference;
			}

			return null;
		}
	}
}
