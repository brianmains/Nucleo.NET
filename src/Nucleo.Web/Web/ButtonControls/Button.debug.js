/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ButtonControls");

Nucleo.Web.ButtonControls.Button = function(associatedElement) {
	Nucleo.Web.ButtonControls.Button.initializeBase(this, [associatedElement]);

	this._causesValidation = null;
	this._commandArgument = null;
	this._commandName = null;
	this._disableOnFirstClick = false;
	this._disableOnFirstClickTimeout = 0;
	this._disableUntilPageLoad = false;
	this._imageAlternateText = null;
	this._imageUrl = null;
	this._navigateUrl = null;
	this._parentList = null;
	this._postBackAlways = false;
	this._postBackUrl = null;
	this._style = null;
	this._text = null;
	this._validationGroup = null;
	this._visibilityGroup = null;
}

Nucleo.Web.ButtonControls.Button.prototype =
{
	get_causesValidation: function () {
		return this._causesValidation;
	},

	set_causesValidation: function (value) {
		if (this.get_isInitialized())
			throw Error.notImplemented("Cannot set after initialization");

		this._causesValidation = value;
	},

	get_commandArgument: function () {
		return this._commandArgument;
	},

	set_commandArgument: function (value) {
		this._commandArgument = value;
	},

	get_commandName: function () {
		return this._commandName;
	},

	set_commandName: function (value) {
		this._commandName = value;
	},

	get_disableOnFirstClick: function () {
		return this._disableOnFirstClick;
	},

	set_disableOnFirstClick: function (value) {
		this._disableOnFirstClick = value;
	},

	get_disableOnFirstClickTimeout: function () {
		return this._disableOnFirstClickTimeout;
	},

	set_disableOnFirstClickTimeout: function (value) {
		this._disableOnFirstClickTimeout = value;
	},

	get_disableUntilPageLoad: function () {
		return this._disableUntilPageLoad;
	},

	set_disableUntilPageLoad: function (value) {
		if (this.get_isInitialized())
			throw Error.notImplemented("Cannot set after initialization");

		this._disableUntilPageLoad = value;
	},

	set_enabled: function (value) {
		Nucleo.Web.ButtonControls.Button.callBaseMethod(this, "set_enabled", [value]);
		this.refresh();
	},

	get_imageAlternateText: function () {
		return this._imageAlternateText;
	},

	set_imageAlternateText: function (value) {
		this._imageAlternateText = value;
		this.refresh();
	},

	get_imageUrl: function () {
		return this._imageUrl;
	},

	set_imageUrl: function (value) {
		this._imageUrl = value;
		this.refresh();
	},

	get_parentList: function () {
		return this._parentList;
	},

	set_parentList: function (value) {
		this._parentList = value;
	},

	get_postBackAlways: function () {
		return this._postBackAlways;
	},

	set_postBackAlways: function (value) {
		this._postBackAlways = value;
	},

	get_postBackUrl: function () {
		return this._postBackUrl;
	},

	set_postBackUrl: function (value) {
		if (this.get_isInitialized())
			throw Error.notImplemented("Cannot set after initialization");

		this._postBackUrl = value;
	},

	get_style: function () {
		return this._style;
	},

	set_style: function (value) {
		this._style = value;
	},

	get_text: function () {
		return this._text;
	},

	set_text: function (value) {
		this._text = value;
		this.refresh();
	},

	get_validationGroup: function () {
		return this._validationGroup;
	},

	set_validationGroup: function (value) {
		if (this.get_isInitialized())
			throw Error.notImplemented("Cannot set after initialization");

		this._validationGroup = value;
	},

	get_visibilityGroup: function () {
		return this._visibilityGroup;
	},

	set_visibilityGroup: function (value) {
		this._visibilityGroup = value;
	},

	add_needPostback: function (handler) {
		this.get_events().addHandler("needPostback", handler);
	},

	remove_needPostback: function (handler) {
		this.get_events().removeHandler("needPostback", handler);
	},

	_onneedPostback: function (e) {
		var h = this.get_events().getHandler("needPostback");
		if (h) h(this, e);
	},

	_onclicked: function (domEvent) {
		//If not enabled, then we don't want the rest of the code to process.
		if (!this.get_enabled())
			return;

		Nucleo.Web.ButtonControls.Button.callBaseMethod(this, "_onclicked", [Sys.EventArgs.Empty]);

		var pb = function (btn) {
			__doPostBack(btn.get_element().name, btn.get_commandName());
		};

		if (this.get_causesValidation() && typeof(Page_ClientValidate) !== "undefined")
			Page_ClientValidate(this.get_validationGroup());

		if (this.get_disableOnFirstClick())
			this.set_enabled(false);

		if (this.get_disableOnFirstClickTimeout() > 0)
			window.setTimeout(Function.createDelegate(this, function () { this.set_enabled(true); }), this.get_disableOnFirstClickTimeout());

		if (typeof (Page_IsValid) === "undefined" || Page_IsValid) {
			if (this.get_postBackAlways())
				pb(this);
			else {
				var args = new Nucleo.Web.ButtonControls.ButtonPostBackEventArgs();
				this._onneedPostback(args);

				if (args.get_shouldPostBack())
					pb(this);
			}
		}
	},

	refresh: function () {
		var button = this.get_element().childNodes[0];

		if (button.tagName == "IMG") {
			button.src = this.get_imageUrl();
			button.alt = this.get_imageAlternateText();
		}
		else if (button.tagName == "A")
			button.innerHTML = this.get_text();
		else
			button.value = this.get_text();

		button.disabled = !this.get_enabled();
	},

	initialize: function () {
		Nucleo.Web.ButtonControls.Button.callBaseMethod(this, "initialize");

		if (this.get_disableUntilPageLoad()) {
			this.set_enabled(true);
		}

		if (this.get_parentList())
			this.get_parentList()._addButton(this);
	},

	dispose: function () {
		if (this._pageLoadHandler != null) {
			Sys.Application.remove_load(this._pageLoadHandler);
			this._pageLoadHandler = null;
		}

		Nucleo.Web.ButtonControls.Button.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ButtonControls.Button.registerClass('Nucleo.Web.ButtonControls.Button', Nucleo.Web.BaseAjaxControl);



Nucleo.Web.ButtonControls.ButtonType = function() { throw Error.notImplemented(); }

Nucleo.Web.ButtonControls.ButtonType.prototype =
{
	Button: 0,
	Image: 1,
	Link: 2
}

Nucleo.Web.ButtonControls.ButtonType.registerEnum("Nucleo.Web.ButtonControls.ButtonType");



Nucleo.Web.ButtonControls.ButtonPostBackEventArgs = function(shouldPostBack) {
	this._shouldPostBack = !!shouldPostBack ? shouldPostBack : false;
}

Nucleo.Web.ButtonControls.ButtonPostBackEventArgs.prototype = {
	get_shouldPostBack: function() {
		return this._shouldPostBack;
	},
	
	set_shouldPostBack: function(value) {
		this._shouldPostBack = value;
	}
}

Nucleo.Web.ButtonControls.ButtonPostBackEventArgs.registerClass("Nucleo.Web.ButtonControls.ButtonPostBackEventArgs", Sys.EventArgs);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
