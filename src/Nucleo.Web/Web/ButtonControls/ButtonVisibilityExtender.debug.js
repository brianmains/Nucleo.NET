/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ButtonControls");

Nucleo.Web.ButtonControls.ButtonVisibilityExtender = function(el) {
	Nucleo.Web.ButtonControls.ButtonVisibilityExtender.initializeBase(this, [el]);

	this._isVisibleInitially = true;
}

Nucleo.Web.ButtonControls.ButtonVisibilityExtender.prototype =
{
	get_isVisibleInitially: function () {
		return this._isVisibleInitially;
	},

	set_isVisibleInitially: function (value) {
		this._isVisibleInitially = value;
	},

	add_visibilityStatusChanged: function (h) {
		this.get_events().addHandler('visibilityStatusChanged', h);
	},

	remove_visibilityStatusChanged: function (h) {
		this.get_events().removeHandler('visibilityStatusChanged', h);
	},

	raise_visibilityStatusChanged: function () {
		var h = this.get_events().getHandler('visibilityStatusChanged');
		if (!!h) h(this, e);
	},

	_hideButton: function () {
		var button = this.get_element();
		button.style.display = "none";
	},

	loadInitialStatus: function () {
		Nucleo.Web.ButtonControls.ButtonVisibilityExtender.callBaseMethod(this, 'loadInitialStatus');

		if (this.get_receiverControl() == null) {
			if (this.get_element().style.display == "")
				this.get_element().style.display = this.get_isVisibleInitially() ? "inline" : "none";
			return;
		}
		else {
			if (this.get_receiverControl().style.display == "")
				this.get_receiverControl().style.display = this.get_isVisibleInitially() ? "inline" : "none";
		}

		var display = null;

		if (!!this.get_clientState())
			display = this.get_clientState();
		else
			display = this.get_isVisibleInitially();

		this._setVisibility(display);
	},

	_setVisibility: function (isVisible) {
		if (this.get_receiverControl() == null) {
			if (isVisible == null)
				this._hideButton();
			return;
		}

		//If visible is null, toggle the visibility
		if (isVisible == null) {
			Sys.UI.DomElement.setVisible(this.get_receiverControl(), !Sys.UI.DomElement.getVisible(this.get_receiverControl()));
			this.raise_visibilityStatusChanged();
		}
		else
			Sys.UI.DomElement.setVisible(this.get_receiverControl(), isVisible);

		this.set_clientState(Sys.UI.DomElement.getVisible(this.get_receiverControl()));
	},

	toggleStatus: function () {
		Nucleo.Web.ButtonControls.ButtonVisibilityExtender.callBaseMethod(this, 'toggleStatus');

		this._setVisibility(null);
		this.raise_visibilityStatusChanged();
	},

	initialize: function () {
		Nucleo.Web.ButtonControls.ButtonVisibilityExtender.callBaseMethod(this, "initialize");

		if (this.get_receiverControl() != null) {
			if (this.get_receiverControl().style == undefined)
				throw Error.invalidOperation("The receiver reference is not a valid element");
		}

		if (this.get_isVisibleInitially() != null)
			this._setVisibility(this.get_isVisibleInitially());
	},

	dispose: function () {

		Nucleo.Web.ButtonControls.ButtonVisibilityExtender.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ButtonControls.ButtonVisibilityExtender.registerClass('Nucleo.Web.ButtonControls.ButtonVisibilityExtender', Nucleo.Web.ButtonControls.BaseButtonExtender);

if (typeof(Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();