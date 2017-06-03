/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

String.isNullOrEmpty = function String$isNullorEmpty(value) {
	return (value == null || typeof (value) === "undefined" || value.length == 0);
};

String.isNullOrWhiteSpace = function String$isNullOrWhiteSpace(value) {
	if (value == null || typeof (value) === "undefined")
		return true;

	value = value.trim();
	return String$isNullorEmpty(value);
};

String.prototype.replace = function (text, oldText, newText) {
	if (text == null || text == "" || oldText == null || oldText == "" || newText == null || newText == "")
		return "";

	while (text.indexOf(oldText) > -1)
		text = text.replace(oldText, newText);
	return text;
};

if (!!Type.registerNamespace)
	Type.registerNamespace("Nucleo");
else {
	if (!window["Nucleo"])
		window["Nucleo"] = {};
}

window["Nucleo"].Debug =
{
	clear: function() {
		Sys.Debug.clearTrace();
	},

	write: function(val) {
		Sys.Debug.trace(val);
	}
};

window["Nucleo"].Element = function(el) {
	this._el = el;
}

window["Nucleo"].Element.prototype = {
	dimensions: function(dim) {
		return window["Nucleo"].Element.provider.dimensions(this._el, dim);
	},

	position: function() {
		return window["Nucleo"].Element.provider.position(this._el);
	},

	scroll: function() {
		return window["Nucleo"].Element.provider.scroll(this._el);
	}
}

window["Nucleo"].Element.provider = null;

window["Nucleo"].Element.getFor = function(el) {
	var provider = window["Nucleo"].Element.provider;
	if (provider == null)
		return null;

	return new window["Nucleo"].Element(el);
};

window["Nucleo"].Components = function() {
	return {
		ensureNamespace: function(ns) {
			if (ns == null)
				throw new Error();

			if (ns.indexOf('.') == -1) {
				if (!window[ns])
					window[ns] = {};
			}
			else {
				var parts = ns.split('.');

				if (!window[parts[0]])
					window[parts[0]] = {};
				var obj = window[parts[0]];

				for (var index = 1, len = parts.length; index < len; index++) {
					if (!obj[parts[index]])
						obj[parts[index]] = {};

					obj = obj[parts[index]];
				}
			}
		}
	};
};

window["Nucleo"].$create = function(type, properties, events, references, element, options) {
	var obj = $create(type, properties, events, references, element);
	if (options == null)
		return;

	if (options["generateProperties"] === true) {
		for (var entry in properties) {
			var varName = "_" + entry;
			obj[varName] = null;
			obj.prototype["get_" + entry] = function() {
				return obj[varName];
			};
			obj.prototype["set_" + entry] = function(value) {
				obj[varName] = value;
			};
		}
	}
	if (options["generateEvents"] === true) {
		for (var entry in events) {
			obj.prototype["add_" + entry] = function(h) {
				obj.get_events().addHandler(entry, h);
			};

			obj.prototype["remove_" + entry] = function(h) {
				obj.get_events().removeHandler(entry, h);
			};

			obj.prototype["_on" + entry] = function(e) {
				var h = obj.get_events().getHandler(entry);
				if (h) h(obj, e);
			};
		}
	}
}

window["Nucleo"].css = function(file) {
	var el = document.createElement("link");
	el.rel = "stylesheet";
	el.type = "text/css";
	el.href = file;

	var head = document.getElementsByTagName("HEAD")[0];
	if (!!head) {
		head.appendChild(el);
		alert('appended: ' + file);
	}
}

var n$ = window["Nucleo"];
n$.el = window["Nucleo"].Element.getFor;

function $nucleo_register(fn) {
	//if (typeof ($) !== 'undefined' && !!$.ready)
	//	$(document).ready(fn);
	//else
		Sys.Application.add_init(fn);
}

var msElementProvider = function() {
	return {
		dimensions: function(el, dim) {
			return Sys.UI.DomElement.getBounds(el);
		},

		position: function(el) {
			return Sys.UI.DomElement.getLocation(el);
		},

		scroll: function(el) {
			return null;
		}
	};
};

var jqueryElementProvider = function() {
	if (jQuery == null)
		return null;
	else
		return {
			dimensions: function(el, dim) {
				var o = jQuery(el);

				if (!dim || dim.toLower() == "normal")
					return { width: o.width(), height: o.height() };
				else if (dim.toLower() == "inner")
					return { width: o.innerWidth(), height: o.innerHeight() };
				else if (dim.toLower() == "outer")
					return { width: o.outerWidth(), height: o.outerHeight() };
				else
					return null;
			},

			position: function(el) {
				var pos = jQuery(el).position();
				return { x: pos.left, y: pos.top };
			},

			scroll: function(el) {
				var o = jQuery(el);
				return { x: o.scrollLeft(), y: o.scrollTop() };
			}
		};
};

window["Nucleo"].Element.provider = msElementProvider();

window["Nucleo"].Content = (function () {
	var _head = document.getElementsByTagName("HEAD")[0];

	return {
		notifyScript: function (key) {
			if (typeof (Sys) !== 'undefined')
				Sys.Application.notifyScriptLoaded();

			if (typeof ($nucleo_scriptNotify) !== 'undefined')
				$nucleo_scriptNotify(key);
		},

		registerScript: function (script) {
			var scriptEl = document.createElement("script");
			scriptEl.type = "text/javascript";
			scriptEl.language = "javascript";
			scriptEl.src = script.path;

			_head.appendChild(scriptEl);

			this.notifyScript(script.key);
		},

		registerScripts: function (scripts) {
			for (var i = 0, len = scripts.length; i < len; i++)
				this.registerScript(scripts[i]);
		}
	};
})();

window["Nucleo"].JsonParse = function (data) {
	if (typeof (data) !== "string")
		return data;
	if (!data || data == "")
		return null;

	if (typeof (JSON) !== "undefined" && typeof (JSON.parse) !== "undefined")
		return JSON.parse(data);
	if (typeof (Sys) !== "undefined")
		return Sys.Serialization.JavaScriptSerializer.deserialize(data);
	else
		return eval(data);
};