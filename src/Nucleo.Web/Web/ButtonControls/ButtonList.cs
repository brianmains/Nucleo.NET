using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Collections;
using Nucleo.Web.Repeating;


namespace Nucleo.Web.ButtonControls
{
	[WebScriptMetadata(typeof(ButtonListScriptMetadata))]
	public class ButtonList : BaseAjaxControl
	{
		#region " Properties "

		[
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public ButtonListControlCollection Buttons
		{
			get { return (ButtonListControlCollection)this.Controls; }
		}

		/// <summary>
		/// Gets a default value to specify whether all buttons should disable themselves on first click.
		/// </summary>
		[DefaultValue(null)]
		public bool? DisableOnFirstClick
		{
			get { return (bool?)ViewState["DisableOnFirstClick"]; }
			set { ViewState["DisableOnFirstClick"] = value; }
		}

		/// <summary>
		/// Gets a default value to specify how long all buttons should disable themselves on first click.
		/// </summary>
		[DefaultValue(null)]
		public int? DisableOnFirstClickTimeout
		{
			get { return (int?)ViewState["DisableOnFirstClickTimeout"]; }
			set { ViewState["DisableOnFirstClickTimeout"] = value; }
		}

		/// <summary>
		/// Gets or sets whether to disable the button until the page's client-side load event occurs.
		/// </summary>
		/// <remarks>It is recommended to allow the the user to work, but prevent them from saving or performing some button-based action, until the page has loaded (other scripts have loaded).</remarks>
		[DefaultValue(null)]
		public bool? DisableUntilPageLoad
		{
			get { return (bool?)ViewState["DisableUntilPageLoad"]; }
			set { ViewState["DisableUntilPageLoad"] = value; }
		}

		/// <summary>
		/// Gets or sets the orientation to render the button list in.
		/// </summary>
		public Orientation Orientation
		{
			get { return (Orientation)(ViewState["Orientation"] ?? Orientation.Horizontal); }
			set { ViewState["Orientation"] = value; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// This method executes whenever a child control has been added to the collection.  Establishes any default values.
		/// </summary>
		/// <param name="control">The control that was added.</param>
		/// <param name="index">The index of the control in the collection.</param>
		protected override void AddedControl(Control control, int index)
		{
			Button button = (Button)control;
			button.ParentList = this;
			//Pass along any default values
			if (this.DisableOnFirstClick.HasValue)
				button.DisableOnFirstClick = this.DisableOnFirstClick.Value;
			if (this.DisableOnFirstClickTimeout.HasValue)
				button.DisableOnFirstClickTimeout = this.DisableOnFirstClickTimeout.Value;
			if (this.DisableUntilPageLoad.HasValue)
				button.DisableUntilPageLoad = this.DisableUntilPageLoad.Value;

			base.AddedControl(control, index);
		}

		/// <summary>
		/// Sets all buttons with the same visibility group property to the visibility level specified.
		/// </summary>
		/// <param name="visibilityGroup">The group to make visible.</param>
		/// <param name="visible">Whether or not the button should be visible.</param>
		public void ChangeVisibility(string visibilityGroup, bool visible)
		{
			foreach (Button button in this.Buttons)
			{
				if (string.Compare(button.VisibilityGroup, visibilityGroup, StringComparison.CurrentCultureIgnoreCase) == 0)
					button.Visible = visible;
			}
		}

		/// <summary>
		/// Creates the customized control collection.
		/// </summary>
		/// <returns>The control collection for buttons.</returns>
		protected override ControlCollection CreateControlCollection()
		{
			return new ButtonListControlCollection(this);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(ButtonList), this.ClientID));
			descriptor.AddProperty("orientation", this.Orientation);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			//Make sure the rendering mode is the same; otherwise, errors may occur
			foreach (Button button in this.Buttons)
				button.RenderingMode = this.RenderingMode;
		}

		protected override void RemovedControl(Control control)
		{
			Button button = (Button)control;
			button.ParentList = null;

			base.RemovedControl(control);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			this.HandleManualScriptRegistering();

			base.AddAttributesToRender(writer);
			writer.RenderBeginTag(HtmlTextWriterTag.Span);

			for (int index = 0, len = this.Buttons.Count; index < len; index++)
			{
				if (this.Orientation == Orientation.Vertical)
					writer.RenderBeginTag(HtmlTextWriterTag.Div);

				this.RenderItem(writer, index);

				if (this.Orientation == Orientation.Vertical)
					writer.RenderEndTag();
			}

			writer.RenderEndTag();
		}

		private void RenderItem(HtmlTextWriter writer, int index)
		{
			Button button = this.Buttons[index];
			button.RenderControl(writer);
		}

		/// <summary>
		/// Loops through the visibility groups property of the child button and toggles the current visibility of this group.
		/// </summary>
		/// <param name="visibilityGroup">The group to make visible.</param>
		/// <param name="visible">Whether or not the button should be visible.</param>
		public void ToggleVisibility(string visibilityGroup)
		{
			foreach (Button button in this.Buttons)
			{
				if (string.Compare(button.VisibilityGroup, visibilityGroup, StringComparison.CurrentCultureIgnoreCase) == 0)
					button.Visible = !button.Visible;
			}
		}

		#endregion
	}
}
