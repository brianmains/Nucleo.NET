using System;
using System.Web.UI;


namespace Nucleo.Web.ValidationControls
{
	public class ValidationManagerScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			return new ScriptReferencingRequestDetailsCollection(
				new []
				{
					new ScriptReferencingRequestDetails(typeof(ValidationManager).Assembly.GetName().Name, "Nucleo.Web.Inspectors.ModelBindingInspectors.js", ScriptMode.Auto),
					new ScriptReferencingRequestDetails(typeof(ValidationManager).Assembly.GetName().Name, "Nucleo.Web.ValidationControls.Categories.Categories.js", ScriptMode.Auto),
					new ScriptReferencingRequestDetails(typeof(ValidationManager).Assembly.GetName().Name, "Nucleo.Web.ValidationControls.Items.DisplayItems.js", ScriptMode.Auto),
					new ScriptReferencingRequestDetails(typeof(ValidationManager), ScriptMode.Auto)
				});
		}
	}
}
