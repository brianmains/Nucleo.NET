/// <reference name="jquery-1.4.2-vsdoc.js" />
/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.Views");

Nucleo.Web.Views.BaseAjaxView = function () {
	this._controls = {};
	this._elements = {};
	this._extenders = {};
	this._events = new Sys.EventHandlerList();
	this._isInitialized = false;
}

Nucleo.Web.Views.BaseAjaxView.prototype = {
	get_events: function () {
		return this._events;
	},

	get_isInitialized: function () {
		return this._isInitialized;
	},

	getControl: function (name, fn) {
		if (!!this._controls[name]) {
			var ctl = this._controls[name];
			if (!!fn) fn(ctl);
			return ctl;
		}
		else
			return null;
	},

	getElement: function (name, fn) {
		if (!!this._elements[name]) {
			var el = this._elements[name];
			if (!!fn) fn(el);
			return el;
		}
		else
			return null;
	},

	getExtender: function (name, fn) {
		if (!!this._extenders[name]) {
			var ext = this._extenders[name];
			if (!!fn) fn(ext);
			return ext;
		}
		else
			return null;
	},

	registerControl: function (name, control) {
		if (name == null || name == "")
			throw Error.argumentNull("name");

		this._controls[name] = control;
	},

	registerElement: function (name, element) {
		if (name == null || name == "")
			throw Error.argumentNull("name");

		this._elements[name] = element;
	},

	registerExtender: function (name, extender) {
		if (name == null || name == "")
			throw Error.argumentNull("name");

		this._extenders[name] = extender;
	},

	initialize: function () {

	},

	dispose: function () {

	}
}

Nucleo.Web.Views.BaseAjaxView.registerClass("Nucleo.Web.Views.BaseAjaxView");

$createView = function (details) {
	var page = details.clientType;
	page._isInitialized = false;

	if (!!details.properties) {
		for (var key in details.properties) {
			if (!!page[key])
				page[key] = details.properties[key];
			else if (!!page["set_" + key])
				page["set_" + key](details.properties[key]);
			else if (!!page["_" + key])
				page["_" + key] = details.properties[key];
		}
	}

	if (!!details.events) {
		for (var key in details.events)
			page.get_events().addHandler(key, details.events[key]);
	}

	if (!!details.elements) {
		for (var key in details.elements)
			page._elements[key] = details.elements[key];
	}

	if (!!details.controls) {
		for (var key in details.controls)
			page._controls[key] = details.controls[key];
	}

	if (!!details.extenders) {
		for (var key in details.extenders)
			page._extenders[key] = details.extenders[key];
	}

	if (typeof (page.initialize) !== "undefined") {
		Sys.Application.add_init(function () {
			page._isInitialized = true;
			page.initialize();
		});
	}

	return page;
}

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();