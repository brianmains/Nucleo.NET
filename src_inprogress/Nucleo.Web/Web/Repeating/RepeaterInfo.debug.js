/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit" />

Type.registerNamespace("Nucleo.Web");

//***************************************************************
//***************************************************************
//***************************************************************
// RepeatDirection Enumeration
//***************************************************************
//***************************************************************
//***************************************************************
Nucleo.Web.Repeating.RepeatDirection = function() { throw Error.notImplemented(); }
Nucleo.Web.Repeating.RepeatDirection.prototype =
{
    Horizontal: 0,
    Vertical: 1
}

Nucleo.Web.Repeating.RepeatDirection.registerEnum("Nucleo.Web.Repeating.RepeatDirection");



//***************************************************************
//***************************************************************
//***************************************************************
// RepeatLayout Enumeration
//***************************************************************
//***************************************************************
//***************************************************************
Nucleo.Web.Repeating.RepeatLayout = function() { throw Error.notImplemented(); }
Nucleo.Web.Repeating.RepeatLayout.prototype =
{
    Table: 0,
    Flow: 1
}

Nucleo.Web.Repeating.RepeatLayout.registerEnum("Nucleo.Web.Repeating.RepeatLayout");



//***************************************************************
//***************************************************************
//***************************************************************
// Repeat Item Event Arguments
//***************************************************************
//***************************************************************
//***************************************************************
Nucleo.Web.Repeating.RepeatItemEventArgs = function(repeatControl, repeatIndex, parentElement) {
    this._repeatControl = repeatControl;
    this._repeatIndex = repeatIndex;
    this._parentElement = parentElement;
}

Nucleo.Web.Repeating.RepeatItemEventArgs.prototype =
{
    get_parentElement: function() {
        return this._parentElement;
    },

    get_repeatControl: function() {
        return this._repeatControl;
    },

    get_repeatIndex: function() {
        return this._repeatIndex;
    }
}

Nucleo.Web.Repeating.RepeatItemEventArgs.descriptor =
{
    properties:
    [
        { name: "parentElement", type: Object, readOnly: true },
        { name: "repeatControl", type: Object, readOnly: true },
        { name: "repeatIndex", type: Number, readOnly: true }
    ]
}

Nucleo.Web.Repeating.RepeatItemEventArgs.registerClass("Nucleo.Web.Repeating.RepeatItemEventArgs", Sys.EventArgs);


//***************************************************************
//***************************************************************
//***************************************************************
//Repeat Setup Manager
//***************************************************************
//***************************************************************
//***************************************************************
Nucleo.Web.Repeating.RepeatLayoutManager = function(repeatColumnCount, repeatingLayout, repeatingDirection) {
    this._repeatColumnCount = repeatColumnCount;
    this._repeatingLayout = repeatingLayout;
    this._repeatingDirection = repeatingDirection;
}

Nucleo.Web.Repeating.RepeatLayoutManager.prototype =
{
	get_repeatColumnCount: function() {
		return this._repeatColumnCount;
	},

	get_repeatingDirection: function() {
		return this._repeatingDirection;
	},

	get_repeatingLayout: function() {
		return this._repeatingLayout;
	},

	appendRow: function(rowItems) { },
	createIndividualElement: function() { return null; },
	createStructure: function() { },
	getStructure: function() { return null; }
}

Nucleo.Web.Repeating.RepeatLayoutManager.descriptor =
{
    methods:
    [
        { name: 'appendRow' },
        { name: 'createStructure' }
    ]
}

Nucleo.Web.Repeating.RepeatLayoutManager.registerClass("Nucleo.Web.Repeating.RepeatLayoutManager");


//***************************************************************
//***************************************************************
//***************************************************************
//Table Repeat Setup Manager
//***************************************************************
//***************************************************************
//***************************************************************
Nucleo.Web.Repeating.TableRepeatLayoutManager = function(repeatColumnCount, repeatingLayout, repeatingDirection) {
    Nucleo.Web.Repeating.TableRepeatLayoutManager.initializeBase(this, [repeatColumnCount, repeatingLayout, repeatingDirection]);

    this._tableElement = null;
    this._bodyElement = null;
}

Nucleo.Web.Repeating.TableRepeatLayoutManager.prototype =
{
    appendRow: function(rowItems) {
        var row = document.createElement("TR");

        for (var index = 0; index < rowItems.length; index++) {
            if (rowItems[index].tagName != "TD")
                throw Error.argument("The tag being added is not a table data tag.  Only TD tags are allowed.");

            row.appendChild(rowItems[index]);
        }

        this._bodyElement.appendChild(row);
    },

    createIndividualElement: function() {
        return document.createElement("TD");
    },

    createStructure: function() {
        this._tableElement = document.createElement("TABLE");
        this._bodyElement = document.createElement("TBODY");
        this._tableElement.appendChild(this._bodyElement);
    },

    getStructure: function() {
        return this._tableElement;
    }
}

Nucleo.Web.Repeating.TableRepeatLayoutManager.descriptor =
{
    methods:
    [
        { name: 'appendRow' },
        { name: 'createStructure' },
        { name: 'getStructure' }
    ]
}

Nucleo.Web.Repeating.TableRepeatLayoutManager.registerClass("Nucleo.Web.Repeating.TableRepeatLayoutManager", Nucleo.Web.Repeating.RepeatLayoutManager);


//***************************************************************
//***************************************************************
//***************************************************************
//Flow Repeat Setup Manager
//***************************************************************
//***************************************************************
//***************************************************************
Nucleo.Web.Repeating.FlowRepeatLayoutManager = function(repeatColumnCount, repeatingLayout, repeatingDirection) {
    Nucleo.Web.Repeating.FlowRepeatLayoutManager.initializeBase(this, [repeatColumnCount, repeatingLayout, repeatingDirection]);

    this._parentSpanElement = null;
}

Nucleo.Web.Repeating.FlowRepeatLayoutManager.prototype =
{
    appendRow: function(rowItems) {
        var row = document.createElement("SPAN");

        for (var index = 0; index < rowItems.length; index++) {
            if (rowItems[index].tagName != "SPAN")
                throw Error.argument("The tag being added is not a span tag.  Only SPAN tags are allowed.");

            row.appendChild(rowItems[index]);
        }

        this._parentSpanElement.appendChild(row);
        this._parentSpanElement.appendChild(document.createElement("BR"));
    },

    createIndividualElement: function() {
        return document.createElement("SPAN");
    },

    createStructure: function() {
        this._parentSpanElement = document.createElement("SPAN");
    },

    getStructure: function() {
        return this._parentSpanElement;
    }
}

Nucleo.Web.Repeating.FlowRepeatLayoutManager.descriptor =
{
    methods:
    [
        { name: 'appendRow' },
        { name: 'createStructure' },
        { name: 'getStructure' }
    ]
}

Nucleo.Web.Repeating.FlowRepeatLayoutManager.registerClass("Nucleo.Web.Repeating.FlowRepeatLayoutManager", Nucleo.Web.Repeating.RepeatLayoutManager);


//***************************************************************
//***************************************************************
//***************************************************************
// Table Repeater Class
//***************************************************************
//***************************************************************
//***************************************************************
Nucleo.Web.Repeating.RepeatRenderer = function() {
    Nucleo.Web.Repeating.RepeatRenderer.initializeBase(this);
}

Nucleo.Web.Repeating.RepeatRenderer.prototype =
{
    //***************************************************************
    //  Event Methods
    //***************************************************************
    add_repeatItemRendered: function(handler) {
        this.get_events().addHandler("repeatItemRendered", handler);
    },

    remove_repeatItemRendered: function(handler) {
        this.get_events().removeHandler("repeatItemRendered", handler);
    },

    raise_repeatItemRendered: function(e) {
        var handler = this.get_events().getHandler("repeatItemRendered");
        if (handler != null)
            handler(this, e);
    },

    //***************************************************************
    //  Methods
    //***************************************************************
    _renderHorizontally: function(repeatableControl, repeatManager) {
        if (repeatableControl == null || repeatableControl == undefined)
            throw Error.argumentNull("repeatableControl");
        if (repeatManager == null || repeatManager == undefined)
            throw Error.argumentNull("repeatManager");
        var index = 0;

        while (index < repeatableControl.get_totalCount()) {
            var indexes = [];

            for (var columnIndex = 0; columnIndex < repeatableControl.get_repeatColumnCount(); columnIndex++) {
                if (index < repeatableControl.get_totalCount())
                    Array.add(indexes, index);
                index++;
            }

            this._renderRow(repeatableControl, indexes, repeatManager);
            indexes = null;
        }

        //        var isTable = null;
        //        var subRootElement = null;
        //        var columns = repeatableControl.get_repeatColumnCount();

        //        for (var i = 0; i < itemCount; i++) {
        //            if (repeatableControl.get_repeatingLayout() == Nucleo.Web.Repeating.RepeatLayout.Table) {
        //                if (tr == null || (columns > 0 && i % columns == 0)) {
        //                    var subRootElement = document.createElement("tr");
        //                    rootElement.appendChild(subRootElement);
        //                }
        //            }
        //            else if (repeatableControl.get_repeatingLayout() == Nucleo.Web.Repeating.RepeatLayout.Flow) {
        //                if (i % columns == 0)
        //                    rootElement.appendChild(document.createElement("br"));
        //            }

        //            var parentElement = null;
        //            if (repeatableControl.get_repeatingLayout() == Nucleo.Web.Repeating.RepeatLayout.Table) {
        //                parentElement = document.createElement("td");
        //                subRootElement.appendChild(td);
        //            }
        //            else if (repeatableControl.get_repeatingLayout() == Nucleo.Web.Repeating.RepeatLayout.Flow)
        //                parentElement = document.createElement("span");

        //            this._renderItem(i, parentElement);
        //        }

        //        return rootElement;
    },

    _renderItem: function(repeatableControl, index, parentElement) {
        repeatableControl._renderItem(index, parentElement);
        this.raise_repeatItemRendered(new Nucleo.Web.Repeating.RepeatItemEventArgs(repeatableControl, index));
    },

    renderItems: function(repeatableControl) {
        if (repeatableControl == null || repeatableControl == undefined)
            throw Error.argumentNull("repeatableControl");
        var repeatManager = null;

        if (repeatableControl.get_repeatingLayout() == Nucleo.Web.Repeating.RepeatLayout.Table)
            repeatManager = new Nucleo.Web.Repeating.TableRepeatLayoutManager(
                repeatableControl.get_repeatColumnCount(),
                repeatableControl.get_repeatingLayout(),
                repeatableControl.get_repeatingDirection());
        else if (repeatableControl.get_repeatingLayout() == Nucleo.Web.Repeating.RepeatLayout.Flow)
            repeatManager = new Nucleo.Web.Repeating.FlowRepeatLayoutManager(
                repeatableControl.get_repeatColumnCount(),
                repeatableControl.get_repeatingLayout(),
                repeatableControl.get_repeatingDirection());
        else if (repeatableControl.get_repeatingLayout() == Nucleo.Web.Repeating.RepeatLayout.List)
            repeatManager = new Nucleo.Web.Repeating.ListRepeatLayoutManager(
                repeatableControl.get_repeatColumnCount(),
                repeatableControl.get_repeatingLayout(),
                repeatableControl.get_repeatingDirection());
        else
            throw Error.notImplemented("The repeating layout value is not supported");

        repeatManager.createStructure();

        if (repeatableControl.get_totalCount() == 0)
            return repeatManager.getStructure();

        if (repeatableControl.get_repeatingDirection() == Nucleo.Web.Repeating.RepeatDirection.Horizontal)
            this._renderHorizontally(repeatableControl, repeatManager);
        else if (repeatableControl.get_repeatingDirection() == Nucleo.Web.Repeating.RepeatDirection.Vertical)
            this._renderVertically(repeatableControl, repeatManager);
        else
            throw Error.notImplemented();

        return repeatManager.getStructure();
    },

    _renderRow: function(repeatableControl, indexes, repeatManager) {
        var items = []

        for (var index = 0; index < indexes.length; index++) {
            var item = repeatManager.createIndividualElement();
            if (item == null)
                throw Error.argumentNull("item");

            this._renderItem(repeatableControl, indexes[index], item);
            Array.add(items, item);
        }

        repeatManager.appendRow(items);
        items = null;
    },

    _renderVertically: function(repeatableControl, repeatManager) {
        if (repeatableControl == null || repeatableControl == undefined)
            throw Error.argumentNull("repeatableControl");
        if (repeatManager == null || repeatManager == undefined)
            throw Error.argumentNull("repeatManager");

        var divisingIndex = 0;

        if (repeatableControl.get_totalCount() == 0 || repeatableControl.get_totalCount() == 1)
            divisingIndex = 1;
        else
            divisingIndex = Math.ceil(repeatableControl.get_totalCount() / repeatableControl.get_repeatColumnCount());

        for (var currentIndex = 0; currentIndex <= divisingIndex; currentIndex++) {
            var indexes = [];

            for (var index = currentIndex; index < repeatableControl.get_repeatColumnCount(); index += divisingIndex) {
                if (index < repeatableControl.get_totalCount())
                    Array.add(indexes, index);
            }

            this._renderRow(repeatableControl, indexes, repeatManager);
        }
    }
}

Nucleo.Web.Repeating.RepeatRenderer.descriptor =
{
    methods:
    [
        { name: "_renderHorizontally" },
        { name: "_renderItem" },
        { name: "renderItems" },
        { name: "_renderRow" },
        { name: "_renderVertically" }
    ]
}

Nucleo.Web.Repeating.RepeatRenderer.registerClass("Nucleo.Web.Repeating.RepeatRenderer", Sys.Component);


//***************************************************************
//***************************************************************
//***************************************************************
// IRepeatingListItem Interface
//***************************************************************
//***************************************************************
//***************************************************************
Nucleo.Web.Repeating.IRepeatingList = function() { throw Error.notImplemented(); }

Nucleo.Web.Repeating.IRepeatingList.prototype =
{
    get_repeatColumnCount: function() {
        throw Error.notImplemented();
    },

    set_repeatColumnCount: function(value) {
        throw Error.notImplemented();
    },

    get_repeatingDirection: function() {
        throw Error.notImplemented();
    },

    set_repeatingDirection: function(value) {
        throw Error.notImplemented();
    },

    get_repeatingLayout: function() {
        throw Error.notImplemented();
    },

    set_repeatingLayout: function(value) {
        throw Error.notImplemented();
    },

    get_showFooter: function() {
        throw Error.notImplemented();
    },

    get_showHeader: function() {
        throw Error.notImplemented();
    },

    get_totalCount: function() {
        throw Error.notImplemented();
    },

    _renderItem: function(index, parentElement) {
        throw Error.notImplemented();
    }
}

Nucleo.Web.Repeating.IRepeatingList.registerInterface("Nucleo.Web.Repeating.IRepeatingList");

if (typeof (Sys) !== 'undefined')
    Sys.Application.notifyScriptLoaded();