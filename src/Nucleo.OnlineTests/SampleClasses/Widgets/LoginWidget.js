/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.SampleClasses.Widgets");

Nucleo.SampleClasses.Widgets.LoginWidget = function () {
	Nucleo.SampleClasses.Widgets.LoginWidget.initializeBase(this);

	this._passwordBox = null;
	this._userNameBox = null;
	this._submitButton = null;
}

Nucleo.SampleClasses.Widgets.LoginWidget.prototype = {
	get_passwordBox: function () {
		return this._passwordBox;
	},

	set_passwordBox: function (value) {
		this._passwordBox = value;
	},

	get_submitButton: function () {
		return this._submitButton;
	},

	set_submitButton: function (value) {
		this._submitButton = value;
	},

	get_userNameBox: function () {
		return this._userNameBox;
	},

	set_userNameBox: function (value) {
		this._userNameBox = value;
	},

	initialize: function () {
		$addHandler(this._submitButton, "click", Function.createDelegate(this, function (e) {
			if (!!e.preventDefault) e.preventDefault();
			if (!!e.stopPropagation) e.stopPropagation();

			alert(String.format("Logged in with {0}/{1}.", this.get_userNameBox().value, this.get_passwordBox().value));
		}));
	}
}

Nucleo.SampleClasses.Widgets.LoginWidget.registerClass("Nucleo.SampleClasses.Widgets.LoginWidget", Nucleo.Web.Pages.PageWidget);