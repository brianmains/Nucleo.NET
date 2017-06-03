
Type.registerNamespace("Nucleo.Web.Inspectors");

Nucleo.Web.Inspectors.ModelBindingInspectors = function () { 
	this._items = [];
}

Nucleo.Web.Inspectors.ModelBindingInspectors.prototype = {
	getInspector: function (obj) {
		for (var i = 0, len = this._items.length; i < len; i++) {
			var inspector = this._items[i];
			if (inspector.isFor(obj))
				return inspector;
		}

		return null;
	},

	registerInspector: function (inspector) {
		this._items.push(inspector);
	}
}


Nucleo.Web.Inspectors.ModelBindingInspectors.getDefault = function () {
	var mbi = new Nucleo.Web.Inspectors.ModelBindingInspectors();
	mbi.registerInspector(new Nucleo.Web.Inspectors.InputInspector());
	mbi.registerInspector(new Nucleo.Web.Inspectors.SelectInspector());
	mbi.registerInspector(new Nucleo.Web.Inspectors.InnerHtmlInspector());

	return mbi;
};

Nucleo.Web.Inspectors.ModelBindingInspectors.registerClass("Nucleo.Web.Inspectors.ModelBindingInspectors");

Nucleo.Web.Inspectors.InputInspector = function () { }

Nucleo.Web.Inspectors.InputInspector.prototype = {
	clearValue: function (obj) {
		if (obj.type == "text" || obj.type == "hidden" || obj.type == "password")
			obj.value = "";
		else if (obj.type == "checkbox" || obj.type == "radio")
			obj.checked = false;
	},

	getValue: function (obj) {
		if (obj.type == "text" || obj.type == "hidden" || obj.type == "password")
			return obj.value;
		else if (obj.type == "checkbox" || obj.type == "radio")
			return obj.checked;
	},

	setValue: function (obj, value) {
		if (obj.type == "text" || obj.type == "hidden" || obj.type == "password")
			obj.value = (!!value) ? value : "";
		else if (obj.type == "checkbox" || obj.type == "radio")
			obj.checked = (!!value) ? value : false;
	},

	isFor: function (obj) {
		return (obj.tagName == "INPUT") && (Array.indexOf(["text", "hidden", "password", "checkbox", "radio"], obj.type) >= 0);
	}
}

Nucleo.Web.Inspectors.InputInspector.registerClass("Nucleo.Web.Inspectors.InputInspector");


Nucleo.Web.Inspectors.InnerHtmlInspector = function () { }

Nucleo.Web.Inspectors.InnerHtmlInspector.prototype = {
	clearValue: function (obj) {
		obj.innerHTML = "";
	},

	getValue: function (obj) {
		return obj.innerHTML;
	},

	setValue: function (obj, value) {
		obj.innerHTML = value;
	},

	isFor: function (obj) {
		return (obj.tagName == "SPAN" || obj.tagName == "TEXTAREA");
	}
}

Nucleo.Web.Inspectors.InnerHtmlInspector.registerClass("Nucleo.Web.Inspectors.InnerHtmlInspector");


Nucleo.Web.Inspectors.SelectInspector = function () { }

Nucleo.Web.Inspectors.SelectInspector.prototype = {
	clearValue: function (obj) {
		obj.selectedIndex = -1;
	},

	getValue: function (obj) {
		if (obj.selectedIndex == -1)
			return null;
		else
			return obj[obj.selectedIndex].value;
	},

	setValue: function (obj, value) {
		for (var i = 0, len = obj.length; i < len; i++) {
			if (obj[i].value == value) {
				obj.selectedIndex = i;
				return;
			}
		}
	},

	isFor: function (obj) {
		return obj.tagName == "SELECT";
	}
}

Nucleo.Web.Inspectors.SelectInspector.registerClass("Nucleo.Web.Inspectors.SelectInspector");