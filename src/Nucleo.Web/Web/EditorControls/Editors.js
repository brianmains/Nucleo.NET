﻿Type.registerNamespace("Nucleo.Web.EditorControls"); Nucleo.Web.EditorControls.EditorCurrentState = function() { throw Error.notImplemented() }; Nucleo.Web.EditorControls.EditorCurrentState.prototype = { Normal: 1, Error: 2 }; Nucleo.Web.EditorControls.EditorCurrentState.registerEnum("Nucleo.Web.EditorControls.EditorCurrentState"); Nucleo.Web.EditorControls.BaseEditorControl = function(a) { Nucleo.Web.EditorControls.BaseEditorControl.initializeBase(this, [a]); this._currentState = Nucleo.Web.EditorControls.EditorCurrentState.Normal; this._readOnly = false; this._text = null }; Nucleo.Web.EditorControls.BaseEditorControl.prototype = { get_currentState: function() { return this._currentState }, set_currentState: function(a) { this._currentState = a; this._changeAppearance() }, get_hasChanges: function() { return false }, get_readOnly: function() { return this._readOnly }, set_readOnly: function(a) { this._readOnly = a }, get_text: function() { return this._text }, set_text: function(a) { this._text = a }, _changeAppearance: function() { if (this.get_currentState() == Nucleo.Web.EditorControls.EditorCurrentState.Normal) { Sys.UI.DomElement.removeCssClass(this.get_element(), "NucleoTextEditorErrorState"); Sys.UI.DomElement.addCssClass(this.get_element(), "NucleoTextEditorNormalState") } else { Sys.UI.DomElement.addCssClass(this.get_element(), "NucleoTextEditorErrorState"); Sys.UI.DomElement.removeCssClass(this.get_element(), "NucleoTextEditorNormalState") } }, refreshUI: function() { var a = this.get_element(); a.value = this.get_text(); a.disabled = this.get_readOnly(); this._changeAppearance() }, initialize: function() { Nucleo.Web.EditorControls.BaseEditorControl.callBaseMethod(this, "initialize"); if (this.get_renderingMode() == Nucleo.Web.RenderMode.ClientOnly) { this.refreshUI() } }, dispose: function() { Nucleo.Web.EditorControls.BaseEditorControl.callBaseMethod(this, "dispose") } }; Nucleo.Web.EditorControls.BaseEditorControl.registerClass("Nucleo.Web.EditorControls.BaseEditorControl", Nucleo.Web.BaseAjaxControl); if (typeof (Sys) !== "undefined") { Sys.Application.notifyScriptLoaded() };

Type.registerNamespace("Nucleo.Web.EditorControls"); Nucleo.Web.EditorControls.TextEditor = function(a) { Nucleo.Web.EditorControls.TextEditor.initializeBase(this, [a]); this._initialText = null }; Nucleo.Web.EditorControls.TextEditor.prototype = { get_initialText: function() { return this._initialText }, get_hasChanges: function() { return (this.get_initialText() != this.get_text()) }, get_text: function() { return this.get_element().value }, set_text: function(a) { this.get_element().value = a }, _onkeyAfterPress: function(b) { Nucleo.Web.EditorControls.TextEditor.callBaseMethod(this, "_onkeyAfterPress", [b]); var a = Nucleo.Web.EditorControls.TextEditor.callBaseMethod(this, "get_clientState"); if (a != null) { a.get_values().addOrUpdate("hasChanges", this.get_hasChanges()) } }, initialize: function() { Nucleo.Web.EditorControls.TextEditor.callBaseMethod(this, "initialize"); this._initialText = this.get_text() }, dispose: function() { Nucleo.Web.EditorControls.TextEditor.callBaseMethod(this, "dispose") } }; Nucleo.Web.EditorControls.TextEditor.registerClass("Nucleo.Web.EditorControls.TextEditor", Nucleo.Web.EditorControls.BaseEditorControl); if (typeof (Sys) !== "undefined") { Sys.Application.notifyScriptLoaded() };