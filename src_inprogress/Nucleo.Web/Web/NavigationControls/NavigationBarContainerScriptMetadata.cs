using System;
using System.Web.UI;


namespace Nucleo.Web.NavigationControls
{
	public class NavigationBarContainerScriptMetadata : WebScriptMetadata
	{
		#region " Methods "

		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(NavigationBarContainer), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(NavigationBarContainer), ScriptMode.Release));
#endif

			return list;
		}

		#endregion
	}
}
