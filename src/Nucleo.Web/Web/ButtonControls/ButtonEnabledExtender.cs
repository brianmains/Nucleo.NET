using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.ButtonControls
{
	[
	TargetControlType(typeof(IButtonControl)),
	WebScriptMetadata(typeof(ButtonEnabledExtenderScriptMetadata))
	]
	public class ButtonEnabledExtender : BaseButtonExtender
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets whether to enable or disable the control defined in <see cref="ReceiverControlID"/> on initial load.
		/// </summary>
		public bool IsEnabledInitially
		{
			get { return (bool)(ViewState["IsEnabledInitially"] ?? true); }
			set { ViewState["IsEnabledInitially"] = value; }
		}

		/// <summary>
		/// Gets or sets the event handler 
		/// </summary>
		public string OnClientEnabledStatusChanged
		{
			get { return (string)(ViewState["OnClientEnabledStatusChanged"] ?? null); }
			set { ViewState["OnClientEnabledStatusChanged"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			base.GetAjaxScriptDescriptors(registrar, targetControl);

			NucleoScriptBehaviorDescriptor descriptor = registrar.AddDescriptor<NucleoScriptBehaviorDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(ButtonEnabledExtender), targetControl.ClientID));

			if (!this.IsEnabledInitially)
				descriptor.AddProperty("isEnabledInitially", this.IsEnabledInitially);
			descriptor.AddEventIfExists("enabledStatusChanged", this.OnClientEnabledStatusChanged);
		}

		#endregion
	}
}
