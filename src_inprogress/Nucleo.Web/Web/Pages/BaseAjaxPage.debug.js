/// <reference name="jquery-1.4.2-vsdoc.js" />
/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.Pages");

Nucleo.Web.Pages.BaseAjaxPage = function () {
	this._clientState = null;
	this._controls = {};
	this._elements = {};
	this._extenders = {};
	this._events = new Sys.EventHandlerList();
	this._isInitialized = false;
	this._propertyChanges = {};
	this._widgets = {};
}

Nucleo.Web.Pages.BaseAjaxPage.prototype = {
	get_body: function () {
		return document.getElementsByTagName("body")[0];
	},

	get_clientState: function () {
		if (this.get_clientStateField() == null)
			return null;

		if (this._clientState != null)
			return this._clientState;

		this._clientState = this._createClientState();
		if (this.get_clientStateField().value.length > 0)
			this._clientState.fromJson(Sys.Serialization.JavaScriptSerializer.deserialize(this.get_clientStateField().value));

		return this._clientState;
	},

	get_clientStateField: function () {
		return $get("__NucleoPageHidden");
	},

	get_events: function () {
		return this._events;
	},

	get_header: function () {
		document.getElementsByTagName("head")[0];
	},

	get_isInitialized: function () {
		return this._isInitialized;
	},

	get_title: function () {
		return this.get_header().getElementsByTagName("title").innerHTML;
	},

	set_title: function (value) {
		this.get_header().getElementsByTagName("title").innerHTML = value;
	},

	get_widgets: function () {
		return this._widgets;
	},

	add_handleError: function (h) {
		this.get_events().addHandler("handleError", h);
	},

	remove_handleError: function (h) {
		this.get_events().removeHandler("handleError", h);
	},

	_onhandleError: function (e) {
		var h = this.get_events().getHandler("handleError");
		if (h) h(this, e);
	},

	_createClientState: function () {
		return new Nucleo.Web.ClientState.ClientStateData();
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

	getWidget: function(name, fn) {
		if (!!this._widgets[name]) {
			var ext = this._widgets[name];
			if (!!fn) fn(ext);
			return ext;
		}
		else
			return null;
	},

	_processError: function (ex) {
		var e = { error: ex, handled: false };
		this._onhandleError(e);

		if (!e.handled)
			throw ex;
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

	registerWidget: function (widget) {
		if (widget == null || widget.get_name() == null || widget.get_name() == "")
			throw Error.argumentNull("name");

		this._widgets[widget.get_name()] = widget;
	},

	setPropertyChange: function (name, value) {
		this._propertyChanges[name] = value;
	},

	initialize: function () {
		//Ensure a client state field to store hidden data
		if (!this.get_clientStateField()) {
			var hidden = document.createElement("input");
			hidden.type = "hidden";
			hidden.value = "";
			hidden.id = "__NucleoPageHidden";
			hidden.name = "__NucleoPageHidden";

			this.get_body().appendChild(hidden);
		}

		this._isInitialized = true;
	},

	dispose: function () {

	}
}

Nucleo.Web.Pages.BaseAjaxPage.registerClass("Nucleo.Web.Pages.BaseAjaxPage");

$createPage = function (details) {
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

	n$.Page = Sys.UI.Page = page;

	if (typeof (page.initialize) !== "undefined") {
		Sys.Application.add_init(function () {
			page.initialize();
		});
	}

	return page;
}

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();