/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.EditorControls");

Nucleo.Web.EditorControls.EditorCurrentState = function() { throw Error.notImplemented(); }

Nucleo.Web.EditorControls.EditorCurrentState.prototype = {
	Normal: 1,
	Error: 2
}

Nucleo.Web.EditorControls.EditorCurrentState.registerEnum("Nucleo.Web.EditorControls.EditorCurrentState");


Nucleo.Web.EditorControls.BaseEditorControl = function(el) {
	Nucleo.Web.EditorControls.BaseEditorControl.initializeBase(this, [el]);

	this._currentState = Nucleo.Web.EditorControls.EditorCurrentState.Normal;
	this._readOnly = false;
	this._text = null;
}

Nucleo.Web.EditorControls.BaseEditorControl.prototype =
{
	get_currentState: function() {
		return this._currentState;
	},

	set_currentState: function(value) {
		this._currentState = value;
		this._changeAppearance();
	},

	get_hasChanges: function() {
		return false;
	},

	get_readOnly: function() {
		return this._readOnly;
	},

	set_readOnly: function(value) {
		this._readOnly = value;
	},

	get_text: function() {
		return this._text;
	},

	set_text: function(value) {
		this._text = value;
	},

	_changeAppearance: function() {
		if (this.get_currentState() == Nucleo.Web.EditorControls.EditorCurrentState.Normal) {
			Sys.UI.DomElement.removeCssClass(this.get_element(), "NucleoTextEditorErrorState");
			Sys.UI.DomElement.addCssClass(this.get_element(), "NucleoTextEditorNormalState");
		}
		else {
			Sys.UI.DomElement.addCssClass(this.get_element(), "NucleoTextEditorErrorState");
			Sys.UI.DomElement.removeCssClass(this.get_element(), "NucleoTextEditorNormalState");
		}
	},

	refreshUI: function() {
		var element = this.get_element();
		element.value = this.get_text();
		element.disabled = this.get_readOnly();
		this._changeAppearance();
		n$.Debug.write("The UI has been refreshed");
	},

	initialize: function() {
		Nucleo.Web.EditorControls.BaseEditorControl.callBaseMethod(this, "initialize");

		this.refreshUI();
	},

	dispose: function() {

		Nucleo.Web.EditorControls.BaseEditorControl.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.EditorControls.BaseEditorControl.registerClass('Nucleo.Web.EditorControls.BaseEditorControl', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();