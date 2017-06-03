Type.registerNamespace("Nucleo.Web.AccordionControls");

Nucleo.Web.AccordionControls.Accordion = function (el) {
	Nucleo.Web.AccordionControls.Accordion.initializeBase(this, [el]);

	this._items = [];
	this._selectedItem = null;
}

Nucleo.Web.AccordionControls.Accordion.prototype = {
	get_items: function () {
		return this._items;
	},

	get_selectedItem: function () {
		return this._selectedItem;
	},

	set_selectedItem: function (value) {
		if (this._selectedItem != value) {
			if (!!this._beforeItemChange(value)) {
				var oldItem = this.get_selectedItem();
				this._selectedItem = value;

				this._afterItemChange(oldItem, value);
			}
		}
	},

	add_itemClosed: function (handler) {
		this.get_events().addHandler("itemClosed", handler);
	},

	remove_itemClosed: function (handler) {
		this.get_events().removeHandler("itemClosed", handler);
	},

	_onitemClosed: function (e) {
		var h = this.get_events().getHandler("itemClosed");
		if (h) h(this, e);
	},

	add_itemClosing: function (handler) {
		this.get_events().addHandler("itemClosing", handler);
	},

	remove_itemClosing: function (handler) {
		this.get_events().removeHandler("itemClosing", handler);
	},

	_onitemClosing: function (e) {
		var h = this.get_events().getHandler("itemClosing");
		if (h) h(this, e);
	},

	add_itemOpened: function (handler) {
		this.get_events().addHandler("itemOpened", handler);
	},

	remove_itemOpened: function (handler) {
		this.get_events().removeHandler("itemOpened", handler);
	},

	_onitemOpened: function (e) {
		var h = this.get_events().getHandler("itemOpened");
		if (h) h(this, e);
	},

	add_itemOpening: function (handler) {
		this.get_events().addHandler("itemOpening", handler);
	},

	remove_itemOpening: function (handler) {
		this.get_events().removeHandler("itemOpening", handler);
	},

	_onitemOpening: function (e) {
		var h = this.get_events().getHandler("itemOpening");
		if (h) h(this, e);
	},

	_addContent: function (root, html) {
		var content = document.createElement("DIV");
		content.className = "NucleoAccordionContent";
		content.innerHTML = html;

		root.appendChild(content);

		return content;
	},

	_addHeader: function (root, title) {
		var header = document.createElement("a");
		header.href = "#";
		header.innerHTML = title;

		var wrapper = document.createElement("h3");
		wrapper.className = "NucleoAccordionHeader";
		wrapper.appendChild(header);

		root.appendChild(wrapper);

		return header;
	},

	_afterItemChange: function (oldItem, newItem) {
		if (!!oldItem) {
			oldItem.close();
			this._onitemClosed({ item: oldItem, isOpen: false });
		}

		if (!!newItem) {
			newItem.open();
			this._onitemOpened({ item: newItem, isOpen: true });
		}
	},

	_beforeItemChange: function (newItem) {
		var e = { item: this.get_selectedItem(), isOpening: false, cancel: false };
		this._onitemClosing(e);

		if (!!e.cancel)
			return false;

		e = { item: newItem, isOpening: true, cancel: false };
		this._onitemOpening(e);

		if (!!e.cancel)
			return false;

		return true;
	},

	_itemSelectedCallback: function (sender, e) {
		e.accordion.set_selectedItem(e.item);
	},

	_registerItem: function (item) {
		this.get_items().push(item);

		item.add_selected(this._itemSelectedCallback);
		
		//If not item selected, select the first by default
		if (this._selectedItem == null && this.get_items().length > 0)
			this._selectedItem = this.get_items()[0];
	},

	dispose: function () {


		Nucleo.Web.AccordionControls.Accordion.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.AccordionControls.Accordion.registerClass("Nucleo.Web.AccordionControls.Accordion", Nucleo.Web.BaseAjaxControl);