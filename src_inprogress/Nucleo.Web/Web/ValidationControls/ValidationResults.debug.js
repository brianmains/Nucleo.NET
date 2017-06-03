/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ValidationControls");

Nucleo.Web.ValidationControls.ValidationResults = function (associatedElement) {
	Nucleo.Web.ValidationControls.ValidationResults.initializeBase(this, [associatedElement]);

	this._aspNetCompatibility = null;
	this._defaultGroupName = null;
	this._headerMessage = "The following results have occurred:";
	this._items = [];
}

Nucleo.Web.ValidationControls.ValidationResults.prototype =
{
	get_aspNetCompatibility: function () {
		return this._aspNetCompatibility;
	},

	set_aspNetCompatibility: function (value) {
		if (typeof (value) === "string")
			this._aspNetCompatibility = n$.JsonParse(value); //Sys.Serialization.JavaScriptSerializer.deserialize(value);
		else
			this._aspNetCompatibility = value;
	},

	get_defaultGroupName: function () {
		return this._defaultGroupName;
	},

	set_defaultGroupName: function (value) {
		this._defaultGroupName = value;
	},

	get_headerElement: function () {
		return this.get_element().getElementsByTagName("DIV")[0];
	},

	get_headerMessage: function () {
		return this._headerMessage;
	},

	set_headerMessage: function (value) {
		this._headerMessage = value;
	},

	get_listElement: function () {
		return this.get_element().getElementsByTagName("UL")[0];
	},

	addItem: function (item) {
		this._items.push(item);
	},

	clearItems: function () {
		for (var i = this._items.length - 1; i >= 0; i--) {
			this._items.pop();
		}
	},

	indexOfKey: function (id) {
		for (var i = 0, len = this._items.length; i < len; i++) {
			if (this._items[i].key == id)
				return i;
		}

		return -1;
	},

	//	_refreshList: function (list, parentEl, itemClass) {
	//		for (var index = 0, len = list.length; index < len; index++) {
	//			var item = list[index];

	//			var element = document.createElement("LI");
	//			element.innerHTML = item.message;
	//			element.className = itemClass;

	//			parentEl.appendChild(element);
	//		}
	//	},

	//	refreshUI: function () {
	//		var label = this.get_element().getElementsByTagName("DIV")[0];
	//		var list = this.get_element().getElementsByTagName("UL")[0];

	//		if (this._items.length == 0) {
	//			label.style.display = "none";
	//			list.style.display = "none";

	//			for (var i = list.childNodes.length - 1; i >= 0; i--)
	//				list.removeChild(list.childNodes[i]);

	//			return;
	//		}

	//		var errors = [];
	//		var warnings = [];
	//		var infos = [];

	//		for (var index = 0, len = this._items.length; index < len; index++) {
	//			var item = this._items[index];

	//			if (!!item.validationType) {
	//				if (item.validationType == "Error")
	//					errors.push(item);
	//				else if (item.validationType == "Information")
	//					infos.push(item);
	//				else if (item.validationType == "Warning")
	//					warnings.push(item);
	//			}
	//		}

	//		label.innerHTML = (!!this.get_headerMessage()) ? this.get_headerMessage() : "The following results have occurred:";
	//		label.style.display = "";

	//		//Remove the child nodes from the array

	//		list.style.display = "";
	//		for (var i = list.childNodes.length - 1; i >= 0; i--)
	//			list.removeChild(list.childNodes[i]);

	//		//Recreate the lists grouped by type
	//		this._refreshList(errors, list, "NucleoValidationItemError");
	//		this._refreshList(warnings, list, "NucleoValidationItemWarning");
	//		this._refreshList(infos, list, "NucleoValidationItemInformation");
	//	},

	refreshUI: function () {
		var list = this.get_listElement();

		for (var i = list.childNodes.length - 1; i >= 0; i--)
			list.removeChild(list.childNodes[i]);

		for (var i = 0, len = this._items.length; i < len; i++) {
			var item = this._items[i];

			var li = document.createElement("li");
			var displayer = n$.ValidatorDisplays[item.category.category];
			if (displayer != null)
				displayer({ message: item.message, element: li });

			list.appendChild(li);
		}

		list.style.display = (this._items.length > 0) ? "" : "none";
		this.get_headerElement().style.display = list.style.display;
	},

	removeItem: function (index) {
		this._items.splice(index, 1);
	},

	initialize: function () {
		Nucleo.Web.ValidationControls.ValidationResults.callBaseMethod(this, "initialize");
		n$.Validators.addValidationResult(this);

		if (!!this.get_aspNetCompatibility() && !!this.get_aspNetCompatibility().attachToValidators && typeof (Page_Validators) !== "undefined") {
			var that = this;

			if (typeof (ValidatorValidate) !== "undefined") {
				var valFn = ValidatorValidate;

				ValidatorValidate = function (val, valGroup, event) {
					valFn(val, valGroup, event);

					if ((!that.get_aspNetCompatibility().validationGroup && (!valGroup || valGroup == "")) ||
						valGroup == that.get_aspNetCompatibility().validationGroup) {
						if (!val.isvalid) {
							var index = that.indexOfKey(val.id);
							if (index == null || isNaN(index))
								that.addItem({ key: val.id, validationType: "Error", description: val.errormessage });
						}
						else {
							var index = that.indexOfKey(val.id);
							if (index != null && index >= 0)
								that.removeItem(index);
						}
					}
				}
			}
		}
	},

	dispose: function () {

		Nucleo.Web.ValidationControls.ValidationResults.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ValidationControls.ValidationResults.registerClass("Nucleo.Web.ValidationControls.ValidationResults", Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
