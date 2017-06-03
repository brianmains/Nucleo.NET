using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.ButtonControls
{
	public class ButtonEnabledExtenderScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(ButtonEnabledExtender), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(ButtonEnabledExtender), ScriptMode.Release));
#endif

			return list;
		}
	}
}
