using System;
using System.Collections.Generic;


namespace Nucleo.Web.Description
{
	/// <summary>
	/// Gets the collection of element description references.
	/// </summary>
	public class ElementDescriptionCollection : Dictionary<string, string>
	{
		#region " Methods "

		/// <summary>
		/// Gets the script for the elements, using the default ID formatter of <see cref="MSScriptIDFormatter"/>.
		/// </summary>
		/// <returns>The script of element references.</returns>
		public string GetScript()
		{
			if (this.Count == 0)
				return "{}";

			return GetScript(new MSScriptIDFormatter());
		}

		/// <summary>
		/// Gets the script for the elements, using the provided ID formatter.  This will, by default, pass an ID format of <see cref="ScriptIDFormatting.Element">the element ID formatting type</see>.
		/// </summary>
		/// <param name="formatter">The formatter to format ID's with.</param>
		/// <returns>The script with the specified ID formatter.</returns>
		public string GetScript(IScriptIDFormatter formatter)
		{
			if (this.Count == 0)
				return "{}";
			if (formatter == null)
				throw new ArgumentNullException("formatter");

			string script = "{ ";
			bool comma = false;

			foreach (KeyValuePair<string, string> element in this)
			{
				if (comma)
					script += ", ";
				else
					comma = true;

				script += element.Key + ":" + formatter.GetFormattedID(element.Value, ScriptIDFormatting.Element);
			}

			return script + " }";
		}

		#endregion
	}
}
