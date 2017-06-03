using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;


namespace Nucleo.Web.MathControls
{
	/// <summary>
	/// Represents an extender that attaches to an HTML element, extracts its numerical value, and calculates it.  The calculation doesn't occur within this component, but a <see cref="CalculatorView">CalculatorView</see> or <see cref="CalculatorExtender">CalculatorExtender</see> component.
	/// </summary>
	[
	TargetControlType(typeof(ITextControl)),
	WebScriptMetadata(typeof(CalculatedFieldExtenderScriptMetadata))
	]
	public class CalculatedFieldExtender : BaseAjaxExtender
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets whether to ignore invalid keypresses, which lets the user delete the previous key stroke before recalculating.  Recalculation only occurs once the erroring characters have been removed.
		/// </summary>
		public string CalculatorControlID
		{
			get { return (string)ViewState["CalculatorControlID"]; }
			set { ViewState["CalculatorControlID"] = value; }
		}

		/// <summary>
		/// Gets or sets an event handler for the 'fieldStatusChanged' event in the client component.  This event fires whenever the underlying value changes.
		/// </summary>
		public string OnClientFieldValueChanged
		{
			get { return (string)(ViewState["OnClientFieldValueChanged"] ?? null); }
			set { ViewState["OnClientFieldValueChanged"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			base.GetAjaxScriptDescriptors(registrar, targetControl);

			NucleoScriptBehaviorDescriptor descriptor = registrar.AddDescriptor<NucleoScriptBehaviorDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(CalculatedFieldExtender), targetControl.ClientID));

			Control control = ControlUtility.FindControl(this, this.CalculatorControlID);
			if (control != null)
				descriptor.AddComponentProperty("calculatorControl", control.ClientID);

			if (!string.IsNullOrEmpty(this.OnClientFieldValueChanged))
				descriptor.AddEvent("fieldValueChanged", this.OnClientFieldValueChanged);
		}

		/// <summary>
		/// Registers with the calculator extender that this extender is working with it.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			Control calculatorReference = ControlUtility.FindControl(this, this.CalculatorControlID);
			if (calculatorReference == null)
				throw new ArgumentException(string.Format("The calculator with an id of '{0}' could not be found.", this.CalculatorControlID));
			if (!(calculatorReference is ICalculator))
				throw new ArgumentException(string.Format("The calculator with an id of '{0}' is not of the correct type.", this.CalculatorControlID));

			((ICalculator)calculatorReference).RegisterField(this);
		}

		#endregion
	}
}
