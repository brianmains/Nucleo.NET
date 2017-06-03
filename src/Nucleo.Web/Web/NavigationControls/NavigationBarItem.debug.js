/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.NavigationControls");

Nucleo.Web.NavigationControls.NavigationBarItem = function(associatedElement) {
	Nucleo.Web.NavigationControls.NavigationBarItem.initializeBase(this, [associatedElement]);

	this._bar = null;
	this._contentTemplate = null;
	this._isSelected = false;
	this._text = null;
}

Nucleo.Web.NavigationControls.NavigationBarItem.prototype =
{
	get_bar: function() {
		return this._bar;
	},

	set_bar: function(value) {
		this._bar = value;
	},

	get_contentTemplate: function() {
		return this._contentTemplate;
	},

	set_contentTemplate: function(value) {
		this._contentTemplate = value;
	},

	get_isSelected: function() {
		return this._isSelected;
	},

	set_isSelected: function(value) {
		this._isSelected = value;

		if (this.get_isInitialized()) {
			if (value)
				this._onselected(Sys.EventArgs.Empty);
			this.refreshUI();
		}
	},

	get_text: function() {
		return this._text;
	},

	set_text: function(value) {
		this._text = value;
	},

	add_selected: function(h) {
		this.get_events().addHandler("selected", h);
	},

	remove_selected: function(h) {
		this.get_events().removeHandler("selected", h);
	},

	_onselected: function(e) {
		var h = this.get_events().getHandler("selected");
		if (h) h(this, e);
	},

	_onclicked: function(e) {
		Nucleo.Web.NavigationControls.NavigationBarItem.callBaseMethod(this, "_onclicked", [e]);
		this.set_isSelected(true);
	},

	refreshUI: function() {
		if (this.get_renderingMode() == Nucleo.Web.RenderMode.ClientOnly) {
			if (this.get_contentTemplate() != null)
				this.get_element().innerHTML = eval(this.get_contentTemplate().evaluate(null));
			else
				this.get_element().innerHTML = this.get_text();
		}

		if (this.get_isSelected()) {
			Sys.UI.DomElement.removeCssClass(this.get_element(), "NavigationBarItem");
			Sys.UI.DomElement.addCssClass(this.get_element(), "NavigationBarItemSelected");
		}
		else {
			Sys.UI.DomElement.addCssClass(this.get_element(), "NavigationBarItem");
			Sys.UI.DomElement.removeCssClass(this.get_element(), "NavigationBarItemSelected");
		}
	},

	initialize: function() {
		Nucleo.Web.NavigationControls.NavigationBarItem.callBaseMethod(this, "initialize");
		this.get_bar().addItem(this);
	},

	dispose: function() {

		Nucleo.Web.NavigationControls.NavigationBarItem.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.NavigationControls.NavigationBarItem.registerClass('Nucleo.Web.NavigationControls.NavigationBarItem', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();