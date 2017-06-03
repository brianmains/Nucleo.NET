using System;
using System.Web.UI;

using Nucleo.Web.ClientState;


namespace Nucleo.Web
{
	public class BaseAjaxControlScriptMetadata : WebScriptMetadata
	{
		#region " Methods "

		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection details = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			details.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxControl).Assembly.FullName, "Nucleo.Common", ScriptMode.Debug));
			details.Add(new ScriptReferencingRequestDetails(typeof(ClientStateData), ScriptMode.Debug));
			details.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxControl), ScriptMode.Debug));
#else
			details.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxControl).Assembly.FullName, "Nucleo.Common", ScriptMode.Release));
			details.Add(new ScriptReferencingRequestDetails(typeof(ClientStateData), ScriptMode.Release));
			details.Add(new ScriptReferencingRequestDetails(typeof(BaseAjaxControl), ScriptMode.Release));
#endif

			return details;
		}

		#endregion
	}
}
