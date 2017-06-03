using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.Script.Serialization;

using Nucleo.EventArguments;
using Nucleo.Web.Core;
using Nucleo.Web.ValidationControls.Results;


namespace Nucleo.Web.ValidationControls
{
	/// <summary>
	/// Represents the base class for validator controls.
	/// </summary>
	public abstract class BaseValidator : BaseAjaxControl, IValidatorControl
	{
		#region " Events "

		/// <summary>
		/// Fires when the validator needs to have values in order to validate.
		/// </summary>
		public event DataEventHandler<object[]> NeedValues;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets the grouping information to group the validator into.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		MergableProperty(false)
		]
		public string DefaultGroupName
		{
			get { return (string)(ViewState["DefaultGroupName"] ?? ""); }
			set { ViewState["DefaultGroupName"] = value; }
		}

		/// <summary>
		/// Gets or sets the text to display when an error happens.
		/// </summary>
		public string DisplayText
		{
			get { return (string)ViewState["DisplayText"]; }
			set { ViewState["DisplayText"] = value; }
		}

		/// <summary>
		/// Gets or sets the text to display when it needs to identify something happened for a field.
		/// </summary>
		public string Message
		{
			get { return (string)ViewState["Message"]; }
			set { ViewState["Message"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the event handler that receives the need values event call.
		/// </summary>
		public string OnClientNeedValues
		{
			get { return (string)ViewState["OnClientNeedValues"]; }
			set { ViewState["OnClientNeedValues"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the event handler that receives the validated event call.
		/// </summary>
		public string OnClientValidated
		{
			get { return (string)ViewState["OnClientValidated"]; }
			set { ViewState["OnClientValidated"] = value; }
		}

		#endregion



		#region " Methods "

		protected abstract void DoValidate(object[] values, ValidatorValidationResults results);

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			var descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(new ScriptDescriptionRequestDetails
				(this, typeof(BaseValidator), this.ClientID));
			descriptor.AddPropertyIfExists("defaultGroupName", (!string.IsNullOrEmpty(this.DefaultGroupName)) ? this.DefaultGroupName : null);
			descriptor.AddPropertyIfExists("message", this.Message);
			descriptor.AddEventIfExists("validated", this.OnClientValidated);
			descriptor.AddEventIfExists("needValues", this.OnClientNeedValues);
		}

		protected override void GetAjaxScriptReferences(IContentRegistrar registrar)
		{
			base.GetAjaxScriptReferences(registrar);

			registrar.AddReferences(new BaseValidatorScriptMetadata().GetPrimaryScripts());
		}

		/// <summary>
		/// Gets the values that are being validated.
		/// </summary>
		/// <returns>The values.</returns>
		protected abstract object[] GetValues();

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			var mgr = WebSingletonManager.GetCurrent().GetEntry<ValidationManager>();
			mgr.AddValidationControl(this);
		}

		/// <summary>
		/// Fires the <see cref="NeedValues"/> event.
		/// </summary>
		/// <param name="e">THe objects values.</param>
		protected virtual void OnNeedValues(DataEventArgs<object[]> e)
		{
			if (NeedValues != null)
				NeedValues(this, e);
		}

		protected override void RenderUI(BaseControlWriter writer)
		{
			var renderer = new BaseValidatorRenderer();
			renderer.Initialize(this, this.Page);

			renderer.Render(writer);
		}

		/// <summary>
		/// Validates all of the validation rules and determines whether the validator data is OK.
		/// </summary>
		/// <returns>A summary of the validation.</returns>
		public void Validate(ValidatorValidationResults results)
		{
			var values = this.GetValues();
			if (values == null)
			{
				var args = new DataEventArgs<object[]>(null);
				this.OnNeedValues(args);

				values = args.Data;
			}

			this.DoValidate(values, results);
		}

		#endregion
	}
}
