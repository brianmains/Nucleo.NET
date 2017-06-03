/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />

Type.registerNamespace("Nucleo.Web.ListControls");

//----------------------------------------------------------------
// ListInterfaceBuilder Class
//----------------------------------------------------------------
Nucleo.Web.ListControls.Builders.ListInterfaceBuilder = function(listControl) {
	Nucleo.Web.ListControls.Builders.ListInterfaceBuilder.initializeBase(this);
	this._listControl = listControl;
	this._parentElement = listControl.get_element();
	this._index = 0;
}

Nucleo.Web.ListControls.Builders.ListInterfaceBuilder.prototype =
{
	//******************************************************
	// Properties
	//******************************************************
	get_listControl: function() {
		return this._listControl;
	},

	get_parentElement: function() {
		return this._parentElement;
	},


	//******************************************************
	// Methods
	//******************************************************
	addItem: function(listItem) {
		this.clearItems();
		this._render();
	},

	clearItems: function() {
		if (this.get_parentElement().hasChildNodes())
			this.get_parentElement().remove(0);
	},

	createItem: function(listItem, parentElement) { },

	_getCurrentIndex: function() {
		return this._index;
	},

	_incrementIndex: function() {
		this._index++;
	},

	removeItem: function(listItem) {
		this.clearItems();
		this._render();
	},

	_render: function() {
		var renderer = new Nucleo.Web.Repeating.RepeatRenderer();
		var structure = renderer.renderItems(this.get_listControl());

		this.get_parentElement().appendChild(structure);
	},

	_resetIndex: function() {
		this._index = 0;
	}
}



Nucleo.Web.ListControls.Builders.ListInterfaceBuilder.descriptor = {
    properties:
    [
        { name: 'listControl', type: Nucleo.Web.ListControls.Builders.ListControl, readOnly: true },
        { name: 'parentElement', type: Object, readOnly: true }
    ],
    methods:
	[
		{ name: 'addItem' },
		{ name: 'clearItems' },
		{ name: 'createItem' },
		{ name: 'removeItem' },
		{ name: '_render' }
	]
}

Nucleo.Web.ListControls.Builders.ListInterfaceBuilder.registerClass('Nucleo.Web.ListControls.Builders.ListInterfaceBuilder', Sys.Component);

Nucleo.Web.ListControls.Builders.ListInterfaceBuilder.buildInterface = function(listControl, parentElement) {
    if (listControl.get_interfaceType() == Nucleo.Web.ListControls.Builders.ListInterfaceType.CheckboxList)
        return new Nucleo.Web.ListControls.Builders.CheckboxListInterfaceBuilder(listControl, parentElement);
    else if (listControl.get_interfaceType() == Nucleo.Web.ListControls.Builders.ListInterfaceType.RadioButtonList)
        return new Nucleo.Web.ListControls.Builders.RadioButtonListInterfaceBuilder(listControl, parentElement);
    else if (listControl.get_interfaceType() == Nucleo.Web.ListControls.Builders.ListInterfaceType.DropDownList)
        return new Nucleo.Web.ListControls.Builders.DropDownListInterfaceBuilder(listControl, parentElement);
    else if (listControl.get_interfaceType() == Nucleo.Web.ListControls.Builders.ListInterfaceType.BulletedList)
        return new Nucleo.Web.ListControls.Builders.BulletedListInterfaceBuilder(listControl, parentElement);
    else
        throw Error.notImplemented();
}


//----------------------------------------------------------------
// CheckboxListInterfaceBuilder Class
//----------------------------------------------------------------
Nucleo.Web.ListControls.Builders.CheckboxListInterfaceBuilder = function(listControl, parentElement) {
    Nucleo.Web.ListControls.Builders.CheckboxListInterfaceBuilder.initializeBase(this, [listControl, parentElement]);
}

Nucleo.Web.ListControls.Builders.CheckboxListInterfaceBuilder.prototype =
{
	createItem: function(listItem, parentElement) {
		//        var checkbox = document.createElement("INPUT");
		//        checkbox.setAttribute("id", String.format("{0}_{1}", this.get_listControl().get_id(), this._index));
		//        checkbox.setAttribute("type", "checkbox");
		//        checkbox.setAttribute("value", listItem.get_value());
		//        if (listItem.get_selected())
		//            checkbox.setAttribute("checked", "checked");
		//        if (!listItem.get_enabled())
		//            checkbox.setAttribute("disabled", "disabled");
		//        parentElement.appendChild(checkbox);

		//        var label = document.createElement("LABEL");
		//        label.setAttribute("for", checkbox.id);
		//        label.innerHTML = listItem.get_text();
		//        parentElement.appendChild(label);

		var builder = new Sys.StringBuilder();

		builder.append("<input type='checkbox' ");
		builder.append(String.format("id='{0}_{1}' ", this.get_listControl().get_id(), this._getCurrentIndex()));
		if (listItem.get_value() != null && listItem.get_value().length > 0)
			builder.append(String.format("value='{0}' ", listItem.get_value()));
		if (listItem.get_selected() == true)
			builder.append("checked='checked' ");
		if (listItem.get_enabled() == false)
			builder.append("disabled='disabled' ");
		builder.append(">");

		if (listItem.get_text() != null && listItem.get_text().length > 0)
			builder.append(String.format("<label for='{0}'>{1}</label>",
                this.get_listControl().get_id(), listItem.get_text()));

		builder.append("</input>");
		parentElement.innerHTML = builder.toString();

		var input = parentElement.childNodes[0];
		this._incrementIndex();
	}
}

Nucleo.Web.ListControls.Builders.CheckboxListInterfaceBuilder.registerClass('Nucleo.Web.ListControls.Builders.CheckboxListInterfaceBuilder', Nucleo.Web.ListControls.Builders.ListInterfaceBuilder);


//----------------------------------------------------------------
// RadioButtonListInterfaceBuilder Class
//----------------------------------------------------------------
Nucleo.Web.ListControls.Builders.RadioButtonListInterfaceBuilder = function(listControl, parentElement) {
    Nucleo.Web.ListControls.Builders.RadioButtonListInterfaceBuilder.initializeBase(this, [listControl, parentElement]);
}

Nucleo.Web.ListControls.Builders.RadioButtonListInterfaceBuilder.prototype =
{
    createItem: function(listItem, parentElement) {
        //        var checkbox = document.createElement("INPUT");
        //        checkbox.setAttribute("id", String.format("{0}_{1}", this.get_listControl().get_id(), this._index));
        //        checkbox.setAttribute("name", this.get_listControl().get_id());
        //        checkbox.setAttribute("type", "radio");
        //        checkbox.setAttribute("value", listItem.get_value());
        //        if (listItem.get_selected())
        //            checkbox.setAttribute("checked", "checked");
        //        if (!listItem.get_enabled())
        //            checkbox.setAttribute("disabled", "disabled");
        //        parentElement.appendChild(checkbox);

        //        var label = document.createElement("LABEL");
        //        label.setAttribute("for", checkbox.id);
        //        label.innerHTML = listItem.get_text();
        //        parentElement.appendChild(label);

        var builder = new Sys.StringBuilder();
        builder.append("<input type='radio' ");
        builder.append(String.format("id='{0}_{1}' ", this.get_listControl().get_id(), this._getCurrentIndex()));
        builder.append(String.format("name='{0}' ", this.get_listControl().get_id()));
        if (listItem.get_value() != null && listItem.get_value().length > 0)
            builder.append(String.format("value='{0}' ", listItem.get_value()));
        if (listItem.get_selected() == true)
            builder.append("checked='checked' ");
        if (listItem.get_enabled() == false)
            builder.append("disabled='disabled' ");
        builder.append(">");

        if (listItem.get_text() != null && listItem.get_text().length > 0)
            builder.append(String.format("<label for='{0}'>{1}</label>",
                this.get_listControl().get_id(), listItem.get_text()));
        builder.append("</input>");

        parentElement.innerHTML = builder.toString();
        this._incrementIndex();
    }
}

Nucleo.Web.ListControls.Builders.RadioButtonListInterfaceBuilder.registerClass('Nucleo.Web.ListControls.Builders.RadioButtonListInterfaceBuilder', Nucleo.Web.ListControls.Builders.ListInterfaceBuilder);


//----------------------------------------------------------------
// DropDownListInterfaceBuilder Class
//----------------------------------------------------------------
Nucleo.Web.ListControls.Builders.DropDownListInterfaceBuilder = function(listControl, parentElement) {
    Nucleo.Web.ListControls.Builders.DropDownListInterfaceBuilder.initializeBase(this, [listControl, parentElement]);
}

Nucleo.Web.ListControls.Builders.DropDownListInterfaceBuilder.prototype =
{
    createItem: function(listItem, parentElement) {
        var option = document.createElement("option");
        option.setAttribute("value", listItem.get_value());
        option.setAttribute("innerText", listItem.get_text());
        if (!listItem.get_enabled())
            option.setAttribute("disabled", "disabled");
        parentElement.appendChild(option);
    },

    _render: function() {
        var dropDown = document.createElement("SELECT");
        this.get_parentElement().appendChild(dropDown);

        for (var index = 0; index < this.get_listControl().get_items().get_count(); index++) {
            var listItem = this.get_listControl().get_items().get_item(index);
            this.createItem(listItem, dropDown);

            if (listItem.get_selected())
                dropDown.setAttribute("selectedIndex", index);
        }
    }
}

Nucleo.Web.ListControls.Builders.DropDownListInterfaceBuilder.registerClass('Nucleo.Web.ListControls.Builders.DropDownListInterfaceBuilder', Nucleo.Web.ListControls.Builders.ListInterfaceBuilder);


//----------------------------------------------------------------
// BulletedListInterfaceBuilder Class
//----------------------------------------------------------------
Nucleo.Web.ListControls.Builders.BulletedListInterfaceBuilder = function(listControl, parentElement) {
    Nucleo.Web.ListControls.Builders.BulletedListInterfaceBuilder.initializeBase(this, [listControl, parentElement]);

}

Nucleo.Web.ListControls.Builders.BulletedListInterfaceBuilder.prototype =
{
    createItem: function(listItem, parentElement) {
        var option = document.createElement("li");
        option.setAttribute("innerText", listItem.get_text());
        parentElement.appendChild(option);
    },

    _render: function() {
        var dropDown = document.createElement("UL");
        this.get_parentElement().appendChild(dropDown);

        for (var index = 0; index < this.get_listControl().get_items().get_count(); index++) {
            var listItem = this.get_listControl().get_items().get_item(index);
            this.createItem(listItem, dropDown);
        }
    }
}

Nucleo.Web.ListControls.Builders.BulletedListInterfaceBuilder.registerClass('Nucleo.Web.ListControls.Builders.BulletedListInterfaceBuilder', Nucleo.Web.ListControls.Builders.ListInterfaceBuilder);


if (typeof (Sys) !== 'undefined')
    Sys.Application.notifyScriptLoaded();