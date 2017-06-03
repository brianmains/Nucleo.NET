using System;
using System.Web.UI;


namespace Nucleo.Web.NavigationControls
{
	public class NavigationBarItemScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(NavigationBarItem), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(NavigationBarItem), ScriptMode.Release));
#endif

			return list;
		}
	}
}
