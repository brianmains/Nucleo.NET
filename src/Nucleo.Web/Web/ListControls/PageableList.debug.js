Type.registerNamespace("Nucleo.Web.ListControls");

Nucleo.Web.ListControls.PageableList = function(el) {
	Nucleo.Web.ListControls.PageableList.initializeBase(this, [el]);

	this._currentIndex = 0;
	this._leftPagerImageUrl = null;
	this._orientation = null;
	this._rightPagerImageUrl = null;
	this._visibleItemCount = 0;
}

Nucleo.Web.ListControls.PageableList.prototype = {
	get_currentIndex: function() {
		return this._currentIndex;
	},

	set_currentIndex: function(value) {
		this._currentIndex = value;
		this._page();
	},

	get_leftPagerImageUrl: function() {
		return this._leftPagerImageUrl;
	},

	set_leftPagerImageUrl: function(value) {
		this._leftPagerImageUrl = value;
	},

	get_maximumIndex: function() {
		return ((this.get_element().childNodes.length - 2) - this.get_visibleItemCount());
	},

	get_orientation: function() {
		return this._orientation;
	},

	set_orientation: function(value) {
		this._orientation = value;
	},

	get_rightPagerImageUrl: function() {
		return this._rightPagerImageUrl;
	},

	set_rightPagerImageUrl: function(value) {
		this._rightPagerImageUrl = value;
	},

	get_totalItemCount: function() {
		return this.get_element().childNodes.length - 2;
	},

	get_visibleItemCount: function() {
		return this._visibleItemCount;
	},

	set_visibleItemCount: function(value) {
		if (value < 0)
			throw Error.argument("value");

		this._visibleItemCount = value;
		this._page();
	},

	_page: function() {
		if (this.get_visibleItemCount() == 0)
			return;

		var horizontal = (this.get_orientation() == 0); //load from orientation
		var startIndex = this.get_currentIndex();
		var endIndex = this.get_currentIndex() + this.get_visibleItemCount();

		for (var index = 1, len = this.get_element().childNodes.length - 1; index < len; index++) {
			this.get_element().childNodes[index].style.display =
				(index >= startIndex && index < endIndex)
					? (horizontal ? "inline-block" : "block") : "none";
		}
	},

	pageLeft: function() {
		if (this.get_currentIndex() > 0)
			this.set_currentIndex(this.get_currentIndex() - 1);
	},

	pageRight: function() {
		if (this.get_currentIndex() < (this.get_maximumIndex() - 1))
			this.set_currentIndex(this.get_currentIndex() + 1);
	},

	refresh: function() {
		var display = "block";

		for (var index = 0, len = this.get_element().childNodes.length; index < len; index++) {
			this.get_element().childNodes[index].style.display = display;
		}
	},

	add_leftPagerClicked: function(h) {
		this.get_events().addHandler("leftPagerClicked", h);
	},

	remove_leftPagerClicked: function(h) {
		this.get_events().removeHandler("leftPagerClicked", h);
	},

	_onleftPagerClicked: function(e) {
		var h = this.get_events().getHandler("leftPagerClicked");
		if (h) h(this, e);
	},

	add_rightPagerClicked: function(h) {
		this.get_events().addHandler("rightPagerClicked", h);
	},

	remove_rightPagerClicked: function(h) {
		this.get_events().removeHandler("rightPagerClicked", h);
	},

	_onrightPagerClicked: function(e) {
		var h = this.get_events().getHandler("rightPagerClicked");
		if (h) h(this, e);
	},

	initialize: function() {
		Nucleo.Web.ListControls.PageableList.callBaseMethod(this, "initialize");
		var that = this;

		var img = this.get_element().childNodes[0].childNodes[0];
		$addHandler(img, "click", function() {
			that.pageLeft();
			that._onleftPagerClicked(Sys.EventArgs.Empty);
		});

		img = this.get_element().childNodes[this.get_element().childNodes.length - 1].childNodes[0];
		$addHandler(img, "click", function() {
			that.pageRight();
			that._onrightPagerClicked(Sys.EventArgs.Empty);
		});
	},

	dispose: function() {
		var state = Nucleo.Web.ListControls.PageableList.callBaseMethod(this, "get_clientState");
		if (state != null) {
			state.get_values().addOrUpdate("currentIndex", this.get_currentIndex());
			state.get_values().addOrUpdate("visibleItemCount", this.get_visibleItemCount());
		}

		Nucleo.Web.ListControls.PageableList.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.ListControls.PageableList.registerClass("Nucleo.Web.ListControls.PageableList", Nucleo.Web.BaseAjaxControl);

if (typeof (Sys) !== 'undefined')
	Sys.Application.notifyScriptLoaded();