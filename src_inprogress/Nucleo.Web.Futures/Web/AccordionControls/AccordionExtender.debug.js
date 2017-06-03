/// <reference name="MicrosoftAjax.js" />
/// <reference name="MicrosoftAjaxTimer.debug.js" />
/// <reference name="MicrosoftAjaxWebForms.debug.js" />
/// <reference name="BaseAjaxExtender.debug.js" />

Type.registerNamespace("Nucleo.Web.AccordionControls");

Nucleo.Web.AccordionControls.AccordionExtender = function (el) {
	Nucleo.Web.AccordionControls.AccordionExtender.initializeBase(this, [el]);

	this._loadOnDemand = false;
}

Nucleo.Web.AccordionControls.AccordionExtender.prototype = {
	get_loadOnDemand: function () {
		return this._loadOnDemand;
	},

	set_loadOnDemand: function (value) {
		this._loadOnDemand = value;
	},

	_addContent: function (root, html) {
		var content = document.createElement("DIV");
		content.className = "NucleoAccordionContentOuter";
		content.innerHTML = html;

		var innerContent = document.createElement("DIV");
		innerContent.className = "NucleoAccordionContentInner";
		content.appendChild(innerContent);

		root.appendChild(content);
	},

	_addHeader: function (root, title) {
		var header = document.createElement("a");
		header.href = "#";
		header.innerHTML = title;

		var wrapper = document.createElement("h3");
		wrapper.className = "NucleoAccordionHeader";
		wrapper.appendChild(header);

		root.appendChild(wrapper);
	},

	bind: function (dataSource) {
		this.clearItems();

		for (var i = 0; i < json.length; i++) {
			this.addItem(json[i]);
		}
	},

	addItem: function (accordionItem) {
		_addHeader(this.get_element(), json[i].title);
		_addContent(this.get_element(), json[i].content);
	},

	clearItems: function () {
		for (var i = this.get_element().childNodes.length; i >= 0; i--)
			this._removeChild(i);
	},

	_removeChild: function (i) {
		this.get_element().removeChild(this.get_element().childNodes[i]);
	},

	removeItem: function (i) {
		if (!!i && !isNaN(i)) {
			if (i == 0) {
				this._removeChild(1);
				this._removeChild(0);
			}
			else {
				i = i * 2;
				this._removeChild(i + 1);
				this._removeChild(i);
			}
		}
	},

	initialize: function () {
		Nucleo.Web.AccordionControls.AccordionExtender.callBaseMethod(this, "initialize");

	},

	dispose: function () {


		Nucleo.Web.AccordionControls.AccordionExtender.callBaseMethod(this, "dispose");
	}
}

Nucleo.Web.AccordionControls.AccordionExtender.registerClass("Nucleo.Web.AccordionControls.AccordionExtender", Nucleo.Web.BaseAjaxExtender);