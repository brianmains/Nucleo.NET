/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ButtonControls");

Nucleo.Web.ButtonControls.ButtonEnabledExtender = function(el) {
Nucleo.Web.ButtonControls.ButtonEnabledExtender.initializeBase(this, [el]);

	this._isEnabledInitially = true;
}

Nucleo.Web.ButtonControls.ButtonEnabledExtender.prototype =
{
	get_isEnabledInitially: function () {
		return this._isEnabledInitially;
	},

	set_isEnabledInitially: function (value) {
		this._isEnabledInitially = value;
	},

	add_enabledStatusChanged: function (handler) {
		this.get_events().addHandler('enabledStatusChanged', handler);
	},

	remove_enabledStatusChanged: function (handler) {
		this.get_events().removeHandler('enabledStatusChanged', handler);
	},

	raise_enabledStatusChanged: function () {
		var eventHandler = this.get_events().getHandler('enabledStatusChanged');

		if (eventHandler != null)
			eventHandler(this, Sys.EventArgs.Empty);
	},

	_disableButton: function () {
		var button = this.get_element();
		button.disabled = "disabled";
	},

	loadInitialStatus: function () {
		Nucleo.Web.ButtonControls.ButtonEnabledExtender.callBaseMethod(this, "loadInitialStatus");

		if (this.get_receiverControl() == null)
			return;

		var isDisabled = false;
		if (!!this.get_clientState())
			isDisabled = this.get_clientState();
		else
			isDisabled = !this.get_isEnabledInitially();

		this._setDisabled(isDisabled);
	},

	_setDisabled: function (isDisabled) {
		if (this.get_receiverControl() == null) {
			if (isDisabled == null)
				this.get_element().disabled = !this.get_element().disabled;
			return;
		}

		if (isDisabled == null) {
			this.get_receiverControl().disabled = !this.get_receiverControl().disabled;
			this.raise_enabledStatusChanged();
		}
		else
			this.get_receiverControl().disabled = isDisabled;

		this.set_clientState(this.get_receiverControl().disabled);
	},

	toggleStatus: function () {
		Nucleo.Web.ButtonControls.ButtonEnabledExtender.callBaseMethod(this, "toggleStatus");

		this._setDisabled(null);
		this.raise_enabledStatusChanged();
	},

	initialize: function () {
		Nucleo.Web.ButtonControls.ButtonEnabledExtender.callBaseMethod(this, "initialize");

		if (this.get_receiverControl() != null) {
			if (this.get_receiverControl().disabled == undefined)
				throw new Error.invalidOperation("The receiver control doesn't support disabling");
		}

		if (this.get_isEnabledInitially() != null)
			this._setDisabled(!this.get_isEnabledInitially());
	},

	dispose: function () {

		Nucleo.Web.ButtonControls.ButtonEnabledExtender.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ButtonControls.ButtonEnabledExtender.registerClass('Nucleo.Web.ButtonControls.ButtonEnabledExtender', Nucleo.Web.ButtonControls.BaseButtonExtender);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();