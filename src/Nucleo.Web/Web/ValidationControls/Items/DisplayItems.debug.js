/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

if (typeof (n$) === "undefined")
	n$ = {};
n$.ValidatorDisplays = {};

n$.ValidatorDisplays["Error"] = function (options) {
	Sys.UI.DomElement.addCssClass(options.element, "NucleoValidationItemError");

	var span = document.createElement("span");
	span.innerHTML = options.message;

	options.element.appendChild(span);
}

n$.ValidatorDisplays["Information"] = function (options) {
	Sys.UI.DomElement.addCssClass(options.element, "NucleoValidationItemInformation");

	var span = document.createElement("span");
	span.innerHTML = options.message;

	options.element.appendChild(span);
}

n$.ValidatorDisplays["Warning"] = function (options) {
	Sys.UI.DomElement.addCssClass(options.element, "NucleoValidationItemWarning");

	var span = document.createElement("span");
	span.innerHTML = options.message;

	options.element.appendChild(span);
}