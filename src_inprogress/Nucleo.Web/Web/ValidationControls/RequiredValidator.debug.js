/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ValidationControls");

Nucleo.Web.ValidationControls.RequiredValidator = function (el) {
	Nucleo.Web.ValidationControls.RequiredValidator.initializeBase(this, [el]);

	this._validatedControl = null;
}

Nucleo.Web.ValidationControls.RequiredValidator.prototype = {
	get_validatedControl: function () {
		return this._validatedControl;
	},

	set_validatedControl: function (value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation();

		this._validatedControl = value;
	},

	_doValidate: function (values, results) {
		if (!values) {
			results.items.push({
				category: n$.CategoryDefinitions.get_error(),
				message: this.get_message()
			});
			results.hasErrors = true;

			return;
		}

		for (var i = 0, len = values.length; i < len; i++) {
			var value = values[i];

			if (value == null || typeof (value) === "undefined" || (typeof (value) === "string" && value == "")) {
				results.items.push({
					category: n$.CategoryDefinitions.get_error(),
					message: this.get_message()
				});
				results.hasErrors = true;

				return;
			}
		}
	},

	_getValues: function () {
		var ctl = this.get_validatedControl();
		if (ctl == null)
			return null;

		if (typeof (ctl.tagName) !== "undefined") {
			return this._getValuesFromElement(ctl);
		}
		else if (typeof (ctl.get_id) !== "undefined") {
			return this._getValuesFromControl(ctl);
		}
	},

	_getValuesFromControl: function (ctl) {
		if (ctl.get_validatedElement()) {
			return this._getValuesFromElement(ctl.get_validatedElement());
		}
		else {
			return this._getValuesFromElement(ctl.get_element());
		}
	},

	_getValuesFromElement: function (ctl) {
		var inspectors = Nucleo.Web.Inspectors.ModelBindingInspectors.getDefault();
		var inspector = inspectors.getInspector(ctl);

		if (inspector == null) {
			var args = { data: [] };
			this._onneedValues(args);

			return args.values;
		}
		else
			return [inspector.getValue(ctl)];
	},

	initialize: function () {
		Nucleo.Web.ValidationControls.RequiredValidator.callBaseMethod(this, "initialize");


	},

	dispose: function () {

		Nucleo.Web.ValidationControls.RequiredValidator.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ValidationControls.RequiredValidator.registerClass("Nucleo.Web.ValidationControls.RequiredValidator", Nucleo.Web.ValidationControls.BaseValidator);