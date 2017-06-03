/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo");
Type.registerNamespace("Nucleo.Text");
Type.registerNamespace("Nucleo.Web");
Type.registerNamespace("Nucleo.Web.DataboundControls");
Type.registerNamespace("Nucleo.Web.ValidationControls");

Nucleo.Web.RenderMode = function() { throw Error.notImplemented(); }

Nucleo.Web.RenderMode.prototype =
{
	ServerOnly: 1,
	ClientOnly: 2,
	ClientAndServer: 3
}

Nucleo.Web.RenderMode.registerEnum("Nucleo.Web.RenderMode");

Nucleo.DataEventArgs = function(data, allowChanges) {
	Nucleo.DataEventArgs.initializeBase(this);

	this._data = data;
	this._allowChanges = allowChanges;
}

Nucleo.DataEventArgs.prototype =
{
	get_allowChanges: function() {
		return this._allowChanges;
	},

	get_data: function() {
		return this._data;
	},

	set_data: function(value) {
		if (this.get_allowChanges() == false)
			throw Error.invalidOperation("The data cannot be set because it is explicitly disallowed");

		this._data = value;
	}
}

Nucleo.DataEventArgs.registerClass("Nucleo.DataEventArgs", Sys.Component);

Type.registerNamespace("Nucleo.Collections");

Nucleo.Collections.Dictionary = function() {
	Nucleo.Collections.Dictionary.initializeBase(this);

	this._events = new Sys.EventHandlerList();
	this._items = [];
}

Nucleo.Collections.Dictionary.prototype =
{
	add: function(key, value) {
		this._items.push(new Nucleo.Collections.KeyValuePair(key, value));
		this._onitemAdded(Sys.EventArgs.Empty);
	},

	addOrUpdate: function(key, value) {
		if (this.containsKey(key))
			this.getItem(key).set_value(value);
		else
			this.add(key, value);
	},

	containsKey: function(key) {
		return (this.getItem(key) != null);
	},

	containsValue: function(value) {
		for (var index = 0; index < this._items.length; index++) {
			if (this._items[index].get_value() == value)
				return true;
		}

		return false;
	},

	getItem: function(key) {
		for (var index = 0; index < this._items.length; index++) {
			if (this._items[index].get_key() == key)
				return this._items[index];
		}

		return null;
	},

	remove: function(val) {
		var item = (!val.get_key) ? this.getItem(key) : val;
		var index = this._items.indexOf(item);

		if (index > -1) {
			this._items.splice(index, 1);
			this._onItemRemoved(Sys.EventArgs.Empty);
		}
	},

	toObject: function() {
		var o = {};

		for (var index = 0, len = this._items.length; index < len; index++)
			o[this._items[index].get_key()] = this._items[index].get_value();

		return o;
	},

	add_itemAdded: function(h) {
		this._events.addHandler('itemAdded', h);
	},

	remove_itemAdded: function(h) {
		this._events.removeHandler('itemAdded', h);
	},

	_onitemAdded: function(e) {
		var h = this._events.getHandler('itemAdded');

		if (!!h)
			h(this, e);
	},

	add_itemRemoved: function(h) {
		this._events.addHandler('itemRemoved', h);
	},

	remove_itemRemoved: function(h) {
		this._events.removeHandler('itemRemoved', h);
	},

	_onItemRemoved: function(e) {
		var h = this._events.getHandler('itemRemoved');

		if (!!h)
			h(this, e);
	}
}

Nucleo.Collections.Dictionary.registerClass('Nucleo.Collections.Dictionary', Sys.Component);

Nucleo.Collections.Dictionary.fromObject = function(obj) {
	var dict = new Nucleo.Collections.Dictionary();

	for (var member in obj)
		dict.add(member, obj[member]);

	return dict;
}

Nucleo.Collections.KeyValuePair = function(key, value) {
	Nucleo.Collections.KeyValuePair.initializeBase(this);

	this._key = key;
	this._value = value;
}

Nucleo.Collections.KeyValuePair.prototype =
{
	get_key: function() {
		return this._key;
	},

	get_value: function() {
		return this._value;
	},

	set_value: function(value) {
		this._value = value;
	}
}

Nucleo.Collections.KeyValuePair.registerClass('Nucleo.Collections.KeyValuePair');

Nucleo.Collections.Collection = function() {
	this._events = new Sys.EventHandlerList();
	this._items = [];
}

Nucleo.Collections.Collection.prototype = {
	get_count: function() {
		return this._items.length;
	},

	get_item: function(index) {
		return this._items[index];
	},

	add: function(value) {
		this._items.push(value);
		this._onitemAdded(Sys.EventArgs.Empty);
	},

	addRange: function(values) {
		if (arguments.length == 1) {
			for (var index in values)
				this.add(values[index]);
		}
		else {
			for (var index = 0, len = arguments.length; index < len; index++)
				this.add(values[index]);
		}
	},

	contains: function(value) {
		return (this.indexOf(value) > -1);
	},

	indexOf: function(value) {
		return Array.indexOf(this._items, value);
	},

	remove: function(value) {
		var index = Array.indexOf(this._items, value);
		if (index != -1)
			this.removeAt(index);
	},

	removeAt: function(index) {
		this._items.slice(index, 1);
		this._onitemRemoved(Sys.EventArgs.Empty);
	},

	add_itemAdded: function(h) {
		this._events.addHandler('itemAdded', h);
	},

	remove_itemAdded: function(h) {
		this._events.removeHandler('itemAdded', h);
	},

	_onitemAdded: function(e) {
		var h = this._events.getHandler('itemAdded');

		if (!!h)
			h(this, e);
	},

	add_itemRemoved: function(h) {
		this._events.addHandler('itemRemoved', h);
	},

	remove_itemRemoved: function(h) {
		this._events.removeHandler('itemRemoved', h);
	},

	_onitemRemoved: function(e) {
		var h = this._events.getHandler('itemRemoved');

		if (!!h)
			h(this, e);
	},

	toArray: function() {
		return _items;
	}
}