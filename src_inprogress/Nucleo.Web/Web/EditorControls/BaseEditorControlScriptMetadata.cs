using System;
using System.Web.UI;


namespace Nucleo.Web.EditorControls
{
	public class BaseEditorControlScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseEditorControl), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseEditorControl), ScriptMode.Release));
#endif

			return list;
		}
	}
}
