using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.ComponentModel;

using Nucleo.Web.Tags;
using Nucleo.Web.Templates;


namespace Nucleo.Web.ListControls
{
	/// <summary>
	/// Represents an item within a pageable list.
	/// </summary>
	[
	WebLegacyRenderer(typeof(PageableListItemRenderer)),
	WebScriptMetadata(typeof(PageableListItemScriptMetadata))
	]
	public class PageableListItem : BaseAjaxControl
	{
		private ControlElementTemplate _content = null;



		#region " Properties "

		/// <summary>
		/// Gets the template for the control.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
		]
		public ControlElementTemplate Content
		{
			get { return _content; }
			set { _content = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(PageableListItem), this.ClientID));
		}

		#endregion
	}
}
