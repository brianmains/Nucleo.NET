Type.registerNamespace("Nucleo.Web.ValidationControls.Rules");

Nucleo.Web.ValidationControls.Rules.BaseValidationRule = function (el) {
	Nucleo.Web.ValidationControls.Rules.BaseValidationRule.initializeBase(this, [el]);

	this._message = null;
}

Nucleo.Web.ValidationControls.Rules.BaseValidationRule.prototype = {

	get_message: function () {
		return this._message;
	},

	set_message: function (value) {
		this._message = value;
	},

	get_name: function () {
		return null;
	},

	validate: function (options) {
		return null;
	},

	initialize: function () {
		n$.Validators.addValidationRule(this.get_name(), this);
	},

	dispose: function () {

	}
}

Nucleo.Web.ValidationControls.Rules.BaseValidationRule.registerClass("Nucleo.Web.ValidationControls.Rules.BaseValidationRule");