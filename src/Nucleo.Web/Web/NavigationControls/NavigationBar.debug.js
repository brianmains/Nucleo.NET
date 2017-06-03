/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.NavigationControls");

Nucleo.Web.NavigationControls.NavigationBar = function(associatedElement) {
	Nucleo.Web.NavigationControls.NavigationBar.initializeBase(this, [associatedElement]);

	this._container = null;
	this._items = new Nucleo.Collections.Collection();
	this._selectedItem = null;
}

Nucleo.Web.NavigationControls.NavigationBar.prototype =
{
	get_container: function() {
		return this._container;
	},

	set_container: function(value) {
		this._container = value;
	},

	addItem: function(item) {
		this._items.add(item);
		item.add_selected(this._itemSelected);
	},

	get_items: function() {
		return this._items;
	},

	get_selectedItem: function() {
		return this._selectedItem;
	},

	clearSelections: function() {
		this._selectedItem = null;

		for (var index = 0, len = this._items.get_count(); index < len; index++)
			this._items.get_item(index).set_isSelected(false);
	},

	removeItem: function(item) {
		item.remove_selected(this._itemSelected);
		this._items.remove(item);
	},

	_itemSelected: function(sender, e) {
		var bar = sender.get_bar();
		if (bar._selectedItem != null)
			bar._selectedItem.set_isSelected(false);

		bar._selectedItem = sender;
		bar._onitemSelected(new Nucleo.DataEventArgs(sender, false));
	},

	add_itemSelected: function(h) {
		this.get_events().addHandler("itemSelected", h);
	},

	remove_itemSelected: function(h) {
		this.get_events().removeHandler("itemSelected", h);
	},

	_onitemSelected: function(e) {
		var h = this.get_events().getHandler("itemSelected");
		if (h) h(this, e);
	},

	initialize: function() {
		Nucleo.Web.NavigationControls.NavigationBar.callBaseMethod(this, "initialize");
		if (this.get_container() != null)
			this.get_container().addBar(this);
	},

	dispose: function() {

		Nucleo.Web.NavigationControls.NavigationBar.callBaseMethod(this, "dispose");
	}
}



Nucleo.Web.NavigationControls.NavigationBar.registerClass('Nucleo.Web.NavigationControls.NavigationBar', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
