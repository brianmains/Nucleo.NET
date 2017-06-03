using System;
using System.Web.UI;


namespace Nucleo.Web.ValidationControls
{
	public class BaseValidatorScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			return new ScriptReferencingRequestDetailsCollection(
				new ScriptReferencingRequestDetails(typeof(BaseValidator), System.Web.UI.ScriptMode.Auto));
		}
	}
}
