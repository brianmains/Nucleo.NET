using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.NavigationControls
{
	/// <summary>
	/// Represents the view of the navigation bar selections; this has to be programmatically controlled by you at the moment.
	/// </summary>
	[WebScriptMetadata(typeof(NavigationBarViewScriptMetadata))]
	public class NavigationBarView : BaseAjaxControl
	{
		#region " Properties "

		/// <summary>
		/// Gets the ID of the container control it resides in.
		/// </summary>
		public string ContainerControlID
		{
			get { return (string)ViewState["ContainerControlID"]; }
			set { ViewState["ContainerControlID"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(NavigationBarView), this.ClientID));
			descriptor.AddComponentPropertyIfExists("containerControl", ControlUtility.FindControl(this, this.ContainerControlID).ClientID);
		}

		#endregion
	}
}
