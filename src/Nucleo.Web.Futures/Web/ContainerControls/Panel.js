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

Nucleo.Web.ContainerControls.PanelPosition = function () { }
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

		var that = this;
		if (typeof (this._modal["open"]) === "undefined") {
			this._modal["open"] = function () {
				jQuery(that.get_element()).dialog("option", "show");
			};
		}

		if (typeof (this._modal["close"]) === "undefined") {
			this._modal["close"] = function () {
				jQuery(that.get_element()).dialog("option", "show");
			}
		}
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

	_initializeHover: function () {
		if (!this.get_hovering()) {
			this.get_element().style.display = "block";
			return;
		}

		if (!this.get_hovering().controlID)
			return;

		var control = $get(this.get_hovering().controlID);
		if (control == null)
			return;
		var that = this;

		this.get_element().style.display = "none";

		if (this.get_hovering().relocatePanel) {
			//Move panel
		}

		control.onmouseover = function () {
			that._isOpen = true;
			that._clearTimeouts();
			that._setupHover();
			that.get_element().style.display = "block";

			n$.Debug.write("Hover control moused over fired.");
		};

		control.onmouseout = function () {
			that._isOpen = false;
			that._timeoutIDs.push(window.setTimeout(function () { that._timerReset(that); }, 1000));

			n$.Debug.write("Hover control moused out fired.");
		};
	},

	_timerReset: function (obj) {
		if (!obj._isOpen)
			obj.get_element().style.display = "none";
	},

	_onmousedOver: function (e) {
		this._isOpen = true;
		this._clearTimeouts();

		n$.Debug.write("Panel control moused over fired.");
	},

	_onmousedOut: function (e) {
		this._isOpen = false;

		var that = this;
		that._timeoutIDs.push(window.setTimeout(function () { that._timerReset(that); }, 1000));

		n$.Debug.write("Panel control moused out fired.");
	},

	refreshUI: function () {
		this._resizeUI();
		this._setTitle();
		this._initializeHover();
		this._setupDragDrop();
		this._setupModal();
	},

	_resizeUI: function () {
		if (!!this.get_resizing() && !!this.get_resizing().autoCapHeight &&
				!!this.get_resizing().maxHeight && this.get_resizing().maxHeight > 0) {
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

	_setupDragDrop: function () {
		if (!this.get_dragDrop() || !this.get_dragDrop().operation)
			return;

		if (!jQuery)
			throw Error.invalidOperation("JQuery script missing.");

		var that = this;

		if (this.get_dragDrop().operation == Nucleo.Web.ContainerControls.DragDropPanelOperation.Drag) {
			if (!jQuery.draggable)
				throw Error.invalidOperation("JQuery draggable script missing.");

			jQuery(this.get_element()).draggable({
				start: function () { that._ondragStarting(Sys.EventArgs.Empty); },
				stop: function () { that._ondragEnding(Sys.EventArgs.Empty); }
			});
		}
		else if (this.get_dragDrop().operation == Nucleo.Web.ContainerControls.DragDropPanelOperation.Drop) {
			if (!jQuery.droppable)
				throw Error.invalidOperation("JQuery droppable script missing.");

			jQuery(this.get_element()).droppable({
				accept: function () { return true; },
				drop: function () { that._ondropped(Sys.EventArgs.Empty); }
			});
		}
	},

	_setupHover: function () {
		var control = $get(this.get_hovering().controlID);
		var controlSize = Sys.UI.DomElement.getBounds(control);

		var x = controlSize.x;
		var y = controlSize.y + controlSize.height;

		var el = this.get_element();
		el.style.position = "absolute";
		//el.style.left = x;
		//el.style.top = y;
	},

	_setupModal: function () {
		if (!this.get_modal())
			return;

		if (!jQuery)
			throw Error.invalidOperation("JQuery script missing.");
		if (!jQuery.dialog)
			throw Error.invalidOperation("JQuery UI script missing.");

		jQuery(this.get_element()).dialog({ autoOpen: false, modal: true });

		if (this.get_modal().isOpen)
			this.get_modal().open();
	},

	_setTitle: function () {
		if (!!this.get_title() && this.get_title().length > 0) {
			this.get_titleElement().innerHTML = this.get_title();
			this.get_titleElement().style.display = "block";
		}
		else
			this.get_titleElement().style.display = "none";
	},

	initialize: function () {
		Nucleo.Web.ContainerControls.Panel.callBaseMethod(this, "initialize");

		this.refreshUI();
	},

	dispose: function () {
		var state = Nucleo.Web.EditorControls.TextEditor.callBaseMethod(this, "get_clientState");
		if (state != null)
			state.get_values().addOrUpdate("modal_isOpen", this._isOpen);

		Nucleo.Web.ContainerControls.Panel.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ContainerControls.Panel.registerClass("Nucleo.Web.ContainerControls.Panel", Nucleo.Web.BaseAjaxControl);