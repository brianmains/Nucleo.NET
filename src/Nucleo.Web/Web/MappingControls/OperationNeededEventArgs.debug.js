/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web.MappingControls");

Nucleo.Web.MappingControls.OperationNeededEventArgs = function(performedOperation, dataOperation) {
	Nucleo.Web.MappingControls.OperationNeededEventArgs.initializeBase(this);

	this._dataOperation = !!dataOperation ? dataOperation : null;
	this._performedOperation = performedOperation;
}

Nucleo.Web.MappingControls.OperationNeededEventArgs.prototype = {
	get_dataOperation: function() {
		return this._dataOperation;
	},

	set_dataOperation: function(value) {
		this._dataOperation = value;
	},

	get_performedOperation: function() {
		return this._performedOperation;
	}
}

Nucleo.Web.MappingControls.OperationNeededEventArgs.registerClass("Nucleo.Web.MappingControls.OperationNeededEventArgs", Sys.EventArgs);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();