/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
Type.registerNamespace("Nucleo.Web.AjaxPages");

Nucleo.Web.AjaxPages.UsingWidgets = function () {
	Nucleo.Web.AjaxPages.UsingWidgets.initializeBase(this);

}

Nucleo.Web.AjaxPages.UsingWidgets.prototype = {

	initialize: function () {
	}
}

Nucleo.Web.AjaxPages.UsingWidgets.registerClass("Nucleo.Web.AjaxPages.UsingWidgets", Nucleo.Web.Pages.BaseAjaxPage);