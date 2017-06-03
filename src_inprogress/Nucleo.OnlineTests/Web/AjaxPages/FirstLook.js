/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
Type.registerNamespace("Nucleo.Web.AjaxPages");

Nucleo.Web.AjaxPages.FirstLook = function () {
	Nucleo.Web.AjaxPages.FirstLook.initializeBase(this);

	this._errorMessage = null;
	this._text = null;
}

Nucleo.Web.AjaxPages.FirstLook.prototype = {
	get_errorMessage: function () {
		return this._errorMessage;
	},

	set_errorMessage: function (value) {
		this._errorMessage = value;

		if (this.get_isInitialized()) {
			this.getElement("ErrorMessage").innerHTML = value;

			if (!!value)
				this.getElement("ErrorMessage").style.display = "inline";
			else
				this.getElement("ErrorMessage").style.display = "none";
		}
	},

	get_text: function () {
		return this._text;
	},

	initialize: function () {
		Nucleo.Web.AjaxPages.FirstLook.callBaseMethod(this, "initialize");

		this.getElement("TitleLabel").innerHTML = "First Look";

		var that = this;
		this.getControl("SubmitButton", function (ctl) {
			ctl.add_clicked(function (sender, e) {
				that.getElement("TitleLabel").innerHTML = "Entry Saved";
			});
		});

		n$.Debug.write("errorMessage: " + this.get_errorMessage());
		n$.Debug.write("text: " + this.get_text());
		n$.Debug.write("TitleLabel: " + this.getElement("TitleLabel").tagName);
		n$.Debug.write("ErrorMessageLabel: " + this.getElement("ErrorMessageLabel").tagName);
		n$.Debug.write("NameBox: " + this.getElement("NameBox").tagName);
		n$.Debug.write("CityBox: " + this.getElement("CityBox").tagName);
		n$.Debug.write("SubmitButton: " + this.getControl("SubmitButton").get_text());
	}
}

Nucleo.Web.AjaxPages.FirstLook.registerClass("Nucleo.Web.AjaxPages.FirstLook", Nucleo.Web.Pages.BaseAjaxPage);