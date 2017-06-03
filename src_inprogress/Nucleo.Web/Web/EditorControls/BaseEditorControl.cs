using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.EditorControls
{
	[
	
	WebScriptMetadata(typeof(BaseEditorControlScriptMetadata))
	]
	public abstract class BaseEditorControl : BaseAjaxControl, IEditorControl
	{
		private bool _hasChanges = false;



		#region " Properties "

		/// <summary>
		/// Gets or sets the state of the control, whether in normal state or error state.  Depending on the state produces a different visual cue to the user.
		/// </summary>
		public EditorCurrentState CurrentState
		{
			get { return (EditorCurrentState)(ViewState["CurrentState"] ?? EditorCurrentState.Normal); }
			set { ViewState["CurrentState"] = value; }
		}

		/// <summary>
		/// Gets whether the control has had any input changes.
		/// </summary>
		public bool HasChanges
		{
			get { return _hasChanges; }
		}

		bool IEditorControl.HasChanges
		{
			get { return this.HasChanges; }
		}

		string IEditorControl.ID
		{
			get { return this.ID; }
			set { this.ID = value; }
		}

		/// <summary>
		/// Gets or sets whether the control is read only.
		/// </summary>
		public bool ReadOnly
		{
			get { return (bool)(ViewState["ReadOnly"] ?? false); }
			set { ViewState["ReadOnly"] = value; }
		}

		bool IEditorControl.ReadOnly
		{
			get { return this.ReadOnly; }
			set { this.ReadOnly = value; }
		}

		/// <summary>
		/// Gets or sets the text of the control.
		/// </summary>
		public virtual string Text
		{
			get { return (string)ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		string ITextControl.Text
		{
			get { return this.Text; }
			set { this.Text = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);
			
			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(BaseEditorControl), this.ClientID));

			if (this.CurrentState != EditorCurrentState.Normal)
				descriptor.AddProperty("currentState", this.CurrentState);
			if (this.ReadOnly)
				descriptor.AddProperty("readOnly", this.ReadOnly);
			descriptor.AddPropertyIfExists("text", this.Text);
		}

		protected override void GetCssReferences(IContentRegistrar registrar)
		{
			base.GetCssReferences(registrar);

			registrar.AddCssReference(new CssReferenceRequestDetails(
				Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.Web.CommonStyles.css")));
		}

		#endregion
	}
}
