/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ValidationControls");

Nucleo.Web.ValidationControls.BaseValidator = function (el) {
	Nucleo.Web.ValidationControls.BaseValidator.initializeBase(this, [el]);

	this._defaultGroupName = null;
	this._message = null;

	
}

Nucleo.Web.ValidationControls.BaseValidator.prototype = {
	add_needValues: function (h) {
		this.get_events().addHandler("needValues", h);
	},

	remove_needValues: function (h) {
		this.get_events().removeHandler("needValues", h);
	},

	_onneedValues: function (e) {
		var h = this.get_events().getHandler("needValues");
		if (h != null)
			h(this, e);
	},

	add_validated: function (h) {
		this.get_events().addHandler("validated", h);
	},

	remove_validated: function (h) {
		this.get_events().removeHandler("validated", h);
	},

	_onvalidated: function (e) {
		var h = this.get_events().getHandler("validated");
		if (h) h(this, e);
	},

	get_defaultGroupName: function () {
		return this._defaultGroupName;
	},

	set_defaultGroupName: function (value) {
		this._defaultGroupName = value;
	},

	get_message: function () {
		return this._message;
	},

	set_message: function (value) {
		this._message = value;
	},

	_displayUI: function (el) {
		el.style.display = "inline";
	},

	_doValidate: function (values, results) {

	},

	_getValues: function () {

	},

	validate: function () {
		var values = this._getValues();

		if (values == null || typeof (values) === "undefined") {
			var args = { data: null };
			this._onneedValues(args);

			values = args.data;
		}

		var results = { items: [], hasErrors: false, groupName: this.get_defaultGroupName() };
		this._doValidate(values, results);

		if (results.hasErrors == true) {
			this._displayUI(this.get_element());
		}
		else {
			this.get_element().style.display = "none";
		}

		this._onvalidated({ values: values, results: results, groupName: this.get_defaultGroupName() });
		return results;
	},

	initialize: function () {
		Nucleo.Web.ValidationControls.BaseValidator.callBaseMethod(this, "initialize");

		n$.Validators.addValidator(this);
	},

	dispose: function () {

		Nucleo.Web.ValidationControls.BaseValidator.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ValidationControls.BaseValidator.registerClass("Nucleo.Web.ValidationControls.BaseValidator", Nucleo.Web.BaseAjaxControl);