/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.Controls");

Nucleo.Web.Controls.HiddenFieldManager = function(associatedElement) {
	Nucleo.Web.Controls.HiddenFieldManager.initializeBase(this, [associatedElement]);

	this._hiddenFields = [];
}

Nucleo.Web.Controls.HiddenFieldManager.prototype =
{
	getFirstKeyValue: function(key) {
		var values = this.getKeyValues(key);

		if (values.length > 0)
			return values[0];
		else
			return null;
	},

	getKeyValues: function(key) {
		if (key == null || key == undefined)
			throw Error.argumentNull("key");
		var values = [];

		for (var index = 0; index < this._hiddenFields.length; index++) {
			var hiddenField = this._hiddenFields[index];
			if (hiddenField.get_key().toLowerCase() == key.toLowerCase()) {
				Array.add(values, hiddenField.get_value());
			}
		}

		return values;
	},

	_registerHiddenField: function(field) {
		if (field == null || field == undefined)
			throw Error.argumentNull("field");

		Array.add(this._hiddenFields, field);
	},

	initialize: function() {
		Nucleo.Web.Controls.HiddenFieldManager.callBaseMethod(this, "initialize");

	},

	dispose: function() {

		Nucleo.Web.Controls.HiddenFieldManager.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.Controls.HiddenFieldManager.registerClass('Nucleo.Web.Controls.HiddenFieldManager', Sys.UI.Control);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
