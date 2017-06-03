using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.ButtonControls
{
	[
	TargetControlType(typeof(IButtonControl)),
	WebScriptMetadata(typeof(ButtonVisibilityExtenderScriptMetadata))
	]
	public class ButtonVisibilityExtender : BaseButtonExtender
	{
		#region " Properties "

		public bool IsVisibleInitially
		{
			get { return (bool)(ViewState["IsVisibleInitially"] ?? true); }
			set { ViewState["IsVisibleInitially"] = value; }
		}

		public string OnClientVisibilityStatusChanged
		{
			get { return (string)ViewState["OnClientVisibilityStatusChanged"]; }
			set { ViewState["OnClientVisibilityStatusChanged"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			base.GetAjaxScriptDescriptors(registrar, targetControl);

			NucleoScriptBehaviorDescriptor descriptor = registrar.AddDescriptor<NucleoScriptBehaviorDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(ButtonVisibilityExtender), targetControl.ClientID));

			if (!this.IsVisibleInitially)
				descriptor.AddProperty("isVisibleInitially", this.IsVisibleInitially);
			descriptor.AddEventIfExists("visibilityStatusChanged", this.OnClientVisibilityStatusChanged);
		}

		#endregion
	}
}
