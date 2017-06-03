using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.ButtonControls
{
	public class ButtonListScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(ButtonList), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(ButtonList), ScriptMode.Release));
#endif

			return list;
		}
	}
}
