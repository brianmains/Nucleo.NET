/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ValidationControls");

Nucleo.Web.ValidationControls.ValidationManager = function (el) {
	Nucleo.Web.ValidationControls.ValidationManager.initializeBase(this, [el]);

	this._aspNetCompatibility = null;
	this._results = [];
	this._validators = [];
}

Nucleo.Web.ValidationControls.ValidationManager.prototype = {
	get_aspNetCompatibility: function () {
		return this._aspNetCompatibility;
	},

	set_aspNetCompatibility: function (value) {
		if (typeof (value) === "string")
			this._aspNetCompatibility = n$.JsonParse(value); //Sys.Serialization.JavaScriptSerializer.deserialize(value);
		else
			this._aspNetCompatibility = value;
	},

	addValidator: function (validator) {
		if (!validator)
			throw Error.argumentNull("validator");

		this._validators.push(validator);

//		validator.add_validated(Function.createDelegate(this, function (sender, e) {
//			this._updateValidationResults(e.results);
//		}));
	},

	addValidationResult: function (result) {
		this._results.push(result);
	},

	getValidationResults: function (valGroup) {
		var results = [];

		for (var i = 0, len = this._results.length; i < len; i++) {
			var result = this._results[i];

			if (
					(String.isNullOrEmpty(result.get_defaultGroupName()) && String.isNullOrEmpty(valGroup)) ||
					(result.get_defaultGroupName() == valGroup)
				) {
				results.push(result);
			}
		}

		return results;
	},

	getValidatorsByGroup: function (group) {
		if (!this._validators || this._validators.length == 0)
			return [];

		var groupVals = [];
		for (var i = 0, len = this._validators.length; i < len; i++) {
			var val = this._validators[i];

			if (
					(String.isNullOrEmpty(val.get_defaultGroupName()) && String.isNullOrEmpty(group)) ||
						(val.get_defaultGroupName() == group)
				   ) {
				groupVals.push(val);
			}
		}

		return groupVals;
	},

	_updateValidationResults: function (results) {
		var resultControls = n$.Validators.getValidationResults(results.groupName);

		for (var c = 0, clen = resultControls.length; c < clen; c++) {
			var resultControl = resultControls[c];

			for (var i = 0, len = results.items.length; i < len; i++) {
				var item = results.items[i];
				resultControl.addItem({ category: item.category, message: item.message });
			}

			resultControl.refreshUI();
		}
	},

	validate: function (group) {
		var vals = this.getValidatorsByGroup(group);
		var results = { items: [], isValid: true };

		var resultControls = n$.Validators.getValidationResults(results.groupName);
		for (var c = 0, clen = resultControls.length; c < clen; c++) {
			resultControls[c].clearItems();
		}

		for (var i = 0, len = vals.length; i < len; i++) {
			var output = vals[i].validate();

			if (output != null) {
				if (typeof (output.items) !== "undefined") {
					for (var j = 0, jlen = output.items.length; j < jlen; j++)
						results.items.push(output.items[j]);
				}
				else
					results.items.push(output);

				if (output.hasErrors)
					results.isValid = false;

				this._updateValidationResults(output);
			}
		}

		return results;
	},

	initialize: function () {
		Nucleo.Web.ValidationControls.ValidationManager.callBaseMethod(this, "initialize");
		n$.Validators = this;

//		var pageFn = null;

//		if (typeof (Page_ClientValidate) !== "undefined")
//			pageFn = Page_ClientValidate;

//		Page_ClientValidate = function (valGroup) {
//			var results = n$.Validators.getValidationResults(valGroup);
//			var result = (pageFn != null) ? pageFn(valGroup) : true;

//			for (var j = 0, jlen = results.length; j < jlen; j++) {
//				var ctl = results[i];
//				ctl.clearItems();

//				if (ctl != null && ctl.get_aspNetCompatibility().attachToValidators == true) {
//					if (result == false) {
//						for (var i = 0; i < Page_Validators.length; i++) {
//							var validator = Page_Validators[i];
//							if (validator.isvalid == false)
//								ctl.addItem({ key: validator.id, category: n$.CategoryDefinitions.get_error(), message: validator.errormessage });
//						}
//					}
//				}


//				ctl.refreshUI();
//			}

//			return result;
//		};
	},

	dispose: function () {

		Nucleo.Web.ValidationControls.ValidationManager.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ValidationControls.ValidationManager.registerClass("Nucleo.Web.ValidationControls.ValidationManager", Nucleo.Web.BaseAjaxControl);

if (typeof (n$) === "undefined")
	n$ = {};
if (typeof (n$.Validators) === "undefined")
	n$.Validators = {};

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();