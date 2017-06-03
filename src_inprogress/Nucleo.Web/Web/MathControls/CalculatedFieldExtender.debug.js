/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web.MathControls");

Nucleo.Web.MathControls.RoundingRules = function() { throw Error.notImplemented(); }

Nucleo.Web.MathControls.RoundingRules.prototype = {
	NeverRound: 1,
	AlwaysRound: 2
}

Nucleo.Web.MathControls.RoundingRules.registerEnum("Nucleo.Web.MathControls.RoundingRules");


Nucleo.Web.MathControls.CalculatedValueEventArgs = function(originalValue, defaultValue) {
	this._originalValue = originalValue;
	this._updatedValue = defaultValue;
}

Nucleo.Web.MathControls.CalculatedValueEventArgs.prototype = {
	get_originalValue: function() {
		return this._originalValue;
	},

	get_updatedValue: function() {
		return this._updatedValue;
	},

	set_updatedValue: function(value) {
		this._updatedValue = value;
	}
}

Nucleo.Web.MathControls.CalculatedValueEventArgs.registerClass("Nucleo.Web.MathControls.CalculatedValueEventArgs", Sys.EventArgs);


Nucleo.Web.MathControls.CalculatedFieldExtender = function(associatedElement) {
	Nucleo.Web.MathControls.CalculatedFieldExtender.initializeBase(this, [associatedElement]);

	this._calculatorControl = null;
	this._currentValue = null;
}



Nucleo.Web.MathControls.CalculatedFieldExtender.prototype =
{
	//***************************************************************
	// Properties
	//***************************************************************
	get_calculatorControl: function() {
		return this._calculatorControl;
	},

	set_calculatorControl: function(value) {
		this._calculatorControl = value;
	},

	get_currentValue: function() {
		return this._currentValue;
	},

	add_fieldValueChanged: function(handler) {
		this.get_events().addHandler('fieldValueChanged', handler);
	},

	remove_fieldValueChanged: function(handler) {
		this.get_events().removeHandler('fieldValueChanged', handler);
	},

	raise_fieldValueChanged: function(e) {
		var eventHandler = this.get_events().getHandler('fieldValueChanged');

		if (eventHandler != null)
			eventHandler(this, e);
	},

	_onlostFocus: function(domEvent) {
		Nucleo.Web.MathControls.CalculatedFieldExtender.callBaseMethod(this, "_onlostFocus", [Sys.EventArgs.Empty]);

		var manager = Nucleo.Web.ElementManagerFactory.findManager(this.get_element());
		if (manager != null)
			manager.setValue(this.get_element(), this.get_currentValue());
		else
			throw Error.notImplemented();
	},

	_ongotFocus: function(domEvent) {
		Nucleo.Web.MathControls.CalculatedFieldExtender.callBaseMethod(this, "_ongotFocus", [Sys.EventArgs.Empty]);
	},

	_onkeyAfterPress: function(domEvent) {
		Nucleo.Web.MathControls.CalculatedFieldExtender.callBaseMethod(this, "_onkeyAfterPress", [Sys.EventArgs.Empty]);

		this._establishValue();
	},

	_establishValue: function() {
		var value = Number.parseInvariant(this.get_element().value);

		if (isNaN(value)) {
			this._currentValue = 0;
			this.raise_fieldValueChanged(Sys.EventArgs.Empty);
		}
		else {
			if (this._currentValue != value) {
				this._currentValue = value;
				this.raise_fieldValueChanged(Sys.EventArgs.Empty);
			}
		}
	},

	initialize: function() {
		Nucleo.Web.MathControls.CalculatedFieldExtender.callBaseMethod(this, "initialize");

		this._establishValue();
		this.get_calculatorControl()._registerCalculatedField(this);
	},

	dispose: function() {
		Nucleo.Web.MathControls.CalculatedFieldExtender.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.MathControls.CalculatedFieldExtender.registerClass('Nucleo.Web.MathControls.CalculatedFieldExtender', Nucleo.Web.BaseAjaxExtender);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
