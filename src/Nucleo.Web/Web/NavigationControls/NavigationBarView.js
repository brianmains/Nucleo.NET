Type.registerNamespace("Nucleo.Web.NavigationControls");Nucleo.Web.NavigationControls.NavigationBarView=function(a){Nucleo.Web.NavigationControls.NavigationBarView.initializeBase(this,[a]);this._containerControl=null};Nucleo.Web.NavigationControls.NavigationBarView.prototype={get_containerControl:function(){return this._containerControl},set_containerControl:function(a){this._containerControl=a;if(a!=null){a._view=this}},initialize:function(){Nucleo.Web.NavigationControls.NavigationBarView.callBaseMethod(this,"initialize")},dispose:function(){Nucleo.Web.NavigationControls.NavigationBarView.callBaseMethod(this,"dispose")}};Nucleo.Web.NavigationControls.NavigationBarView.registerClass("Nucleo.Web.NavigationControls.NavigationBarView",Nucleo.Web.BaseAjaxControl);if(typeof(Sys)!=="undefined"){Sys.Application.notifyScriptLoaded()};