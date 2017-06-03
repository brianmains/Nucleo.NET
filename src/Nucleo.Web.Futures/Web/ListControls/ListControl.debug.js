/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

//TODO: Need to control if setting activeIndex or selectedIndex, should select or toggle the appropriate
//checkmark; need to figure out if selectedIndex should be lower index or how that should be handled.

Type.registerNamespace("Nucleo.Web.ListControls");

Nucleo.Web.ListControls.ListControl = function(associatedElement) {
	Nucleo.Web.ListControls.ListControl.initializeBase(this, [associatedElement]);

	this._activeIndex = null;
	this._alternatingItemStyle = null;
	this._dataTextField = null;
	this._dataTextFormatString = null;
	this._dataValueField = null;
	this._interfaceBuilder = null;
	this._interfaceType = null;
	this._items = null;
	this._itemSelectedStyle = null;
	this._itemStyle = null;
	this._itemToggledStyle = null;
	this._renderOnLoad = null;
	this._repeatColumnCount = null;
	this._repeatingDirection = null;
	this._repeatingLayout = null;
	this._selectedIndex = null;

	this._currentCheckIndex = 1;
	this._clickedHandler = null;

	this._listItemAddedHandler = null;
	this._listItemRemovedHandler = null;
	this._listClearedHandler = null;
	this._listSelectionClearedHandler = null;
}

Nucleo.Web.ListControls.ListControl.prototype = {
	//******************************************************
	// Properties
	//******************************************************
	get_activeIndex: function() {
		if (this._activeIndex >= 0)
			return this._activeIndex;
		else {
			if (this._selectedIndex >= 0)
				this._activeIndex = this._selectedIndex;
			return this._activeIndex;
		}
	},

	get_alternatingItemStyle: function() {
		return this._alternatingItemStyle;
	},

	set_alternatingItemStyle: function(value) {
		if (this._alternatingItemStyle != value) {
			this._alternatingItemStyle = value;
			this.raisePropertyChanged("alternatingItemStyle");
		}
	},

	get_dataTextField: function() {
		return this._dataTextField;
	},

	set_dataTextField: function() {
		if (this._dataTextField != value) {
			this._dataTextField = value;
			this.raisePropertyChanged("dataTextField");
		}
	},

	get_dataTextFormatString: function() {
		return this._dataTextFormatString;
	},

	set_dataTextFormatString: function() {
		if (this._dataTextFormatString != value) {
			this._dataTextFormatString = value;
			this.raisePropertyChanged("dataTextFormatString");
		}
	},

	get_dataValueField: function() {
		return this._dataValueField;
	},

	set_dataValueField: function() {
		if (this._dataValueField != value) {
			this._dataValueField = value;
			this.raisePropertyChanged("dataValueField");
		}
	},

	get_interfaceBuilder: function() {
		if (this._interfaceBuilder == null)
			this._createBuilder();

		return this._interfaceBuilder;
	},

	get_interfaceType: function() {
		return this._interfaceType;
	},

	set_interfaceType: function(value) {
		if (this.get_isInitialized())
			throw Error.notImplemented("The interface type cannot be changed after initialization");

		if (value == Nucleo.Web.ListControls.ListInterfaceType.Custom)
			throw new Error.notImplemented("The custom interface type will be implemented in a later release.  This is currently not supported.");

		if (this._interfaceType != value) {
			this._interfaceType = value;
			this.raisePropertyChanged("interfaceType");
		}
	},

	get_items: function() {
		if (this._items == null)
			this._items = [];
		return this._items;
	},

	set_items: function(value) {
		if (this.get_isInitialized())
			throw Error.notImplemented("The items cannot be set after initialization");

		if (this._items != value) {
			if (typeof (value) == 'string')
				this._items = this._convertToListItemCollection(Sys.Serialization.JavaScriptSerializer.deserialize(value).ItemsList);
			else
				this._items = value;


			this.raisePropertyChanged("items");
		}
	},

	get_itemSelectedStyle: function() {
		return this._itemSelectedStyle;
	},

	set_itemSelectedStyle: function(value) {
		if (this._itemSelectedStyle != value) {
			this._itemSelectedStyle = value;
			this.raisePropertyChanged("itemSelectedStyle");
		}
	},

	get_itemStyle: function() {
		return this._itemStyle;
	},

	set_itemStyle: function(value) {
		if (this._itemStyle != value) {
			this._itemStyle = value;
			this.raisePropertyChanged("itemStyle");
		}
	},

	get_itemToggledStyle: function() {
		return this._itemToggledStyle;
	},

	set_itemToggledStyle: function(value) {
		if (this._itemToggledStyle != value) {
			this._itemToggledStyle = value;
			this.raisePropertyChanged("itemToggledStyle");
		}
	},

	get_renderOnLoad: function() {
		return this._renderOnLoad;
	},

	set_renderOnLoad: function(value) {
		if (this._renderOnLoad != value) {
			this._renderOnLoad = value;
			this.raisePropertyChanged("renderOnLoad");
		}
	},

	get_repeatColumnCount: function() {
		return this._repeatColumnCount;
	},

	set_repeatColumnCount: function(value) {
		if (this._repeatColumnCount != value) {
			this._repeatColumnCount = value;
			this.raisePropertyChanged("repeatColumnCount");
		}
	},

	get_repeatingDirection: function() {
		return this._repeatingDirection;
	},

	set_repeatingDirection: function(value) {
		if (this._repeatingDirection != value) {
			this._repeatingDirection = value;
			this.raisePropertyChanged("repeatingDirection");
		}
	},

	get_repeatingLayout: function() {
		return this._repeatingLayout;
	},

	set_repeatingLayout: function(value) {
		if (this._repeatingLayout != value) {
			this._repeatingLayout = value;
			this.raisePropertyChanged("repeatingLayout");
		}
	},

	get_selectedItem: function() {
		var index = this.get_selectedIndex();
		if (index < 0 || index >= this.get_items().get_count())
			return null;

		return this.get_items().get_item(index);
	},

	get_selectedIndex: function() {
		return this._selectedIndex;
	},

	set_selectedIndex: function(value) {
		if (this._selectedIndex != value) {
			this._selectedIndex = value;
			this.raisePropertyChanged("selectedIndex");
		}
	},

	get_showFooter: function() {
		return false;
	},

	get_showHeader: function() {
		return false;
	},

	get_totalCount: function() {
		return this.get_items().get_count();
	},

	//******************************************************
	// Event Methods
	//******************************************************
	add_allItemsSelected: function(handler) {
		this.get_events().addHandler("allItemsSelected", handler);
	},

	remove_allItemsSelected: function(handler) {
		this.get_events().removeHandler("allItemsSelected", handler);
	},

	raise_allItemsSelected: function() {
		var handler = this.get_events().getHandler("allItemsSelected");
		if (handler != null)
			handler(this, Sys.EventArgs.Empty);
	},

	add_noItemsSelected: function(handler) {
		this.get_events().addHandler("noItemsSelected", handler);
	},

	remove_noItemsSelected: function(handler) {
		this.get_events().removeHandler("noItemsSelected", handler);
	},

	raise_noItemsSelected: function() {
		var handler = this.get_events().getHandler("noItemsSelected");
		if (handler != null)
			handler(this, Sys.EventArgs.Empty);
	},

	add_itemSelected: function(handler) {
		this.get_events().addHandler("itemSelected", handler);
	},

	remove_itemSelected: function(handler) {
		this.get_events().removeHandler("itemSelected", handler);
	},

	raise_itemSelected: function() {
		var handler = this.get_events().getHandler("itemSelected");
		if (handler != null)
			handler(this, Sys.EventArgs.Empty);
	},

	add_itemToggled: function(handler) {
		this.get_events().addHandler("itemToggled", handler);
	},

	remove_itemToggled: function(handler) {
		this.get_events().removeHandler("itemToggled", handler);
	},

	raise_onItemToggled: function() {
		var handler = this.get_events().getHandler("itemToggled");
		if (handler != null)
			handler(this, Sys.EventArgs.Empty);
	},

	//******************************************************
	// Methods
	//******************************************************
	_convertToListItemCollection: function(items) {
		if (items.length == 0)
			return [];

		var listItems = new Nucleo.Web.ListControls.ListItemCollection();

		for (var i = 0; i < items.length; i++) {
			var item = items[i];

			if (item.get_text == undefined) {
				var listItem = new Nucleo.Web.ListControls.ListItem(item.Text, item.Value, item.Selected, item.Enabled);
				listItems.add(listItem);
			}
		}

		this._listItemAddedHandler = Function.createDelegate(this, this._listItemAddedCallback);
		this._listItemRemovedHandler = Function.createDelegate(this, this._listItemRemovedCallback);
		this._listClearedHandler = Function.createDelegate(this, this._listClearedCallback);
		this._listSelectionClearedHandler = Function.createDelegate(this, this._listSelectionClearedCallback);
		listItems.add_itemAdded(this._listItemAddedHandler);
		listItems.add_itemRemoved(this._listItemRemovedHandler);
		listItems.add_cleared(this._listClearedHandler);
		listItems.add_selectionCleared(this._listSelectionClearedHandler);

		return listItems;
	},

	_createBuilder: function() {
		if (this._interfaceBuilder != null)
			return;

		this._interfaceBuilder = Nucleo.Web.ListControls.Builders.ListInterfaceBuilder.buildInterface(this);

		if (this.get_renderOnLoad() == true)
			this._interfaceBuilder._render();
		return this._interfaceBuilder;
	},

	findIndex: function(listItem) {
		return Array.indexOf(listItem);
	},

	findSelectedIndex: function() {
		for (var i = 0; i < this.get_items().length; i++) {
			if (this.get_items()[i].get_selected())
				return i;
		}

		return -1;
	},

	//	_processCheckboxes : function()
	//	{
	//		this._checkboxClickHandler = Function.createDelegate(this, this.checkboxClickCallback);	
	//		this._checkboxes = this.get_element().getElementsByTagName("input");
	//		for (var i = 0; i < this.get_checkboxes().length; i++)
	//			$addHandler(this.get_checkboxes()[i], "click", this._checkboxClickHandler);
	//	},

	_listClearedCallback: function(sender, e) {
		this.get_interfaceBuilder().clearItems();
	},

	_listItemAddedCallback: function(sender, e) {
		this._setupItem(e.get_data());
		this.get_interfaceBuilder().addItem(e.get_data());
	},

	_listItemClickedCallback: function(sender, e) {
		var index = this.findIndex(sender);
		this.set_activeIndex(index);

		if (sender.get_selected())
			this.set_selectedIndex(index);
		else
			this.findSelectedIndex();
	},

	_listItemRemovedCallback: function(sender, e) {
		this._teardownItem(e.get_data());
		this.get_interfaceBuilder().removeItem(e.get_data());
	},

	_listItemSelectedCallback: function(sender, e) {
		if (this.get_itemSelectedStyle() != null)
			sender.style = this.get_itemSelectedStyle();
	},

	_listSelectionClearedCallback: function(sender, e) {
		this.set_selectedIndex(-1);
	},

	_listItemToggledCallback: function(sender, e) {
		if (this.get_itemToggledStyle() != null)
			sender.style = this.get_itemToggledStyle();
	},

	_renderItem: function(index, parentElement) {
		var listItem = this.get_items().get_item(index);
		this.get_interfaceBuilder().createItem(listItem, parentElement);
	},

	selectAllItems: function() {
		for (var i = 0; i < this.get_items().length; i++)
			this.get_items()[i].set_selected(true);
	},

	_setupItem: function(listItem) {
		listItem.add_clicked(this._listItemClickedCallback);
		listItem.add_selected(this._listItemSelectedCallback);
		listItem.add_toggled(this._listItemToggledCallback);
	},

	_teardownItem: function(listItem) {
		listItem.remove_clicked(this._listItemClickedCallback);
		listItem.remove_selected(this._listItemSelectedCallback);
		listItem.remove_toggled(this._listItemToggledCallback);
	},

	//******************************************************
	// Callback Methods
	//******************************************************
	//	checkboxClickCallback : function(domEvent)
	//	{
	//		var checkbox = domEvent.target;
	//		if (checkbox == null) return;
	//		if (checkbox.checked)
	//			this.raise_itemSelected();
	//		
	//		var total = this.get_checkboxes().length;
	//		var count = 0;
	//		
	//		for (var i = 0; i < this.get_checkboxes().length; i++)
	//		{
	//			var checkboxToCompare = this.get_checkboxes()[i];
	//			if (checkbox == checkboxToCompare)
	//				this.set_activeIndex(i);
	//			
	//			if (checkboxToCompare.checked)
	//			{
	//				this.set_selectedIndex(i);
	//				count++;
	//			}
	//		}
	//		
	//		if (count == 0)
	//			this.raise_noItemsSelected();
	//		else if (count == total)
	//			this.raise_allItemsSelected();
	//		this.raise_onItemToggled();
	//	},

	//******************************************************
	// Lifecycle Methods
	//******************************************************
	initialize: function() {
		Nucleo.Web.ListControls.ListControl.callBaseMethod(this, "initialize");
		
		if (this.get_bind
				
		this._createBuilder();
	},

	dispose: function() {

		Nucleo.Web.ListControls.ListControl.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ListControls.ListControl.descriptor = {
	properties:
	[
		{ name: 'activeIndex', type: Number },
		{ name: 'dataTextField', type: String },
		{ name: 'dataTextFormatString', type: String },
		{ name: 'dataValueField', type: String },
		{ name: 'items', type: Array, readOnly: true },
		{ name: 'repeatColumnCount', type: Number },
		{ name: 'repeatingDirection', type: Nucleo.Web.RepeatDirection },
		{ name: 'repeatingLayout', type: Nucleo.Web.RepeatLayout },
		{ name: 'selectedIndex', type: Number }
	],
	methods:
	[
		{ name: 'clearAll' },
		{ name: 'selectAll' }
	],
	events:
	[
		{ name: 'allItemsSelected' },
		{ name: 'noItemsSelected' },
		{ name: 'itemToggled' },
		{ name: 'itemSelected' }
	]
}

Nucleo.Web.ListControls.ListControl.registerClass('Nucleo.Web.ListControls.ListControl', Nucleo.Web.DataboundControls.AjaxDataboundControl, Nucleo.Web.Repeating.IRepeatingList);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();