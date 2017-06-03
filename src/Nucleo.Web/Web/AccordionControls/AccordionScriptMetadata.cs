using System;
using System.Web.UI;

namespace Nucleo.Web.AccordionControls
{
	public class AccordionScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(Accordion), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(Accordion), ScriptMode.Release));
#endif

			return list;
		}
	}
}