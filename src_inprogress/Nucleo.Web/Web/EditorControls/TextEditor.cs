using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.ClientState;


namespace Nucleo.Web.EditorControls
{
	[
	WebScriptMetadata(typeof(TextEditorScriptMetadata)),
	WebRenderer(typeof(TextEditorRenderer))
	]
	public class TextEditor : BaseEditorControl
	{
		#region " Events "

		/// <summary>
		/// Fires whenever the text changes in the control, when posted back to the server.
		/// </summary>
		public event EventHandler TextChanged;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the client ID for the wrapper element.
		/// </summary>
		protected internal string WrapperClientID
		{
			get { return this.ClientID + "_wrapper"; }
		}

		/// <summary>
		/// Gets the unique ID for the wrapper element.
		/// </summary>
		protected internal string WrapperUniqueID
		{
			get { return this.UniqueID + "$wrapper"; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(TextEditor), this.ClientID));
		}

		protected override void LoadClientState(ClientStateData stateData)
		{
			base.LoadClientState(stateData);

			if (stateData == null)
				return;

			if (stateData.Values.ContainsKey("hasChanges") && ((bool)stateData.Values["hasChanges"]) == true)
				this.OnTextChanged(EventArgs.Empty);
		}

		/// <summary>
		/// Loads post data values for the text value, for the text value that changed.
		/// </summary>
		/// <param name="postDataKey">The key for the control (this control).</param>
		/// <param name="postCollection">The collection of values posted.</param>
		protected override void LoadPostDataValues(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			this.Text = postCollection[postDataKey];
		}

		/// <summary>
		/// Fires the <see cref="TextChanged">TextChanged event</see> whenever the text value changes on the client.
		/// </summary>
		/// <param name="e">The details for the event.</param>
		protected virtual void OnTextChanged(EventArgs e)
		{
			if (TextChanged != null)
				TextChanged(this, e);
		}

		#endregion
	}
}
