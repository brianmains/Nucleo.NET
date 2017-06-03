/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ClientState");

Nucleo.Web.ClientState.ClientStateData = function() {
	this._values = new Nucleo.Collections.Dictionary();
}

Nucleo.Web.ClientState.ClientStateData.prototype = {
	get_values: function() {
		return this._values;
	},

	fromJson: function(json) {
		if (typeof (json) === "string")
			json = Sys.Serialization.JavaScriptSerializer.deserialize(json);
		
		this._values = Nucleo.Collections.Dictionary.fromObject(json.values);
	},

	toJson: function() {
		var obj = {};
		obj["values"] = this.get_values().toObject();

		return obj;
	}
}

Nucleo.Web.ClientState.ClientStateData.registerClass("Nucleo.Web.ClientState.ClientStateData");