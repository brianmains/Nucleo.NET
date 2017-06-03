Nucleo.Web.Pages.AjaxFormWidget = function (name) {
	Nucleo.Web.Pages.AjaxFormWidget.initializeBase(this, [name]);

	this._buttons = [];
	this._canAjaxReload = false;
	this._fields = {};

	this._defaultAdapter = (function () {
		return {
			disable: function (control) {
				control.disabled = true;
			},

			enable: function (control) {
				control.disabled = false;
			},

			getText: function (control) {
				if (control.tagName == "input")
					return control.value;
				else if (control.tagName == "select")
					return control.options[control.selectedindex].innerHTML;
				else
					return control.innerHTML;
			},

			setText: function (control, value) {
				if (control.tagName == "input")
					control.value = value;
				else if (control.tagName == "select") {
					//select by text
					//control.options[control.selectedindex].innerHTML;
				}
				else
					control.innerHTML = value;
			},

			getValue: function (control) {
				if (control.tagName == "input")
					return control.value;
				else if (control.tagName == "select")
					return control.options[control.selectedindex].value;
				else
					return control.innerHTML;
			},

			setValue: function (control, value) {
				if (control.tagName == "input")
					control.value = value;
				else if (control.tagName == "select") {
					//select by text
					//control.options[control.selectedindex].innerHTML;
				}
				else
					control.innerHTML = value;
			}
		};
	})();
}

Nucleo.Web.Pages.AjaxFormWidget.prototype = {
	getField: function (name) {
		return this._fields[name];
	},

	getFields: function () {
		return this._fields;
	},

	registerCancelButton: function (button) {
		this._buttons.push({ button: button, action: 'cancel' });
	},

	registerField: function (name, control, adapter) {
		var f = { control: control };
		f["adapter"] = (!!adapter) ? adapter : this._defaultAdapter;

		this._fields[name] = f;
	},

	registerSaveButton: function (button) {
		this._buttons.push({ button: button, action: 'save' });
	}
}

Nucleo.Web.Pages.AjaxFormWidget.registerClass("Nucleo.Web.Pages.AjaxFormWidget", Nucleo.Web.Pages.PageWidget);