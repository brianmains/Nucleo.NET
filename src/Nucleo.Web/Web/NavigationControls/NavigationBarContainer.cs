using System;
using System.ComponentModel;
using System.Web.UI;


namespace Nucleo.Web.NavigationControls
{
	[
	WebScriptMetadata(typeof(NavigationBarContainerScriptMetadata)),
	WebLegacyRenderer(typeof(NavigationBarContainerRenderer))
	]
	public class NavigationBarContainer : BaseAjaxControl
	{
		#region " Properties "

		[
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public NavigationBarCollection Bars
		{
			get { return (NavigationBarCollection)this.Controls; }
		}

		#endregion



		#region " Methods "

		protected override void AddedControl(Control control, int index)
		{
			NavigationBar bar = (NavigationBar)control;
			bar.SetOwner(this);

			base.AddedControl(control, index);
		}

		protected override ControlCollection CreateControlCollection()
		{
			return new NavigationBarCollection(this);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(NavigationBarContainer), this.ClientID));
		}

		protected override void GetCssReferences(IContentRegistrar registrar)
		{
			registrar.AddCssReference(new CssReferenceRequestDetails(
					Page.ClientScript.GetWebResourceUrl(this.GetType(),
						"Nucleo.Web.ContentControls.NavigationBarStyles.css")));
		}

		protected override void RemovedControl(Control control)
		{
			NavigationBar bar = (NavigationBar)control;
			bar.SetOwner(this);

			base.RemovedControl(control);
		}

		#endregion
	}
}
