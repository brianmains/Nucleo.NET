/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ClientState");

Nucleo.Web.ClientState.ListClientStateData = function() {
	Nucleo.Web.ClientState.ListClientStateData.initializeBase(this);

	this._additions = new Nucleo.Collections.Collection();
	this._removals = new Nucleo.Collections.Collection();
	this._updates = new Nucleo.Collections.Collection();
	this._values = new Nucleo.Collections.Dictionary();
}

Nucleo.Web.ClientState.ListClientStateData.prototype = {
	get_additions: function() {
		return this._additions;
	},

	get_removals: function() {
		return this._removals;
	},

	get_updates: function() {
		return this._updates;
	},

	get_values: function() {
		return this._values;
	},
	
	fromJson: function(json) {
		var clientState = new Nucleo.Web.ClientState.ListClientStateData();
		clientState._additions.addRange(json["additions"]);
		clientState._removals.addRange(json["removals"]);
		clientState._updates.addRange(json["updates"]);
		clientState._values = json["values"];

		return clientState;
	},

	toJson: function() {
		var obj = {};

		obj["additions"] = this.get_additions().toArray();
		obj["removals"] = this.get_removals().toArray();
		obj["updates"] = this.get_updates().toArray();
		obj["values"] = this.get_values().toObject();

		return obj;
	}
}

Nucleo.Web.ClientState.ListClientStateData.registerClass("Nucleo.Web.ClientState.ListClientStateData");