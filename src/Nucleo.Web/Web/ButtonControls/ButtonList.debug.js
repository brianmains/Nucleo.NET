/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web.ButtonControls");

Nucleo.Web.ButtonControls.ButtonList = function(associatedElement) {
	Nucleo.Web.ButtonControls.ButtonList.initializeBase(this, [associatedElement]);

	this._buttons = [];
	this._orientation = null;
}

Nucleo.Web.ButtonControls.ButtonList.prototype =
{
	get_buttons: function() {
		return this._buttons;
	},

	get_orientation: function() {
		return this._orientation;
	},

	set_orientation: function(value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Cannot change orientation after initialization currently; will change in the future");

		this._orientation = value;
	},

	_addButton: function(button) {
		this._buttons.push(button);
	},

	changeVisibility: function(visibilityGroup, visible) {
		for (var index = 0, len = this.get_buttons().length; index < len; index++) {
			var button = this.get_buttons()[index];

			if (button.get_visibilityGroup() == visibilityGroup)
				button.set_visible(visible);
		}
	},

	toggleVisibility: function(visibilityGroup) {
		for (var index = 0, len = this.get_buttons().length; index < len; index++) {
			var button = this.get_buttons()[index];

			if (button.get_visibilityGroup() == visibilityGroup)
				button.set_visible(!button.get_visible());
		}
	},

	initialize: function() {
		Nucleo.Web.ButtonControls.ButtonList.callBaseMethod(this, "initialize");


	},

	dispose: function() {

		Nucleo.Web.ButtonControls.ButtonList.callBaseMethod(this, "dispose");
	}
}



Nucleo.Web.ButtonControls.ButtonList.registerClass('Nucleo.Web.ButtonControls.ButtonList', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
