/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.NavigationControls");

Nucleo.Web.NavigationControls.NavigationBarView = function(el) {
	Nucleo.Web.NavigationControls.NavigationBarView.initializeBase(this, [el]);

	this._containerControl = null;
}

Nucleo.Web.NavigationControls.NavigationBarView.prototype =
{
	get_containerControl: function() {
		return this._containerControl;
	},

	set_containerControl: function(value) {
		this._containerControl = value;
		if (value != null)
			value._view = this;
	},

	initialize: function() {
		Nucleo.Web.NavigationControls.NavigationBarView.callBaseMethod(this, "initialize");

	},

	dispose: function() {

		Nucleo.Web.NavigationControls.NavigationBarView.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.NavigationControls.NavigationBarView.registerClass('Nucleo.Web.NavigationControls.NavigationBarView', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
