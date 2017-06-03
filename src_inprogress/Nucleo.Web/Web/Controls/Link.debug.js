/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web.Controls");

Nucleo.Web.Controls.LinkClickAction = function() { throw Error.notImplemented(); }

Nucleo.Web.Controls.LinkClickAction.prototype =
{
	FireEvent: 1,
	Redirect: 2
}

Nucleo.Web.Controls.LinkClickAction.registerEnum("Nucleo.Web.Controls.LinkClickAction");

Nucleo.Web.Controls.LinkTargetOptions = function() { throw Error.notImplemented(); }

Nucleo.Web.Controls.LinkTargetOptions.prototype =
{
	SameWindow: 1,
	NewWindow: 2
}

Nucleo.Web.Controls.LinkTargetOptions.registerEnum("Nucleo.Web.Controls.LinkTargetOptions");

Nucleo.Web.Controls.Link = function(associatedElement) {
	Nucleo.Web.Controls.Link.initializeBase(this, [associatedElement]);

	this._clickAction = null;
	this._navigateUrl = null;
	this._target = null;
	this._text = null;
}

Nucleo.Web.Controls.Link.prototype =
{
	get_clickAction: function() {
		return this._clickAction;
	},

	set_clickAction: function(value) {
		this._clickAction = value;
	},

	get_navigateUrl: function() {
		return this._navigateUrl;
	},

	set_navigateUrl: function(value) {
		this._navigateUrl = value;
	},

	get_target: function() {
		return this._target;
	},

	set_target: function(value) {
		this._target = value;
	},

	get_text: function() {
		return this._text;
	},

	set_text: function(value) {
		this._text = value;
	},

	add_redirecting: function(handler) {
		this.get_events().addHandler('redirecting', handler);
	},

	remove_redirecting: function(handler) {
		this.get_events().removeHandler('redirecting', handler);
	},

	_onredirecting: function(e) {
		var h = this.get_events().getHandler('redirecting');
		if (h) h(this, e);
	},

	getTarget: function() {
		return (this.get_target() == Nucleo.Web.Controls.LinkTargetOptions.NewWindow) ? "_blank" : "_self";
	},

	_onclicked: function(e) {
		if (this.get_clickAction() == Nucleo.Web.Controls.LinkClickAction.FireEvent) {
			if (this.get_renderingMode() == Nucleo.Web.RenderMode.ClientAndServer)
				__doPostBack(this.get_element().name, "click");
			else
				Nucleo.Web.Controls.Link.callBaseMethod(this, "_onclicked", [e]);
		}
		else {
			if (this.get_target() == Nucleo.Web.Controls.LinkTargetOptions.SameWindow)
				this.redirect();
		}
	},

	redirect: function() {
		if (this.get_navigateUrl() == null || this.get_navigateUrl() == "")
			throw Error.invalidOperation("The URL being redirected to cannot be null");

		this._onredirecting(Sys.EventArgs.Empty);
		window.location = this.get_navigateUrl();
	},

	refreshUI: function() {
		var link = this.get_element().getElementsByTagName("A")[0];
		link.innerHTML = (this.get_text() != null) ? this.get_text() : "";

		if (this.get_clickAction() == Nucleo.Web.Controls.LinkClickAction.Redirect) {
			link.href = this.get_navigateUrl();
			link.target = this.getTarget();
		}
		else {
			link.href = "javascript:void(0);";
			link.target = "";
		}
	},

	initialize: function() {
		Nucleo.Web.Controls.Link.callBaseMethod(this, "initialize");
	},

	dispose: function() {
		Nucleo.Web.Controls.Link.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.Controls.Link.registerClass('Nucleo.Web.Controls.Link', Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
