using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Nucleo.Web.ClientRegistration;
using Nucleo.Web.Templates;


namespace Nucleo.Web.DropDownControls
{
	/// <summary>
	/// Represents the drop down control.
	/// </summary>
	[
	WebLegacyRenderer(typeof(DropDownRenderer)),
	WebScriptMetadata(typeof(DropDownScriptMetadata)),
	WebCssMetadata(typeof(DropDownCssMetadata))
	]
	public class DropDown : BaseAjaxControl
	{
		private ControlElementTemplate _content = null;
		private DropDownInputOptions _inputOptions = null;
		private DropDownMenuOptions _menuOptions = null;
		private DropDownSelectorOptions _selectorOptions = null;



		#region " Properties "

		/// <summary>
		/// Gets the content of the drop down control.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		ClientProperty("content"),
		MergableProperty(false)
		]
		public ControlElementTemplate Content
		{
			get { return _content; }
			set { _content = value; }
		}

		/// <summary>
		/// Gets the options for the input control.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		ClientProperty("inputOptions"),
		MergableProperty(false)
		]
		public DropDownInputOptions InputOptions
		{
			get
			{
				if (_inputOptions == null)
					_inputOptions = new DropDownInputOptions();
				return _inputOptions;
			}
			set { _inputOptions = value; }
		}

		/// <summary>
		/// Gets the options for the menu section of the drop down.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		ClientProperty("menuOptions"),
		MergableProperty(false)
		]
		public DropDownMenuOptions MenuOptions
		{
			get
			{
				if (_menuOptions == null)
					_menuOptions = new DropDownMenuOptions();
				return _menuOptions;
			}
			set { _menuOptions = value; }
		}

		/// <summary>
		/// Gets the options for the selector section of the drop down (the drop down arrow).
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		ClientProperty("selectorOptions"),
		MergableProperty(false)
		]
		public DropDownSelectorOptions SelectorOptions
		{
			get
			{
				if (_selectorOptions == null)
					_selectorOptions = new DropDownSelectorOptions();
				return _selectorOptions;
			}
			set { _selectorOptions = value; }
		}

		/// <summary>
		/// Gets the text of the control to appear in the input area.
		/// </summary>
		/// <remarks>The text has to appear outside the input options to make it easy to tap into on the client-side.</remarks>
		[ClientProperty("text")]
		public string Text
		{
			get { return (string)ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		#endregion


		#region " Methods "

		/// <summary>
		/// Gets the control script descriptors for the drop down control.
		/// </summary>
		/// <param name="registrar">The registrar.</param>
		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(DropDown), this.ClientID));

			descriptor.AddPropertyIfExists("inputOptions", this.InputOptions);
			descriptor.AddPropertyIfExists("menuOptions", this.MenuOptions);
			descriptor.AddPropertyIfExists("selectorOptions", this.SelectorOptions);
			descriptor.AddPropertyIfExists("text", this.Text);
		}

		protected internal virtual IElementTemplate GetContent()
		{
			return this.Content;
		}

		//protected override void GetCssReferences(IContentRegistrar registrar)
		//{
		//    base.GetCssReferences(registrar);

		//    registrar.AddCssReference(new CssReferenceRequestDetails(
		//        this.Page.ClientScript.GetWebResourceUrl(this.GetType(),
		//            "Nucleo.Web.DropDownControls.DropDownStyles.css")));
		//}

		#endregion
	}
}