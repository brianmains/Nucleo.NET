Type.registerNamespace("Nucleo.Web.DropDownControls");

Nucleo.Web.DropDownControls.DropDown = function(el) {
	Nucleo.Web.DropDownControls.DropDown.initializeBase(this, [el]);

	this._content = null;
	this._inputOptions = null;
	this._menuOptions = null;
	this._selectorOptions = null;
	this._text = null;

	this._closeButtonClickHandler = null;
	this._inputBlurHandler = null;
	this._selectorClickHandler = null;
}

Nucleo.Web.DropDownControls.DropDown.prototype = {
	get_content: function() {
		return this._content;
	},

	set_content: function(value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Cannot be set after initialize");

		this._content = value;
	},

	get_inputElement: function() {
		return this._getInnerElement(this.get_inputOptions().ControlID);
	},

	get_inputOptions: function() {
		return this._inputOptions;
	},

	set_inputOptions: function(value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Cannot be set after initialize");

		this._inputOptions = value;
	},

	get_menuElement: function() {
		return this._getInnerElement(this.get_menuOptions().ControlID);
	},

	get_menuOptions: function() {
		return this._menuOptions;
	},

	set_menuOptions: function(value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Cannot be set after initialize");

		this._menuOptions = value;
	},

	get_selectorElement: function() {
		return this._getInnerElement(this.get_selectorOptions().ControlID);
	},

	get_selectorOptions: function() {
		return this._selectorOptions;
	},

	set_selectorOptions: function(value) {
		if (this.get_isInitialized())
			throw Error.invalidOperation("Cannot be set after initialize");

		this._selectorOptions = value;
	},

	get_text: function() {
		return this._text;
	},

	set_text: function(value) {
		this._text = value;
		this.get_inputElement().value = value;
	},

	_closeButtonClickCallback: function(e) {
		this.hideMenu();
		n$.Debug.write("The menu has been closed via the close button");
	},

	hideMenu: function() {
		this.get_menuElement().style.display = "none";
	},

	_inputBlurCallback: function(e) {
		this._text = this.get_inputElement().value;
		n$.Debug.write("Text changed to: " + this._text);
	},

	resizeMenu: function() {
		var menu = this.get_menuElement();
		var width = 0;

		for (var i = 0, len = menu.childNodes.length - 1; i < len; i++) {
			var w = n$.el(menu.childNodes[i]).dimensions("outer").width;
			width += w;

			n$.Debug.write("Menu child at " + i + " is " + w + "pixels");
		}

		menu.style.width = width;
	},

	_selectorClickCallback: function(e) {
		this.toggleMenu();
		n$.Debug.write("The selector has been clicked");
	},

	_setMenuOuterWidth: function() {
		var menu = this.get_menuElement();
		var width = 0;

		for (var i = 0, len = menu.childNodes.length - 1; i < len; i++) {
			var child = menu.childNodes[i];
		}

		menu.style.width = width;
	},

	showMenu: function() {
		var menu = this.get_menuElement();
		menu.style.display = "block";

		try { this.resizeMenu(); }
		catch (ex) { }
	},

	toggleMenu: function() {
		var menu = this.get_menuElement();

		if (menu.style.display == "block")
			this.hideMenu();
		else
			this.showMenu();
	},

	initialize: function() {
		Nucleo.Web.DropDownControls.DropDown.callBaseMethod(this, "initialize");

		this.hideMenu();
		this._initializeSelector();
	},

	_initializeSelector: function() {
		var dropDown = this.get_selectorElement();
		var closeBtn = this._getInnerElement(this.get_menuOptions().CloseButtonControlID);

		this._selectorClickHandler = Function.createDelegate(this, this._selectorClickCallback);
		$addHandler(dropDown, "click", this._selectorClickHandler);
		this._closeButtonClickHandler = Function.createDelegate(this, this._closeButtonClickCallback);
		$addHandler(closeBtn, "click", this._closeButtonClickHandler);
		this._inputBlurHandler = Function.createDelegate(this, this._inputBlurCallback);
		$addHandler(this.get_inputElement(), "blur", this._inputBlurHandler);
	},

	dispose: function() {

		Nucleo.Web.DropDownControls.DropDown.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.DropDownControls.DropDown.registerClass("Nucleo.Web.DropDownControls.DropDown", Nucleo.Web.BaseAjaxControl);