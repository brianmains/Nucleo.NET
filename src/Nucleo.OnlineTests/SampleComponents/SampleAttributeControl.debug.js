/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.SampleComponents");

Nucleo.SampleComponents.SampleAttributeControl = function(associatedElement) {
	Nucleo.SampleComponents.SampleAttributeControl.initializeBase(this, [associatedElement]);

	this._alertMessage = null;
	this._text = null;
}

Nucleo.SampleComponents.SampleAttributeControl.prototype =
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
		this._ontextChanged(Sys.EventArgs.Empty);
	},

	add_alerted: function(h) {
		this.get_events().addHandler("alerted", h);
	},

	remove_alerted: function(h) {
		this.get_events().removeHandler("alerted", h);
	},

	_onalerted: function(e) {
		var h = this.get_events().getHandler("alerted");
		if (h) h(this, e);
	},

	add_textChanged: function(h) {
		this.get_events().addHandler("textChanged", h);
	},

	remove_textChanged: function(h) {
		this.get_events().removeHandler("textChanged", h);
	},

	_ontextChanged: function(e) {
		var h = this.get_events().getHandler("textChanged");
		if (h) h(this, e);
	},

	_onclicked: function(e) {
		alert(this.get_alertMessage());
		this._onalerted(e);
	},

	initialize: function() {
		Nucleo.SampleComponents.SampleAttributeControl.callBaseMethod(this, "initialize");

	},

	dispose: function() {

		Nucleo.SampleComponents.SampleAttributeControl.callBaseMethod(this, "dispose");
	}
}



Nucleo.SampleComponents.SampleAttributeControl.registerClass('Nucleo.SampleComponents.SampleAttributeControl', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
