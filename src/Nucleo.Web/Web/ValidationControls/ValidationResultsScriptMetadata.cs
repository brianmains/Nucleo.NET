using System;
using System.Web.UI;

using Nucleo.Web.ValidationControls.Items;

namespace Nucleo.Web.ValidationControls
{
	public class ValidationResultsScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(ValidationResults), ScriptMode.Debug));
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseValidationDisplayItem).Assembly.GetName().Name, "Nucleo.Web.ValidationControls.Categories.Categories.js", ScriptMode.Debug));
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseValidationDisplayItem).Assembly.GetName().Name, "Nucleo.Web.ValidationControls.Items.DisplayItems.js", ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(ValidationResults), ScriptMode.Release));
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseValidationDisplayItem).Assembly.GetName().Name, "Nucleo.Web.ValidationControls.Categories.Categories.js", ScriptMode.Release));
			list.Add(new ScriptReferencingRequestDetails(typeof(BaseValidationDisplayItem).Assembly.GetName().Name, "Nucleo.Web.ValidationControls.Items.DisplayItems.js", ScriptMode.Release));
#endif

			return list;
		}
	}
}
