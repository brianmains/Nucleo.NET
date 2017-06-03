/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Nucleo.Web.WebTemplateFormat = function() { throw Error.notImplemented(); }

Nucleo.Web.WebTemplateFormat.prototype =
{
	Prototype: 1
}

Nucleo.Web.WebTemplateFormat.registerEnum("Nucleo.Web.WebTemplateFormat");


Nucleo.Web.WebTemplate = function(template) {
	this._template = template;
}

Nucleo.Web.WebTemplate.prototype =
{
	get_format: function() {
		return null;
	},

	get_template: function() {
		return this._template;
	},

	set_template: function(value) {
		this._template = value;
	},

	evaluate: function(params) { }
}

Nucleo.Web.WebTemplate.registerClass("Nucleo.Web.WebTemplate");

Nucleo.Web.WebTemplate.fromJSON = function(json) {
	if (json.Format == 1)
		return new Nucleo.Web.PrototypeWebTemplate(json.Template);
	else
		return null;
}