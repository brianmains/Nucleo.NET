/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Nucleo.Web.PrototypeWebTemplate = function(template) {
	Nucleo.Web.PrototypeWebTemplate.initializeBase(this, [template]);
}

Nucleo.Web.PrototypeWebTemplate.prototype = {
	get_format: function() {
		return Nucleo.Web.WebTemplateFormat.Prototype;
	},

	evaluate: function(params) {
		var template = new Template(this.get_template());
		return template.evaluate(params);
	}
}

Nucleo.Web.PrototypeWebTemplate.registerClass("Nucleo.Web.PrototypeWebTemplate", Nucleo.Web.WebTemplate);