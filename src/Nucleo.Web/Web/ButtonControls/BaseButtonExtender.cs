using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.ButtonControls
{
	/// <summary>
	/// Represents the base class for button-based extenders that target another control.  For instance, on clicking the button, a derived component could target another control (say a textbox) to do something (enable/disable, hide/show, etc.).
	/// </summary>
	[
	TargetControlType(typeof(IButtonControl)),
	WebScriptMetadata(typeof(BaseButtonExtenderScriptMetadata))
	]
	public abstract class BaseButtonExtender : BaseAjaxExtender
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets whether the button posts back when clicked.  This allows the extender to alter the button, but still allow the postback.
		/// </summary>
		public bool AllowPostback
		{
			get { return (bool)(ViewState["AllowPostback"] ?? false); }
			set { ViewState["AllowPostback"] = value; }
		}

		/// <summary>
		/// Gets or sets the control that is the recipient of the button click.
		/// </summary>
		public string ReceiverControlID
		{
			get { return (string)(ViewState["ReceiverControlID"] ?? null); }
			set { ViewState["ReceiverControlID"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			base.GetAjaxScriptDescriptors(registrar, targetControl);

			NucleoScriptBehaviorDescriptor descriptor = registrar.AddDescriptor<NucleoScriptBehaviorDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(BaseButtonExtender), targetControl.ClientID));
			this.ScriptComponents.RegisterScriptComponentDescriptors(registrar, descriptor);

			if (this.AllowPostback)
				descriptor.AddProperty("allowPostback", this.AllowPostback);

			Control receiverControl = ControlUtility.FindControl(this, this.ReceiverControlID);
			if (receiverControl != null)
				descriptor.AddElementProperty("receiverControl", receiverControl.ClientID);
			else
				throw new NullReferenceException("Control for element " + ReceiverControlID + " cannot be found.");
		}

		protected override void OnPreRender(EventArgs e)
		{
			if (string.IsNullOrEmpty(this.ReceiverControlID))
				throw new ArgumentNullException("ReceiverControlID", "The receiver control ID must be provided");

			base.OnPreRender(e);
		}

		#endregion
	}
}
