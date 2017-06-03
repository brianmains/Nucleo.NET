using System;
using System.ComponentModel;
using System.Web.UI;

using Nucleo.Web.Inspectors;
using Nucleo.Web.ValidationControls.Categories;
using Nucleo.Web.ValidationControls.Results;


namespace Nucleo.Web.ValidationControls
{
	/// <summary>
	/// Represents the validator that ensures the input is required.
	/// </summary>
	public class RequiredValidator : BaseValidator
	{
		#region " Properties "

		/// <summary>
		/// Gets the control being validated; returns null if the ID is null.  Null is OK, but the client-side NeedValues event must be handled for the validator to do anything.
		/// </summary>
		public Control ValidatedControl
		{
			get 
			{
				if (string.IsNullOrEmpty(this.ValidatedControlID))
					return null;

				return ControlUtility.FindControl(this, this.ValidatedControlID); 
			}
		}

		/// <summary>
		/// Gets or sets the ID of the control being validated; can be null.  Null is OK, but the client-side NeedValues event must be handled for the validator to do anything.
		/// </summary>
		public string ValidatedControlID
		{
			get { return (string)ViewState["ValidatedControlID"]; }
			set { ViewState["ValidatedControlID"] = value; }
		}
		
		#endregion



		#region " Methods "

		protected override void DoValidate(object[] values, ValidatorValidationResults results)
		{
			if (values == null)
			{
				results.AddItem(new ValidatorValidationResultItem(CategoryDefinitions.Error, base.Message));
				return;
			}

			foreach (var value in values)
			{
				if (value == null || (value is string && string.IsNullOrEmpty(value.ToString())))
				{
					results.AddItem(new ValidatorValidationResultItem(CategoryDefinitions.Error, base.Message));
					return;
				}
			}
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			var descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(RequiredValidator), this.ClientID));

			Control ctl = this.ValidatedControl;
			if (ctl == null)
				descriptor.AddElementPropertyIfExists("validatedControl", this.ValidatedControlID);
			else if (ctl is IScriptControl || ctl is IExtenderControl)
				descriptor.AddComponentProperty("validatedControl", ctl.ClientID);
			else if (ctl is Control)
				descriptor.AddElementProperty("validatedControl", ctl.ClientID);
		}

		protected override void GetAjaxScriptReferences(IContentRegistrar registrar)
		{
			base.GetAjaxScriptReferences(registrar);

			registrar.AddReference(new ScriptReferencingRequestDetails(
				typeof(RequiredValidator), ScriptMode.Auto));
		}

		protected override object[] GetValues()
		{
			Control ctl = this.ValidatedControl;
			if (ctl == null)
				return null;

			var inspectors = ModelBindingInspectors.GetDefault();
			var inspector = inspectors.GetInspectorForControl(this.ValidatedControl);
			if (inspector == null)
				return null;

			if (inspector is IValueControlInspector)
				return new object[] { ((IValueControlInspector)inspector).GetValueFromControl(ctl) };
			else
				return null;
		}

		#endregion
	}
}
