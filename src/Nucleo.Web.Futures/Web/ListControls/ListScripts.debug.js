/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web.ListControls");


//----------------------------------------------------------------
// ListInterfaceType Enumeration
//----------------------------------------------------------------
Nucleo.Web.ListControls.ListInterfaceType = function() {
    throw Error.notImplemented();
}

Nucleo.Web.ListControls.ListInterfaceType.prototype =
{
    CheckboxList: 0,
    RadioButtonList: 1,
    DropDownList: 2,
    BulletedList: 3,
    Custom: 4
}

Nucleo.Web.ListControls.ListInterfaceType.registerEnum("Nucleo.Web.ListControls.ListInterfaceType");




//----------------------------------------------------------------
// ListItem Class
//----------------------------------------------------------------
Nucleo.Web.ListControls.ListItem = function(text, value, selected, enabled) {
    Nucleo.Web.ListControls.ListItem.initializeBase(this);

    this._text = text;
    this._value = value;
    this._selected = selected;
    this._enabled = enabled;
}

Nucleo.Web.ListControls.ListItem.prototype =
{
    //*****************************************
    // Properties
    //*****************************************
    get_enabled: function() {
        return this._enabled;
    },

    set_enabled: function(value) {
        if (this._enabled != value) {
            this._enabled = value;
            this.raisePropertyChanged("enabled");
        }
    },

    get_selected: function() {
        return this._selected;
    },

    set_selected: function(value) {
        if (this._selected != value) {
            this._selected = value;
            this.raisePropertyChanged("selected");

            if (this._selected == true)
                this.raise_selected();
            this.raise_toggled();
        }
    },

    get_text: function() {
        return this._text;
    },

    set_text: function(value) {
        if (this._text != value) {
            this._text = value;
            this.raisePropertyChanged("text");
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

    //*****************************************
    // Event Handlers
    //*****************************************
    add_clicked: function(handler) {
        this.get_events().addHandler("clicked", handler);
    },

    remove_clicked: function(handler) {
        this.get_events().removeHandler("clicked", handler);
    },

    raise_clicked: function() {
        var handler = this.get_events().getHandler("clicked");
        if (handler != null)
            handler(this, Sys.EventArgs.Empty);
    },

    add_selected: function(handler) {
        this.get_events().addHandler("selected", handler);
    },

    remove_selected: function(handler) {
        this.get_events().removeHandler("selected", handler);
    },

    raise_selected: function() {
        var handler = this.get_events().getHandler("selected");
        if (handler != null)
            handler(this, Sys.EventArgs.Empty);
    },

    add_toggled: function(handler) {
        this.get_events().addHandler("toggled", handler);
    },

    remove_toggled: function(handler) {
        this.get_events().removeHandler("toggled", handler);
    },

    raise_toggled: function() {
        var handler = this.get_events().getHandler("toggled");
        if (handler != null)
            handler(this, Sys.EventArgs.Empty);
    }
}

Nucleo.Web.ListControls.ListItem.descriptor = {
    properties:
	[
		{ name: 'enabled', type: Boolean },
		{ name: 'selected', type: Boolean },
		{ name: 'text', type: String },
		{ name: 'value', type: String }
	],
    events:
	[
		{ name: 'clicked' },
		{ name: 'selected' },
		{ name: 'toggled' }
	]
}

Nucleo.Web.ListControls.ListItem.registerClass('Nucleo.Web.ListControls.ListItem', Sys.Component);



//----------------------------------------------------------------
// ListItemEventArgs Class
//----------------------------------------------------------------
Nucleo.Web.ListControls.ListItemCollection = function() {
    Nucleo.Web.ListControls.ListItemCollection.initializeBase(this);

    this._itemsList = [];
}

Nucleo.Web.ListControls.ListItemCollection.prototype =
{
    //*************************************************************
    // Properties
    //*************************************************************
    get_count: function() {
        return this._itemsList.length;
    },

    get_item: function(index) {
        if (index < 0 || index >= this.get_count())
            throw Error.argumentOutOfRange("index", index);

        return this._itemsList[index];
    },

    //*************************************************************
    // Event Methods
    //*************************************************************
    add_itemAdded: function(handler) {
        this.get_events().addHandler("itemAdded", handler);
    },

    remove_itemAdded: function(handler) {
        this.get_events().removeHandler("itemAdded", handler);
    },

    raise_itemAdded: function(e) {
        var handler = this.get_events().getHandler("itemAdded");
        if (handler != null)
            handler(this, e);
    },

    add_cleared: function(handler) {
        this.get_events().addHandler("cleared", handler);
    },

    remove_cleared: function(handler) {
        this.get_events().removeHandler("cleared", handler);
    },

    raise_cleared: function() {
        var handler = this.get_events().getHandler("cleared");
        if (handler != null)
            handler(this, Sys.EventArgs.Empty);
    },

    add_itemRemoved: function(handler) {
        this.get_events().addHandler("itemRemoved", handler);
    },

    remove_itemRemoved: function(handler) {
        this.get_events().removeHandler("itemRemoved", handler);
    },

    raise_itemRemoved: function(e) {
        var handler = this.get_events().getHandler("itemRemoved");
        if (handler != null)
            handler(this, e);
    },

    add_selectionCleared: function(handler) {
        this.get_events().addHandler("selectionCleared", handler);
    },

    remove_selectionCleared: function(handler) {
        this.get_events().removeHandler("selectionCleared", handler);
    },

    raise_selectionCleared: function() {
        var handler = this.get_events().getHandler("selectionCleared");
        if (handler != null)
            handler(this, Sys.EventArgs.Empty);
    },

    //*************************************************************
    // Methods
    //*************************************************************
    add: function(listItem) {
        if (listItem == null)
            throw Error.argumentNull("listItem");

        Array.add(this._itemsList, listItem);
        this.raise_itemAdded(new Nucleo.DataEventArgs(listItem));
    },

    clear: function() {
        Array.clear(this._itemsList);
        this.raise_cleared();
    },

    clearSelection: function() {
        for (var i = 0; i < this.get_count(); i++)
            this.get_items()[i].set_selected(false);
        this.raise_selectionCleared();
    },

    contains: function(listItem) {
        if (listItem == null)
            throw Error.argumentNull("listItem");

        return (this.indexOf(listItem) != -1);
    },

    findByText: function(text) {
        for (var index = 0; index < this.get_count(); index++) {
            var listItem = this.get_item(index);
            if (listItem.get_text() == text)
                return listItem;
        }

        return null;
    },

    findByValue: function(value) {
        for (var index = 0; index < this.get_count(); index++) {
            var listItem = this.get_item(index);
            if (listItem.get_value() == value)
                return listItem;
        }

        return null;
    },

    indexOf: function(listItem) {
        if (listItem == null)
            throw Error.argumentNull("listItem");

        for (var index = 0; index < this.get_count(); index++) {
            var comparison = this.get_item(index);
            if (comparison.get_text() == listItem.get_text() &&
                comparison.get_value() == listItem.get_value())
                return index;
        }

        return -1;
    },

    remove: function(listItem) {
        if (listItem == null)
            throw Error.argumentNull("listItem");

        Array.remove(this._itemsList, listItem);
        this.raise_itemRemoved(new Nucleo.DataEventArgs(listItem));
    }
}

Nucleo.Web.ListControls.ListItemCollection.descriptor =
{
    properties:
    [
        { name: "count", type: Number, readOnly: true },
        { name: "item", type: Object, readOnly: true }
    ],
    methods:
    [
        { name: "add" },
        { name: "clear" },
        { name: "contains" },
        { name: "findByText" },
        { name: "findByValue" },
        { name: "indexOf" },
        { name: "remove" }
    ],
    events:
    [
        { name: "itemAdded" },
        { name: "cleared" },
        { name: "itemRemoved" },
        { name: "selectionCleared" }
    ]
}

Nucleo.Web.ListControls.ListItemCollection.registerClass("Nucleo.Web.ListControls.ListItemCollection", Sys.Component);



//----------------------------------------------------------------
// ListItemEventArgs Class
//----------------------------------------------------------------
Nucleo.Web.ListControls.ListItemEventArgs = function(listItem) {
    this._listItem = listItem;
}

Nucleo.Web.ListControls.ListItemEventArgs.prototype =
{
    get_listItem: function() {
        return this._listItem;
    }
}

Nucleo.Web.ListControls.ListItemEventArgs.registerClass("Nucleo.Web.ListControls.ListItemEventArgs", Sys.EventArgs);

if (typeof (Sys) !== 'undefined')
    Sys.Application.notifyScriptLoaded();