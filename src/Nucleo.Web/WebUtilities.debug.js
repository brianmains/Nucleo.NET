/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo");
Type.registerNamespace("Nucleo.Web");

Nucleo.CookieManager = function() { }
Nucleo.CookieManager.registerClass("Nucleo.CookieManager");

Nucleo.CookieManager.deleteAllCookies = function() {
	throw Error.notImplemented();
}

Nucleo.CookieManager.deleteCookie = function(cookieName) {
	Nucleo.CookieManager.writeCookie(cookieName, null, "Thu, 01-Jan-1970 00:00:01 GMT");
}

Nucleo.CookieManager.deleteCookieAtIndex = function(index) {
	Nucleo.CookieManager.deleteCookie(
		Nucleo.CookieManager.getNameAtIndex(index));
}

Nucleo.CookieManager.getAllCookies = function() {
	throw Error.notImplemented();
}

Nucleo.CookieManager.getNameAtIndex = function(index) {
	var tC = document.cookie.split('; ');
	var val = tC[index].split('=');
	return val[0];
}

Nucleo.CookieManager.readCookie = function(cookieName) {
	//	var tC = document.cookie.split('; ');
	//	for (var i = tC.length - 1; i >= 0; i--) {
	//		var x = tC[i].split('=');
	//	if (nam = x[0]) return unescape(x[1]);
	return unescape(document.cookie[cookieName]);
}

Nucleo.CookieManager.readCookieAtIndex = function(index) {
	var tC = document.cookie.split('; ');
	var val = tC[index].split('=');
	return unescape(val[1]);
}

Nucleo.CookieManager.writeCookie = function(cookieName, value, expireDate) {
	document.cookie = String.format("{0}={1}; expires={2}", cookieName, escape(value), expireDate);
}

Nucleo.CookieManager.writeCookieAtIndex = function(index, value) {
	var name = Nucleo.CookieManager.getNameAtIndex(index);
	if (name == null || name.length == 0)
		throw Error.argumentNull("index", "Nothing exists at the index value of " + index.toString());

	Nucleo.CookieManager.writeCookie(name, value);
}

Nucleo.Web.WebUtility = function() { }
Nucleo.Web.WebUtility.registerClass("Nucleo.Web.WebUtility");

Nucleo.Web.WebUtility.addCssClass = function(element, className) {
	Sys.UI.DomElement.addCssClass(element, className);
}

Nucleo.Web.WebUtility.CenterHorizontally = function(element) {
	var lca;
	var lcb;
	var lcx;
	var iebody;
	var dsocleft;

	if (window.innerWidth)
		lca = window.innerWidth;
	else
		lca = document.body.clientWidth;

	lcb = element.offsetWidth;
	lcx = (Math.round(lca / 2)) - (Math.round(lcb / 2));
	iebody = (document.compatMode && document.compatMode != "BackCompat") ? document.documentElement : document.body;
	dsocleft = document.all ? iebody.scrollLeft : window.pageXOffset;

	element.style.left = lcx + dsocleft + "px";
}

Nucleo.Web.WebUtility.CenterVertically = function(element) {
	var lca;
	var lcb;
	var lcy;
	var iebody;
	var dsoctop;

	if (window.innerHeight)
		lca = window.innerHeight;
	else
		lca = document.body.clientHeight;

	lcb = element.offsetHeight;
	lcy = (Math.round(lca / 2)) - (Math.round(lcb / 2));
	iebody = (document.compatMode && document.compatMode != "BackCompat") ? document.documentElement : document.body;
	dsoctop = document.all ? iebody.scrollTop : window.pageYOffset;
	element.style.top = lcy + dsoctop + "px";
}

Nucleo.Web.WebUtility.checkHttps = function(url) {
	if (window.location.protocol != 'https:')
		window.location = 'https://' + location.host + location.pathname + location.search;
}

Nucleo.Web.WebUtility.containsCssClass = function(element, className) {
	return Sys.UI.DomElement.containsCssClass(element, className);
}

Nucleo.Web.WebUtility.getBounds = function(element) {
	return Sys.UI.DomElement.getBounds(element);
}

Nucleo.Web.WebUtility.getLocation = function(element) {
	return Sys.UI.DomElement.getLocation(element);
}

Nucleo.Web.WebUtility.getInnerWindowHeight = function(element) {
	return window.innerHeight ? window.innerHeight : document.body.clientWidth;
}

Nucleo.Web.WebUtility.getInnerWindowWidth = function(element) {
	return window.innerWidth ? window.innerWidth : document.body.clientWidth;
}

Nucleo.Web.WebUtility.isEnabledOrVisible = function(element) {
	if ((element.disabled != undefined) && element.disabled)
		return false;
	if (element.style.display == "none")
		return false;

	return true;
}

Nucleo.Web.WebUtility.removeCssClass = function(element, className) {
	Sys.UI.DomElement.removeCssClass(element, className);
}

Nucleo.Web.WebUtility.setDisabled = function(element, disabled) {
	if (disabled instanceof Boolean) {
		if (disabled)
			element.disabled = "disabled";
		else
			element.disabled = null;
	}
	else if (disabled instanceof String)
		element.disabled = disabled;
	else
		throw new Error.argument("disabled", "Disabled is not of the correct type");
}

Nucleo.Web.WebUtility.setDisplay = function(element, display) {
	if (display instanceof Boolean) {
		if (display)
			element.style.display = "";
		else
			element.style.display = "none";
	}
	else if (display instanceof String)
		element.style.display = display;
	else
		throw new Error.argument("display", "Display is not of the correct type");
}

Nucleo.Web.WebUtility.setLocation = function(element) {
	Sys.UI.DomElement.setLocation(element);
}

Nucleo.Web.WebUtility.setStyle = function(element, style) {
	try {
		element.setAttribute('style', style);
		element.style.cssText = style;
	}
	catch (ex) { }
}

Nucleo.Web.WebUtility.toggleCssClass = function(element, className) {
	Sys.UI.DomElement.toggleCssClass(element, className);
}

Nucleo.Web.WebUtility.toggleDisabled = function(element) {
	if (element.disabled == "undefined")
		return;

	if (element.disabled == "disabled")
		element.disabled = null;
	else
		element.disabled = "disabled";
}

Nucleo.Web.WebUtility.toggleDisplay = function(element) {
	if (element.style.display == "none")
		element.style.display = "";
	else
		element.style.display = "none";
}


Nucleo.Web.ElementManager = function() { }

Nucleo.Web.ElementManager.prototype = {
	createShell: function() { },
	getValue: function(target) { },
	isCorrectElement: function(target) { return false; },
	setValue: function(target, value) { }
}

Nucleo.Web.ElementManager.registerClass("Nucleo.Web.ElementManager");

Nucleo.Web.InnerHtmlBasedElementManager = function() {
	Nucleo.Web.InnerHtmlBasedElementManager.initializeBase(this);
}

Nucleo.Web.InnerHtmlBasedElementManager.prototype = {
	getValue: function(target) { return target.innerHTML; },
	setValue: function(target, value) { target.innerHTML = value; }
}

Nucleo.Web.InnerHtmlBasedElementManager.registerClass("Nucleo.Web.InnerHtmlBasedElementManager", Nucleo.Web.ElementManager);

Nucleo.Web.ValueBasedElementManager = function() {
	Nucleo.Web.ValueBasedElementManager.initializeBase(this);
}

Nucleo.Web.ValueBasedElementManager.prototype = {
	getValue: function(target) { return target.value; },
	setValue: function(target, value) { target.value = value; }
}

Nucleo.Web.ValueBasedElementManager.registerClass("Nucleo.Web.ValueBasedElementManager", Nucleo.Web.ElementManager);

Nucleo.Web.ButtonElementManager = function() {
	Nucleo.Web.ButtonElementManager.initializeBase(this);
}

Nucleo.Web.ButtonElementManager.prototype = {
	createShell: function() {
		var button = document.createElement("INPUT");
		button.type = "button";

		return button;
	},

	getValue: function(target) {
		return Nucleo.Web.ButtonElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) {
		return ((target.tagName == "INPUT" && (target.type == "button" || target.type == "submit")) || target.tagName == "BUTTON");
	},

	setValue: function(target, value) {
		return Nucleo.Web.ButtonElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.ButtonElementManager.registerClass("Nucleo.Web.ButtonElementManager", Nucleo.Web.ValueBasedElementManager);

Nucleo.Web.CheckBoxElementManager = function() {
	Nucleo.Web.CheckBoxElementManager.initializeBase(this);
}

Nucleo.Web.CheckBoxElementManager.prototype = {
	createShell: function() {
		var checkbox = document.createElement("INPUT");
		checkbox.type = "checkbox";

		return checkbox;
	},

	getValue: function(target) {
		return Nucleo.Web.CheckBoxElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) {
		return (target.tagName == "INPUT" && target.type == "checkbox");
	},

	setValue: function(target, value) {
		return Nucleo.Web.CheckBoxElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.CheckBoxElementManager.registerClass("Nucleo.Web.CheckBoxElementManager", Nucleo.Web.ValueBasedElementManager);

Nucleo.Web.HiddenFieldElementManager = function() {
	Nucleo.Web.HiddenFieldElementManager.initializeBase(this);
}

Nucleo.Web.HiddenFieldElementManager.prototype = {
	createShell: function() {
		var hidden = document.createElement("INPUT");
		hidden.type = "hidden";

		return hidden;
	},

	getValue: function(target) {
		return Nucleo.Web.HiddenFieldElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) {
		return (target.tagName == "INPUT" && target.type == "text");
	},

	setValue: function(target, value) {
		return Nucleo.Web.HiddenFieldElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.HiddenFieldElementManager.registerClass("Nucleo.Web.HiddenFieldElementManager", Nucleo.Web.ValueBasedElementManager);

Nucleo.Web.InlineCheckBoxListElementManager = function() {
	Nucleo.Web.InlineCheckBoxListElementManager.initializeBase(this);
}

Nucleo.Web.InlineCheckBoxListElementManager.prototype = {
	createShell: function() {
		throw Error.notImplemented();
	},

	getValue: function(target) {
		var evenIndex = true;

		if (target.childNodes.length <= 1)
			return null;
		if (target.childNodes[1].tagName == "INPUT")
			evenIndex = false;
		var values = [];

		for (var index = (evenIndex) ? 0 : 1; index < target.childNodes.length; index += 2) {
			var checkbox = target.childNodes[evenIndex ? index + 1 : index - 1];

			if (checkbox.checked)
				Array.add(values, index);
		}

		if (values.length > 0)
			return values;
		else
			return null;
	},

	isCorrectElement: function(target) {
		if (target.tagName != "SPAN")
			return false;

		for (var child in target) {
			if ((child.tagName != "LABEL") && (child.tagName != "INPUT" && child.type == "checkbox"))
				return false;
		}

		return true;
	},

	setValue: function(target, value) {
		var evenIndex = true;

		if (target.childNodes.length <= 1)
			return;
		if (target.childNodes[1].tagName == "INPUT")
			evenIndex = false;

		for (var index = (evenIndex) ? 0 : 1; index < target.childNodes.length; index += 2) {
			var checkbox = target.childNodes[evenIndex ? index + 1 : index - 1];

			checkbox.checked = Array.contains(index);
		}
	}
}

Nucleo.Web.InlineCheckBoxListElementManager.registerClass("Nucleo.Web.InlineCheckBoxListElementManager", Nucleo.Web.ElementManager);

Nucleo.Web.InlineRadioButtonListElementManager = function() {
	Nucleo.Web.InlineRadioButtonListElementManager.initializeBase(this);
}

Nucleo.Web.InlineRadioButtonListElementManager.prototype = {
	createShell: function() {
		throw Error.notImplemented();
	},

	getValue: function(target) {
		var evenIndex = true;

		if (target.childNodes.length <= 1)
			return null;
		if (target.childNodes[1].tagName == "INPUT")
			evenIndex = false;

		for (var index = (evenIndex) ? 0 : 1; index < target.childNodes.length; index += 2) {
			var radio = target.childNodes[evenIndex ? index + 1 : index - 1];

			if (radio.checked)
				return index;
		}

		return null;
	},

	isCorrectElement: function(target) {
		if (target.tagName != "SPAN")
			return false;

		for (var child in target) {
			if ((child.tagName != "LABEL") && (child.tagName != "INPUT" && child.type == "radio"))
				return false;
		}

		return true;
	},

	setValue: function(target, value) {
		var evenIndex = true;

		if (target.childNodes.length <= 1)
			return;
		if (target.childNodes[1].tagName == "INPUT")
			evenIndex = false;

		var index = (1 * value);
		if (evenIndex) index--;

		target.childNodes[index].checked = true;
	}
}

Nucleo.Web.InlineRadioButtonListElementManager.registerClass("Nucleo.Web.InlineRadioButtonListElementManager", Nucleo.Web.ElementManager);

Nucleo.Web.LabelElementManager = function() {
	Nucleo.Web.LabelElementManager.initializeBase(this);
}

Nucleo.Web.LabelElementManager.prototype = {
	createShell: function() {
		return document.createElement("SPAN");
	},

	getValue: function(target) {
		return Nucleo.Web.LabelElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) {
		return (target.tagName == "SPAN");
	},

	setValue: function(target, value) {
		return Nucleo.Web.LabelElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.LabelElementManager.registerClass("Nucleo.Web.LabelElementManager", Nucleo.Web.InnerHtmlBasedElementManager);

Nucleo.Web.ListItemElementManager = function() {
	Nucleo.Web.ListItemElementManager.initializeBase(this);
}

Nucleo.Web.ListItemElementManager.prototype = {
	createShell: function() {
		return document.createElement("LI");
	},

	getValue: function(target) {
		return Nucleo.Web.ListItemElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) {
		return (target.tagName == "LI");
	},

	setValue: function(target, value) {
		return Nucleo.Web.ListItemElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.ListItemElementManager.registerClass("Nucleo.Web.ListItemElementManager", Nucleo.Web.InnerHtmlBasedElementManager);

Nucleo.Web.PanelElementManager = function() {
	Nucleo.Web.PanelElementManager.initializeBase(this);
}

Nucleo.Web.PanelElementManager.prototype = {
	createShell: function() {
		return document.createElement("DIV");
	},

	getValue: function(target) {
		return Nucleo.Web.PanelElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) {
		return (target.tagName == "DIV");
	},

	setValue: function(target, value) {
		return Nucleo.Web.PanelElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.PanelElementManager.registerClass("Nucleo.Web.PanelElementManager", Nucleo.Web.InnerHtmlBasedElementManager);

Nucleo.Web.RadioButtonElementManager = function() {
	Nucleo.Web.RadioButtonElementManager.initializeBase(this);
}

Nucleo.Web.RadioButtonElementManager.prototype = {
	createShell: function() {
		return Nucleo.Web.RadioButtonElementManager.callBaseMethod(this, "createShell");
	},

	getValue: function(target) {
		return Nucleo.Web.RadioButtonElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) { return (target.tagName == "INPUT" && target.type == "text"); },

	setValue: function(target, value) {
		return Nucleo.Web.RadioButtonElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.RadioButtonElementManager.registerClass("Nucleo.Web.RadioButtonElementManager", Nucleo.Web.ValueBasedElementManager);

Nucleo.Web.TableCellElementManager = function() {
	Nucleo.Web.TableCellElementManager.initializeBase(this);
}

Nucleo.Web.TableCellElementManager.prototype = {
	createShell: function() {
		return document.createElement("TD");
	},

	getValue: function(target) {
		return Nucleo.Web.TableCellElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) {
		return (target.tagName == "TD");
	},

	setValue: function(target, value) {
		return Nucleo.Web.TableCellElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.TableCellElementManager.registerClass("Nucleo.Web.TableCellElementManager", Nucleo.Web.InnerHtmlBasedElementManager);

Nucleo.Web.TableHeaderCellElementManager = function() {
	Nucleo.Web.TableHeaderCellElementManager.initializeBase(this);
}

Nucleo.Web.TableHeaderCellElementManager.prototype = {
	createShell: function() {
		return document.createElement("TH");
	},

	getValue: function(target) {
		return Nucleo.Web.TableHeaderCellElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) {
		return (target.tagName == "TH");
	},

	setValue: function(target, value) {
		return Nucleo.Web.TableHeaderCellElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.TableHeaderCellElementManager.registerClass("Nucleo.Web.TableHeaderCellElementManager", Nucleo.Web.InnerHtmlBasedElementManager);

Nucleo.Web.TextBoxElementManager = function() {
	Nucleo.Web.TextBoxElementManager.initializeBase(this);
}

Nucleo.Web.TextBoxElementManager.prototype = {
	createShell: function() {
		var textbox = document.createElement("INPUT");
		textbox.type = "text";

		return textbox;
	},

	getValue: function(target) {
		return Nucleo.Web.TextBoxElementManager.callBaseMethod(this, "getValue", [target]);
	},

	isCorrectElement: function(target) {
		return (target.tagName == "INPUT" && target.type == "text");
	},

	setValue: function(target, value) {
		return Nucleo.Web.TextBoxElementManager.callBaseMethod(this, "setValue", [target, value]);
	}
}

Nucleo.Web.TextBoxElementManager.registerClass("Nucleo.Web.TextBoxElementManager", Nucleo.Web.ValueBasedElementManager);

Nucleo.Web.ElementManagerFactory = function() {
	this._managers = [
			new Nucleo.Web.TextBoxElementManager(),
			new Nucleo.Web.LabelElementManager(),
			new Nucleo.Web.ButtonElementManager(),
			new Nucleo.Web.InlineRadioButtonListElementManager(),
			new Nucleo.Web.HiddenFieldElementManager(),
			new Nucleo.Web.CheckBoxElementManager(),
			new Nucleo.Web.RadioButtonElementManager(),
			new Nucleo.Web.ListItemElementManager(),
			new Nucleo.Web.PanelElementManager(),
			new Nucleo.Web.TableCellElementManager(),
			new Nucleo.Web.TableHeaderCellElementManager()
		];
}

Nucleo.Web.ElementManagerFactory.prototype = {
	findManager: function(target) {
		if (target == null)
			throw Error.argumentNull("target");
		if (target.tagName == undefined || target.tagName == null)
			throw new Error.invalidOperation("The element being targeted is not an HTML tag");

		for (var index = 0; index < this._managers.length; index++) {
			var manager = this._managers[index];

			if (manager.isCorrectElement(target))
				return manager;
		}

		return null;
	},

	registerManager: function(manager) {
		if (manager == null)
			throw Error.argumentNull("manager");
		Array.add(this._managers, manager);
	}
}

Nucleo.Web.ElementManagerFactory.registerClass("Nucleo.Web.ElementManagerFactory");

Nucleo.Web.ElementManagerFactory._staticInstance = new Nucleo.Web.ElementManagerFactory();

Nucleo.Web.ElementManagerFactory.findManager = function(target) {
	return Nucleo.Web.ElementManagerFactory._staticInstance.findManager(target);
}

Nucleo.Web.ElementManagerFactory.registerManager = function(target) {
	Nucleo.Web.ElementManagerFactory._staticInstance.registerManager(target);
}