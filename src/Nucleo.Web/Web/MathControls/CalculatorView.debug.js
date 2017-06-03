/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web.MathControls");

Nucleo.Web.MathControls.CalculatorView = function(associatedElement) {
Nucleo.Web.MathControls.CalculatorView.initializeBase(this, [associatedElement]);

this._extenders = [];
}

Nucleo.Web.MathControls.CalculatorView.prototype =
{
	get_extenders: function() {
		return this._extenders;
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

	_registerCalculatedField: function(extender) {
		if (extender == null)
			throw Error.argumentNull("extender", "The extender is null");

		extender.add_fieldValueChanged(this._fieldValueChangedCallback);

		Array.add(this._extenders, extender);
		this.calculate();
	},

	initialize: function() {
		Nucleo.Web.MathControls.CalculatorView.callBaseMethod(this, "initialize");

		this.calculate();
	},

	dispose: function() {

		Nucleo.Web.MathControls.CalculatorView.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.MathControls.CalculatorView.registerClass('Nucleo.Web.MathControls.CalculatorView', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
