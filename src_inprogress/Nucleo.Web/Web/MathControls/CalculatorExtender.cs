using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Collections;


namespace Nucleo.Web.MathControls
{
	/// <summary>
	/// Represents an extender to attach to a control that will act as a summation control; this control receives a numerical value from a <see cref="CalculatedFieldExtender">CalculatedFieldExtender</see> extender, and the summed value is added.
	/// </summary>
	[
	TargetControlType(typeof(Control)),
	WebScriptMetadata(typeof(CalculatorExtenderScriptMetadata))
	]
	public class CalculatorExtender : BaseAjaxExtender, ICalculator
	{
		private SimpleCollection<CalculatedFieldExtender> _fields = null;



		#region " Properties "

		/// <summary>
		/// Gets a collection of the fields that have their <see cref="CalculatedFieldExtender.CalculatorControlID" /> properties set to this control's ID.
		/// </summary>
		public SimpleCollection<CalculatedFieldExtender> Fields
		{
			get
			{
				if (_fields == null)
					_fields = new SimpleCollection<CalculatedFieldExtender>();
				return _fields;
			}
		}

		SimpleCollection<CalculatedFieldExtender> ICalculator.Fields
		{
			get { return this.Fields; }
		}

		/// <summary>
		/// Gets or sets the client-side event that fires when the control value is unassigned, and needs assigned to some value.
		/// </summary>
		public string OnClientControlValueUnassigned
		{
			get { return (string)ViewState["OnClientControlValueUnassigned"]; }
			set { ViewState["OnClientControlValueUnassigned"] = value; }
		}

		/// <summary>
		/// Gets or sets the client-side event that fires when the control's total is updated. 
		/// </summary>
		public string OnClientTotalUpdated
		{
			get { return (string)ViewState["OnClientTotalUpdated"]; }
			set { ViewState["OnClientTotalUpdated"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			base.GetAjaxScriptDescriptors(registrar, targetControl);

			NucleoScriptBehaviorDescriptor descriptor = registrar.AddDescriptor<NucleoScriptBehaviorDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(CalculatorExtender), targetControl.ClientID));

			descriptor.AddEventIfExists("controlValueUnassigned", this.OnClientControlValueUnassigned);
			descriptor.AddEventIfExists("totalUpdated", this.OnClientTotalUpdated);
		}

		/// <summary>
		/// Registers a <see cref="CalculatedFieldExtender">field</see> with the calculator.
		/// </summary>
		/// <param name="field">The field to register.</param>
		/// <exception cref="ArgumentNullException">Thrown when the field passed in is null.</exception>
		internal void RegisterField(CalculatedFieldExtender field)
		{
			if (field == null)
				throw new ArgumentNullException("field");

			this.Fields.Add(field);
		}

		void ICalculator.RegisterField(CalculatedFieldExtender field)
		{
			this.RegisterField(field);
		}

		#endregion
	}
}
