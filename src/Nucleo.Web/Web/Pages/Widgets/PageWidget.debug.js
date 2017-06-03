/// <reference name="jquery-1.4.2-vsdoc.js" />
/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Nucleo.Web.Pages.PageWidget = function (name) {
	this._events = new Sys.EventHandlerList();
	this._isInitialized = false;
	this._name = name;
	this._page = n$.Page;
}

Nucleo.Web.Pages.PageWidget.prototype = {
	get_name: function () {
		return this._name;
	},

	get_page: function () {
		return this._page;
	},

	initialize: function () {
		this._page.registerWidget(this);

		this._isInitialized = true;
	},

	dispose: function () {

	}
}

Nucleo.Web.Pages.PageWidget.registerClass("Nucleo.Web.Pages.PageWidget");


$createWidget = function (details) {
	var widget = details.clientType;
	widget._isInitialized = false;

	var setProp = function (key, value) {
		if (!!widget["set_" + key])
			widget["set_" + key](value);
		else if (!!widget["_" + key])
			widget["_" + key] = value;
		else
			widget[key] = value;
	}

	if (!!details.properties) {
		for (var key in details.properties) {
			setProp(key, details.properties[key]);
		}
	}

	if (!!details.events) {
		for (var key in details.events)
			widget.get_events().addHandler(key, details.events[key]);
	}

	if (!!details.elements) {
		for (var key in details.elements)
			setProp(key, details.elements[key]);
	}

	if (!!details.controls) {
		for (var key in details.controls)
			setProp(key, details.controls[key]);
	}

	if (!!details.extenders) {
		for (var key in details.extenders)
			setProp(key, details.extenders[key]);
	}

	if (typeof (widget.initialize) !== "undefined") {
		Sys.Application.add_init(function () {
			widget.initialize();
		});
	}

	return widget;
}

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();