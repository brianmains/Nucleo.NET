using System;
using System.Web.UI;


namespace Nucleo.Web.Controls
{
	[WebScriptMetadataRelationship(typeof(CommonScriptMetadata))]
	public class CheckScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(Check), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(Check), ScriptMode.Release));
#endif

			return list;
		}
	}
}
