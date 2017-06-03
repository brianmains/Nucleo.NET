using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using Nucleo.Web.Core;
using Nucleo.Web.ValidationControls.Categories;
using Nucleo.Web.ValidationControls.Results;


namespace Nucleo.Web.ValidationControls
{
	/// <summary>
	/// Represents the manager for the validation.
	/// </summary>
	public class ValidationManager : BaseAjaxControl
	{
		private AspNetValidatorCompatibilityOptions _aspNetCompatibility = null;
		private bool _isValid = false;
		private ValidationResultsCollection _validationResults = null;
		private ValidatorCollection _validators = null;



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
		/// Gets whether the manager is valid.
		/// </summary>
		public bool IsValid
		{
			get
			{
				return _isValid;
			}
		}

		public ValidationResultsCollection ValidationResults
		{
			get 
			{
				if (_validationResults == null)
					_validationResults = new ValidationResultsCollection();

				return _validationResults; 
			}
		}

		/// <summary>
		/// Gets the collection of validators.
		/// </summary>
		public ValidatorCollection Validators
		{
			get
			{
				if (_validators == null)
					_validators = new ValidatorCollection();

				return _validators;
			}
		}

		#endregion

		

		#region " Methods "

		public void AddValidationResults(ValidationResults results)
		{
			this.ValidationResults.Add(results);
		}

		public void AddValidationControl(IValidatorControl validator)
		{
			this.Validators.Add(validator);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(ValidationManager), this.ClientID));

			if (_aspNetCompatibility != null)
				descriptor.AddPropertyIfExists("aspNetCompatibility", this.AspNetCompatibility.ToJson());
		}

		protected override void GetAjaxScriptReferences(IContentRegistrar registrar)
		{
			base.GetAjaxScriptReferences(registrar);

			registrar.AddReferences(new ValidationManagerScriptMetadata().GetPrimaryScripts());
		}

		public static ValidationManager GetCurrent()
		{
			return WebSingletonManager.GetCurrent().GetEntry<ValidationManager>();
		}

		protected override void OnInit(EventArgs e)
		{
			WebSingletonManager.GetCurrent().AddEntry<ValidationManager>(this);

			base.OnInit(e);
		}

		protected override void RenderUI(BaseControlWriter writer)
		{
			ValidationManagerRenderer renderer = new ValidationManagerRenderer();
			renderer.Initialize(this, this.Page);

			renderer.Render(writer);
		}

		public void ValidateEmptyGroup()
		{
			this.ValidateGroup(string.Empty);
		}

		public void ValidateGroup(string group)
		{
			ValidatorValidationResults results = new ValidatorValidationResults();
			var validators = this.Validators.FindByGroup(group);

			foreach (IValidatorControl validator in validators)
			{
				validator.Validate(results);
			}

			var resultControls = this.ValidationResults.FindByGroup(group);
			foreach (var resultControl in resultControls)
				resultControl.LoadResult(results);
		}

		#endregion
	}
}
