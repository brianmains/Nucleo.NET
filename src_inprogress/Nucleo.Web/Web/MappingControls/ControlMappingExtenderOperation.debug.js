/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web.MappingControls");

Nucleo.Web.MappingControls.ControlMappingExtenderOperation = function(operationKey, order) {
	this._operationKey = operationKey;
	this._order = order;
}

Nucleo.Web.MappingControls.ControlMappingExtenderOperation.prototype = {
	get_operationKey: function() {
		return this._operationKey;
	},

	set_operationKey: function(value) {
		this._operationKey = value;
	},

	get_order: function() {
		return this._order;
	},

	set_order: function(value) {
		this._order = value;
	}
}

Nucleo.Web.MappingControls.ControlMappingExtenderOperation.registerClass("Nucleo.Web.MappingControls.ControlMappingExtenderOperation");