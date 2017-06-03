/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web");

Nucleo.Web.NucleoAjaxManager = function(associatedElement) {
	Nucleo.Web.NucleoAjaxManager.initializeBase(this, [associatedElement]);
}

Nucleo.Web.NucleoAjaxManager.prototype =
{
	initialize: function() {
		Nucleo.Web.NucleoAjaxManager.callBaseMethod(this, "initialize");

	},

	dispose: function() {

		Nucleo.Web.NucleoAjaxManager.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.NucleoAjaxManager.registerClass('Nucleo.Web.NucleoAjaxManager', Sys.UI.Control);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();