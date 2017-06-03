/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
Type.registerNamespace("Nucleo.Tests.Ajax");

Nucleo.Tests.Ajax.UsingScriptManager = function () {
	Nucleo.Tests.Ajax.UsingScriptManager.initializeBase(this);

	this._message = null;
}

Nucleo.Tests.Ajax.UsingScriptManager.prototype = {
	get_message: function () {
		return this._message;
	},

	set_message: function (value) {
		this._message = value;
	},

	initialize: function () {
		Nucleo.Tests.Ajax.UsingScriptManager.callBaseMethod(this, "initialize");

		document.write("Created from script");
	}
}

Nucleo.Tests.Ajax.UsingScriptManager.registerClass("Nucleo.Tests.Ajax.UsingScriptManager", Nucleo.Web.Views.BaseAjaxView);