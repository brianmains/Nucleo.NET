using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.Description
{
	public interface IScriptIDFormatter
	{
		string GetFormattedID(string baseID, ScriptIDFormatting formatType);
	}
}
