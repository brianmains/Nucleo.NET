using System;
using System.Web.UI;


namespace Nucleo.Web.MappingControls
{
	public class ControlMappingExtenderScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(ControlMappingExtender), ScriptMode.Debug));
			list.Add(new ScriptReferencingRequestDetails(typeof(ControlMappingExtender).Assembly.FullName, "Nucleo.WebUtilities", ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(ControlMappingExtender), ScriptMode.Release));
			list.Add(new ScriptReferencingRequestDetails(typeof(ControlMappingExtender).Assembly.FullName, "Nucleo.WebUtilities", ScriptMode.Release));
#endif

			return list;
		}
	}
}
