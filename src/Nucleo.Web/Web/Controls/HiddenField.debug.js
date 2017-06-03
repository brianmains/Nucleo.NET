/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.Controls");

Nucleo.Web.Controls.HiddenField = function(associatedElement) {
    Nucleo.Web.Controls.HiddenField.initializeBase(this, [associatedElement]);

    this._key = null;
    this._manager = null;
    this._value = null;
}



Nucleo.Web.Controls.HiddenField.prototype =
{
    get_key: function() {
        return this._key;
    },

    set_key: function(value) {
        if (this._key != value) {
            this._key = value;
            this.raisePropertyChanged("key");
        }
    },

	get_manager: function() {
		return this._manager;
	},

	set_manager: function(value) {
		if (this._manager != value) {
			this._manager = value;
			this.raisePropertyChanged("manager");
		}
	},

    get_value: function() {
        return this._value;
    },

    set_value: function(value) {
        if (this._value != value) {
            this._value = value;
            this.raisePropertyChanged("value");
        }
    },

	initialize: function() {
		Nucleo.Web.Controls.HiddenField.callBaseMethod(this, "initialize");
		var registered = false;

		if (!registered && this.get_manager() != null)
			this.get_manager()._registerHiddenField(this);
	},

    dispose: function() {

        Nucleo.Web.Controls.HiddenField.callBaseMethod(this, "dispose");
    }
}

Nucleo.Web.Controls.HiddenField.registerClass('Nucleo.Web.Controls.HiddenField', Sys.UI.Control);

if (typeof (Sys) !== 'undefined')
    Sys.Application.notifyScriptLoaded();