using System;
using System.Web.UI;


namespace Nucleo.Web.AccordionControls
{
	public class AccordionItemScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
#if DEBUG
			return new ScriptReferencingRequestDetailsCollection(
				new ScriptReferencingRequestDetails(typeof(AccordionItem), ScriptMode.Debug));	
#else
			return new ScriptReferencingRequestDetailsCollection(
				new ScriptReferencingRequestDetails(typeof(AccordionItem), ScriptMode.Release));	
#endif
		}
	}
}
