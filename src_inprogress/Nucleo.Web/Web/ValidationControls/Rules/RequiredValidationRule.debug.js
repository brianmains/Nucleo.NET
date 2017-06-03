Type.registerNamespace("Nucleo.Web.ValidationControls.Rules");

Nucleo.Web.ValidationControls.Rules.RequiredValidationRule = function (el) {
	Nucleo.Web.ValidationControls.Rules.RequiredValidationRule.initializeBase(this, [el]);

}

Nucleo.Web.ValidationControls.Rules.RequiredValidationRule.prototype = {
	get_name: function () {
		return "Required";
	},

	validate: function (options) {

		for (var i = 0, len = options.values.length; i < len; i++) {
			var value = options.values[i];
			var ok = true;

			if (typeof (value) === "string")
				ok = !String.isNullOrEmpty(value);
			else
				ok = (value != null);

			if (!ok)
				return { category: n$.ValidatorCategories["Error"], message: this.get_message(), value: value };
		}

		return null;
	},

	initialize: function () {
		Nucleo.Web.ValidationControls.Rules.RequiredValidationRule.callBaseMethod(this, "initialize");

	},

	dispose: function () {

		Nucleo.Web.ValidationControls.Rules.RequiredValidationRule.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ValidationControls.Rules.RequiredValidationRule.registerClass("Nucleo.Web.ValidationControls.Rules.RequiredValidationRule", Nucleo.Web.ValidationControls.Rules.BaseValidationRule);

if (typeof (n$) === "undefined")
	n$ = {};
if (typeof (n$.ValidationRules) === "undefined")
	n$.ValidationRules = {};

n$.ValidationRules["Required"] = (function (options) {
	return {
		var rule = new Nucleo.Web.ValidationControls.Rules.RequiredValidationRule();
		rule.set_message(options["message"]);
		rule.initialize();

		return rule;
	};
})();