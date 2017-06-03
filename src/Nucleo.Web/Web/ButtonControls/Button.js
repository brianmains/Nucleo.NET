Type.registerNamespace("Nucleo.Web.ButtonControls");Nucleo.Web.ButtonControls.Button=function(a){Nucleo.Web.ButtonControls.Button.initializeBase(this,[a]);this._causesValidation=null;this._commandArgument=null;this._commandName=null;this._disableOnFirstClick=false;this._disableOnFirstClickTimeout=0;this._disableUntilPageLoad=false;this._imageAlternateText=null;this._imageUrl=null;this._navigateUrl=null;this._parentList=null;this._postBackAlways=false;this._postBackUrl=null;this._style=null;this._text=null;this._validationGroup=null;this._visibilityGroup=null};Nucleo.Web.ButtonControls.Button.prototype={get_causesValidation:function(){return this._causesValidation},set_causesValidation:function(a){if(this.get_isInitialized()){throw Error.notImplemented("Cannot set after initialization")}this._causesValidation=a},get_commandArgument:function(){return this._commandArgument},set_commandArgument:function(a){this._commandArgument=a},get_commandName:function(){return this._commandName},set_commandName:function(a){this._commandName=a},get_disableOnFirstClick:function(){return this._disableOnFirstClick},set_disableOnFirstClick:function(a){this._disableOnFirstClick=a},get_disableOnFirstClickTimeout:function(){return this._disableOnFirstClickTimeout},set_disableOnFirstClickTimeout:function(a){this._disableOnFirstClickTimeout=a},get_disableUntilPageLoad:function(){return this._disableUntilPageLoad},set_disableUntilPageLoad:function(a){if(this.get_isInitialized()){throw Error.notImplemented("Cannot set after initialization")}this._disableUntilPageLoad=a},set_enabled:function(a){Nucleo.Web.ButtonControls.Button.callBaseMethod(this,"set_enabled",[a]);this.refresh()},get_imageAlternateText:function(){return this._imageAlternateText},set_imageAlternateText:function(a){this._imageAlternateText=a;this.refresh()},get_imageUrl:function(){return this._imageUrl},set_imageUrl:function(a){this._imageUrl=a;this.refresh()},get_parentList:function(){return this._parentList},set_parentList:function(a){this._parentList=a},get_postBackAlways:function(){return this._postBackAlways},set_postBackAlways:function(a){this._postBackAlways=a},get_postBackUrl:function(){return this._postBackUrl},set_postBackUrl:function(a){if(this.get_isInitialized()){throw Error.notImplemented("Cannot set after initialization")}this._postBackUrl=a},get_style:function(){return this._style},set_style:function(a){this._style=a},get_text:function(){return this._text},set_text:function(a){this._text=a;this.refresh()},get_validationGroup:function(){return this._validationGroup},set_validationGroup:function(a){if(this.get_isInitialized()){throw Error.notImplemented("Cannot set after initialization")}this._validationGroup=a},get_visibilityGroup:function(){return this._visibilityGroup},set_visibilityGroup:function(a){this._visibilityGroup=a},add_needPostback:function(a){this.get_events().addHandler("needPostback",a)},remove_needPostback:function(a){this.get_events().removeHandler("needPostback",a)},_onneedPostback:function(b){var a=this.get_events().getHandler("needPostback");if(a){a(this,b)}},_onclicked:function(b){if(!this.get_enabled()){return}Nucleo.Web.ButtonControls.Button.callBaseMethod(this,"_onclicked",[Sys.EventArgs.Empty]);var a=function(d){__doPostBack(d.get_element().name,d.get_commandName())};if(this.get_causesValidation()&&typeof(Page_ClientValidate)!=="undefined"){Page_ClientValidate(this.get_validationGroup())}if(this.get_disableOnFirstClick()){this.set_enabled(false)}if(this.get_disableOnFirstClickTimeout()>0){window.setTimeout(Function.createDelegate(this,function(){this.set_enabled(true)}),this.get_disableOnFirstClickTimeout())}if(typeof(Page_IsValid)==="undefined"||Page_IsValid){if(this.get_postBackAlways()){a(this)}else{var c=new Nucleo.Web.ButtonControls.ButtonPostBackEventArgs();this._onneedPostback(c);if(c.get_shouldPostBack()){a(this)}}}},refresh:function(){var a=this.get_element().childNodes[0];if(a.tagName=="IMG"){a.src=this.get_imageUrl();a.alt=this.get_imageAlternateText()}else{if(a.tagName=="A"){a.innerHTML=this.get_text()}else{a.value=this.get_text()}}a.disabled=!this.get_enabled()},initialize:function(){Nucleo.Web.ButtonControls.Button.callBaseMethod(this,"initialize");if(this.get_disableUntilPageLoad()){this.set_enabled(true)}if(this.get_parentList()){this.get_parentList()._addButton(this)}},dispose:function(){if(this._pageLoadHandler!=null){Sys.Application.remove_load(this._pageLoadHandler);this._pageLoadHandler=null}Nucleo.Web.ButtonControls.Button.callBaseMethod(this,"dispose")}};Nucleo.Web.ButtonControls.Button.registerClass("Nucleo.Web.ButtonControls.Button",Nucleo.Web.BaseAjaxControl);Nucleo.Web.ButtonControls.ButtonType=function(){throw Error.notImplemented()};Nucleo.Web.ButtonControls.ButtonType.prototype={Button:0,Image:1,Link:2};Nucleo.Web.ButtonControls.ButtonType.registerEnum("Nucleo.Web.ButtonControls.ButtonType");Nucleo.Web.ButtonControls.ButtonPostBackEventArgs=function(a){this._shouldPostBack=!!a?a:false};Nucleo.Web.ButtonControls.ButtonPostBackEventArgs.prototype={get_shouldPostBack:function(){return this._shouldPostBack},set_shouldPostBack:function(a){this._shouldPostBack=a}};Nucleo.Web.ButtonControls.ButtonPostBackEventArgs.registerClass("Nucleo.Web.ButtonControls.ButtonPostBackEventArgs",Sys.EventArgs);if(typeof(Sys)!=="undefined"){Sys.Application.notifyScriptLoaded()};