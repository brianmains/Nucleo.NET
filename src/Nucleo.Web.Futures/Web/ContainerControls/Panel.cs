using System;
using System.Web.UI;
using System.ComponentModel;
using System.Collections.Generic;

using Nucleo.Web;
using Nucleo.Web.ContainerControls.ClientSettings;
using Nucleo.Web.Templates;


namespace Nucleo.Web.ContainerControls
{
	/// <summary>
	/// Represents a panel that contains content.
	/// </summary>
	[
	WebLegacyRenderer(typeof(PanelRenderer)),
	WebScriptMetadata(typeof(PanelScriptMetadata))
	]
	public class Panel : BaseAjaxControl
	{
		private ControlElementTemplate _content = null;
		private PanelDragDropOptions _dragDrop = null;
		private PanelHoverOptions _hovering = null;
		private PanelModalOptions _modal = null;
		private PanelResizeOptions _resizing = null;
		private PanelTimeSensitivityOptions _timeSensitivity = null;



		#region " Events "


		#endregion

		

		#region " Properties "

		/// <summary>
		/// Gets or sets the content of the panel.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public ControlElementTemplate Content
		{
			get { return _content; }
			set { _content = value; }
		}

		/// <summary>
		/// Gets or sets the drag/drop options of the panel.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public PanelDragDropOptions DragDrop
		{
			get { return _dragDrop; }
			set { _dragDrop = value; }
		}
		
		/// <summary>
		/// Gets or sets the hovering options for the panel.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public PanelHoverOptions Hovering
		{
			get { return _hovering; }
			set { _hovering = value; }
		}

		/// <summary>
		/// Gets or sets the modal options of the panel.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public PanelModalOptions Modal
		{
			get { return _modal; }
			set { _modal = value; }
		}

		/// <summary>
		/// Gets or sets the resizing options for the panel.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public PanelResizeOptions Resizing
		{
			get { return _resizing; }
			set { _resizing = value; }
		}

		/// <summary>
		/// Gets or sets the time sensitivity.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public PanelTimeSensitivityOptions TimeSensitivity
		{
			get { return _timeSensitivity; }
			set { _timeSensitivity = value; }
		}

		/// <summary>
		/// Gets or sets the title to appear overtop the panel.
		/// </summary>
		public string Title
		{
			get { return (string)ViewState["Title"]; }
			set { ViewState["Title"] = value; }
		}

		/// <summary>
		/// Gets or sets the visibility of the panel.  If <see cref="TimeSensitivity">TimeSensitivity options</see> are specified, these overtake the base definition.
		/// </summary>
		public override bool Visible
		{
			get 
			{
				if (_timeSensitivity != null && !_timeSensitivity.IsVisible)
					return false;

				return base.Visible; 
			}
			set { base.Visible = value; }
		}

		#endregion



		#region " Methods "

		protected override void AddScriptComponents()
		{
			base.AddScriptComponents();

			if (_dragDrop != null && _dragDrop.ClientEvents != null)
				this.ScriptComponents.Add(_dragDrop.ClientEvents);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(Panel), this.ClientID));

			if (_dragDrop != null)
				descriptor.AddProperty("dragDrop", _dragDrop.ToJson());
			if (_hovering != null)
				descriptor.AddProperty("hovering", _hovering.ToJson());
			if (_modal != null)
				descriptor.AddProperty("modal", _modal.ToJson());
			if (_resizing != null)
				descriptor.AddProperty("resizing", _resizing.ToJson());
			descriptor.AddPropertyIfExists("title", this.Title);
		}

		protected override void GetCssReferences(IContentRegistrar registrar)
		{
			base.GetCssReferences(registrar);

			registrar.AddCssReference(new CssReferenceRequestDetails(
				Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.Web.CommonStyles.css")));
		}

		protected override void OnPreRender(EventArgs e)
		{
			if (!Visible)
				this.RenderingMode = RenderMode.ServerOnly;

			base.OnPreRender(e);

			if (_hovering != null)
			{
				//Ensure control ID us the client ID
				if (!string.IsNullOrEmpty(_hovering.ControlID))
				{
					Control control = ControlUtility.FindControl(this, _hovering.ControlID);
					if (control != null)
						_hovering.ControlID = control.ClientID;
				}
			}

			if (_modal != null)
			{
				//Ensure a client ID
				if (!string.IsNullOrEmpty(_modal.OKButtonID))
				{
					Control okControl = ControlUtility.FindControl(this, _modal.OKButtonID);
					if (okControl == null)
						throw new ArgumentNullException(string.Format("The OK button control with ID of '{0}' could not be found.", _modal.OKButtonID));

					_modal.OKButtonID = okControl.ClientID;
				}
			}
		}

		#endregion
	}
}