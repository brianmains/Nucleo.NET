/// <reference name="jquery-1.4.2-vsdoc.js" />
/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ContainerControls");

Nucleo.Web.ContainerControls.DragDropPanelOperation = function () { throw Error.invalidOperation(); }
Nucleo.Web.ContainerControls.DragDropPanelOperation.prototype =
{
	Drag: 1,
	Drop: 2
}
Nucleo.Web.ContainerControls.DragDropPanelOperation.registerEnum("Nucleo.Web.ContainerControls.DragDropPanelOperation");

Nucleo.Web.ContainerControls.PanelPosition = function() { }
Nucleo.Web.ContainerControls.PanelPosition.prototype = {
	BottomLeft: 1
}
Nucleo.Web.ContainerControls.PanelPosition.registerEnum("Nucleo.Web.ContainerControls.PanelPosition");


Nucleo.Web.ContainerControls.Panel = function (el) {
	Nucleo.Web.ContainerControls.Panel.initializeBase(this, [el]);

	this._dragDrop = null;
	this._hovering = null;
	this._modal = null;
	this._resizing = null;
	this._title = null;

	this._timeoutIDs = [];
	this._isOpen = false;
}

Nucleo.Web.ContainerControls.Panel.prototype = {
	get_contentElement: function () {
		return this.get_element().childNodes[1];
	},

	get_dragDrop: function () {
		return this._dragDrop;
	},

	set_dragDrop: function (value) {
		if (typeof (value) === "string")
			this._dragDrop = Sys.Serialization.JavaScriptSerializer.deserialize(value);
		else
			this._dragDrop = value;
	},

	get_hovering: function () {
		return this._hovering;
	},

	set_hovering: function (value) {
		if (typeof (value) === "string")
			this._hovering = Sys.Serialization.JavaScriptSerializer.deserialize(value);
		else
			this._hovering = value;
	},

	get_modal: function () {
		return this._modal;
	},

	set_modal: function (value) {
		if (typeof (value) === "string")
			this._modal = Sys.Serialization.JavaScriptSerializer.deserialize(value);
		else
			this._modal = value;
	},

	get_resizing: function () {
		return this._resizing;
	},

	set_resizing: function (value) {
		if (typeof (value) === "string")
			this._resizing = Sys.Serialization.JavaScriptSerializer.deserialize(value);
		else
			this._resizing = value;
	},

	get_title: function () {
		return this._title;
	},

	set_title: function (value) {
		this._title = value;
	},

	get_titleElement: function () {
		return this.get_element().childNodes[0];
	},

	add_dragEnding: function (h) {
		this.get_events().addHandler("dragEnding", h);
	},

	remove_dragEnding: function (h) {
		this.get_events().removeHandler("dragEnding", h);
	},

	_ondragEnding: function (e) {
		var h = this.get_events().getHandler("dragEnding");
		if (h) h(this, e);
	},

	add_dragStarting: function (h) {
		this.get_events().addHandler("dragStarting", h);
	},

	remove_dragStarting: function (h) {
		this.get_events().removeHandler("dragStarting", h);
	},

	_ondragStarting: function (e) {
		var h = this.get_events().getHandler("dragStarting");
		if (h) h(this, e);
	},

	add_dropped: function (h) {
		this.get_events().addHandler("dropped", h);
	},

	remove_dropped: function (h) {
		this.get_events().removeHandler("dropped", h);
	},

	_ondropped: function (e) {
		var h = this.get_events().getHandler("dropped");
		if (h) h(this, e);
	},

	_clearTimeouts: function () {
		for (var i = 0, len = this._timeoutIDs.length; i < len; i++) {
			window.clearTimeout(this._timeoutIDs.pop());
		}
	},

	_initializeDragDrop: function () {
		if (!this.get_dragDrop() || !this.get_dragDrop().operation)
			return;

		if (!jQuery)
			throw Error.invalidOperation("JQuery script missing.");

		n$.Debug.write("Initializing drag/drop...");

		var that = this;

		if (this.get_dragDrop().operation == Nucleo.Web.ContainerControls.DragDropPanelOperation.Drag) {
			jQuery(this.get_element()).draggable({
				start: function () { that._ondragStarting(Sys.EventArgs.Empty); },
				stop: function () { that._ondragEnding(Sys.EventArgs.Empty); }
			});
		}
		else if (this.get_dragDrop().operation == Nucleo.Web.ContainerControls.DragDropPanelOperation.Drop) {
			jQuery(this.get_element()).droppable({
				accept: function () { return true; },
				drop: function () { that._ondropped(Sys.EventArgs.Empty); }
			});
		}
	},

	_initializeHover: function () {
		if (!this.get_hovering()) {
			this.get_element().style.display = "block";
			return;
		}

		if (!this.get_hovering().controlID)
			return;
		if (this.get_hovering()["__initialized"] == true)
			return;

		n$.Debug.write("Initializing hovering...");

		var control = $get(this.get_hovering().controlID);
		if (control == null)
			return;
		var that = this;

		this.get_element().style.display = "none";

		if (this.get_hovering().relocatePanel) {
			//Move panel
			n$.Debug.write("Relocating panel...");

			//var dims = Sys.UI.DomElement.getBounds(control);
			//var odims = Sys.UI.DomElement.getBounds(this.get_element());

			debugger;
			//n$.Debug.write("Original location: " + dims.x.toString() + ", " + dims.y.toString());
			//Sys.UI.DomElement.setLocation(this.get_element(), dims.x, (dims.y + dims.height));
			//Sys.UI.DomElement.setLocation(this.get_element(), dims.x - odims.x, (dims.y + dims.height - odims.y));

			var dims = jQuery(control).position();
			this.get_element().style.position = "absolute";
			this.get_element().style.left = dims.left.toString() + "px";
			this.get_element().style.top = (dims.top + jQuery(control).outerHeight()).toString() + "px";

			n$.Debug.write("Moved to: " + this.get_element().style.left.toString() + ", " + this.get_element().style.top.toString());
		}

		control.onmouseover = function () {
			that._isOpen = true;
			that._clearTimeouts();
			that._setupHover();
			that.get_element().style.display = "";

			n$.Debug.write("Hover control moused over fired.");
		};

		control.onmouseout = function () {
			that._isOpen = false;
			that._timeoutIDs.push(window.setTimeout(function () { that._timerReset(that); }, 1000));

			n$.Debug.write("Hover control moused out fired.");
		};

		this.get_hovering()["__initialized"] == true;
	},

	_initializeModal: function () {
		if (!this.get_modal())
			return;

		if (!jQuery)
			throw Error.invalidOperation("JQuery script missing.");
		if (!jQuery(this.get_element()).dialog)
			throw Error.invalidOperation("JQuery UI script missing.");

		n$.Debug.write("Initializing modal window...");

		jQuery(this.get_element()).dialog({ autoOpen: false, modal: true });
		var that = this;

		if (typeof (this.get_modal().open) === "undefined") {
			this.get_modal().open = function () {
				jQuery(that.get_element()).dialog("open");
				that._isOpen = true;

				n$.Debug.write("Modal window opened.");
			}
		}
		if (typeof (this.get_modal().close) === "undefined") {
			this.get_modal().close = function () {
				jQuery(that.get_element()).dialog("close");
				that._isOpen = false;

				n$.Debug.write("Modal window closed.");
			}
		}

		if (this.get_modal().isOpen)
			this.get_modal().open();
	},

	_timerReset: function (obj) {
		if (!obj._isOpen)
			obj.get_element().style.display = "none";
	},

	_onmousedOver: function (e) {
		if (!this.get_hovering() || !this.get_hovering().controlID)
			return;

		this._isOpen = true;
		this._clearTimeouts();

		n$.Debug.write("Hover control moused over fired.");
	},

	_onmousedOut: function (e) {
		if (!this.get_hovering() || !this.get_hovering().controlID)
			return;

		this._isOpen = false;

		var that = this;
		that._timeoutIDs.push(window.setTimeout(function () { that._timerReset(that); }, 1000));

		n$.Debug.write("Hover control moused out fired.");
	},

	refreshUI: function () {
		this._resizeUI();
		this._setTitle();
		this._initializeHover();
		this._initializeDragDrop();
		this._initializeModal();
	},

	_resizeUI: function () {
		if (!!this.get_resizing() && !!this.get_resizing().autoCapHeight &&
				!!this.get_resizing().maxHeight && this.get_resizing().maxHeight > 0) {

			n$.Debug.write("Initializing resize...");

			var bounds = Sys.UI.DomElement.getBounds(this.get_element());
			var maxHeight = this.get_resizing().maxHeight;
			if (!maxHeight) maxHeight = 0;

			if (bounds.height > maxHeight) {
				this.get_contentElement().style.overflowY = "scroll";
				this.get_contentElement().style.height = maxHeight
			}
			else {
				this.get_contentElement().style.overflowY = "auto";
				this.get_contentElement().style.height = null;
			}
		}
	},

	_setupHover: function () {
		//		var control = $get(this.get_hovering().controlID);
		//		var controlSize = Sys.UI.DomElement.getBounds(control);

		//		var x = controlSize.x;
		//		var y = controlSize.y + controlSize.height;

		//		var el = this.get_element();
		//		el.style.position = "absolute";
		//el.style.left = x;
		//el.style.top = y;
	},

	_setTitle: function () {
		if (!!this.get_title() && this.get_title().length > 0) {
			this.get_titleElement().innerHTML = this.get_title();
			this.get_titleElement().style.display = "block";
		}
		else
			this.get_titleElement().style.display = "none";

		n$.Debug.write("Title has ben refreshed in the UI");
	},

	initialize: function () {
		Nucleo.Web.ContainerControls.Panel.callBaseMethod(this, "initialize");

		this.refreshUI();
	},

	dispose: function () {

		Nucleo.Web.ContainerControls.Panel.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ContainerControls.Panel.registerClass("Nucleo.Web.ContainerControls.Panel", Nucleo.Web.BaseAjaxControl);