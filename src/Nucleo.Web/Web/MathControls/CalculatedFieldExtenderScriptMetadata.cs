using System;
using System.Web.UI;


namespace Nucleo.Web.MathControls
{
	public class CalculatedFieldExtenderScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatedFieldExtender), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(CalculatedFieldExtender), ScriptMode.Release));
#endif

			return list;
		}
	}
}
