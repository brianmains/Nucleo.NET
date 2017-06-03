/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.EditorControls");

Nucleo.Web.EditorControls.TextEditor = function(el)
{
	Nucleo.Web.EditorControls.TextEditor.initializeBase(this, [el]);

	this._initialText = null;
}

Nucleo.Web.EditorControls.TextEditor.prototype =
{
	get_initialText: function() {
		return this._initialText;
	},

	get_hasChanges: function() {
		return (this.get_initialText() != this.get_text());
	},

	get_text: function() {
		return this.get_element().value;
	},

	set_text: function(value) {
		this.get_element().value = value;
	},

	_onkeyAfterPress: function(e) {
		Nucleo.Web.EditorControls.TextEditor.callBaseMethod(this, "_onkeyAfterPress", [e]);

		var state = Nucleo.Web.EditorControls.TextEditor.callBaseMethod(this, "get_clientState");
		if (state != null)
			state.get_values().addOrUpdate("hasChanges", this.get_hasChanges());
	},

	initialize: function() {
		Nucleo.Web.EditorControls.TextEditor.callBaseMethod(this, "initialize");
		this._initialText = this.get_text();
	},

	dispose: function() {

		Nucleo.Web.EditorControls.TextEditor.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.EditorControls.TextEditor.registerClass('Nucleo.Web.EditorControls.TextEditor', Nucleo.Web.EditorControls.BaseEditorControl);

if (typeof(Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
