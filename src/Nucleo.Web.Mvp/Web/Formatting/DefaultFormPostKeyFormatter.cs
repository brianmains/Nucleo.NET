using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Formatting
{
	public class DefaultFormPostKeyFormatter : IFormPostKeyFormatter
	{
		#region " Methods "

		/// <summary>
		/// Gets the ID of the control.
		/// </summary>
		/// <param name="control">The control to format the ID for.</param>
		/// <returns>The formatted ID.</returns>
		public string GetId(string formPostKey)
		{
			if (string.IsNullOrEmpty(formPostKey))
				throw new ArgumentNullException("formPostKey");

			return formPostKey;
		}

		#endregion
	}
}
