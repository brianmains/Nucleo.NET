/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
Type.registerNamespace("Nucleo.Tests.Ajax");

Nucleo.Tests.Ajax.AjaxViewsFirstLook = function () {
	Nucleo.Tests.Ajax.AjaxViewsFirstLook.initializeBase(this);

	this._message = null;
}

Nucleo.Tests.Ajax.AjaxViewsFirstLook.prototype = {
	get_message: function () {
		return this._message;
	},

	set_message: function (value) {
		this._message = value;
	},

	add_changed: function (handler) {
		this.get_events().addHandler('changed', handler);
	},

	remove_changed: function (handler) {
		this.get_events().removeHandler('changed', handler);
	},

	_onchanged: function (e) {
		var h = this.get_events().getHandler('changed');
		if (h) h(this, e);
	},

	initialize: function () {
		Nucleo.Tests.Ajax.AjaxViewsFirstLook.callBaseMethod(this, "initialize");

		alert("Hello with message of: " + this.get_message());
	}
}

Nucleo.Tests.Ajax.AjaxViewsFirstLook.registerClass("Nucleo.Tests.Ajax.AjaxViewsFirstLook", Nucleo.Web.Views.BaseAjaxView);