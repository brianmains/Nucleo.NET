/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.MappingControls");

Nucleo.Web.MappingControls.ControlMappingOperation = function() { throw Error.notImplemented(); }

Nucleo.Web.MappingControls.ControlMappingOperation.prototype = {
	Create: 1,
	Update: 2,
	Load: 3
}

Nucleo.Web.MappingControls.ControlMappingOperation.registerEnum("Nucleo.Web.MappingControls.ControlMappingOperation");

Nucleo.Web.MappingControls.ControlMappingManager = function(associatedElement) {
	Nucleo.Web.MappingControls.ControlMappingManager.initializeBase(this, [associatedElement]);

	this._dataSourceManager = null;
	this._extenders = [];
}

Nucleo.Web.MappingControls.ControlMappingManager.prototype =
{
	get_dataSourceManager: function() {
		return this._dataSourceManager;
	},

	set_dataSourceManager: function(value) {
		this._dataSourceManager = value;
	},

	get_extenders: function() {
		return this._extenders;
	},

	add_operationNeeded: function(h) {
		this.get_events().addHandler("operationNeeded", h);
	},

	remove_operationNeeded: function(h) {
		this.get_events().removeHandler("operationNeeded", h);
	},

	_onoperationNeeded: function(e) {
		var h = this.get_events().addHandler("operationNeeded");
		if (h) h(this, e);
	},

	addExtender: function(extender) {
		if (extender == null)
			throw Error.argumentNull("extender");

		this._extenders.push(extender);
	},

	createObject: function(opKey) {
		var obj = {};

		if (!!opKey) {
			this._executeOperation(opKey);
		}

		this._refreshObject(obj);
		return obj;
	},

	_executeOperation: function(opKey) {
		var manager = this.get_dataSourceManager();
		var op = manager.get_operations().getByKey(opKey);

		if (op == null)
			throw Error.argumentNull("The operation couldn't be retrieved using the key: " + opKey);

		var params = {};
		var exts = this._getSortedExtenders(opKey);

		for (var index = 0, len = exts.length; index < len; index++) {
			var ext = exts[index];
			params[ext.get_mappedName()] = ext.getValue();
		}

		manager.execute(op, params);
	},

	_getSortedExtenders: function(opKey) {
		var arr = [];

		for (var index = 0, len = this.get_extenders().length; index < len; index++) {
			var ext = this.get_extenders()[index];
			if (ext.get_order() <= -1)
				throw Error.argumentOutOfRange("The order is out of the valid range");

			arr[ext.get_order() - 1] = ext;
		}

		return arr;
	},

	loadObject: function(obj, opKey) {
		var exts = this.get_extenders();

		if (!!opKey) {

		}

		for (var index = 0, len = exts.length; index < len; index++) {
			var ext = exts[index];
			ext.setValue(obj[ext.get_mappedName()]);
		}

		return obj;
	},

	_refreshObject: function(obj) {
		var exts = this.get_extenders();

		for (var index = 0, len = exts.length; index < len; index++) {
			var ext = exts[index];
			obj[ext.get_mappedName()] = ext.getValue();
		}
	},

	removeExtender: function(extender) {
		Array.remove(this._extenders, extender);
	},

	updateObject: function(obj, opKey) {
		var exts = this.get_extenders();

		if (!!opKey) {

		}

		this._refreshObject(obj);
		return obj;
	},

	initialize: function() {
		Nucleo.Web.MappingControls.ControlMappingManager.callBaseMethod(this, "initialize");

	},

	dispose: function() {

		Nucleo.Web.MappingControls.ControlMappingManager.callBaseMethod(this, "dispose");
	}
}


Nucleo.Web.MappingControls.ControlMappingManager.registerClass('Nucleo.Web.MappingControls.ControlMappingManager', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
