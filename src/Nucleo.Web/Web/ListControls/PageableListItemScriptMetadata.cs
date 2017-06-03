using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.ListControls
{
	public class PageableListItemScriptMetadata : WebScriptMetadata
	{
		#region " Methods "

		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(PageableListItem), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(PageableListItem), ScriptMode.Release));
#endif

			return list;
		}

		#endregion
	}
}
