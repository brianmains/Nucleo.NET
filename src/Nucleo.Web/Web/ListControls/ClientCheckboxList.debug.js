/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

//TODO: Need to control if setting activeIndex or selectedIndex, should select or toggle the appropriate
//checkmark; need to figure out if selectedIndex should be lower index or how that should be handled.

Type.registerNamespace("Nucleo.Web.ListControls");

Nucleo.Web.ListControls.ClientCheckboxList = function(associatedElement)
{
	Nucleo.Web.ListControls.ClientCheckboxList.initializeBase(this, [associatedElement]);
	
	this._checkboxes = null;
	this._checkboxClickHandler = null;
	this._newItemsClientState = null;
	this._removedItemsClientState = null;
	this._activeIndex = null;
	this._selectedIndex = null;
	this._currentCheckIndex = 1;
}

Nucleo.Web.ListControls.ClientCheckboxList.prototype = {
	//******************************************************
	// Properties
	//******************************************************
	get_activeIndex : function()
	{
		return this._activeIndex;
	},
	
	set_activeIndex : function(value)
	{
		if (this._activeIndex != value)
		{
			this._activeIndex = value;
			this.raisePropertyChanged("activeIndex");
		}
	},
	
	get_checkboxes : function()
	{
		if (this._checkboxes == null)
			this._processCheckboxes();
		return this._checkboxes;
	},
	
	get_newItemsClientState : function()
	{
		return this._newItemsClientState;
	},
	
	set_newItemsClientState : function(value)
	{
		if (this._newItemsClientState != value)
		{
			this._newItemsClientState = value;
			this.raisePropertyChanged("newItemsClientState");
		}
	},
	
	get_removedItemsClientState : function()
	{
		return this._removedItemsClientState;
	},
	
	set_removedItemsClientState : function(value)
	{
		if (this._removedItemsClientState != value)
		{
			this._removedItemsClientState = value;
			this.raisePropertyChanged("removedItemsClientState");
		}
	},
	
	get_selectedIndex : function()
	{
		return this._selectedIndex;
	},
	
	set_selectedIndex : function(value)
	{
		if (this._selectedIndex != value)
		{
			this._selectedIndex = value;
			this.raisePropertyChanged("selectedIndex");
		}
	},
	
	//******************************************************
	// Event Methods
	//******************************************************
	add_allItemsSelected : function(handler)
	{
		this.get_events().addHandler("allItemsSelected", handler);
	},
	
	remove_allItemsSelected : function(handler)
	{
		this.get_events().removeHandler("allItemsSelected", handler);
	},
	
	_onAllItemsSelected : function()
	{
		var handler = this.get_events().getHandler("allItemsSelected");
		if (handler != null)
			handler(this, Sys.EventArgs.Empty);
	},
	
	add_noItemsSelected : function(handler)
	{
		this.get_events().addHandler("noItemsSelected", handler);
	},
	
	remove_noItemsSelected : function(handler)
	{
		this.get_events().removeHandler("noItemsSelected", handler);
	},
	
	_onNoItemsSelected : function()
	{
		var handler = this.get_events().getHandler("noItemsSelected");
		if (handler != null)
			handler(this, Sys.EventArgs.Empty);
	},
	
	add_itemSelected : function(handler)
	{
		this.get_events().addHandler("itemSelected", handler);
	},

	remove_itemSelected : function(handler)
	{
		this.get_events().removeHandler("itemSelected", handler);
	},

	_onitemSelected : function()
	{
		var handler = this.get_events().getHandler("itemSelected");
		if (handler != null)
			handler(this, Sys.EventArgs.Empty);
	},

	add_itemToggled : function(handler)
	{
		this.get_events().addHandler("itemToggled", handler);
	},

	remove_itemToggled : function(handler)
	{
		this.get_events().removeHandler("itemToggled", handler);
	},

	_onitemToggled : function()
	{
		var handler = this.get_events().getHandler("itemToggled");
		if (handler != null)
			handler(this, Sys.EventArgs.Empty);
	},
	
	//******************************************************
	// Lifecycle Methods
	//******************************************************
	initialize : function()
	{
		Nucleo.Web.ListControls.ClientCheckboxList.callBaseMethod(this, "initialize");
		this._processCheckboxes();
	},

	dispose : function()
	{
		for (var i = 0; i <  this.get_checkboxes().length; i++)
			$removeHandler(this.get_checkboxes()[i], "click", this._checkboxClickHandler);
		
		this._checkboxClickHandler = null;
		Nucleo.Web.ListControls.ClientCheckboxList.callBaseMethod(this, "dispose");
	},
	
	//******************************************************
	// Methods
	//******************************************************
	addItem : function(text, value, selected, enabled)
	{
		var hiddenField = this.get_newItemsClientState();
		var newItem = text + "$" + value + "$" + selected.toString() + "$" + enabled.toString();
		
		if (hiddenField.value != null && hiddenField.value.length > 0)
			hiddenField.value += ";";
		hiddenField.value += newItem;
		
		this._createCheck(text, value, selected, enabled);
	},
	
	clearAll : function()
	{
		for (var i = 0; i < this.get_checkboxes().length; i++)
		{
			var checkbox = this.get_checkboxes()[i];
			checkbox.checked = false;
		}
	},
	
	_createCheck : function(text, value, selected, enabled)
	{
		if (this._currentCheckIndex == null)
			this._currentCheckIndex = 1;
	
//		var check = '<input type="check" ';
//		check += 'id="' + this.get_id() + this._currentCheckIndex.toString() + '" ';
//		check += 'checked="' + selected.toString() + '">';
//		check += text;
//		check += '</input>';

		var check = document.createElement("input");
		check.type = "checkbox";
		check.checked = selected;
		if (!enabled)
			check.disabled = "disabled";
		check.value = text;
		$addHandler(check, "click", this._checkboxClickHandler);
			
		if (this.get_element().tagName == "SPAN")
			this.get_element().appendChild(check);
		else
		{
			
		}
		
		this._currentCheckIndex += 1;
	},
	
	_processCheckboxes : function()
	{
		this._checkboxClickHandler = Function.createDelegate(this, this.checkboxClickCallback);	
		this._checkboxes = this.get_element().getElementsByTagName("input");
		for (var i = 0; i < this.get_checkboxes().length; i++)
			$addHandler(this.get_checkboxes()[i], "click", this._checkboxClickHandler);
	},
		
	removeItem : function(value)
	{
		var hiddenField = this.get_removedItemsClientState();
		var removedItem = value;
		
		if (hiddenField.value != null && hiddenField.value.length > 0)
			hiddenField.value += ";";
		hiddenField.value += removedItem;
		
		for (var i = 0; i < this.get_element().length; i++)
		{
			if (this.get_element().options[i].value == value)
				this.get_element().options[i] = null;
		}
	},

	selectAll : function()
	{
		for (var i = 0; i < this.get_checkboxes().length; i++)
		{
			var checkbox = this.get_checkboxes()[i];
			checkbox.checked = true;
		}
	},
	
	//******************************************************
	// Callback Methods
	//******************************************************
	checkboxClickCallback : function(domEvent)
	{
		var checkbox = domEvent.target;
		if (checkbox == null) return;
		if (checkbox.checked)
			this.raise_itemSelected();
		
		var total = this.get_checkboxes().length;
		var count = 0;
		var hasSelected = false;

		for (var i = 0; i < this.get_checkboxes().length; i++)
		{
			var checkboxToCompare = this.get_checkboxes()[i];
			if (checkbox == checkboxToCompare)
				this.set_activeIndex(i);
			
			if (checkboxToCompare.checked)
			{
				if (!hasSelected)
				{
					this.set_selectedIndex(i);
					hasSelected = true;
				}
				
				count++;
			}
		}

		if (hasSelected == false)
			this.set_selectedIndex(-1);
		
		if (count == 0)
			this.raise_noItemsSelected();
		else if (count == total)
			this.raise_allItemsSelected();
		this.raise_itemToggled();
	}
}
	
Nucleo.Web.ListControls.ClientCheckboxList.descriptor = {
	properties:
	[
		{ name: 'activeIndex', type: Number },
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

Nucleo.Web.ListControls.ClientCheckboxList.registerClass('Nucleo.Web.ListControls.ClientCheckboxList', Sys.UI.Control);

if (typeof(Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();