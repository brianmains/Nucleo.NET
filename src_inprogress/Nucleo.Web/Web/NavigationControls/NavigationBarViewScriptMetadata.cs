using System;
using System.Web.UI;


namespace Nucleo.Web.NavigationControls
{
	public class NavigationBarViewScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(NavigationBarView), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(NavigationBarView), ScriptMode.Release));
#endif

			return list;
		}
	}
}
