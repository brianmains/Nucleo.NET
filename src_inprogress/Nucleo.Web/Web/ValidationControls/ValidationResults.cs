using System;
using System.ComponentModel;
using System.Web.UI;
using System.Collections.Generic;

using Nucleo.Validation;
using Nucleo.Web.ValidationControls.Categories;
using Nucleo.Web.ValidationControls.Items;
using Nucleo.Web.ValidationControls.Results;


namespace Nucleo.Web.ValidationControls
{
	/// <summary>
	/// Represents a control that can display errors, warnings, or informational messages.  
	/// </summary>
	[
	WebScriptMetadata(typeof(ValidationResultsScriptMetadata)),
	WebRenderer(typeof(ValidationResultsRenderer))
	]
	public class ValidationResults : BaseAjaxControl
	{
		private AspNetValidatorCompatibilityOptions _aspNetCompatibility = null;
		private ValidationDisplayItemCollection _items = null;
		private ValidationSession _session = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the ASP.NET compatibility options for the validation results control.  This integrates the validation results summary in with the ASP.NET validation controls.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public AspNetValidatorCompatibilityOptions AspNetCompatibility
		{
			get 
			{
				if (_aspNetCompatibility == null)
					_aspNetCompatibility = new AspNetValidatorCompatibilityOptions();

				return _aspNetCompatibility;
			}
			set { _aspNetCompatibility = value; }
		}

		/// <summary>
		/// Gets or sets the group name that's the default.
		/// </summary>
		public string DefaultGroupName
		{
			get { return (string)ViewState["DefaultGroupName"]; }
			set { ViewState["DefaultGroupName"] = value; }
		}

		/// <summary>
		/// Gets or sets the header message to use when displaying the error, warning, or informational messages.  This control isn't just for errors, so make sure your display message matches this possibility.
		/// </summary>
		public string HeaderMessage
		{
			get { return (string)ViewState["HeaderMessage"]; }
			set { ViewState["HeaderMessage"] = value; }
		}

		/// <summary>
		/// Gets the collection of items within the results.
		/// </summary>
		public ValidationDisplayItemCollection Items
		{
			get
			{
				if (_items == null)
					_items = new ValidationDisplayItemCollection(this);

				return _items;
			}
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(ValidationResults), this.ClientID));
			descriptor.AddPropertyIfExists("headerMessage", this.HeaderMessage);

			if (_aspNetCompatibility != null)
				descriptor.AddPropertyIfExists("aspNetCompatibility", this.AspNetCompatibility.ToJson());
			descriptor.AddPropertyIfExists("defaultGroupName", this.DefaultGroupName);
		}

		protected override void GetCssReferences(IContentRegistrar registrar)
		{
			base.GetCssReferences(registrar);

			registrar.AddCssReference(new CssReferenceRequestDetails(
				Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.Web.CommonStyles.css")));
		}

		internal void LoadResult(Results.ValidatorValidationResults results)
		{
			var items = results.GetItems();

			foreach (var item in items)
			{
				if (item.Category.Name == ErrorValidatorCategory.CategoryName)
					this.Items.Add(new ErrorValidationDisplayItem { Message = item.Message });
				else if (item.Category.Name == WarningValidatorCategory.CategoryName)
					this.Items.Add(new WarningValidationDisplayItem { Message = item.Message });
				else if (item.Category.Name == InformationValidatorCategory.CategoryName)
					this.Items.Add(new InformationValidationDisplayItem { Message = item.Message });
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			ValidationManager mgr = ValidationManager.GetCurrent();
			mgr.AddValidationResults(this);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (_aspNetCompatibility != null && this.AspNetCompatibility.AttachToValidators)
			{
				if (!Page.IsPostBack)
					return;
				if (Page.IsValid)
					return;
				
				var validators = Page.Validators.FindByValidationGroup(this.DefaultGroupName ?? "");
				foreach (var validator in validators)
				{
					if (validator.IsValid == false)
						this.Items.Add(new ErrorValidationDisplayItem { Message = validator.ErrorMessage });
				}
			}

			
		}

		protected override void RenderUI(BaseControlWriter writer)
		{
			ValidationResultsRenderer renderer = new ValidationResultsRenderer();
			renderer.Initialize(this, this.Page);

			renderer.Render(writer);
		}

		#endregion
	}
}
