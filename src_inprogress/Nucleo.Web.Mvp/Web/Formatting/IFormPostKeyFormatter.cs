using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Formatting
{
	/// <summary>
	/// Represents a formatter that can format control ID's for various reasons.
	/// </summary>
	public interface IFormPostKeyFormatter
	{
		/// <summary>
		/// Gets the formatted ID.
		/// </summary>
		/// <param name="control">The control to format.</param>
		/// <returns>The format string.</returns>
		string GetId(string key);
	}
}
