using System;
using System.Web.UI;


namespace Nucleo.Web
{
	public class BaseAjaxPanelScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxPanel), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxPanel), ScriptMode.Release));
#endif

			return list;
		}
	}
}
