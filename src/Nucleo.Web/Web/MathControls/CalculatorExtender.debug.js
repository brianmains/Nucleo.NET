/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web.MathControls");

//***************************************************************
// Constructor
//***************************************************************
Nucleo.Web.MathControls.CalculatorExtender = function(el) {
	Nucleo.Web.MathControls.CalculatorExtender.initializeBase(this, [el]);

	this._extenders = [];
	this._totalValue = 0;
}



Nucleo.Web.MathControls.CalculatorExtender.prototype =
{
	//***************************************************************
	// Properties
	//***************************************************************
	get_extenders: function() {
		return this._extenders;
	},

	get_totalValue: function() {
		return this._totalValue;
	},

	add_controlValueUnassigned: function(handler) {
		this.get_events().addHandler("controlValueUnassigned", handler);
	},

	remove_controlValueUnassigned: function(handler) {
		this.get_events.removeHandler("controlValueUnassigned", handler);
	},

	_oncontrolValueUnassigned: function() {
		var eventHandler = this.get_events().getHandler("controlValueUnassigned");
		if (eventHandler != null)
			eventHandler(this, Sys.EventArgs.Empty);
	},

	add_totalUpdated: function(handler) {
		this.get_events().addHandler('totalUpdated', handler);
	},

	remove_totalUpdated: function(handler) {
		this.get_events().removeHandler('totalUpdated', handler);
	},

	_ontotalUpdated: function(e) {
		var eventHandler = this.get_events().getHandler('totalUpdated');

		if (eventHandler != null)
			eventHandler(this, e);
	},

	calculate: function() {
		if (this.get_extenders() == null || this.get_extenders().length == 0) {
			this._totalValue = 0;
			this._setControlTotal();
			return;
		}

		var total = 0;

		for (var i = 0; i < this.get_extenders().length; i++) {
			var extenderValue = this.get_extenders()[i].get_currentValue();
			if (!isNaN(extenderValue))
				total += extenderValue;
		}

		this._totalValue = total;
		this._setControlTotal();
	},

	_registerCalculatedField: function(extender) {
		if (extender == null)
			throw Error.argumentNull("extender", "The extender is null");

		extender.add_fieldValueChanged(this._fieldValueChangedCallback);

		Array.add(this._extenders, extender);
		this.calculate();
	},

	_setControlTotal: function() {
		var manager = Nucleo.Web.ElementManagerFactory.findManager(this.get_element());
		if (manager != null)
			manager.setValue(this.get_element(), this._totalValue);
		//Otherwise, raise an event to notify that the value has been unassigned
		else
			this._oncontrolValueUnassigned();
	},

	_fieldValueChangedCallback: function(sender, e) {
		sender.get_calculatorControl().calculate();
	},

	initialize: function() {
		Nucleo.Web.MathControls.CalculatorExtender.callBaseMethod(this, "initialize");

		this.calculate();
	},

	dispose: function() {

		Nucleo.Web.MathControls.CalculatorExtender.callBaseMethod(this, "dispose");
	}
}

//***************************************************************
// Registration
//***************************************************************
Nucleo.Web.MathControls.CalculatorExtender.registerClass('Nucleo.Web.MathControls.CalculatorExtender', Nucleo.Web.BaseAjaxExtender);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();