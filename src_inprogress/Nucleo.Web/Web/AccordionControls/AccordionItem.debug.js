/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="BaseAjaxControl.debug.js" />

Type.registerNamespace("Nucleo.Web.AccordionControls");

Nucleo.Web.AccordionControls.AccordionItem = function (el) {
	Nucleo.Web.AccordionControls.AccordionItem.initializeBase(this, [el]);

	this._accordion = null;
	this._content = null;
	this._contentElement = null;
	this._isSelected = false;
	this._title = null;
	this._titleElement = null;
}

Nucleo.Web.AccordionControls.AccordionItem.prototype = {
	get_accordion: function () {
		return this._accordion;
	},

	set_accordion: function (value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Can't set after initialization");

		this._accordion = value;
	},

	get_content: function () {
		return this._content;
	},

	set_content: function (value) {
		this._content = value;
	},

	get_isSelected: function () {
		return this._isSelected;
	},

	set_isSelected: function (value) {
		this._isSelected = value;

		if (!!value)
			this._onselected({ accordion: this.get_accordion(), item: this });

		var state = Nucleo.Web.AccordionControls.AccordionItem.callBaseMethod(this, "get_clientState");
		if (state != null)
			state.get_values().addOrUpdate("isSelected", this.get_isSelected());
	},

	get_title: function () {
		return this._title;
	},

	set_title: function (value) {
		this._title = value;
	},

	get_titleElement: function () {
		return this._titleElement;
	},

	set_titleElement: function (value) {
		this._titleElement = value;
	},

	add_closed: function (h) {
		this.get_events().addHandler("closed", h);
	},

	remove_closed: function (h) {
		this.get_events().removeHandler("closed", h);
	},

	_onclosed: function (e) {
		var h = this.get_events().getHandler("closed");
		if (h) h(this, e);
	},

	add_opened: function (h) {
		this.get_events().addHandler("opened", h);
	},

	remove_opened: function (h) {
		this.get_events().removeHandler("opened", h);
	},

	_onopened: function (e) {
		var h = this.get_events().getHandler("opened");
		if (h) h(this, e);
	},

	add_selected: function (h) {
		this.get_events().addHandler("selected", h);
	},

	remove_selected: function (h) {
		this.get_events().removeHandler("selected", h);
	},

	_onselected: function (e) {
		var h = this.get_events().getHandler("selected");
		if (h) h(this, e);
	},

	_addContent: function (root, html) {
		var content = document.createElement("DIV");
		content.className = "NucleoAccordionContent";
		content.innerHTML = html;

		root.appendChild(content);
	},

	_addHeader: function (root, title) {
		var header = document.createElement("a");
		header.href = "#";
		header.innerHTML = title;

		var wrapper = document.createElement("h3");
		wrapper.className = "NucleoAccordionHeader";
		wrapper.appendChild(header);

		root.appendChild(wrapper);
	},

	close: function () {
		this._contentElement.style.display = "none";
		this._onclosed({ accordion: this.get_accordion(), item: this });
	},

	open: function () {
		this._contentElement.style.display = "block";
		this._onopened({ accordion: this.get_accordion(), item: this });
	},

	initialize: function () {
		this._titleElement = this.get_element().getElementsByTagName("h3")[0];
		this._contentElement = this.get_element().getElementsByTagName("div")[0];

		this.get_accordion()._registerItem(this);

		$addHandler(this._titleElement, "click", Function.createDelegate(this, function (sender, e) {
			this.set_isSelected(true);
		}), true);
	}
}

Nucleo.Web.AccordionControls.AccordionItem.registerClass("Nucleo.Web.AccordionControls.AccordionItem", Nucleo.Web.BaseAjaxControl);