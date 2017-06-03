using System;
using System.Web.UI;


namespace Nucleo.Web.MappingControls
{
	public class ControlMappingManagerScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(ControlMappingManager), ScriptMode.Debug));
			list.Add(new ScriptReferencingRequestDetails(typeof(ControlMappingManager).Assembly.FullName, "Nucleo.Web.MappingControls.OperationNeededEventArgs", ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(ControlMappingManager), ScriptMode.Release));
			list.Add(new ScriptReferencingRequestDetails(typeof(ControlMappingManager).Assembly.FullName, "Nucleo.Web.MappingControls.OperationNeededEventArgs", ScriptMode.Release));
#endif

			return list;
		}
	}
}
