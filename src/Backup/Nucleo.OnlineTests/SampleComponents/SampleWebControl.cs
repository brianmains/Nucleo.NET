using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web;

[assembly:WebResource("Nucleo.SampleComponents.SampleWebControl.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.SampleComponents.SampleWebControl.js", "text/javascript")]

namespace Nucleo.SampleComponents
{
	[
	WebRenderer(typeof(SampleWebControlWebRenderer)),
	WebScriptMetadata(typeof(SampleWebControlScriptMetadata))
	]
	public class SampleWebControl : BaseAjaxControl
	{
		#region " Properties "

		public string AlertMessage
		{
			get { return (string)ViewState["AlertMessage"]; }
			set { ViewState["AlertMessage"] = value; }
		}

		public string Text
		{
			get { return (string)ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(SampleWebControl), this.ClientID));
			descriptor.AddPropertyIfExists("alertMessage", this.AlertMessage);
			descriptor.AddPropertyIfExists("text", this.Text);
		}

		#endregion
	}
}