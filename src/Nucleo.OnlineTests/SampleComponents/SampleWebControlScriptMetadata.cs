using System;
using System.Web.UI;
using Nucleo.Web;


namespace Nucleo.SampleComponents
{
	public class SampleWebControlScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(SampleWebControl), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(SampleWebControl), ScriptMode.Release));
#endif

			return list;
		}
	}
}