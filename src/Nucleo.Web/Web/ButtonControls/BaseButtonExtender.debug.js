/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ButtonControls");

Nucleo.Web.ButtonControls.BaseButtonExtender = function(el) {
	Nucleo.Web.ButtonControls.BaseButtonExtender.initializeBase(this, [el]);

	this._allowPostback = false;
	this._receiverControl = null;
}

Nucleo.Web.ButtonControls.BaseButtonExtender.prototype =
{
	get_allowPostback: function () {
		return this._allowPostback;
	},

	set_allowPostback: function (value) {
		this._allowPostback = value;
	},

	get_receiverControl: function () {
		return this._receiverControl;
	},

	set_receiverControl: function (value) {
		this._receiverControl = value;
	},

	_cancelEvent: function (ev) {
		if (ev.stopPropagation)
			ev.stopPropagation();
		if (ev.preventDefault)
			ev.preventDefault();
	},

	toggleStatus: function () {

	},

	_onclicked: function (ev) {
		Nucleo.Web.ButtonControls.BaseButtonExtender.callBaseMethod(this, "_onclicked", [ev]);
		this._cancelEvent(ev.domEvent);

		this.toggleStatus();

		if (this.get_allowPostback())
			__doPostBack(this.get_element().name, "");

		return false;
	},

	initialize: function () {
		Nucleo.Web.ButtonControls.BaseButtonExtender.callBaseMethod(this, "initialize");

		if (this.get_receiverControl() != null) {
			if (this.get_receiverControl().onclick != null)
				this.get_receiverControl().onclick = null;
		}
	},

	dispose: function () {

		Nucleo.Web.ButtonControls.BaseButtonExtender.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ButtonControls.BaseButtonExtender.registerClass('Nucleo.Web.ButtonControls.BaseButtonExtender', Nucleo.Web.BaseAjaxExtender);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();