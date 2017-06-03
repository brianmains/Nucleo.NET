using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.Description
{
	public class MSScriptIDFormatter : IScriptIDFormatter
	{
		#region " Methods "

		public string GetFormattedID(string baseID, ScriptIDFormatting formatType)
		{
			if (formatType == ScriptIDFormatting.Element)
				return string.Concat("$get(\"", baseID, "\")");
			else if (formatType == ScriptIDFormatting.Control || formatType == ScriptIDFormatting.Extender)
				return string.Concat("$find(\"", baseID, "\")");
			else
				return baseID;
		}

		#endregion
	}
}
