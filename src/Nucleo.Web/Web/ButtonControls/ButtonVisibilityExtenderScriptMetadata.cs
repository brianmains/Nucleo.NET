using System;
using System.Web.UI;


namespace Nucleo.Web.ButtonControls
{
	public class ButtonVisibilityExtenderScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(ButtonVisibilityExtender), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(ButtonVisibilityExtender), ScriptMode.Release));
#endif

			return list;
		}
	}
}
