using System;
using System.Web.UI;


namespace Nucleo.Web.EditorControls
{
	public class TextEditorScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(TextEditor), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(TextEditor), ScriptMode.Release));
#endif

			return list;
		}
	}
}
