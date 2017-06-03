using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Formatting
{
	public class HungarianFormPostKeyFormatter : IFormPostKeyFormatter
	{
		#region " Methods "

		/// <summary>
		/// Gets the ID of the control without the hungarian notion.
		/// </summary>
		/// <param name="control">The control reference.</param>
		/// <returns>Gets the ID without the hungarian.</returns>
		public string GetId(string formPostKey)
		{
			if (string.IsNullOrEmpty(formPostKey))
				return null;

			for (int index = 0, len = formPostKey.Length; index < len; index++)
			{
				if (Char.IsUpper(formPostKey[index]))
					return formPostKey.Substring(index);
			}

			return formPostKey;
		}

		#endregion
	}
}
