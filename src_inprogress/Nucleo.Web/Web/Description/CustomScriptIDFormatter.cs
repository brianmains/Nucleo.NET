using System;
using System.Collections.Generic;


namespace Nucleo.Web.Description
{
	/// <summary>
	/// Represents a ID formatter that takes a prefix/suffix to wrap the ID's with.
	/// </summary>
	public class CustomScriptIDFormatter : IScriptIDFormatter
	{
		private string _prefix = "";
		private string _suffix = "";



		#region " Properties "

		/// <summary>
		/// Gets the prefix for the ID format.
		/// </summary>
		/// <remarks>Set the prefix in the constructor.</remarks>
		public string Prefix
		{
			get { return _prefix; }
		}

		/// <summary>
		/// Gets the suffix for the ID format.
		/// </summary>
		public string Suffix
		{
			get { return _suffix; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the formatter with the prefix and suffix.
		/// </summary>
		/// <param name="prefix">The prefix to wrap the ID with.</param>
		/// <param name="suffix">The suffix to wrap the ID with.</param>
		public CustomScriptIDFormatter(string prefix, string suffix)
		{
			_prefix = prefix;
			_suffix = suffix;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the ID with the applied prefix and suffix.
		/// </summary>
		/// <param name="baseID">The core ID.</param>
		/// <param name="formatType">The type to format as (ignored).</param>
		/// <returns>The applied format.</returns>
		public string GetFormattedID(string baseID, ScriptIDFormatting formatType)
		{
			return (_prefix ?? "") + baseID + (_suffix ?? "");
		}

		#endregion
	}
}
