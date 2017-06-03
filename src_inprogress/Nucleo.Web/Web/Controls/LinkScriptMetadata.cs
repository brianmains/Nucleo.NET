using System;
using System.Web.UI;


namespace Nucleo.Web.Controls
{
	public class LinkScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(Link), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(Link), ScriptMode.Release));
#endif

			return list;
		}
	}
}
