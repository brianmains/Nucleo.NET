/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web");


Nucleo.Web.BaseAjaxExtender = function(el) {
Nucleo.Web.BaseAjaxExtender.initializeBase(this, [el]);

	this._clientStateField = null;
	this._referenceName = null;
	this._renderingMode = null;

	this._blurHandler = null;
	this._clickHandler = null;
	this._dblclickHandler = null;
	this._focusHandler = null;
	this._keydownHandler = null;
	this._keypressHandler = null;
	this._keyupHandler = null;
	this._mousedownHandler = null;
	this._mousemoveHandler = null;
	this._mouseoverHandler = null;
	this._mouseoutHandler = null;
	this._mouseupHandler = null;
}

Nucleo.Web.BaseAjaxExtender.prototype =
{
	get_clientState: function () {
		if (this.get_clientStateField() == null)
			return null;

		if (this._clientState != null)
			return this._clientState;

		this._clientState = this._createClientState();
		if (this.get_clientStateField().value.length > 0) {
			var json = Nucleo.JsonParse(this.get_clientStateField().value);
			this._clientState.fromJson(json);
		}

		return this._clientState;
	},

	set_clientState: function(value) {
		if (this.get_clientStateField() == null)
			return;

		this.get_clientStateField().value = value;
	},

	get_clientStateField: function() {
		return this._clientStateField;
	},

	set_clientStateField: function(value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Client state cannot be set after initialization");

		this._clientStateField = value;
	},

	get_enabled: function() {
		return !this.get_element().disabled;
	},

	set_enabled: function(value) {
		this.get_element().disabled = !value;
	},
	
	get_referenceName: function() {
		return this._referenceName;
	},

	set_referenceName: function(value) {
		this._referenceName = value;
	},

	get_renderingMode: function() {
		return this._renderingMode;
	},

	set_renderingMode: function(value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Rendering mode cannot be set after initialization");

		this._renderingMode = value;
	},

	get_visible: function() {
		return Sys.UI.DomElement.getVisible(this.get_element());
	},

	set_visible: function(value) {
		Sys.UI.DomElement.setVisible(this.get_element(), value);
	},

	_createClientState: function() {
		return new Nucleo.Web.ClientState.ClientStateData();
	},

	add_clicked: function(handler) {
		this.get_events().addHandler('clicked', handler);
	},

	remove_clicked: function(handler) {
		this.get_events().removeHandler('clicked', handler);
	},

	_onclicked: function(e) {
		var h = this.get_events().getHandler('clicked');
		if (h) h(this, e);
	},

	add_doubleClicked: function(handler) {
		this.get_events().addHandler('doubleClicked', handler);
	},

	remove_doubleClicked: function(handler) {
		this.get_events().removeHandler('doubleClicked', handler);
	},

	_ondoubleClicked: function(e) {
		var h = this.get_events().getHandler('doubleClicked');
		if (h) h(this, e);
	},

	add_gotFocus: function(handler) {
		this.get_events().addHandler('gotFocus', handler);
	},

	remove_gotFocus: function(handler) {
		this.get_events().removeHandler('gotFocus', handler);
	},

	_ongotFocus: function(e) {
		var h = this.get_events().getHandler('gotFocus');
		if (h) h(this, e);
	},

	add_keyAfterPress: function(handler) {
		this.get_events().addHandler('keyAfterPress', handler);
	},

	remove_keyAfterPress: function(handler) {
		this.get_events().removeHandler('keyAfterPress', handler);
	},

	_onkeyAfterPress: function(e) {
		var h = this.get_events().getHandler('keyAfterPress');
		if (h) h(this, e);
	},

	add_keyBeforePress: function(handler) {
		this.get_events().addHandler('keyBeforePress', handler);
	},

	remove_keyBeforePress: function(handler) {
		this.get_events().removeHandler('keyBeforePress', handler);
	},

	_onkeyBeforePress: function(e) {
		var h = this.get_events().getHandler('keyBeforePress');
		if (h) h(this, e);
	},

	add_keyPressed: function(handler) {
		this.get_events().addHandler('keyPressed', handler);
	},

	remove_keyPressed: function(handler) {
		this.get_events().removeHandler('keyPressed', handler);
	},

	_onkeyPressed: function(e) {
		var h = this.get_events().getHandler('keyPressed');
		if (h) h(this, e);
	},

	add_lostFocus: function(handler) {
		this.get_events().addHandler('lostFocus', handler);
	},

	remove_lostFocus: function(handler) {
		this.get_events().removeHandler('lostFocus', handler);
	},

	_onlostFocus: function(e) {
		var h = this.get_events().getHandler('lostFocus');
		if (h) h(this, e);
	},

	add_mousedDown: function(handler) {
		this.get_events().addHandler('mousedDown', handler);
	},

	remove_mousedDown: function(handler) {
		this.get_events().removeHandler('mousedDown', handler);
	},

	_onmousedDown: function(e) {
		var h = this.get_events().getHandler('mousedDown');
		if (h) h(this, e);
	},

	add_mousedOut: function(handler) {
		this.get_events().addHandler('mousedOut', handler);
	},

	remove_mousedOut: function(handler) {
		this.get_events().removeHandler('mousedOut', handler);
	},

	_onmousedOut: function(e) {
		var h = this.get_events().getHandler('mousedOut');
		if (h) h(this, e);
	},

	add_mousedOver: function(handler) {
		this.get_events().addHandler('mousedOver', handler);
	},

	remove_mousedOver: function(handler) {
		this.get_events().removeHandler('mousedOver', handler);
	},

	_onmousedOver: function(e) {
		var h = this.get_events().getHandler('mousedOver');
		if (h) h(this, e);
	},

	add_mousedUp: function(handler) {
		this.get_events().addHandler('mousedUp', handler);
	},

	remove_mousedUp: function(handler) {
		this.get_events().removeHandler('mousedUp', handler);
	},

	_onmousedUp: function(e) {
		var h = this.get_events().getHandler('mousedUp');
		if (h) h(this, e);
	},

	add_mouseMove: function(handler) {
		this.get_events().addHandler('mouseMove', handler);
	},

	remove_mouseMove: function(handler) {
		this.get_events().removeHandler('mouseMove', handler);
	},

	_onmouseMove: function(e) {
		var h = this.get_events().getHandler('mouseMove');
		if (h) h(this, e);
	},

	_blurCallback: function (domEvent) {
		this._onlostFocus({ component: this, domEvent: domEvent });
	},

	_clickCallback: function (domEvent) {
		this._onclicked({ component: this, domEvent: domEvent });
	},

	_dblclickCallback: function (domEvent) {
		this._ondoubleClicked({ component: this, domEvent: domEvent });
	},

	_focusCallback: function (domEvent) {
		this._ongotFocus({ component: this, domEvent: domEvent });
	},

	_keydownCallback: function (domEvent) {
		this._onkeyBeforePress({ component: this, domEvent: domEvent });
	},

	_keypressCallback: function (domEvent) {
		this._onkeyPressed({ component: this, domEvent: domEvent });
	},

	_keyupCallback: function (domEvent) {
		this._onkeyAfterPress({ component: this, domEvent: domEvent });
	},

	_mousedownCallback: function (domEvent) {
		this._onmousedDown({ component: this, domEvent: domEvent });
	},

	_mousemoveCallback: function (domEvent) {
		this._onmouseMove({ component: this, domEvent: domEvent });
	},

	_mouseoverCallback: function (domEvent) {
		this._onmousedOver({ component: this, domEvent: domEvent });
	},

	_mouseoutCallback: function (domEvent) {
		this._onmousedOut({ component: this, domEvent: domEvent });
	},

	_mouseupCallback: function (domEvent) {
		this._onmousedUp({ component: this, domEvent: domEvent });
	},

	initialize: function() {
		Nucleo.Web.BaseAjaxExtender.callBaseMethod(this, "initialize");

		this._blurHandler = Function.createDelegate(this, this._blurCallback);
		$addHandler(this.get_element(), 'blur', this._blurHandler);
		this._clickHandler = Function.createDelegate(this, this._clickCallback);
		$addHandler(this.get_element(), 'click', this._clickHandler);
		this._dblclickHandler = Function.createDelegate(this, this._dblclickCallback);
		$addHandler(this.get_element(), 'dblclick', this._dblclickHandler);
		this._focusHandler = Function.createDelegate(this, this._focusCallback);
		$addHandler(this.get_element(), 'focus', this._focusHandler);
		this._keydownHandler = Function.createDelegate(this, this._keydownCallback);
		$addHandler(this.get_element(), 'keydown', this._keydownHandler);
		this._keypressHandler = Function.createDelegate(this, this._keypressCallback);
		$addHandler(this.get_element(), 'keypress', this._keypressHandler);
		this._keyupHandler = Function.createDelegate(this, this._keyupCallback);
		$addHandler(this.get_element(), 'keyup', this._keyupHandler);
		this._mousedownHandler = Function.createDelegate(this, this._mousedownCallback);
		$addHandler(this.get_element(), 'mousedown', this._mousedownHandler);
		this._mousemoveHandler = Function.createDelegate(this, this._mousemoveCallback);
		$addHandler(this.get_element(), 'mousemove', this._mousemoveHandler);
		this._mouseoverHandler = Function.createDelegate(this, this._mouseoverCallback);
		$addHandler(this.get_element(), 'mouseover', this._mouseoverHandler);
		this._mouseoutHandler = Function.createDelegate(this, this._mouseoutCallback);
		$addHandler(this.get_element(), 'mouseout', this._mouseoutHandler);
		this._mouseupHandler = Function.createDelegate(this, this._mouseupCallback);
		$addHandler(this.get_element(), 'mouseup', this._mouseupHandler);
	},

	dispose: function() {
		$removeHandler(this.get_element(), 'blur', this._blurHandler);
		this._blurHandler = null;
		$removeHandler(this.get_element(), 'click', this._clickHandler);
		this._clickHandler = null;
		$removeHandler(this.get_element(), 'dblclick', this._dblclickHandler);
		this._dblclickHandler = null;
		$removeHandler(this.get_element(), 'focus', this._focusHandler);
		this._focusHandler = null;
		$removeHandler(this.get_element(), 'keydown', this._keydownHandler);
		this._keydownHandler = null;
		$removeHandler(this.get_element(), 'keypress', this._keypressHandler);
		this._keypressHandler = null;
		$removeHandler(this.get_element(), 'keyup', this._keyupHandler);
		this._keyupHandler = null;
		$removeHandler(this.get_element(), 'mousedown', this._mousedownHandler);
		this._mousedownHandler = null;
		$removeHandler(this.get_element(), 'mousemove', this._mousemoveHandler);
		this._mousemoveHandler = null;
		$removeHandler(this.get_element(), 'mouseover', this._mouseoverHandler);
		this._mouseoverHandler = null;
		$removeHandler(this.get_element(), 'mouseout', this._mouseoutHandler);
		this._mouseoutHandler = null;
		$removeHandler(this.get_element(), 'mouseup', this._mouseupHandler);
		this._mouseupHandler = null;

		if (this._clientState != null)
			this.get_clientStateField().value = Sys.Serialization.JavaScriptSerializer.serialize(this._clientState.toJson());

		Nucleo.Web.BaseAjaxExtender.callBaseMethod(this, "dispose");
	}
}


//***************************************************************
// Registration
//***************************************************************
Nucleo.Web.BaseAjaxExtender.registerClass('Nucleo.Web.BaseAjaxExtender', Sys.UI.Behavior);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();
