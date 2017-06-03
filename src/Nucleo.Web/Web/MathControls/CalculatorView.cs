using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Collections;

#if DEBUG

#endif


namespace Nucleo.Web.MathControls
{
	/// <summary>
	/// Represents a control that will act as a summation control; this control receives a numerical value from a <see cref="CalculatedFieldExtender">CalculatedFieldExtender</see> extender, and the summed value is added.
	/// </summary>
	[
	WebScriptMetadata(typeof(CalculatorViewScriptMetadata)),
	WebRenderer(typeof(CalculatorViewWebFormsWebRenderer))
	]
	public class CalculatorView : BaseAjaxControl, ICalculator
	{
		private SimpleCollection<CalculatedFieldExtender> _fields = null;
		private ITemplate _viewTemplate = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the appearance of the control.
		/// </summary>
		public CalculatorViewAppearance Appearance
		{
			get { return (CalculatorViewAppearance)(ViewState["Appearance"] ?? CalculatorViewAppearance.Readonly); }
			set { ViewState["Appearance"] = value; }
		}

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

		public string OnClientControlValueUnassigned
		{
			get { return (string)ViewState["OnClientControlValueUnassigned"]; }
			set { ViewState["OnClientControlValueUnassigned"] = value; }
		}

		/// <summary>
		/// Gets or sets the template to use as its view.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateInstance(TemplateInstance.Single),
		MergableProperty(false)
		]
		public ITemplate ViewTemplate
		{
			get { return _viewTemplate; }
			set { _viewTemplate = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(CalculatorView), this.ClientID));
			descriptor.AddEventIfExists("controlValueUnassigned", this.OnClientControlValueUnassigned);
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

		protected override void Render(HtmlTextWriter writer)
		{
			base.HandleManualScriptRegistering();
			base.AddAttributesToRender(writer);

			//TODO: Render label or textbox, or render template
			if (this.Appearance == CalculatorViewAppearance.Custom)
			{
				if (this.ViewTemplate == null)
					throw new NullReferenceException("The view template must be provided");

				Panel panel = new Panel();
				panel.ID = this.ID + "_template";
				this.ViewTemplate.InstantiateIn(panel);
				panel.RenderControl(writer);
			}
			else if (this.Appearance == CalculatorViewAppearance.Readonly)
			{
				writer.RenderBeginTag(HtmlTextWriterTag.Span);
				writer.RenderEndTag();
			}
			else if (this.Appearance == CalculatorViewAppearance.Editable)
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
				writer.RenderBeginTag(HtmlTextWriterTag.Input);
				writer.RenderEndTag();
			}
			else
				throw new NotImplementedException();
		}

		#endregion
	}
}
