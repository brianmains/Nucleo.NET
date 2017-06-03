using System;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Web.ClientState;


namespace Nucleo.Web
{
	public class BaseAjaxExtenderScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxExtender).Assembly.FullName, "Nucleo.Common", ScriptMode.Debug));
			list.Add(new ScriptReferencingRequestDetails(typeof(ClientStateData), ScriptMode.Debug));
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxExtender), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxExtender).Assembly.FullName, "Nucleo.Common", ScriptMode.Release));
			list.Add(new ScriptReferencingRequestDetails(typeof(ClientStateData), ScriptMode.Release));
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxExtender), ScriptMode.Release));
#endif

			return list;
		}
	}
}
