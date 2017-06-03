/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.NavigationControls");

Nucleo.Web.NavigationControls.NavigationBarContainer = function(associatedElement) {
	Nucleo.Web.NavigationControls.NavigationBarContainer.initializeBase(this, [associatedElement]);

	this._bars = new Nucleo.Collections.Collection();
	this._view = null;
}

Nucleo.Web.NavigationControls.NavigationBarContainer.prototype = {
	get_bars: function() {
		return this._bars;
	},

	get_view: function() {
		return this._view;
	},

	addBar: function(bar) {
		this._bars.add(bar);
		bar.add_itemSelected(this._itemSelected);
	},

	removeBar: function(bar) {
		bar.remove_itemSelected(this._itemSelected);
		this._bars.remove(bar);
	},

	add_barSelected: function(h) {
		this.get_events().addHandler("barSelected", h);
	},

	remove_barSelected: function(h) {
		this.get_events().removeHandler("barSelected", h);
	},

	_onbarSelected: function(e) {
		var h = this.get_events().getHandler("barSelected");
		if (h) h(this, e);
	},

	_itemSelected: function(sender, e) {
		var container = sender.get_container();
		container._onbarSelected(new Nucleo.DataEventArgs(sender, false));

		var barIndex = container.get_bars().indexOf(sender);
		if (barIndex > -1) {
			for (var index = barIndex + 1, len = container.get_bars().get_count(); index < len; index++) {
				container.get_bars().get_item(index).clearSelections();
			}
		}
		else
			throw Error.argument("The bar could not be found when selected");
	},

	initialize: function() {
		Nucleo.Web.NavigationControls.NavigationBarContainer.callBaseMethod(this, "initialize");

	},

	dispose: function() {

		Nucleo.Web.NavigationControls.NavigationBarContainer.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.NavigationControls.NavigationBarContainer.registerClass("Nucleo.Web.NavigationControls.NavigationBarContainer", Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();