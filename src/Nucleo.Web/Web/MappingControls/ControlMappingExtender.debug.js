/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.MappingControls");

Nucleo.Web.MappingControls.ControlMappingExtender = function(associatedElement) {
	Nucleo.Web.MappingControls.ControlMappingExtender.initializeBase(this, [associatedElement]);

	this._manager = null;
	this._mappedName = null;
	this._order = null;
}

Nucleo.Web.MappingControls.ControlMappingExtender.prototype =
{
	get_manager: function() {
		return this._manager;
	},

	set_manager: function(value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("The manager can't be set after initialization");

		this._manager = value;
	},

	get_mappedName: function() {
		return this._mappedName;
	},

	set_mappedName: function(value) {
		this._mappedName = value;
	},

	get_order: function() {
		return this._order;
	},

	set_order: function(value) {
		this._order = value;
	},

	getValue: function() {
		var manager = Nucleo.Web.ElementManagerFactory.findManager(this.get_element());
		return manager.getValue(this.get_element());
	},

	setValue: function(value) {
		var manager = Nucleo.Web.ElementManagerFactory.findManager(this.get_element());
		return manager.setValue(this.get_element(), value);
	},

	initialize: function() {
		Nucleo.Web.MappingControls.ControlMappingExtender.callBaseMethod(this, "initialize");

		this.get_manager().addExtender(this);
	},

	dispose: function() {
		this.get_manager().removeExtender(this);

		Nucleo.Web.MappingControls.ControlMappingExtender.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.MappingControls.ControlMappingExtender.registerClass('Nucleo.Web.MappingControls.ControlMappingExtender', Nucleo.Web.BaseAjaxExtender);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
