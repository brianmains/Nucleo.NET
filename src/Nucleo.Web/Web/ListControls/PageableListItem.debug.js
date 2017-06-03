Type.registerNamespace("Nucleo.Web.ListControls");

Nucleo.Web.ListControls.PageableListItem = function(el) {
	Nucleo.Web.ListControls.PageableListItem.initializeBase(this, [el]);

	this._controlTemplate = null;
}

Nucleo.Web.ListControls.PageableListItem.prototype = {
	get_controlTemplate: function() {
		return this._controlTemplate;
	},

	set_controlTemplate: function(value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Cannot set after initialization");

		this._controlTemplate = value;
	},

	refresh: function() {
		this.get_element().innerHTML = this.get_controlTemplate().innerHTML;
	}
}

Nucleo.Web.ListControls.PageableListItem.registerClass("Nucleo.Web.ListControls.PageableListItem", Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();