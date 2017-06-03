using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.ButtonControls
{
	public class BaseButtonExtenderScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseButtonExtender), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseButtonExtender), ScriptMode.Release));
#endif

			return list;
		}
	}
}
