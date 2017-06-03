using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.MathControls
{
	public class CalculatorViewScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatorView), ScriptMode.Debug));
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatorView).Assembly.FullName, "Nucleo.WebUtilities", ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatorView), ScriptMode.Release));
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatorView).Assembly.FullName, "Nucleo.WebUtilities", ScriptMode.Release));
#endif

			return list;
		}
	}
}
