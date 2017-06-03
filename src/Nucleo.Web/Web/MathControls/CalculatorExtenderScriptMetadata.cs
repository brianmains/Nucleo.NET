using System;
using System.Web.UI;


namespace Nucleo.Web.MathControls
{
	public class CalculatorExtenderScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatorExtender), ScriptMode.Debug));
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatorExtender).Assembly.FullName, "Nucleo.WebUtilities", ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatorExtender), ScriptMode.Release));
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatorView).Assembly.FullName, "Nucleo.WebUtilities", ScriptMode.Release));
#endif

			return list;
		}
	}
}
