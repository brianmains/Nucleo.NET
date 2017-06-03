using System;
using System.Web.UI;


namespace Nucleo.Web.ContainerControls
{
	public class PanelScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(Panel), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(Panel), ScriptMode.Release));
#endif

			return list;
		}
	}
}