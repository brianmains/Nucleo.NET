/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.Controls");

Nucleo.Web.Controls.CheckImage = function(imageUrl, disabledImageUrl, associatedValue) {
	this._associatedValue = associatedValue || null;
	this._disabledImageUrl = disabledImageUrl || null;
	this._imageUrl = imageUrl || null;
}

Nucleo.Web.Controls.CheckImage.prototype =
{
	get_associatedValue: function() {
		return this._associatedValue;
	},

	get_disabledImageUrl: function() {
		return this._disabledImageUrl;
	},

	set_disabledImageUrl: function(value) {
		this._disabledImageUrl = value;
	},

	get_imageUrl: function() {
		return this._imageUrl;
	},

	set_imageUrl: function(value) {
		this._imageUrl = value;
	}
}

Nucleo.Web.Controls.CheckImage.registerClass("Nucleo.Web.Controls.CheckImage");

Nucleo.Web.Controls.CheckImage.parse = function(obj) {
	return new Nucleo.Web.Controls.CheckImage(obj.ImageUrl, obj.DisabledImageUrl, obj.AssociatedValue);
}


Nucleo.Web.Controls.Check = function (associatedElement) {
	Nucleo.Web.Controls.Check.initializeBase(this, [associatedElement]);

	this._allowEmptyCheckState = false;
	this._checked = null;
	this._emptyImage = null;
	this._falseImage = null;
	this._initialChecked = null;
	this._text = null;
	this._trueImage = null;
}

Nucleo.Web.Controls.Check.prototype =
{
	get_allowEmptyCheckState: function () {
		return this._allowEmptyCheckState;
	},

	set_allowEmptyCheckState: function (value) {
		this._allowEmptyCheckState = value;
	},

	get_checked: function () {
		return this._checked;
	},

	set_checked: function (value) {
		this._checked = value;

		this._refreshImage();
	},

	get_emptyImage: function () {
		return this._emptyImage;
	},

	set_emptyImage: function (value) {
		if (value.get_associatedValue)
			this._emptyImage = value;
		else
			this._emptyImage = Nucleo.Web.Controls.CheckImage.parse(value);
	},

	set_enabled: function (value) {
		Nucleo.Web.Controls.Check.callBaseMethod(this, "set_enabled", [value]);
		this._refreshImage();
	},

	get_falseImage: function () {
		return this._falseImage;
	},

	set_falseImage: function (value) {
		if (value.get_associatedValue)
			this._falseImage = value;
		else
			this._falseImage = Nucleo.Web.Controls.CheckImage.parse(value);
	},

	get_initialChecked: function () {
		return this._initialChecked;
	},

	set_initialChecked: function (value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Cannot set after initialization");

		this._initialChecked = value;
	},

	get_selectedImage: function () {
		if (this.get_checked() == true)
			return this.get_trueImage();
		else if (this.get_checked() == false)
			return this.get_falseImage();
		else
			return this.get_emptyImage();
	},

	get_text: function () {
		return this._text;
	},

	set_text: function (value) {
		this._text = value;
		this._refreshText();
	},

	get_trueImage: function () {
		return this._trueImage;
	},

	set_trueImage: function (value) {
		if (value.get_associatedValue)
			this._trueImage = value;
		else
			this._trueImage = Nucleo.Web.Controls.CheckImage.parse(value);
	},

	add_checkChanged: function (handler) {
		this.get_events().addHandler('checkChanged', handler);
	},

	remove_checkChanged: function (handler) {
		this.get_events().removeHandler('checkChanged', handler);
	},

	_oncheckChanged: function (e) {
		var h = this.get_events().getHandler('checkChanged');
		if (h) h(this, Sys.EventArgs.Empty);
	},

	_onclicked: function (domEvent) {
		Nucleo.Web.Controls.Check.callBaseMethod(this, "_onclicked", [Sys.EventArgs.Empty]);

		if (this.get_enabled()) {
			this.toggleCheckedValue();
			this._oncheckChanged(Sys.EventArgs.Empty);

			var state = Nucleo.Web.Controls.Check.callBaseMethod(this, "get_clientState");
			if (state != null)
				state.get_values().addOrUpdate("hasChanges", (this.get_checked() != this.get_initialChecked()));
		}
	},

	_refreshImage: function () {
		var imageElement = this.get_element().getElementsByTagName("IMG")[0];
		var image = this.get_selectedImage();
		var enabled = Nucleo.Web.Controls.Check.callBaseMethod(this, "get_enabled");

		if (image != null)
			imageElement.src = enabled ? image.get_imageUrl() : image.get_disabledImageUrl();
	},

	_refreshText: function () {
		var labelElement = this.get_element().getElementsByTagName("LABEL")[0];
		labelElement.innerHTML = (this.get_text() != null) ? this.get_text() : "";
	},

	refreshUI: function () {
		this._refreshImage();
		this._refreshText();
	},

	toggleCheckedValue: function () {
		if (this.get_checked() == true)
			this.set_checked(false);
		else if (this.get_checked() == false) {
			if (!!this.get_allowEmptyCheckState())
				this.set_checked(null);
			else
				this.set_checked(true);
		}
		else if (!this.get_checked())
			this.set_checked(true);
	},

	initialize: function () {
		Nucleo.Web.Controls.Check.callBaseMethod(this, "initialize");

		if (this._checked == null)
			this._refreshImage();

		this._initialChecked = this._checked;
	},

	dispose: function () {
		Nucleo.Web.Controls.Check.callBaseMethod(this, "dispose");
	}
}


Nucleo.Web.Controls.Check.registerClass('Nucleo.Web.Controls.Check', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
