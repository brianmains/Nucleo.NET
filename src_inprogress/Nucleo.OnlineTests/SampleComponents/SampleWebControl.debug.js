/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.SampleComponents");

Nucleo.SampleComponents.SampleWebControl = function(associatedElement) {
	Nucleo.SampleComponents.SampleWebControl.initializeBase(this, [associatedElement]);

	this._alertMessage = null;
	this._text = null;
}

Nucleo.SampleComponents.SampleWebControl.prototype =
{
	get_alertMessage: function() {
		return this._alertMessage;
	},

	set_alertMessage: function(value) {
		this._alertMessage = value;
	},

	get_text: function() {
		return this._text;
	},

	set_text: function(value) {
		this._text = value;
		this.get_element().innerHTML = value;
	},

	_onclicked: function(e) {
		alert(this.get_alertMessage());
	},

	initialize: function() {
		Nucleo.SampleComponents.SampleWebControl.callBaseMethod(this, "initialize");

	},

	dispose: function() {

		Nucleo.SampleComponents.SampleWebControl.callBaseMethod(this, "dispose");
	}
}



Nucleo.SampleComponents.SampleWebControl.registerClass('Nucleo.SampleComponents.SampleWebControl', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
