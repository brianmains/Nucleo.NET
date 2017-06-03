Type.registerNamespace("Nucleo.Web.Pages");Nucleo.Web.Pages.BaseAjaxPage=function(){this._clientState=null;this._controls={};this._elements={};this._extenders={};this._events=new Sys.EventHandlerList();this._isInitialized=false;this._propertyChanges={};this._widgets={}};Nucleo.Web.Pages.BaseAjaxPage.prototype={get_body:function(){return document.getElementsByTagName("body")[0]},get_clientState:function(){if(this.get_clientStateField()==null){return null}if(this._clientState!=null){return this._clientState}this._clientState=this._createClientState();if(this.get_clientStateField().value.length>0){this._clientState.fromJson(Sys.Serialization.JavaScriptSerializer.deserialize(this.get_clientStateField().value))}return this._clientState},get_clientStateField:function(){return $get("__NucleoPageHidden")},get_events:function(){return this._events},get_header:function(){document.getElementsByTagName("head")[0]},get_isInitialized:function(){return this._isInitialized},get_title:function(){return this.get_header().getElementsByTagName("title").innerHTML},set_title:function(a){this.get_header().getElementsByTagName("title").innerHTML=a},get_widgets:function(){return this._widgets},add_handleError:function(a){this.get_events().addHandler("handleError",a)},remove_handleError:function(a){this.get_events().removeHandler("handleError",a)},_onhandleError:function(b){var a=this.get_events().getHandler("handleError");if(a){a(this,b)}},_createClientState:function(){return new Nucleo.Web.ClientState.ClientStateData()},getControl:function(b,a){if(!!this._controls[b]){var c=this._controls[b];if(!!a){a(c)}return c}else{return null}},getElement:function(c,b){if(!!this._elements[c]){var a=this._elements[c];if(!!b){b(a)}return a}else{return null}},getExtender:function(c,b){if(!!this._extenders[c]){var a=this._extenders[c];if(!!b){b(a)}return a}else{return null}},getWidget:function(c,b){if(!!this._widgets[c]){var a=this._widgets[c];if(!!b){b(a)}return a}else{return null}},_processError:function(b){var a={error:b,handled:false};this._onhandleError(a);if(!a.handled){throw b}},registerControl:function(a,b){if(a==null||a==""){throw Error.argumentNull("name")}this._controls[a]=b},registerElement:function(a,b){if(a==null||a==""){throw Error.argumentNull("name")}this._elements[a]=b},registerExtender:function(a,b){if(a==null||a==""){throw Error.argumentNull("name")}this._extenders[a]=b},registerWidget:function(a){if(a==null||a.get_name()==null||a.get_name()==""){throw Error.argumentNull("name")}this._widgets[a.get_name()]=a},setPropertyChange:function(a,b){this._propertyChanges[a]=b},initialize:function(){if(!this.get_clientStateField()){var a=document.createElement("input");a.type="hidden";a.value="";a.id="__NucleoPageHidden";a.name="__NucleoPageHidden";this.get_body().appendChild(a)}this._isInitialized=true},dispose:function(){}};Nucleo.Web.Pages.BaseAjaxPage.registerClass("Nucleo.Web.Pages.BaseAjaxPage");$createPage=function(b){var c=b.clientType;c._isInitialized=false;if(!!b.properties){for(var a in b.properties){if(!!c[a]){c[a]=b.properties[a]}else{if(!!c["set_"+a]){c["set_"+a](b.properties[a])}else{if(!!c["_"+a]){c["_"+a]=b.properties[a]}}}}}if(!!b.events){for(var a in b.events){c.get_events().addHandler(a,b.events[a])}}if(!!b.elements){for(var a in b.elements){c._elements[a]=b.elements[a]}}if(!!b.controls){for(var a in b.controls){c._controls[a]=b.controls[a]}}if(!!b.extenders){for(var a in b.extenders){c._extenders[a]=b.extenders[a]}}n$.Page=Sys.UI.Page=c;if(typeof(c.initialize)!=="undefined"){Sys.Application.add_init(function(){c.initialize()})}return c};if(typeof(Sys)!=="undefined"){Sys.Application.notifyScriptLoaded()};