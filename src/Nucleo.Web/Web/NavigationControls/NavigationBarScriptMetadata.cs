using System;
using System.Web.UI;


namespace Nucleo.Web.NavigationControls
{
	public class NavigationBarScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(NavigationBar), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(NavigationBar), ScriptMode.Release));
#endif

			return list;
		}
	}
}
